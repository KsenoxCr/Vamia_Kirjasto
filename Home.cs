using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Devices;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Org.BouncyCastle.Crypto;
using System.Collections.Generic;
using System.Data;
using System.IO;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Reflection.Metadata.BlobBuilder;
//using System.Reflection.Emit;

namespace Kirjasto_ohjelma
{
    public partial class Home : Form
    {
        private readonly DatabaseAccess db = DatabaseAccess.GetInstance();

        private static Home _instance = null;
        private static readonly object _lock = new();

        private string orderBy = "nimi ASC";

        public Home()
        {
            InitializeComponent();

            this.FormClosing += FormManager.Form_FormClosing;

            FormManager.AddMouseEnterAndLeave(new System.Windows.Forms.Label[] { oma_tili, tuki, palautteet, ehdota_kirjaa, kirjauduUlos, asiakkaat });
        }

        public static Home Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Home();
                    }
                    return _instance;
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            FormManager.toggleMenu(Menu);
        }


        private void Form3_Load(object sender, EventArgs e)
        {
            bool isStaff = User.IsStaff;


            if (isStaff)
            {
                asiakkaat.Visible = true;
                lisaa_kirja.Visible = true;
                asiakkaat.Location = ehdota_kirjaa.Location;
                lisaa_kirja.Location = tuki.Location;
                tuki.Visible = false;
                palautteet.Visible = false;
                ehdota_kirjaa.Visible = false;
            }
            else
            {
                asiakkaat.Visible = false;
                lisaa_kirja.Visible = false;
                tuki.Visible = true;
                palautteet.Visible = true;
                ehdota_kirjaa.Visible = true;
            }

            LoadBooksFromDatabase();

            ControlsAreClickable(this, "kirja", "picturebox");
            ControlsAreClickable(this, "lainaaBtn", "button");
        }

        private void kirjauduUlos_Click(object sender, EventArgs e)
        {
            FormManager.openLogin(this);
        }

        private void ehdota_kirjaa_Click(object sender, EventArgs e)
        {
            BookRecommendation bookRecom = new();
            bookRecom.Show();
        }

        private void tuki_Click(object sender, EventArgs e)
        {
            FormManager.openContact("tuki");
        }

        private void palautteet_Click(object sender, EventArgs e)
        {
            FormManager.openContact("palaute");
        }

        private void label3_Click(object sender, EventArgs e)
        {
            string userType = User.IsStaff ? "staff" : "customer";

            FormManager.openAccountDetails(User.Username, userType);
        }

        private void lisaaKirja_Click(object sender, EventArgs e)
        {

        }

        private void asiakkaat_Click(object sender, EventArgs e)
        {
            FormManager.openUserList(this);
        }

        private void jarjestysCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (jarjestysCB.SelectedIndex)
            {
                case 0:
                default:
                    orderBy = "nimi ASC";
                    break;
                case 1:
                    orderBy = "nimi DESC";
                    break;
                case 2:
                    orderBy = "snimi, enimi ASC";
                    break;
                case 3:
                    orderBy = "snimi, enimi DESC";
                    break;
                case 4:
                    orderBy = "sivut ASC";
                    break;
                case 5:
                    orderBy = "sivut DESC";
                    break;
                case 6:
                    orderBy = "sivut ASC";
                    break;
                case 7:
                    orderBy = "sivut DESC";
                    break;
            }

            LoadBooksFromDatabase();
        }

        public void LoadBooksFromDatabase()
        {
            List<string[]> books = new List<string[]>();

            try
            {
                db.OpenConnection();

                string query = $"SELECT k.nimi, kir.enimi, kir.snimi, k.img FROM kirja k INNER JOIN kirjailija kir ON k.kirtu = kir.kirtunnus ORDER BY {orderBy}";

                using (MySqlCommand command = new MySqlCommand(query, db.connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            string[] bookInfo = new string[]
                            {
                                reader.GetString(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetString(3)
                            };

                            books.Add(bookInfo);   
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Tietokantavirhe: {ex.Message}");
            }
            finally
            {
                db.CloseConnection();
            }

            displayBooks(books);
        }

        private void displayBooks(List<string[]> bookList)
        {
            //Arvojen nollaus
            kirjaFlowLayoutPanel.SuspendLayout();
            kirjaFlowLayoutPanel.Controls.Clear();

            kirjaFlowLayoutPanel.Height = 292;
            Menu.Height = 715;
            footer.Top = 715;
            this.Height = 715;

            int booksOnRow = 0;
            int rows = 1;

            const int moreHeight = 350;

            List<Panel> panelsToAdd = new List<Panel>();

            for (int i = 0; i < bookList.Count; i++)
            {
                string[] bookInfo = bookList[i];

                string nimi = bookInfo[0];
                string kirjailija = bookInfo[1] + " " + bookInfo[2];
                string imageName = bookInfo[3] + ".png";

                booksOnRow++;

                if (booksOnRow > 4)
                {
                    kirjaFlowLayoutPanel.Height += moreHeight;
                    footer.Top += moreHeight;
                    Menu.Height += moreHeight;
                    booksOnRow = 1;
                    rows++;
                }

                Panel kirjaPanel = new Panel
                {
                    Size = new Size(130, 330),
                    BackColor = Color.FromArgb(255, 241, 220),
                    Font = new Font("Impact", 12),
                    Name = "kirjaPanel" + (i + 1),
                    Margin = new Padding(5)
                };

                PictureBox bookCover = new PictureBox
                {
                    Size = new Size(110, 165),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Top = 15,
                    Name = "kirja" + (i + 1)
                };

                bookCover.Left = (kirjaPanel.Width - bookCover.Width) / 2;
                bookCover.Click += (s, args) => controlClicked(s, args, bookCover);


                string rootPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..");
                string imagePath = Path.GetFullPath(Path.Combine(rootPath, "Images", imageName));

                try
                {
                    bookCover.Image = Image.FromFile(imagePath);
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Virhe ladatessa kuvaa: " + ex.Message);
                }

                kirjaPanel.Controls.Add(bookCover);

                Label bookName = new Label
                {
                    Width = kirjaPanel.Width,
                    Top = bookCover.Bottom + 15,
                    Left = 0,
                    Text = nimi,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Name = "nimi" + (i + 1),
                };

                kirjaPanel.Controls.Add(bookName);

                Label bookAuthor = new Label
                {
                    Width = kirjaPanel.Width,
                    Top = bookName.Bottom + 10,
                    Left = 0,
                    Text = kirjailija,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Impact", 8)
                };

                kirjaPanel.Controls.Add(bookAuthor);
                Button lainaaButton = new() 
                { 
                    Name = "lainaaBtn" + (i + 1),
                    Text = User.IsStaff ? "Katso" : "Lainaa",
                    BackColor = Color.Beige,
                    FlatStyle = FlatStyle.Flat,
                    Height = 45,
                    Width = 90,
                    Location = new Point((kirjaPanel.Width - 90) / 2, bookAuthor.Bottom + 15),
                    Font = new Font("Impact", 10F)
                };

                lainaaButton.Click += (s, args) => controlClicked(s, args, lainaaButton);
                kirjaPanel.Controls.Add(lainaaButton);

                panelsToAdd.Add(kirjaPanel);
            }

            kirjaFlowLayoutPanel.Controls.AddRange(panelsToAdd.ToArray());
            kirjaFlowLayoutPanel.ResumeLayout();
        }
        public void ControlsAreClickable(Control control, string controlName, string controlType)
        {
            var clickableControls = control.EnumerateControls().Where(c => c is Button || c is PictureBox && c.Name.StartsWith(controlName) && c.Name.Length > controlName.Length);

            foreach (var controlToClick in clickableControls)
            {
                controlToClick.Click += (s, args) => controlClicked(s, args, controlToClick);
            }
        }

        public static void controlClicked(object sender, EventArgs e, Control control)
        {
            string name = "";

            foreach (Control c in control.Parent.Controls)
            {
                if (c is Label label && label.Name.StartsWith("nimi"))
                {
                    name = label.Text;
                }
            }

            if ((control is PictureBox picbox && picbox.Name.StartsWith("kirja")) || (control is Button && (control.Text == "Katso")))
            {
                FormManager.openBookInfo(name);
            }
            else if (control is Button btn)
            {
                if (!string.IsNullOrEmpty(name))
                {
                    if (btn.Text == "Lainaa")
                    {
                        FormManager.CreateNewLoan(name);
                    }
                    else if (btn.Text == "Poista")
                    {
                        FormManager.openConfirmMessage("varmistus", name);
                    }
                }
            }
        }
    }
}

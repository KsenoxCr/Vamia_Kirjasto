using Microsoft.VisualBasic.ApplicationServices;
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
        private DatabaseAccess db = DatabaseAccess.GetInstance();
        private string orderBy = "nimi ASC";
        private bool menuOpen = false;

        public Home()
        {
            InitializeComponent();

            //DESIGN {
            haeKirjoja.Location = new Point((this.Width - haeKirjoja.Width) / 2, 75);

            kirjaFlowLayoutPanel.Size = new Size(560, 292);
            kirjaFlowLayoutPanel.Location = new Point(Menu.Width + 30, 342);

            selausAsetukset.Location = new Point(kirjaFlowLayoutPanel.Left, kirjaFlowLayoutPanel.Top - selausAsetukset.Height);
            selausAsetukset.Size = new Size(560, 94);

            selaaKirjoja.Location = new Point((selaaKirjoja.Parent.Width - selaaKirjoja.Width) / 2, 20);
            jarjestysCB.Location = new Point((jarjestysCB.Parent.Width - jarjestysCB.Width - 10), jarjestysCB.Parent.Height - jarjestysCB.Height - 10);
            jarjestys.Location = new Point(jarjestysCB.Location.X - jarjestys.Width - 10, jarjestysCB.Location.Y);

            Menu.Size = new Size(125, 715);
            Menu.Location = new Point(0, 0);

            footer.Location = new Point(0, Menu.Height);
            footer.BringToFront();

            kirjauduUlos.Location = new Point(12, Menu.Height - 50);

            //} DESIGN

            bool isStaff = User.IsStaff;

            this.FormClosing += FormManager.Form_FormClosing;

            FormManager.AddMouseEnterAndLeave(new System.Windows.Forms.Label[] { oma_tili, tuki, palautteet, ehdota_kirjaa, kirjauduUlos, asiakkaat });

            tuki.Visible = !isStaff;
            palautteet.Visible = !isStaff;
            ehdota_kirjaa.Visible = !isStaff;

            if (isStaff)
            {
                asiakkaat.Visible = true;
                asiakkaat.Location = ehdota_kirjaa.Location;
                lisaa_kirja.Location = tuki.Location;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            FormManager.toggleMenu(Menu);
        }


        private void Form3_Load(object sender, EventArgs e)
        {
            LoadBooksFromDatabase();

            ControlsAreClickable(this, "kirja", "picturebox");
            ControlsAreClickable(this, "lainaaBtn", "button");
        }

        private void kirjauduUlos_Click(object sender, EventArgs e)
        {
            LogIn login = new LogIn();
            login.Show();
            this.Hide();
        }

        private void ehdota_kirjaa_Click(object sender, EventArgs e)
        {
            BookRecommendation bookRecom = new BookRecommendation();
            bookRecom.Show();
        }

        private void tuki_Click(object sender, EventArgs e)
        {
            FeedBackForm tukiForm = new FeedBackForm(tuki.Name);
            tukiForm.Show();
        }

        private void palautteet_Click(object sender, EventArgs e)
        {
            FeedBackForm palauteForm = new FeedBackForm(palautteet.Name);
            palauteForm.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            string userType = User.IsStaff ? "staff" : "customer";

            FormManager.openAccountDetails(User.Username, userType);
        }

        private void asiakkaat_Click(object sender, EventArgs e)
        {
            UserList userList = UserList.GetInstance();
            userList.Show();

            this.Hide();
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

        public void ControlsAreClickable(Control control, string controlName, string controlType)
        {
            var clickableControls = control.EnumerateControls().Where(c => c is Button || c is PictureBox && c.Name.StartsWith(controlName) && c.Name.Length > controlName.Length);

            foreach (var controlToClick in clickableControls)
            {
                controlToClick.Click += (s, args) => FormManager.controlClicked(s, args, controlToClick);
            }
        }
        public void LoadBooksFromDatabase()
        {
            kirjaFlowLayoutPanel.Height = 292;
            Menu.Height = 715;
            footer.Top = 715;
            this.Height = 715;

            string nimi = "";
            string kirjailija = "";
            string imageName = "";

            int bookCount = 0;
            int booksOnRow = 0;

            const int moreHeight = 350;

            int rows = 1;

            List<Panel> panelsToAdd = new List<Panel>();

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
                bookCover.Click += (s, args) => FormManager.controlClicked(s, args, bookCover);


                string rootPath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..");
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

                basicButton lainaaButton = new basicButton(User.IsStaff ? "Katso" : "Lainaa", "beige", 45, 90, (kirjaPanel.Width - 90) / 2, bookAuthor.Bottom + 15, 10F);
                lainaaButton.Name += (i + 1);
                lainaaButton.Click += (s, args) => FormManager.controlClicked(s, args, lainaaButton);

                kirjaPanel.Controls.Add(lainaaButton);

                panelsToAdd.Add(kirjaPanel);
            }

            kirjaFlowLayoutPanel.Controls.AddRange(panelsToAdd.ToArray());
            kirjaFlowLayoutPanel.ResumeLayout();
        }
        private void lisaaKirja_Click(object sender, EventArgs e)
        {

        }
    }
}

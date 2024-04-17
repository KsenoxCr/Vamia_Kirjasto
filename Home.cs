using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Devices;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Org.BouncyCastle.Crypto;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.CompilerServices;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Reflection.Metadata.BlobBuilder;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;
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

            this.FormClosing += FormManager.FormClosing;

            FormManager.AddMouseEnterAndLeave(new System.Windows.Forms.Label[] { oma_tili, tuki, palautteet, ehdota_kirjaa, kirjauduUlos, asiakkaat });

            DesignHome();
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

        private void MenuButton_Click(object sender, EventArgs e)
        {

            FormManager.ToggleMenu(Menu, timerHome);
        }

        private void TimerHome_Tick(object sender, EventArgs e)
        {
            FormManager.timerTick(timerHome, Menu);
        }

        private void Home_Load(object sender, EventArgs e)
        {
            bool isStaff = User.IsStaff;

            asiakkaat.Visible = isStaff;
            lisaa_kirja.Visible = isStaff;
            tuki.Visible = !isStaff;
            palautteet.Visible = !isStaff;
            ehdota_kirjaa.Visible = !isStaff;

            asiakkaat.Location = isStaff ? ehdota_kirjaa.Location : new Point(10, 205);
            lisaa_kirja.Location = isStaff ? tuki.Location : new Point(10, 235);

            LoadBooksFromDatabase();

            ControlsAreClickableRecursive(this.Controls, "kirja");
            ControlsAreClickableRecursive(this.Controls, "lainaaBtn");
        }

        private void LogOut_Click(object sender, EventArgs e)
        {
            FormManager.OpenLogin(this);
        }

        private void SuggestBook_Click(object sender, EventArgs e)
        {
            BookRecommendation bookRecom = new();
            bookRecom.Show();
        }

        private void Support_Click(object sender, EventArgs e)
        {
            FormManager.OpenContact("tuki");
        }

        private void Feedback_Click(object sender, EventArgs e)
        {
            FormManager.OpenContact("palaute");
        }

        private void Profile_Click(object sender, EventArgs e)
        {
            string userType = User.IsStaff ? "staff" : "customer";

            FormManager.OpenAccountDetails(User.Username, userType);
        }

        private void AddBook_Click(object sender, EventArgs e)
        {

        }

        private void Customers_Click(object sender, EventArgs e)
        {
            FormManager.OpenUserList(this);
        }

        private void JarjestysCB_SelectedIndexChanged(object sender, EventArgs e)
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
            List<string[]> books = new();

            try
            {
                db.OpenConnection();

                string query = $"SELECT k.isbn, k.nimi, kir.enimi, kir.snimi, k.img FROM kirja k INNER JOIN kirjailija kir ON k.kirtu = kir.kirtunnus ORDER BY {orderBy}";

                using MySqlCommand command = new(query, db.connection);
                using MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    string[] bookInfo = new string[]
                    {
                                reader["isbn"] as string,
                                reader["nimi"] as string,
                                reader["enimi"] as string,
                                reader["snimi"] as string,
                                reader["img"] as string
                    };

                    books.Add(bookInfo);
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

            DisplayBooks(books);
        }

        private void DisplayBooks(List<string[]> bookList)
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

            List<Panel> panelsToAdd = new();

            for (int i = 0; i < bookList.Count; i++)
            {
                string[] bookInfo = bookList[i];

                string nimi = bookInfo[1];
                string kirjailija = bookInfo[2] + " " + bookInfo[3];
                string imageName = bookInfo[4];

                booksOnRow++;

                if (booksOnRow > 4)
                {
                    kirjaFlowLayoutPanel.Height += moreHeight;
                    footer.Top += moreHeight;
                    Menu.Height += moreHeight;
                    booksOnRow = 1;
                    rows++;
                }

                Panel kirjaPanel = new()
                {
                    Size = new Size(130, 330),
                    BackColor = Color.FromArgb(255, 241, 220),
                    Font = new Font("Impact", 12),
                    Name = "kirjaPanel" + (i + 1),
                    Margin = new Padding(5)
                };

                PictureBox bookCover = new()
                {
                    Size = new Size(110, 165),
                    Top = 15,
                    Name = "kirja" + (i + 1)
                };


                bookCover.Left = (kirjaPanel.Width - bookCover.Width) / 2;
                bookCover.Click += (s, args) => ControlClicked(s, args, bookCover);


                string rootPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..");
                string imagePath = Path.GetFullPath(Path.Combine(rootPath, @"Images\BookCovers", imageName));

                try
                {
                    bookCover.Image = Image.FromFile(imagePath);

                    if (bookCover.Image.Height > bookCover.Image.Width)
                    {
                        bookCover.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    else
                    {
                        bookCover.SizeMode = PictureBoxSizeMode.CenterImage;
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Virhe ladatessa kuvaa: " + ex.Message);
                }

                kirjaPanel.Controls.Add(bookCover);

                Label bookName = new()
                {
                    Width = kirjaPanel.Width,
                    Top = bookCover.Bottom + 15,
                    Left = 0,
                    Text = nimi,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Name = "nimi" + (i + 1),
                };

                kirjaPanel.Controls.Add(bookName);

                Label bookAuthor = new()
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

                lainaaButton.Click += (s, args) => ControlClicked(s, args, lainaaButton);
                kirjaPanel.Controls.Add(lainaaButton);

                panelsToAdd.Add(kirjaPanel);
            }

            kirjaFlowLayoutPanel.Controls.AddRange(panelsToAdd.ToArray());
            kirjaFlowLayoutPanel.ResumeLayout();
        }

        private void ControlsAreClickableRecursive(Control.ControlCollection coll, string controlName)
        {
            foreach (Control c in coll)
            {
                if (c is Button || c is PictureBox && c.Name.StartsWith(controlName))
                {
                    c.Click += (s, args) => ControlClicked(s, args, c); // this is the problem
                }
                else if (c.HasChildren)
                {
                    ControlsAreClickableRecursive(c.Controls, controlName);
                }
            }
        }

        private static void ControlClicked(object sender, EventArgs e, Control control) // Error: called twice on every click
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
                FormManager.OpenBookInfo(name);
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
                        FormManager.OpenConfirmMessage("varmistus", name);
                    }
                }
            }
        }

        public void DesignHome()
        {
            int maxLength = username.Text.Length;
            string userName = User.Username;

            if (userName.Length > maxLength)
            {
                username.Text = string.Concat(userName.AsSpan(0, maxLength - 3), "...");
                wholeUsername.SetToolTip(username, userName);
            }
            else
            {
                username.Text = userName;
            }

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
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }
    }
}

using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Devices;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Org.BouncyCastle.Crypto;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml.Linq;
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

        private string orderBy = "nimi ASC";
        private string filter = "";
        private string userName = User.Username;

        public Home()
        {
            InitializeComponent();

            this.FormClosing += FormManager.FormClosing;

            FormManager.AddMouseEnterAndLeave(new System.Windows.Forms.Label[] { oma_tili, tuki, palautteet, ehdota_kirjaa, kirjauduUlos, asiakkaat, lisaa_kirja });

            DesignHome();

            FormManager.SetDoubleBuffered(this);
            FormManager.SetDoubleBuffered(kirjaFlowLayoutPanel);
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            // Avataan ja suljetaan valikko

            FormManager.ToggleMenu(Menu, timerHome);
        }

        private void TimerHome_Tick(object sender, EventArgs e)
        {
            //Käynnistetään valikon animaatio

            FormManager.timerTick(timerHome, Menu);
        }

        private void Home_Load(object sender, EventArgs e)
        {
            FormManager.ShowPartOrFullText(username, username.Text.Length, userName.ToLower(), wholeUsername);

            // Tarkistetaan käyttäjän tyyppi ja näytetään oikeat vaihtoehdot

            bool isStaff = User.IsStaff;

            asiakkaat.Visible = isStaff;
            lisaa_kirja.Visible = isStaff;
            tuki.Visible = !isStaff;
            palautteet.Visible = !isStaff;
            ehdota_kirjaa.Visible = !isStaff;

            asiakkaat.Location = isStaff ? ehdota_kirjaa.Location : new Point(10, 205);
            lisaa_kirja.Location = isStaff ? tuki.Location : new Point(10, 235);

            LoadBooksFromDatabase();
        }

        private void LogOut_Click(object sender, EventArgs e)
        {
            // Kirjaudutaan ulos ja avataan kirjautumisikkuna

            FormManager.OpenLogin(this);
        }

        private void SuggestBook_Click(object sender, EventArgs e)
        {
            // Avataan kirjaehdotusikkuna

            BookRecommendation bookRecom = new();
            bookRecom.Show();
        }

        private void Support_Click(object sender, EventArgs e)
        {
            // Avataan tukilomake

            FormManager.OpenContact("tuki");
        }

        private void Feedback_Click(object sender, EventArgs e)
        {
            // Avataan palaute lomake

            FormManager.OpenContact("palaute");
        }

        private void Profile_Click(object sender, EventArgs e)
        {
            // Avataan käyttäjän tiedot

            FormManager.OpenAccountDetails(User.Asnum);
        }

        private void AddBook_Click(object sender, EventArgs e)
        {
            // Avataan uuden kirjan lisäysikkuna
            FormManager.OpenBookInfo();
        }

        private void Customers_Click(object sender, EventArgs e)
        {
            // Avataan asiakaslista

            FormManager.OpenUserList(this);
        }

        private void JarjestysCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Muutetaan kirjojen järjestystä

            haeKirjojaTB.Text = "";

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
                    orderBy = "enimi ASC, snimi ASC";
                    break;
                case 3:
                    orderBy = "enimi DESC, snimi DESC"; //Virhe: ei käännä järjestystä
                    break;
                case 4:
                    orderBy = "sivut DESC";
                    break;
                case 5:
                    orderBy = "sivut ASC";
                    break;
                case 6:
                    orderBy = "julkaistu DESC";
                    break;
                case 7:
                    orderBy = "julkaistu ASC";
                    break;
            }

            // Ladataan kirjat uudelleen järjestyksen mukaan

            LoadBooksFromDatabase();
        }

        private void haeKirjojaTB_TextChanged(object sender, EventArgs e)
        {
            // Filtteröidään kirjoja haun perusteella

            string search = haeKirjojaTB.Text;

            //string filter = "WHERE k.nimi LIKE '%" + search + "%' OR kir.enimi LIKE '%" + search + "%' OR kir.snimi LIKE '%" + search + "%'";
            filter = search != "" ? $"WHERE k.nimi LIKE \"{search}%\" " : "";

            LoadBooksFromDatabase();
        }

        public void LoadBooksFromDatabase()
        {
            // Ladataan kirjat tietokannasta

            List<string[]> books = new();

            try
            {
                db.OpenConnection();

                string query = $"SELECT k.isbn, k.nimi, kir.enimi, kir.snimi, k.img FROM kirja k INNER JOIN kirjailija kir ON k.kirtu = kir.kirtunnus {filter}ORDER BY {orderBy}";

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

            // Näytetään kirjat

            DisplayBooks(books);
        }

        private void DisplayBooks(List<string[]> bookList)
        {
            // Näytetään kirjat käyttöliittymässä

            kirjaFlowLayoutPanel.SuspendLayout();
            kirjaFlowLayoutPanel.Controls.Clear();

            kirjaFlowLayoutPanel.Height = 340;
            Menu.Height = kirjaFlowLayoutPanel.Bottom - Header.Height + 30;
            footer.Top = Menu.Bottom;
            this.Height = 655;
            CopyrightLabel.Top = Menu.Bottom - CopyrightLabel.Height - 30;

            int booksOnRow = 0;
            int rows = 1;

            int moreHeight = 340;

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


                string rootPath = Directory.GetCurrentDirectory();
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
                    Name = "nimi" + (i + 1),
                    TextAlign = ContentAlignment.MiddleCenter,
                };

                bookName.Location = new Point((kirjaPanel.Width - bookName.Width) / 2, bookCover.Bottom + 10);
                FormatLabel(bookName, nimi);

                kirjaPanel.Controls.Add(bookName);

                Label bookAuthor = new()
                {
                    Width = kirjaPanel.Width,
                    Left = 0,
                    Text = kirjailija,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Impact", 8)
                };
                if (bookName.Height > 30)
                {
                    bookAuthor.Top = bookName.Bottom;
                }
                else
                {
                    bookAuthor.Top = bookName.Bottom + 5;
                }

                kirjaPanel.Controls.Add(bookAuthor);
                Button lainaaButton = new()
                {
                    Name = "lainaaBtn" + (i + 1),
                    Text = "Lainaa",
                    BackColor = Color.Beige,
                    FlatStyle = FlatStyle.Flat,
                    Height = 45,
                    Width = 90,
                    Font = new Font("Impact", 10F)
                };
                lainaaButton.Location = new Point((kirjaPanel.Width - 90) / 2, kirjaPanel.Bottom - lainaaButton.Height - 20);

                lainaaButton.Click += (s, args) => ControlClicked(s, args, lainaaButton);
                kirjaPanel.Controls.Add(lainaaButton);

                panelsToAdd.Add(kirjaPanel);
            }

            kirjaFlowLayoutPanel.Controls.AddRange(panelsToAdd.ToArray());

            if (bookList.Count == 0)
            {
                Label noBooks = new()
                {
                    Text = "Kirjoja ei löytynyt",
                    Font = new Font("Impact", 14F),
                    BackColor = Color.Transparent,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Width = kirjaFlowLayoutPanel.Width,
                    Height = 50,
                };

                kirjaFlowLayoutPanel.Height = 150;
                noBooks.Location = new Point(0, (kirjaFlowLayoutPanel.Height - noBooks.Height) / 2 + 50);

                kirjaFlowLayoutPanel.Controls.Add(noBooks);
            }

            Menu.Height = kirjaFlowLayoutPanel.Bottom - Header.Height + 30;
            footer.Top = Menu.Bottom;
            CopyrightLabel.Top = Menu.Bottom - CopyrightLabel.Height - 30;

            if (Menu.Bottom < 640)
            {
                Header.Width = this.Width;
                footer.Width = this.Width;
                this.AutoScroll = false;
                this.Height = footer.Bottom + 40;
            }
            else
            {
                Header.Width = 800;
                //Header.Width = this.Width - SystemInformation.VerticalScrollBarWidth;
                footer.Width = Header.Width;
                this.AutoScroll = true;
                this.Height = 800;
            }

            kirjaFlowLayoutPanel.ResumeLayout();
        }

        private static void FormatLabel(Label label, string bookName)
        {
            string[] words = bookName.Split(' ');

            if (words.Length > 1 && bookName.Length > 16)
            {
                string firstLine = "";
                string secondLine = "";

                foreach (string word in words)
                {
                    if ((firstLine + word).Length <= 16)
                    {
                        firstLine += word + " ";
                    }
                    else
                    {
                        secondLine += word + " ";
                    }
                }

                firstLine = firstLine.TrimEnd();
                secondLine = secondLine.TrimEnd();

                label.Text = firstLine + Environment.NewLine + secondLine;

                label.Height *= 2;
            }
            else
            {
                label.Text = bookName;
            }
        }

        private static void ControlClicked(object sender, EventArgs e, Control control)
        {
            string name = "";

            // Tallennetaan klikatun kirjan nimi

            foreach (Control c in control.Parent.Controls)
            {
                if (c is Label label && label.Name.StartsWith("nimi"))
                {
                    name = label.Text;
                }
            }

            // Avataan kirjan tiedot

            if (control is PictureBox picbox && picbox.Name.StartsWith("kirja"))
            {
                FormManager.OpenBookInfo(name);
            }

            // Luodaan uusi lainaus

            else if (control is Button btn && btn.Name.StartsWith("lainaaBtn"))
            {
                FormManager.CreateNewLoan(name);
            }
        }

        public void DesignHome()
        {
            // Muotoillaan aloitussivun näkymä dynaamisesti            

            haeKirjoja.Location = new Point((this.Width - haeKirjoja.Width) / 2, 150);
            kirjaFlowLayoutPanel.Size = new Size(560, 300);
            kirjaFlowLayoutPanel.Location = new Point((this.Width - kirjaFlowLayoutPanel.Width) / 2, 342);

            selausAsetukset.Size = new Size(560, 94);
            selausAsetukset.Location = new Point(kirjaFlowLayoutPanel.Left, kirjaFlowLayoutPanel.Top - selausAsetukset.Height);

            selaaKirjoja.Location = new Point((selaaKirjoja.Parent.Width - selaaKirjoja.Width) / 2, 20);
            jarjestysCB.Location = new Point((jarjestysCB.Parent.Width - jarjestysCB.Width - 10), jarjestysCB.Parent.Height - jarjestysCB.Height - 10);
            jarjestys.Location = new Point(jarjestysCB.Location.X - jarjestys.Width - 10, jarjestysCB.Location.Y);

            footer.BringToFront();
        }

        private void FooterLogo_Click(object sender, EventArgs e)
        {
            this.AutoScrollPosition = Point.Empty;
        }
    }
}

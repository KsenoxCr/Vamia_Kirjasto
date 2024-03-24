using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Org.BouncyCastle.Crypto;
using System.Data;
using static System.ComponentModel.Design.ObjectSelectorEditor;
//using System.Reflection.Emit;

namespace Kirjasto_ohjelma
{
    public partial class Home : Form
    {
        bool menuOpen = false;

        private DatabaseAccess db = DatabaseAccess.GetInstance();

        public Home()
        {
            InitializeComponent();

            bool isStaff = User.IsStaff;

            this.FormClosing += FormManager.Form_FormClosing;

            FormManager.AddMouseEnterAndLeave(new System.Windows.Forms.Label[] { oma_tili, tuki, palautteet, ehdota_kirjaa, kirjauduUlos, asiakkaat });

            tuki.Visible = !isStaff;
            palautteet.Visible = !isStaff;
            ehdota_kirjaa.Visible = !isStaff;

            asiakkaat.Visible = isStaff;
            asiakkaat.Location = tuki.Location;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            FormManager.toggleMenu(Menu);
        }


        private void Form3_Load(object sender, EventArgs e)
        {
            string query = "SELECT k.nimi, kir.enimi, kir.snimi, k.img FROM kirja k INNER JOIN kirjailija kir ON k.kirtu = kir.kirtunnus ORDER BY k.nimi ASC";

            LoadBooksFromDatabase(query);

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

            AccountDetails accDetails = AccountDetails.Instance;

            accDetails.Show();

            foreach (Form form in Application.OpenForms)
            {

                if (form.Name != accDetails.Name)
                {
                    form.Hide();
                }
            }
        }

        private void asiakkaat_Click(object sender, EventArgs e)
        {

        }

        private void jarjestysCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            kirjaFlowLayoutPanel.Controls.Clear();

            string OrderBy = "";

            switch (jarjestysCB.SelectedIndex)
            {
                case 0:
                default:
                    OrderBy = "nimi ASC";
                    break;
                case 1:
                    OrderBy = "nimi DESC";
                    break;
                case 2:
                    OrderBy = "snimi, enimi ASC";
                    break;
                case 3:
                    OrderBy = "snimi, enimi DESC";
                    break;
                case 4:
                    OrderBy = "sivut ASC";
                    break;
                case 5:
                    OrderBy = "sivut DESC";
                    break;
                case 6:
                    OrderBy = "sivut ASC";
                    break;
                case 7:
                    OrderBy = "sivut DESC";
                    break;
            }

            string query = $"SELECT k.nimi, kir.enimi, kir.snimi, k.img, k.julkaistu, k.sivut FROM kirja k INNER JOIN kirjailija kir ON k.kirtu = kir.kirtunnus ORDER BY {OrderBy}";

            LoadBooksFromDatabase(query);
        }

        public void ControlsAreClickable(Control control, string controlName, string controlType)
        {
            var clickableControls = control.EnumerateControls().Where(c => c is Button || c is PictureBox && c.Name.StartsWith(controlName) && c.Name.Length > controlName.Length);

            foreach (var controlToClick in clickableControls)
            {
                controlToClick.Click += (s, args) => FormManager.controlClicked(s, args, controlToClick);
            }
        }
        public void LoadBooksFromDatabase(string query)
        {
            string nimi = "";
            string kirjailija = "";
            string imageName = "";

            int rowCount = 0;

            try
            {
                db.OpenConnection();

                using (MySqlCommand command = new MySqlCommand(query, db.connection))
                {

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            rowCount++;
                            if (rowCount % 4 == 1)
                            {
                                kirjaFlowLayoutPanel.Height *= 2;
                            }

                            nimi = reader.GetString(0);
                            kirjailija = reader.GetString(1)+" "+reader.GetString(2);
                            imageName = reader.GetString(3) + ".png";

                            Panel kirjaPanel = new Panel
                            {
                                Size = new Size(130, 330),
                                BackColor = Color.FromArgb(255, 241, 220),
                                Font = new Font("Impact", 12),
                                Name = "kirjaPanel" + rowCount,
                                Margin = new Padding(5)
                            };

                            PictureBox bookCover = new PictureBox();
                            bookCover.Size = new Size(110, 165);
                            bookCover.Left = (kirjaPanel.Width - bookCover.Width) / 2;
                            bookCover.Top = 15;
                            bookCover.SizeMode = PictureBoxSizeMode.Zoom;
                            //bookCover.SizeMode = PictureBoxSizeMode.StretchImage;
                            bookCover.Name = "kirja" + rowCount;
                            bookCover.Click += (s, args) => FormManager.controlClicked(s, args, bookCover);

                            string imagePath = Path.Combine("Images", imageName);

                            try
                            {
                                bookCover.Image = Image.FromFile(imagePath);
                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show("Virhe ladatessa kuvaa: " + ex.Message);
                            }

                            kirjaPanel.Controls.Add(bookCover);

                            Label bookName = new Label();
                            bookName.Width = kirjaPanel.Width;
                            bookName.Top = bookCover.Bottom + 15;
                            bookName.Left = 0;
                            bookName.Text = nimi;
                            bookName.TextAlign = ContentAlignment.MiddleCenter;

                            kirjaPanel.Controls.Add(bookName);

                            Label bookAuthor = new Label();
                            bookAuthor.Width = kirjaPanel.Width;
                            bookAuthor.Top = bookName.Bottom + 10;
                            bookAuthor.Left = 0;
                            bookAuthor.Text = kirjailija;
                            bookAuthor.TextAlign = ContentAlignment.MiddleCenter;
                            bookAuthor.Font = new Font("Impact", 8);

                            kirjaPanel.Controls.Add(bookAuthor);

                            basicButton lainaaButton = new basicButton(User.IsStaff ? "Katso" : "Lainaa", "beige", 45, 90, (kirjaPanel.Width - 90) / 2, bookAuthor.Bottom + 15, 10F);
                            lainaaButton.Name = "lainaaBtn" + rowCount;
                            lainaaButton.Click += (s, args) => FormManager.controlClicked(s, args, lainaaButton);

                            kirjaPanel.Controls.Add(lainaaButton);

                            kirjaFlowLayoutPanel.Controls.Add(kirjaPanel);
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
        }
    }
}

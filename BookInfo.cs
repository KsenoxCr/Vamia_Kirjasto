using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Kirjasto_ohjelma
{
    public partial class BookInfo : Form
    {
        private DatabaseAccess db = DatabaseAccess.GetInstance();

        private string _bookName;
        private string isbn;

        public BookInfo(string bookName)
        {
            InitializeComponent();

            this._bookName = bookName;

            loadBookInfo(_bookName);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            muokkaaBtn.Visible = User.IsStaff;
            poistaBtn.Visible = User.IsStaff;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (FormManager.CreateNewLoan(_bookName))
            {

                FormManager.openConfirmMessage("lainaus", _bookName);
            }
            else
            {
                MessageBox.Show("Virhe lainauksessa. Yritä myöhemmin uudelleen.");
            }

            FormManager.openConfirmMessage("lainaus");

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormManager.openConfirmMessage("muokkaus");

            this.Close();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            FormManager.openConfirmMessage("varmistus", _bookName, isbn);

            this.Close();
        }
        private void loadBookInfo(string booksName)
        {
            string query = $"SELECT kir.isbn, kir.enimi, kir.snimi, k.genre, k.julkaistu, k.kustantaja, k.sivut, k.img FROM kirja k INNER JOIN kirjailija kir ON k.kirtu = kir.kirtunnus WHERE k.nimi = \"{booksName}\"";

            string descFileName = "";

            try
            {
                db.connection.Open();

                using (MySqlCommand command = new MySqlCommand(query, db.connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isbn = reader.GetString(0);

                            nimi.Text = booksName;
                            nimi.Left = (this.Width - nimi.Width) / 2;
                            kirjailija.Text = reader.GetString(1) + " " + reader.GetString(2);
                            kirjailija.Left = (this.Width - kirjailija.Width) / 2;
                            genre.Text = reader.GetString(3);
                            genre.Left = ((kirjanTiedot.Width + genreLabel.Width) - genre.Width) / 2;
                            julkaistu.Text = reader.GetInt32(4).ToString();
                            kustantaja.Text = reader.GetString(5);
                            sivumaara.Text = reader.GetInt32(6).ToString();

                            string image = reader.GetString(7) + ".png";

                            string rootPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..");
                            string imagePath = Path.GetFullPath(Path.Combine(rootPath, "Images", image));

                            try
                            {
                                kansikuva.Image = Image.FromFile(imagePath);
                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show("Virhe ladatessa kuvaa: " + ex.Message);
                            }
                            kansikuva.SizeMode = PictureBoxSizeMode.Zoom;

                            descFileName = reader.GetString(7)+".txt";
                        }
                    }
                }
            } catch (Exception ex)
            {
                MessageBox.Show($"Tietokantavirhe: {ex.Message}");
            }
            finally
            {
                db.connection.Close();
            }

            string description = "";

            string root = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..");
            string descPath = Path.Combine(root, "BookDescriptions", descFileName);

            if (descFileName != "")
            {
                try
                {
                    using (StreamReader reader = new StreamReader(descPath))
                    {
                        description = reader.ReadToEnd();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Virhe lukiessa tiedostoa: " + ex.Message);
                }

                kuvaus.Text = description;
            }
        }
    }
}

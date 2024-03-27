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

namespace Kirjasto_ohjelma
{
    public partial class BookInfo : Form
    {
        private DatabaseAccess db = DatabaseAccess.GetInstance();

        public BookInfo(string bookName)
        {
            InitializeComponent();

            loadBookInfo(bookName);
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
            ConfirmMessage lainausOk = new ConfirmMessage("lainaus");
            lainausOk.Show();

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConfirmMessage muokkausOk = new ConfirmMessage("muokkaus");
            muokkausOk.Show();

            this.Close();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            ConfirmMessage varmistus = new ConfirmMessage("varmistus");
            varmistus.Show();

            this.Close();
        }
        private void loadBookInfo(string booksName)
        {
            string query = $"SELECT kir.enimi, kir.snimi, k.genre, k.julkaistu, k.kustantaja, k.sivut, k.img FROM kirja k INNER JOIN kirjailija kir ON k.kirtu = kir.kirtunnus WHERE k.nimi = \"{booksName}\"";

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
                            nimi.Text = booksName;
                            kirjailija.Text = reader.GetString(0) + " " + reader.GetString(1);
                            genre.Text = reader.GetString(2);
                            julkaistu.Text = reader.GetInt32(3).ToString();
                            kustantaja.Text = reader.GetString(4);
                            sivumaara.Text = reader.GetInt32(5).ToString();

                            string imagePath = Path.Combine("Images", reader.GetString(6)+".png");

                            try
                            {
                                kansikuva.Image = Image.FromFile(imagePath);
                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show("Virhe ladatessa kuvaa: " + ex.Message);
                            }
                            kansikuva.SizeMode = PictureBoxSizeMode.Zoom;

                            descFileName = reader.GetString(6)+".txt";
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

            string descPath = Path.Combine("BookDescriptions", descFileName);

            if(descFileName != "")
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

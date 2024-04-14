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
        private readonly DatabaseAccess db = DatabaseAccess.GetInstance();

        private readonly string _bookName;
        private string isbn;

        private string genreDB;
        private int publishedDB;
        private string publisherDB;
        private int pagesDB;
        private string descFileName;
        private string Description;
        private readonly string root = Directory.GetCurrentDirectory();

        public BookInfo(string bookName)
        {
            InitializeComponent();

            this._bookName = bookName;

            bool isStaff = User.IsStaff;

            muokkaaBtn.Visible = isStaff;
            poistaBtn.Visible = isStaff;

            if (isStaff)
            {
                foreach (Control control in Controls)
                {
                    if (control is TextBox tb)
                    {
                        tb.ReadOnly = false;
                    }
                }
            }
        }
        private void BookInfo_Load(object sender, EventArgs e)
        {
            LoadBookInfo(_bookName);
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Lend_Click(object sender, EventArgs e)
        {
            if (FormManager.CreateNewLoan(_bookName))
            {
                this.Close();
            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if (nimi.Text != _bookName)
            {
                UpdateBookInfo(nimi.Text, "nimi");
            }
            if (genre.Text != genreDB)
            {
                UpdateBookInfo(genre.Text, "genre");
            }
            if (julkaistu.Text != publishedDB.ToString())
            {
                UpdateBookInfo(julkaistu.Text, "julkaistu");
            }
            if (kustantaja.Text != publisherDB)
            {
                UpdateBookInfo(kustantaja.Text, "kustantaja");
            }
            if (sivumaara.Text != pagesDB.ToString())
            {
                UpdateBookInfo(sivumaara.Text, "sivut");
            }
            if (kuvaus.Text != Description)
            {
                UpdateBookInfo(kuvaus.Text, descFileName);
            }

            this.Refresh();
        }
        
        private void Delete_Click(object sender, EventArgs e)
        {
            FormManager.OpenConfirmMessage("poisto", _bookName, isbn);

            this.Close();
        }

        private void LoadBookInfo(string booksName)
        {
            string image = "";
            string authorDB = "";

            try
            {
                db.connection.Open();

                string queryBookInfo = $"SELECT k.isbn, kir.enimi, kir.snimi, k.genre, k.julkaistu, k.kustantaja, k.sivut, k.img, k.kuvaus FROM kirja k INNER JOIN kirjailija kir ON k.kirtu = kir.kirtunnus WHERE k.nimi = \"{booksName}\"";

                using MySqlCommand command = new(queryBookInfo, db.connection);
                using MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isbn = reader["isbn"] as string;

                    authorDB = reader["enimi"] as string + " " + reader["snimi"] as string;

                    genreDB = reader["genre"] as string;
                    publishedDB = (int)reader["julkaistu"];
                    publisherDB = reader["kustantaja"] as string;
                    pagesDB = (int)reader["sivut"];

                    image = reader["img"] as string;

                    descFileName = reader["kuvaus"] as string;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Tietokantavirhe: {ex.Message}");
            }
            finally
            {
                db.connection.Close();
            }

            try
            {
                nimi.Text = booksName;
                nimi.Left = (this.Width - nimi.Width) / 2;
                kirjailija.Text = authorDB;
                kirjailija.Left = (this.Width - kirjailija.Width) / 2;
                genre.Text = genreDB;
                genre.Left = ((kirjanTiedot.Width + genreLabel.Width) - genre.Width) / 2;
                julkaistu.Text = publishedDB.ToString();
                kustantaja.Text = publisherDB;
                sivumaara.Text = pagesDB.ToString();
            } 
            catch (Exception ex)
            {
                MessageBox.Show("Virhe ladatessa kirjan tietoja: " + ex.Message);
            }

            string root = Directory.GetCurrentDirectory();
            string imagePath = Path.GetFullPath(Path.Combine(root, "Images", image));

            try
            {
                kansikuva.Image = Image.FromFile(imagePath);
                kansikuva.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Virhe ladatessa kuvaa: " + ex.Message);
            }

            string descPath = Path.Combine(root, "BookDescriptions", descFileName);

            try
            {
                using StreamReader reader = new(descPath);

                kuvaus.Text = reader.ReadToEnd();
                Description = kuvaus.Text;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Virhe lukiessa tiedostoa: " + ex.Message);
            }
        }

        private void BookCover_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new();
            openFileDialog.Filter = "Image files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp"; // Filter for common image formats
            openFileDialog.Title = "Valitse uusi kansikuva";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;

                try
                {
                    string newImagePath = Path.GetFullPath(Path.Combine(root, "Images", isbn + ".png"));

                    kansikuva.Image = Image.FromFile(imagePath);
                }
                catch (Exception ex)
                {
                    // Handle potential exceptions (e.g., invalid file format)
                    MessageBox.Show("Error loading image: " + ex.Message);
                }
            }
        }
        private void UpdateBookInfo(string value, string col)
        {
            if (col == descFileName)
            {
                string descPath = Path.GetFullPath(Path.Combine(root, "BookDescriptions", descFileName));

                try
                {
                    File.WriteAllText(descPath, value);
                    Console.WriteLine("File updated successfully!");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error updating file: {e.Message}");
                }
            } else
            {
                try
                {
                    db.connection.Open();

                    if (col == "julkaistu" || col == "sivut")
                    {
                        int.Parse(value);
                    }

                    string queryUpdateBook= $"UPDATE kirja SET @col = @value WHERE isbn = @isbn";

                    using MySqlCommand command = new(queryUpdateBook, db.connection);
                    command.Parameters.AddWithValue("@col", col);
                    command.Parameters.AddWithValue("@value", value);
                    command.Parameters.AddWithValue("@isbn", isbn);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Virhe muokatessa kirjan tietoa: {col}");
                    MessageBox.Show($"Tietokantavirhe: {ex.Message}");
                }
                finally
                {
                    db.connection.Close();
                }
            }
        }
    }
}

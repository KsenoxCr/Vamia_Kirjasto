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
        private Image bookCover;
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
            string image = "";

            try
            {
                db.connection.Open();

                string queryBookInfo = $"SELECT k.isbn, kir.enimi, kir.snimi, k.genre, k.julkaistu, k.kustantaja, k.sivut, k.img, k.kuvaus FROM kirja k INNER JOIN kirjailija kir ON k.kirtu = kir.kirtunnus WHERE k.nimi = \"{_bookName}\"";

                using MySqlCommand command = new(queryBookInfo, db.connection);
                using MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isbn = reader["isbn"] as string;
                    string authorDB = reader["enimi"] as string + " " + reader["snimi"] as string;
                    genreDB = reader["genre"] as string;
                    publishedDB = (int)reader["julkaistu"];
                    publisherDB = reader["kustantaja"] as string;
                    pagesDB = (int)reader["sivut"];

                    image = reader["img"] as string;
                    descFileName = reader["kuvaus"] as string;

                    nimi.Text = _bookName;
                    nimi.Left = (this.Width - nimi.Width) / 2;
                    kirjailija.Text = authorDB;
                    kirjailija.Left = (this.Width - kirjailija.Width) / 2;
                    genre.Text = genreDB;
                    genre.Left = ((kirjanTiedot.Width + genreLabel.Width) - genre.Width) / 2;
                    julkaistu.Text = publishedDB.ToString();
                    kustantaja.Text = publisherDB;
                    sivumaara.Text = pagesDB.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Virhe ladatessa kirjan tietoja");
                MessageBox.Show($"Tietokantavirhe: {ex.Message}");
            }
            finally
            {
                db.connection.Close();
            }

            string root = Directory.GetCurrentDirectory();
            string imagePath = Path.GetFullPath(Path.Combine(root, "Images", image));

            try
            {
                kansikuva.Image = Image.FromFile(imagePath);
                kansikuva.SizeMode = PictureBoxSizeMode.Zoom;

                bookCover = kansikuva.Image;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Virhe ladatessa kansikuvaa: " + ex.Message);
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
                Console.WriteLine("Virhe ladatessa kirjan kuvausta: " + ex.Message);
            }
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
            string[] columsToUpdate = new string[7];
            string[] valuesForColumns = new string[7];

            if (nimi.Text != _bookName)
            {
                columsToUpdate[0] = "nimi";
                valuesForColumns[0] = nimi.Text;
            }
            if (genre.Text != genreDB)
            {
                columsToUpdate[1] = "genre";
                valuesForColumns[1] = genre.Text;
            }
            if (julkaistu.Text != publishedDB.ToString())
            {
                columsToUpdate[2] = "julkaistu";
                valuesForColumns[2] = julkaistu.Text;
            }
            if (kustantaja.Text != publisherDB)
            {
                columsToUpdate[3] = "kustantaja";
                valuesForColumns[3] = kustantaja.Text;
            }
            if (sivumaara.Text != pagesDB.ToString())
            {
                columsToUpdate[4] = "sivut";
                valuesForColumns[4] = sivumaara.Text;
            }
            if (kuvaus.Text != Description)
            {
                columsToUpdate[5] = descFileName;
                valuesForColumns[5] = kuvaus.Text;
            }
            if (kansikuva.Image != bookCover)
            {
                columsToUpdate[6] = "img";

                string imgPath = kansikuva.ImageLocation;
                valuesForColumns[6] = Path.GetFileName(imgPath);
            }

            if (UpdateBookInfo(valuesForColumns, columsToUpdate))
            {
                this.Refresh();
            }
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            FormManager.OpenConfirmMessage("poisto", _bookName, isbn);

            this.Close();
        }

        private void BookCover_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new()
            {
                Filter = "Image files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp",
                Title = "Valitse uusi kansikuva"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string newImagePath = openFileDialog.FileName;
                    string newImageName = Path.GetFileName(newImagePath);

                    kansikuva.Image = Image.FromFile(newImagePath);
                }
                catch (Exception ex)
                {
                    // Handle potential exceptions (e.g., invalid file format)
                    MessageBox.Show("Virhe vaihtaessa kuvaa: " + ex.Message);
                }
            }
        }
        private bool UpdateBookInfo(string[] values, string[] columns)
        {
            int i = 0;

            try
            {
                db.OpenConnection();

                for (i = 0; i < columns.Length; i++)
                {
                    string col = columns[i];
                    string value = values[i];

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
                            Console.WriteLine($"Virhe päivittäessä kirjan kuvausta: {e.Message}");
                        }
                    }
                    else
                    {
                        if (col == "julkaistu" || col == "sivut")
                        {
                            int.Parse(value);
                        }

                        string queryUpdateBookInfo = $"UPDATE kirja SET @col = @value WHERE isbn = @isbn";

                        using MySqlCommand command = new(queryUpdateBookInfo, db.connection);
                        command.Parameters.AddWithValue("@col", col);
                        command.Parameters.AddWithValue("@value", value);
                        command.Parameters.AddWithValue("@isbn", isbn);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Virhe päivittäessä kirjan tietoja: " + ex.Message);
                if (i == 0)
                {
                    return false;
                }
            }
            finally
            {
                db.CloseConnection();
            }
            return true;
        }
    }
}

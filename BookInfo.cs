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
        private readonly string rootPath = Directory.GetCurrentDirectory();
        private string isbn;

        private string genreDB;
        private int publishedDB;
        private string publisherDB;
        private int pagesDB;
        private string descFileName;
        private string Description;
        private string newImageName;
        private Image bookCover;

        public BookInfo(string bookName)
        {
            InitializeComponent();

            this._bookName = bookName;

            bool isStaff = User.IsStaff;

            muokkaaBtn.Visible = isStaff;
            poistaBtn.Visible = isStaff;

            genre.ReadOnly = !isStaff;
            julkaistu.ReadOnly = !isStaff;
            kustantaja.ReadOnly = !isStaff;
            sivumaara.ReadOnly = !isStaff;
            kuvaus.ReadOnly = !isStaff;
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

                    if (!reader.IsDBNull(reader.GetOrdinal("img")))
                    {
                        image = reader["img"] as string;
                    }
                    else
                    {
                        image = "ImageNotFound.png";
                    }

                    if (!reader.IsDBNull(reader.GetOrdinal("kuvaus")))
                    {
                        descFileName = reader["kuvaus"] as string;
                    }
                    else
                    {
                        descFileName = FormManager.CreateBookDescription(_bookName);
                    }

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

            string imagePath = Path.GetFullPath(Path.Combine(rootPath, @"Images\BookCovers", image));

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

            string descPath = Path.Combine(rootPath, "BookDescriptions", descFileName);

            try
            {
                using StreamReader streamReader = new(descPath);

                kuvaus.Text = streamReader.ReadToEnd();
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
            List<string> columsToUpdate = new();
            List<string> valuesForColumns = new();

            bool hasChanges = false;

            if (nimi.Text != _bookName)
            {
                columsToUpdate.Add("nimi");
                valuesForColumns.Add(nimi.Text);
                hasChanges = true;
            }
            if (genre.Text != genreDB)
            {
                columsToUpdate.Add("genre");
                valuesForColumns.Add(genre.Text);
                hasChanges = true;
            }
            if (julkaistu.Text != publishedDB.ToString())
            {
                columsToUpdate.Add("julkaistu");
                valuesForColumns.Add(julkaistu.Text);
                hasChanges = true;
            }
            if (kustantaja.Text != publisherDB)
            {
                columsToUpdate.Add("kustantaja");
                valuesForColumns.Add(kustantaja.Text);
                hasChanges = true;
            }
            if (sivumaara.Text != pagesDB.ToString())
            {
                columsToUpdate.Add("sivut");
                valuesForColumns.Add(sivumaara.Text);
                hasChanges = true;
            }
            if (kuvaus.Text != Description && kuvaus.Text != "")
            {
                columsToUpdate.Add(descFileName);
                valuesForColumns.Add(kuvaus.Text);
                hasChanges = true;
            }
            if (kansikuva.Image != bookCover)
            {
                columsToUpdate.Add("img");
                valuesForColumns.Add(newImageName);

                string newImgPath = Path.Combine(rootPath, @"Images\BookCovers", newImageName);
                kansikuva.Image.Save(newImgPath);

                hasChanges = true;
            }
            if (hasChanges)
            {
                if (UpdateBookInfo(valuesForColumns, columsToUpdate))
                {
                    FormManager.OpenConfirmMessage("muokkaus", _bookName, isbn, columsToUpdate);

                    this.Close();
                }
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
                Filter = "Kuva tiedostot (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp",
                Title = "Valitse uusi kansikuva"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string newImagePath = openFileDialog.FileName;
                    newImageName = Path.GetFileName(newImagePath);

                    kansikuva.Image = Image.FromFile(newImagePath);
                }
                catch (Exception ex)
                {
                    // Handle potential exceptions (e.g., invalid file format)
                    MessageBox.Show("Virhe vaihtaessa kuvaa: " + ex.Message);
                }
            }
        }

        private bool UpdateBookInfo(List<string> values, List<string> columns)
        {
            int i = 0;

            try
            {
                db.OpenConnection();

                for (i = 0; i < columns.Count; i++)
                {
                    string col = columns[i];
                    string value = values[i];

                    if (col == descFileName)
                    {
                        string descPath = Path.GetFullPath(Path.Combine(rootPath, "BookDescriptions", descFileName));

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

                        string queryUpdateBookInfo = $"UPDATE kirja SET {col} = @value WHERE isbn = \"{isbn}\"";

                        using MySqlCommand command = new(queryUpdateBookInfo, db.connection);
                        command.Parameters.AddWithValue("@value", value);

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

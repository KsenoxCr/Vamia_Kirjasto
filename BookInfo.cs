using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.ComboBox;
using Image = System.Drawing.Image;

namespace Kirjasto_ohjelma
{
    public partial class BookInfo : Form
    {
        private readonly DatabaseAccess db = DatabaseAccess.GetInstance();

        private readonly string _bookName;
        private readonly string rootPath = Directory.GetCurrentDirectory();
        private bool isStaff;
        private string isbn;

        private string authorDB;
        private string genreDB;
        private int publishedDB;
        private string publisherDB;
        private int pagesDB;
        private string descFileName;
        private string Description;
        private string newImageName;
        private Image bookCover;

        public BookInfo(string bookName = "")
        {
            InitializeComponent();

            this._bookName = bookName;

            _bookName = _bookName.Replace("\r\n", " ");

            isStaff = User.IsStaff;

            Design();
        }

        private void BookInfo_Load(object sender, EventArgs e)
        {
            if (_bookName != "")
            {
                LoadBookInfo();
            }

            if (isStaff)
            {
                kirjailija.Visible = false;
                kirjailijaCB.Visible = true;
                LoadAuthors();

                FormManager.AddPlaceholder(isbnTB, "13 numeroa");
                FormManager.AddPlaceholder(nimi, "Kirjan nimi");
                FormManager.AddPlaceholder(genre, "Genre");
                FormManager.AddPlaceholder(julkaistu, "Julkaisuvuosi");
                FormManager.AddPlaceholder(kustantaja, "Kustantaja");  // Make sure to not allow updating values that are grey (palceholders)
                FormManager.AddPlaceholder(sivumaara, "Sivumäärä");
                FormManager.AddPlaceholder(kuvaus, "Kuvaus");
            }
            else
            {
                kirjailija.Visible = true;
                kirjailijaCB.Visible = false;
            }
        }

        private void LoadBookInfo()
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
                    authorDB = reader["enimi"] as string + " " + reader["snimi"] as string;
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

            DisplayBookInfo(isbn, _bookName, authorDB, genreDB, publishedDB, publisherDB, pagesDB, image, descFileName);
        }

        private void DisplayBookInfo(string isbn, string name, string author, string genreName, int published, string publisher, int pages, string imageName, string descName)
        {
            // Näytetään kirjan tiedot

            isbnTB.Text = isbn;
            nimi.Text = name;
            nimi.Left = (this.Width - nimi.Width) / 2;
            kirjailija.Text = author;
            kirjailija.Left = (this.Width - kirjailija.Width) / 2;
            genre.Text = genreName;
            genre.Left = ((kirjanTiedot.Width + genreLabel.Width) - genre.Width) / 2;
            julkaistu.Text = published.ToString();
            kustantaja.Text = publisher;
            sivumaara.Text = pages.ToString();

            // Kansikuva

            string imagePath = Path.GetFullPath(Path.Combine(rootPath, @"Images\BookCovers", imageName));

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

            // Kuvaus

            string descPath = Path.Combine(rootPath, "BookDescriptions", descName);

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

            // Lisätään kuvaukselle scroll bar jos teksti on liian pitkä

            int lineHeight = TextRenderer.MeasureText("A", kuvaus.Font).Height;
            int lines = kuvaus.GetLineFromCharIndex(kuvaus.TextLength) + 1;
            int preferredHeight = lineHeight * lines;

            if (preferredHeight > kuvaus.ClientSize.Height - kuvaus.Padding.Top - kuvaus.Padding.Bottom)
            {
                kuvaus.ScrollBars = ScrollBars.Vertical;
            }
            else
            {
                kuvaus.ScrollBars = ScrollBars.None;
            }

            // Muokataan tiedot sopivan kokoisiksi

            if (nimi.Text.Length > 33)
            {
                nimi.Font = new Font("Impact", 22F);
            }
            if (genre.Text.Length > 10)
            {
                genre.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            }
            if (kustantaja.Text.Length > 9)
            {
                kustantaja.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                kustantaja.Top = 95;
            }
        }

        private void Design()
        {
            if (_bookName == "")
            {
                muokkaaBtn.Visible = false;
                poistaBtn.Visible = false;
                lainaaBtn.Text = "Lisää";
            }
            else
            {
                muokkaaBtn.Visible = isStaff;
                poistaBtn.Visible = isStaff;
                lainaaBtn.Text = "Lainaa";
            }

            isbnPanel.Visible = isStaff;

            kuvaus.Height = isStaff ? 385 - isbnPanel.Height : 385;
            kuvaus.Top = isStaff ? isbnPanel.Bottom : 15;

            nimi.ReadOnly = !isStaff;
            genre.ReadOnly = !isStaff;
            julkaistu.ReadOnly = !isStaff;
            kustantaja.ReadOnly = !isStaff;
            sivumaara.ReadOnly = !isStaff;
            kuvaus.ReadOnly = !isStaff;
        }

        private void kirjailijaCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (kirjailijaCB.SelectedItem.ToString() == "Lisää uusi kirjailija")
            {
                // Avataan kirjailijan lisäys ikkuna

                FormManager.OpenChangeValue("set", "kirjailija");

                kirjailijaCB.Text = "Kirjailija";
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Lend_Click(object sender, EventArgs e)
        {
            if (lainaaBtn.Text.ToLower() == "lainaa")
            {
                if (FormManager.CreateNewLoan(_bookName))
                {
                    this.Close();
                }
            }
            else if (lainaaBtn.Text.ToLower() == "lisää")
            {
                string isbn_ = FormManager.ValidateName(isbnTB.Text, "isbn", isbnTB);
                string name = FormManager.ValidateName(nimi.Text, "kirjan nimi", nimi);
                string author = FormManager.ValidateAuthor(kirjailijaCB.Text);
                string genre_ = FormManager.ValidateName(genre.Text, "genre", genre);
                int pages = FormManager.ValidateNumber(sivumaara.Text, "sivumäärä");
                int published = FormManager.ValidateNumber(julkaistu.Text, "julkaisuvuosi");
                string publisher = FormManager.ValidateName(kustantaja.Text, "kustantaja", kustantaja);

                if (isbn_ != "" && name != "" && author != "" && genre_ != "" && pages != -1 && published != -1 && publisher != "")
                {
                    string descFileName = FormManager.CreateBookDescription(name);

                    UpdateBookDesc(descFileName, kuvaus.Text);

                    if (AddBookToDatabase(isbn_.ToString(), name, author, genre_, pages, published, publisher, descFileName, newImageName))
                    {
                        FormManager.OpenConfirmMessage("lisäys", name);
                    }
                }
            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            List<string> columsToUpdate = new();
            List<string> valuesForColumns = new();

            bool hasChanges = false;

            if (kirjailijaCB.Text != authorDB)
            {
                string authorID = FindAuthorID(kirjailijaCB.Text);

                if (authorID != null)
                {
                    columsToUpdate.Add("kirtu");
                    valuesForColumns.Add(authorID);
                    hasChanges = true;
                }
            }
            if (isbnTB.Text != isbn)
            {
                int isbn_ = FormManager.ValidateNumber(isbnTB.Text, "isbn");

                if (isbn_ != -1)
                {
                    columsToUpdate.Add("isbn");
                    valuesForColumns.Add(isbn_.ToString());
                    hasChanges = true;
                }
            }

            if (nimi.Text != _bookName)
            {
                string name = FormManager.ValidateName(nimi.Text, "kirjan nimi", nimi);

                if (name != "")
                {
                    columsToUpdate.Add("nimi");
                    valuesForColumns.Add(name);
                    hasChanges = true;
                }
            }
            if (genre.Text != genreDB)
            {
                string genre_ = FormManager.ValidateName(genre.Text, "genre", genre);

                if (genre_ != "")
                { 
                    columsToUpdate.Add("genre");
                    valuesForColumns.Add(genre_);
                    hasChanges = true;                    
                }
            }
            if (julkaistu.Text != publishedDB.ToString())
            {
                int published = FormManager.ValidateNumber(julkaistu.Text, "julkaisuvuosi");

                if (published != -1)
                {
                    columsToUpdate.Add("julkaistu");
                    valuesForColumns.Add(published.ToString());
                    hasChanges = true;
                }
            }
            if (kustantaja.Text != publisherDB)
            {
                string publisher = FormManager.ValidateName(kustantaja.Text, "kustantaja", kustantaja);

                if (publisher != "")
                {
                    columsToUpdate.Add("kustantaja");
                    valuesForColumns.Add(publisher);
                    hasChanges = true;    
                }
            }
            if (sivumaara.Text != pagesDB.ToString())
            {
                int pages = FormManager.ValidateNumber(sivumaara.Text, "sivumäärä");

                if (pages != -1)
                {
                    columsToUpdate.Add("sivut");
                    valuesForColumns.Add(pages.ToString());
                    hasChanges = true;
                }
            }
            if (kuvaus.Text != Description && kuvaus.Text != "")
            {
                if (kuvaus.Text.Length > 65335)
                {
                    columsToUpdate.Add("kuvaus");
                    valuesForColumns.Add(kuvaus.Text);
                    hasChanges = true;
                }
                else
                {
                    MessageBox.Show("Kuvaus on liian pitkä. Se saa olla suurimmillaan 65 535 merkkiä pitkä");
                }
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
            if (!isStaff)
            {
                return;
            }

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

                    if (col == "kuvaus")
                    {
                        if (!UpdateBookDesc(descFileName, value))
                        {
                            return false;
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

        private bool UpdateBookDesc(string fileName, string text)
        {
            string descPath = Path.GetFullPath(Path.Combine(rootPath, "BookDescriptions", fileName));

            try
            {
                File.WriteAllText(descPath, text);
                Console.WriteLine("Tiedoston päivitys onnistui");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Virhe päivittäessä kirjan kuvaus tiedostoa: {e.Message}");
                return false;
            }
        }

        private bool AddBookToDatabase(string isbn, string bookName, string authorName, string genre, int pages, int published, string publisher, string descName, string imageName)
        {
            string authID = FindAuthorID(authorName);

            if (authID == "")
            {
                MessageBox.Show("Kirjailijaa ei löytynyt");
                return false;
            }
            try
            {
                db.OpenConnection();

                string addBookQuery = $"INSERT INTO kirja (isbn, kirtu, nimi, genre, julkaistu, kustantaja, sivut, img, kuvaus) VALUES (@isbn, @kirtu, @nimi, @genre, @julkaistu, @kustantaja, @sivut, @img, @kuvaus)";

                using MySqlCommand command = new(addBookQuery, db.connection);
                command.Parameters.AddWithValue("@isbn", isbn);
                command.Parameters.AddWithValue("@kirtu", authID);
                command.Parameters.AddWithValue("@nimi", bookName);
                command.Parameters.AddWithValue("@genre", genre);
                command.Parameters.AddWithValue("@julkaistu", published);
                command.Parameters.AddWithValue("@kustantaja", publisher);
                command.Parameters.AddWithValue("@sivut", pages);
                command.Parameters.AddWithValue("@img", imageName);
                command.Parameters.AddWithValue("@kuvaus", descName);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Tietokantavirhe: {ex.Message}");
                return false;
            }
            finally
            {
                db.CloseConnection();
            }

            return true;
        }
    
        private string FindAuthorID (string authorName)
        {
            string enimi = authorName.Split(' ')[0];
            string snimi = authorName.Split(' ')[1];

            string authorID = "";

            try
            {
                db.OpenConnection();

                string queryAuthorID = $"SELECT kirtunnus FROM kirjailija WHERE enimi = \"{enimi}\" AND snimi = \"{snimi}\"";

                using MySqlCommand command = new(queryAuthorID, db.connection);
                using MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    authorID = reader["kirtunnus"] as string;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Virhe ladatessa kirjailijan tunnusta: " + ex.Message);
                return "";
            }
            finally
            {
                db.CloseConnection();
            }

            return authorID;
        }

        private void LoadAuthors()
        {
            try
            {
                db.OpenConnection();

                string queryAuthors = "SELECT enimi, snimi FROM kirjailija";

                using MySqlCommand command = new(queryAuthors, db.connection);
                using MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string enimi = reader["enimi"] as string;
                    string snimi = reader["snimi"] as string;

                    string kirjailija = enimi + " " + snimi;

                    kirjailijaCB.Items.Add(kirjailija);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Virhe ladatessa kirjailijoita: " + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }

            kirjailijaCB.Items.Add("Lisää uusi kirjailija");

            FormManager.AdjustComboBoxWidth(kirjailijaCB);

            int index = kirjailijaCB.FindString(authorDB);

            if (index != -1)
            {
                kirjailijaCB.SelectedIndex = index;
            }
            else
            {
                kirjailijaCB.Text = "kirjailija";
            }
        }
    }
}

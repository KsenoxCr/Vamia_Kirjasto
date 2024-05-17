using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Timer = System.Windows.Forms.Timer;

namespace Kirjasto_ohjelma
{
    public static class FormManager
    {
        private static readonly DatabaseAccess db = DatabaseAccess.GetInstance();

        private static readonly string asnum = User.Asnum;
        private static readonly bool isStaff = User.IsStaff;
        private static string currentLainanum = "";
        private static string rivinum = "";

        private static int startX;
        private static int endX;
        private static int animSpeed = 10;
        private static bool isAnimating;

        public static void FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        public static void AddMouseEnterAndLeave(Label[] labels)
        {
            // Lisätään animaatio hiiren ollessa labelien päällä

            foreach (System.Windows.Forms.Label label in labels)
            {
                float fontSize = label.Font.SizeInPoints;

                label.MouseEnter += (sender, e) => label.Font = new Font("Impact", fontSize + 2);
                label.MouseLeave += (sender, e) => label.Font = new Font("Impact", fontSize);
            }
        }

        public static void OpenLogin(Form callerForm)
        {
            // Avataan isäänkirjautumisikkuna

            Login login = Login.Instance;
            login.Show();

            callerForm.Hide();
        }

        public static void OpenConfirmMessage(string msgType, string bookName = "", string ktun = "", List<string> edits = null)
        {
            // Avataan viesti-ikkuna

            ConfirmMessage msg = new(msgType, bookName, ktun, edits);
            msg.ShowDialog();
        }

        public static void OpenContact(string type)
        {
            // Avataan yhteydenottolomake

            ContactUs contactUs = new(type);
            contactUs.ShowDialog();
        }

        public static void OpenBookInfo(string bookName = "")
        {
            // Avataan kirjan tietoikkuna

            BookInfo bookInfo = new(bookName);
            bookInfo.ShowDialog();
        }

        public static void OpenChangeValue(string action, string valueType, AccountDetails accDetails = null)
        {
            // Avataan vaihtoikkuna

            ChangeValue changeValue = new(action, valueType, accDetails);
            changeValue.ShowDialog();
        }

        public static void OpenUserList(Form callerForm)
        {
            // Avataan käyttäjälista

            UserList userList = UserList.GetInstance();
            userList.Show();

            callerForm.Hide();
        }

        public static bool CreateNewLoan(string kirjanNimi)
        {
            // Luodaan uusi lainaus

            string tunnus = "";

            try
            {
                db.OpenConnection();

                // Pyydetään käyttäjää viimeistelemään profiilinsa ennen lainausta

                if (!CheckUserDetails())
                {
                    ConfirmMessage confirmMessage = new("viimeistele");
                    confirmMessage.Show();

                    return false;
                }
                else
                {
                    tunnus = FindLoanableBook(kirjanNimi);

                    if (tunnus != "")
                    {
                        string astun = isStaff ? "TTXXXXX" : asnum;

                        string tyonum = isStaff ? asnum : "TTXXXX";

                        // Luodaan uusi lainaus jos käyttäjälle ei ole vielä luotu lainausta session aikana

                        if (string.IsNullOrEmpty(currentLainanum))
                        {
                            string newLainanum = CreateLainanum();

                            string insertLainausQuery = $"INSERT INTO lainaus (lainanum, astun, tyonum) VALUES ({newLainanum}, \"{astun}\", \"{tyonum}\")";

                            ExecuteQuery(insertLainausQuery);

                            currentLainanum = newLainanum;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Virhe lainauksessa. Yritä myöhemmin uudelleen.");
                MessageBox.Show("Tietokantavirhe: " + ex.Message);

                return false;
            }
            finally
            {
                db.CloseConnection();
            }

            // Lisätään lainarivi lainatulle kirjalle

            CreateNewLainarivi(kirjanNimi, tunnus);

            return true;
        }

        public static bool CheckUserDetails()
        {
            // Tarkistetaan käyttäjän tiedot ennen lainausta

            if (db.connection.State == ConnectionState.Open)
            {
                try
                {
                    string details = isStaff ? "ptp" : "loso, pno, ptp";
                    string userType = isStaff ? "henkilokunta" : "asiakas";
                    string astun = isStaff ? "tyonum" : "asnum";

                    string query = $"SELECT {details}, puh FROM {userType} WHERE {astun} = \"{asnum}\"";

                    using MySqlCommand command = new(query, db.connection);
                    using MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        if (isStaff)
                        {
                            string ptp = reader.GetString(0);
                            return !string.IsNullOrEmpty(ptp) && ptp != "NotSpecified";
                        }
                        else
                        {
                            string loso = reader.GetString(0);
                            string pno = reader.GetString(1);
                            string ptp = reader.GetString(2);
                            return !string.IsNullOrEmpty(loso) || loso != "NotSpecified"
                                   && !string.IsNullOrEmpty(pno) || pno != "00000"
                                   && !string.IsNullOrEmpty(ptp) || ptp != "NotSpecified";
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Tietokantavirhe: {ex.Message}");
                }
            } else
            {
                MessageBox.Show("Tietokantavirhe: Yhteys ei ole auki");
            }

            return false;
        }

        public static string CreateLainanum()
        {
            // Etsitään vanha lainanumero

            string lainanum = FindLastLainanum();

            
            string newLoanCount = "";

            string currentYear = DateTime.Now.ToString("yy");

            string currentMonth = DateTime.Now.ToString("MM");

            // Luodaan uusi lainanumero vanhan perusteella

            if (lainanum != "")
            {
                int loanCount = int.Parse(lainanum[^3..]);

                if (loanCount < 999)
                {
                    string lastLainanumYear = lainanum[..2];

                    if (currentYear == lastLainanumYear) 
                    {
                        string lastLainanumMonth = lainanum.Substring(2, 2);

                        if(currentMonth == lastLainanumMonth)
                        {
                            newLoanCount = (loanCount + 1).ToString("D3");
                        }
                        else if(int.Parse(currentMonth) > int.Parse(lastLainanumMonth))
                        {
                            newLoanCount = "001";
                        }
                    }
                    else if (int.Parse(currentYear) > int.Parse(lastLainanumYear))
                    {
                        newLoanCount = "001";
                    }
                }
                else
                {
                    MessageBox.Show("Tietokantavirhe: Kuukauden lainamäärä on ylittynyt");
                }
            }
            else
            {
                MessageBox.Show("Tietokantavirhe: Yhtäkään aikaisempaa lainausta ei löytynyt"); //Jos käyttäjällä ei ole aikaisempia lainauksia, Etsi tietokannasta viimeisin lainaus (ei käyttäjä specifi) ja tee uusi lainaus sen perusteella

                newLoanCount = "001";
            }
            
            return currentYear + currentMonth + newLoanCount;
        }    

        public static void CreateNewLainarivi(string bookName, string id)
        {
            // Luodaan uusi lainarivi

            try
            {
                db.OpenConnection();

                CreateRivinum();

                if (rivinum != "" && currentLainanum != "" && id != "")
                {
                    // lisätään uusi lainarivi tietokantaan

                    string queryInsertLainarivi = $"INSERT INTO lainarivi (rivinum, ltunnus, kohdetun) VALUES (\"{rivinum}\", \"{currentLainanum}\", \"{id}\")";

                    ExecuteQuery(queryInsertLainarivi);

                    // Päivitetään lainakohdeen tila lainatuksi

                    string updateLainakohdeQuery = $"UPDATE lainakohde SET tila = 'lainattu' WHERE tunnus = \"{id}\"";

                    ExecuteQuery(updateLainakohdeQuery);

                    OpenConfirmMessage("lainaus", bookName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lainausta tehdessä tapahtui virhe. Yritä myöhemmin uudelleen");
                MessageBox.Show($"Tietokantavirhe: {ex.Message}"); //Dont show to user
            }
            finally
            {
                db.CloseConnection();
            }
        }

        public static string FindLoanableBook(string bookName)
        {
            string id = "";

            // Haetaan valitun kirjan lainattavissa oleva lainakohde tietokannasta

            string querySelectLainakohde = $"SELECT lainakohde.tunnus FROM Lainakohde INNER JOIN Kirja ON Lainakohde.ktun = Kirja.isbn WHERE Kirja.nimi = \"{bookName}\" AND Lainakohde.tila = 'lainattavissa' LIMIT 1";

            using (MySqlCommand command = new(querySelectLainakohde, db.connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        id = reader.GetString(0);
                    }
                    else
                    {
                        FormManager.OpenConfirmMessage("joLainassa");
                    }
                }
            }

            return id;
        }

        public static void ExecuteQuery(string query)
        {
            try
            {
                if (db.connection.State == ConnectionState.Closed)
                {
                    db.OpenConnection();
                }

                using MySqlCommand command = new(query, db.connection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Tietokantavirhe: {ex.Message}");
            }
        }

        public static void CreateRivinum()
        {
            // Luodaan uusi rivinumero uudelle lainariville

            if (rivinum != currentLainanum + "01")
            {
                // Jos aikaisempaa rivinumeroa lainaukselle ei ole vielä luotu, luodaan se nykyisen lainanumeron perusteella

                rivinum = currentLainanum + "01";
            }
            else
            {
                // Jos nykyisellä lainauksella on rivinumero, luodaan uusi vanhan perusteella

                string lainanumPart = rivinum[0..7];
                string rivinumPart = (int.Parse(rivinum[7..9]) + 1).ToString("D2");

                rivinum = lainanumPart + rivinumPart;
            }
        }

        public static string FindLastLainanum()
        {
            // Etsitään viimeisin lainanumero

            string lastLainanum = "";

            string userNumType = isStaff ? "tyonum" : "astun";
            
            string queryLainanum = $"SELECT lainanum FROM lainaus ORDER BY lainanum DESC LIMIT 1;";

            try
            {
                db.OpenConnection();

                using MySqlCommand command = new(queryLainanum, db.connection);
                using MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    lastLainanum = reader.GetString(0);
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

            return lastLainanum;
        }

        public static void ToggleMenu(Panel menu, Timer timer)
        {
            menu.BringToFront();
            timer.Interval = 25;
            // Avataan tai suljetaan valikko jos animaatio ei ole käynnissä

            if (!isAnimating)
            {
                if (menu.Tag.ToString() == "Closed")
                {
                    menu.Tag = "Open";

                    startX = menu.Location.X;

                    if (menu.Location.X == -menu.Width)
                    {
                        endX = 0;
                    }
                    else
                    {
                        endX = -menu.Width;
                    }
                    isAnimating = true;
                    timer.Start();
                }
                else
                {
                    menu.Tag = "Closed";

                    startX = menu.Location.X;

                    if (menu.Location.X == 0)
                    {
                        endX = -menu.Width;
                    }
                    else
                    {
                        endX = 0;
                    }
                    isAnimating = true;
                    timer.Start();
                }
            }
        }
         
        public static void timerTick(Timer timer, Panel panelToMove)
        {
            // Valikon animaatio


            // Lasketaan välimatka ja liikutetaan paneelia

            int deltaX = (endX - startX) / (timer.Interval / animSpeed);
            panelToMove.Location = new Point(panelToMove.Location.X + deltaX, panelToMove.Location.Y);

            // Varmistetaan tarkka lopetuspaikka ja pysäytetään ajastin

            if (Math.Abs(panelToMove.Location.X - endX) <= animSpeed) 
            {
                timer.Stop();
                panelToMove.Location = new Point(endX, panelToMove.Location.Y); 
                isAnimating = false;
            }
        }

        public static void ToHome(Form callerForm)
        {
            // Avataan aloitussivu

            Home home = new();
            home.Show();

            callerForm.Hide();
        }

        public static void OpenAccountDetails(string asnum)
        {
            // Avataan käyttäjän tietosivu

            AccountDetails accountDetails = new(asnum);
            accountDetails.Show();

            foreach (Form form in Application.OpenForms)
            {

                if (form.Name != accountDetails.Name)
                {
                    form.Hide();
                }
            }
        }

        public static void SetDoubleBuffered(System.Windows.Forms.Control c)
        {
            // Lisätään doublebuffering kontrollille vähentääksemme välkkymistä

            if (System.Windows.Forms.SystemInformation.TerminalServerSession)
            {
                return;
            }

            System.Reflection.PropertyInfo aProp =
                  typeof(System.Windows.Forms.Control).GetProperty(
                        "DoubleBuffered",
                        System.Reflection.BindingFlags.NonPublic |
                        System.Reflection.BindingFlags.Instance);

            aProp.SetValue(c, true, null);
        }

        public static string ValidateName(string input, string nameType, TextBox inputTB)
        {
            // Tarkistetaan onko nimi sopiva tietokantaan

            string error = "";

            if (inputTB.ForeColor == Color.Gray)
            {
                error = GetErrorMessage(nameType, "tyhjä");
            }
            else
            {
                switch (input)
                {
                    case null: 
                    case "":
                        error = GetErrorMessage(nameType, "tyhjä");
                        break;
                    case string s when s.Length < GetMinimumLength(nameType):
                        error = GetErrorMessage(nameType, "liian lyhyt");
                        break;
                    case string s when s.Length > GetMaximumLength(nameType):
                        error = GetErrorMessage(nameType, "liian pitkä");
                        break;
                    case string s when s.Contains(' ') && nameType != "kirjan nimi" && nameType != "kustantaja" && nameType != "kustantaja" && nameType != "loso":
                        error = GetErrorMessage(nameType, "ei saa sisältää välilyöntejä");
                        break;
                    case string s when !Regex.IsMatch(s, GetRegex(nameType)):
                        error = GetErrorMessage(nameType, "virheellinen");
                        break;
                }
            }


            if (error != "")
            {
                MessageBox.Show(error);
                return "";
            }

            // Tarkista onko kirjan nimi/kayttajatunnus/kirjailija jo tietokannassa

            if ((nameType == "Kirjan nimi" && ValueExistsInDB(input, nameType))
                || (nameType == "käyttäjätunnus" && ValueExistsInDB(input, nameType))
                || (nameType == "kirjailija" && ValueExistsInDB(input, nameType)))
            {
                MessageBox.Show($"{nameType} on jo olemassa");

                return "";
            }

            // Tarkistetaan kirjailijan nimen muoto (Etunimi Sukunimi)

            if (nameType == "kirjailija" && input.Split(' ').Length != 2)
            {
                MessageBox.Show(GetErrorMessage(nameType, " on virheellisessä muodossa"));
                
                return "";
            }

            return input;
        }

        private static string GetErrorMessage(string nameType, string errorType)
        {
            // Luodaan virheilmoitus nimen tarkistuksen tuloksen perusteella

            string errorMessage = nameType switch
            {
                "isbn" => "ISBN on " + errorType,
                "kayttajatunnus" or "käyttäjätunnus" => "Käyttäjätunnus on " + errorType,
                "etunimi" => "Etunimi on " + errorType,
                "sukunimi" => "Sukunimi on " + errorType,
                "kirjan nimi" => "Kirjan nimi on " + errorType,
                "kirjailija" => "Kirjailijan nimi on " + errorType,
                "genre" => "Genre on " + errorType,
                "kustantaja" => "Kustantaja on " + errorType,
                "puh" => "Puhelinnumero on " + errorType,
                "loso" => "Lähiosoite on " + errorType,
                "pno" => "Postinumero on " + errorType,
                "ptp" => "Postitoimipaikka on " + errorType,
                _ => "Nimi on " + errorType,
            };

            if (errorType == "liian lyhyt")
            {
                errorMessage += $".\r\nNimen tulee olla vähintään {GetMinimumLength(nameType)} kirjainta.";
            }
            else if (errorType == "liian pitkä")
            {
                errorMessage += $".\r\nNimen tulee olla enintään {GetMaximumLength(nameType)} kirjainta.";
            }
            else if (errorType == "virheellinen")
            {
                switch (nameType)
                {
                    case "käyttäjätunnus":
                    case "kirjan nimi":
                    case "genre":
                    case "kustantaja":
                        errorMessage += $"\r\n{nameType} voi sisältää ainoastaan\r\nkirjaimia, numeroita ja välilyöntejä"; 
                        break;
                    case "etunimi":
                    case "sukunimi":
                        errorMessage += $"\r\n{nameType} voi sisältää ainoastaan\r\nkirjaimia sekä yhden välilyönnin";
                        break;
                    case "kirjailija":
                        errorMessage += $"\r\n{nameType} voi sisältää ainoastaan\r\nkirjaimia, välilyöntejä ja väliviivoja";
                        break;
                    default:
                        errorMessage += $"\r\n{nameType} voi sisältää ainoastaan\r\nkirjaimia, numeroita, välilyöntejä ja väliviivoja";
                        break;
                }
            }

            return errorMessage;
        }

        private static int GetMinimumLength(string nameType)
        {
            // Palauttaa nimen minimipituuden

            switch (nameType)
            {
                case "sivumäärä":
                case "julkaisuvuosi":
                case "syntymävuosi":
                case "kuolinvuosi":
                    return 1;
                case "etunimi":
                case "sukunimi":
                case "enimi":
                case "snimi":   
                case "Kirjan nimi":
                case "ptp":
                    return 2;
                case "Genre":
                case "kustantaja":
                    return 3;
                case "kirjailija":
                case "loso":
                case "pno":
                case "käyttäjätunnus":
                case "kayttajatunnus":
                    return 5;
                case "puh":
                    return 8;
                case "isbn":
                    return 13;
                default:
                    return 0;
            }
        }

        private static int GetMaximumLength(string nameType)
        {
            // Palauttaa nimen maksimipituuden

            switch (nameType)
            {
                case "pno":
                    return 5;
                case "isbn":
                    return 13;
                case "etunimi":
                case "enimi":
                    return 15;
                case "käyttäjätunnus":
                case "kayttajatunnus":
                case "puh":
                    return 20;
                case "sukunimi":
                case "snimi":
                case "genre":
                case "ptp":
                    return 30;
                case "loso":
                    return 45;
                case "kirjailija":
                    return 46;
                case "kirjan nimi":
                    return 55;
                case "sivumäärä":
                    return 10000;
                case "julkaisuvuosi":
                case "syntymävuosi":
                case "kuolinvuosi":
                    return DateTime.Now.Year;
                case "kustantaja":
                    return 30;
                default:
                    return 0;
            }
        }

        private static string GetRegex(string nameType)
        {
            // Palauttaa nimen sallitut merkit

            switch (nameType)
            {
                case "isbn":
                case "puh":
                    return "^[0-9]+$"; // numeroita
                case "käyttäjätunnus":
                    return "^[\\p{L}0-9\\-_ ]+$"; // kirjaimia, numeroita, välilyöntejä, väli- sekä alaviivoja
                case "kirjan nimi":
                case "genre":
                case "kustantaja":
                    return "^[\\p{L}0-9 ]+$"; // kirjaimia, numeroita ja välilyöntejä
                case "etunimi":
                case "sukunimi":
                case "ptp":
                    return "^[\\p{L}-]+$"; // kirjaimia ja yksi väliviiva
                case "kirjailija":
                    return "^[\\p{L} -.]+$"; // kirjaimia, välilyöntejä ja väliviivoja
                case "loso":
                default:
                    return "^[\\p{L}0-9 -]+$"; // kirjaimia, numeroita, välilyöntejä ja väliviivoja
            }
        }

        public static string ValidatePassword(string password)
        {
            // Tarkistetaan on salasana turvallinen sekä sopiva tietokantaan

            switch (password)
            {
                case null:
                case "":
                case "salasana":
                    MessageBox.Show("Salasana on tyhjä");
                    return "";
                case string s when s.Contains(' '):
                    MessageBox.Show("Salasana ei saa sisältää välilyöntejä");
                    return "";
                case string s when s.Length < 8:
                    MessageBox.Show("Salasana on liian lyhyt.\r\nSalasanan tulee olla vähintään 8 merkkiä pitkä.");
                    return "";
                case string s when s.Length > 30:
                    MessageBox.Show("Salasana on liian pitkä.\r\nSalasanan tulee olla enintään 30 merkkiä pitkä.");
                    return "";
                case string s when !s.Any(c => c == '!' || c == '?') && !s.Any(char.IsSymbol):
                    MessageBox.Show("Salasana on liian heikko.\r\nSalasanan tulee sisältää vähintään yksi erikoismerkki");
                    return "";
                default:
                    return password;
            }
        }

        public static string ValidateAuthor(string input)
        {
            if (input == "kirjailija" || input == "")
            {
                MessageBox.Show("Valitse kirjailija");
                return "";
            }

            return input;
        }

        public static int ValidateNumber(string input, string fieldName)
        {
            if (input == "13 numeroa" || input == "Sivumäärä" || input == "Julkaisuvuosi" || input == "syntymävuosi" || input == "kuolinvuosi")
            {
                MessageBox.Show($"{fieldName} on tyhjä");
                return -1;
            }

            int min = GetMinimumLength(fieldName);
            int max = GetMaximumLength(fieldName);

            int value = 0;

            try
            {
                if (!int.TryParse(input, out value))
                {
                    MessageBox.Show($"{fieldName} on virheellinen.\r\n{fieldName} voi sisältää vain numeroita");
                    return -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }

            if (value < min)
            {
                MessageBox.Show($"{fieldName} on liian pieni.\r\n{fieldName} voi olla {min}-{max}.");
                return -1;
            }

            if (value > max)
            {
                MessageBox.Show($"{fieldName} on liian suuri.\r\n{fieldName} voi olla {min}-{max}.");
                return -1;
            }

            return value;
        }

        public static bool ValueExistsInDB(string value, string table)
        {
            string query = "";

            switch (table)
            {
                case "käyttäjätunnus":
                    query = $"SELECT asnum FROM asiakas WHERE kayttajatunnus = \"{value}\"";
                    break;
                case "kirjan nimi":
                    query = $"SELECT isbn FROM kirja WHERE name = \"{value}\"";
                    break;
                case "isbn":
                    query = $"SELECT isbn FROM kirja WHERE isbn = \"{value}\"";
                    break;
                case "kirjailija":
                    string enimi = value.Split(' ')[0];
                    string snimi = value.Split(' ')[1];

                    query = $"SELECT kirtunnus FROM kirjailija WHERE enimi = \"{enimi}\" AND snimi = \"{snimi}\"";
                    break;
            }

            try
            {
                db.OpenConnection();

                using MySqlCommand command = new(query, db.connection);
                using MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Tietokantavirhe: {ex.Message}");
                return true;
            }
            finally
            {
                db.CloseConnection();
            }

            return false;
        }

        public static string CreateBookDescription(string bookName)
        {
            // Luodaan uusi tekstitiedosto kirjan kuvaukselle ja tallennetaan se kansioon

            string fileName = "";
            string root = Directory.GetCurrentDirectory();
            string filePath = Path.GetFullPath(Path.Combine(root, @"BookDescriptions", bookName.Trim() + ".txt"));

            File.Create(filePath).Close();

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
            else
            {
                MessageBox.Show($"Virhe luodessa kuvausta: {bookName}.txt on jo olemassa");
            }

            // Tallennetaan kuvaksen tiedoston nimi tietokantaan 

            fileName = Path.GetFileName(filePath) + ".txt";

            string queryUpdateDesc = $"UPDATE kirja SET kuvaus = \"{fileName}\" WHERE nimi = \"{bookName}\"";

            ExecuteQuery(queryUpdateDesc);

            db.CloseConnection();

            return fileName;
        }

        public static void ShowPartOrFullText(Label label, int maxLength, string textToShow, ToolTip toolTip)
        {
            if (textToShow.Length > maxLength)
            {
                label.Text = string.Concat(textToShow.AsSpan(0, maxLength - 3), "...");
                toolTip.SetToolTip(label, textToShow);
            }
            else
            {
                label.Text = textToShow;
            }
        }

        public static void AdjustComboBoxWidth(ComboBox comboBox)
        {
            // Etsitään pisimmän arvon pituus ja asetetaan ComboBoxin leveys sen mukaan

            string longestValue = "";

            Font font = comboBox.Font;

            foreach (object item in comboBox.Items)
            {
                string value = item.ToString();

                if (value.Length > longestValue.Length)
                {
                    longestValue = value;
                }
            }

            Size stringSize = TextRenderer.MeasureText(longestValue, font);

            comboBox.Width = stringSize.Width + 10;
        }

        public static void AddPlaceholder(TextBox textBox, string placeholder)
        {
            bool isPassword = placeholder == "salasana";

            if (isPassword)
            {
                textBox.PasswordChar = '\0';
            }

            // Lisätään tekstikenttään placeholder
            if (textBox.Text == "")
            {
                textBox.Text = placeholder;
                textBox.ForeColor = Color.Gray;
            }

            textBox.GotFocus += (sender, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    if (isPassword)
                    {
                        textBox.PasswordChar = '*';
                    }

                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            };

            textBox.LostFocus += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    if (isPassword)
                    {
                        textBox.PasswordChar = '\0';
                    }

                    textBox.Text = placeholder;
                    textBox.ForeColor = Color.Gray;
                }
            };
        }

        private static string BuildStringArrayArray(List<string[]> stringArrays, int level = 0)
        {
            // Testityökalu - rakentaa merkkijonon Listan taulukon hierarkiasta

            string hierarchy = "";
            foreach (var stringArray in stringArrays)
            {
                hierarchy += $"{new string(' ', level * 2)}- String Array:\n";
                foreach (var str in stringArray)
                {
                    hierarchy += $"{new string(' ', (level + 1) * 2)}- {str}\n";
                }
            }
            return hierarchy;
        }

        private static string BuildListHierarchy(List<List<string[]>> data, int level = 0)
        {
            // Testityökalu - rakentaa merkkijonon Listan listan taulukon hierarkiasta

            string hierarchy = "";
            foreach (var innerList in data)
            {
                hierarchy += $"{new string(' ', level * 2)}- List:\n";
                hierarchy += BuildStringArrayArray(innerList, level + 1);
            }
            return hierarchy;
        }

        public static Color GetRandomColor()
        {
            // Testityökalu - palauttaa satunnaisen värin (helpottaa esim. controllien erottamista toisistaan)

            Random random = new();
            int red = random.Next(0, 256);
            int green = random.Next(0, 256);
            int blue = random.Next(0, 256);
            int alpha = 255;

            return Color.FromArgb(alpha, red, green, blue);
        }
    }
}

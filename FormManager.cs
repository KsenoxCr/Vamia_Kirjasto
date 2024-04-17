using MySql.Data.MySqlClient;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;
using Timer = System.Windows.Forms.Timer;

namespace Kirjasto_ohjelma
{
    public static class FormManager
    {
        private static readonly DatabaseAccess db = DatabaseAccess.GetInstance();

        private static readonly string asnum = User.Asnum;
        private static readonly bool isStaff = User.IsStaff;
        private static readonly string lainanum = FindLastLainanum();
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
            foreach (System.Windows.Forms.Label label in labels)
            {
                float fontSize = label.Font.SizeInPoints;

                label.MouseEnter += (sender, e) => label.Font = new Font("Impact", fontSize + 2);
                label.MouseLeave += (sender, e) => label.Font = new Font("Impact", fontSize);
            }
        }

        public static void OpenLogin(Form callerForm)
        {
            Login login = Login.Instance;
            login.Show();

            callerForm.Hide();
        }

        public static void OpenConfirmMessage(string msgType, string bookName = "", string ktun = "", List<string> edits = null)
        {
            if (msgType == "poistettu" || msgType == "lainaus" || msgType == "poistettu" || msgType == "määritys" || msgType == "vaihto")
            {
                ConfirmMessage msg = new(msgType, bookName);
                msg.Show();
            } 
            else if (msgType == "poisto") 
            {
                ConfirmMessage msg = new(msgType, bookName, ktun);
                msg.Show();
            }
            else if (msgType == "muokkaus")
            {
                ConfirmMessage msg = new(msgType, bookName, ktun, edits);
                msg.Show();
            }
            else 
            {
                ConfirmMessage msg = new(msgType);
                msg.Show();
            }
        }

        public static void OpenContact(string type)
        {
            ContactUs contactUs = new(type);
            contactUs.Show();
        }

        public static void OpenBookInfo(string bookName)
        {
            BookInfo bookInfo = new(bookName);
            bookInfo.Show();
        }

        public static void OpenUserList(Form callerForm)
        {
            UserList userList = UserList.GetInstance();
            userList.Show();

            callerForm.Hide();
        }

        public static bool CreateNewLoan(string kirjanNimi)
        {
            try
            {
                db.OpenConnection();

                //Tarkistetaan onko käyttäjän profiili viimeistelty

                if (!CheckUserDetails())
                {
                    ConfirmMessage confirmMessage = new("viimeistele");
                    confirmMessage.Show();

                    return false;
                }
                else
                {
                    string astun = isStaff ? "XXXXXXX" : asnum;

                    string tyonum = isStaff ? asnum : "XXXXXX";

                    // Luodaan uusi lainaus jos käyttäjälle ei ole vielä luotu lainausta session aikana

                    if (string.IsNullOrEmpty(currentLainanum))
                    {

                        currentLainanum = CreateLainanum();

                        string insertLainausQuery = $"INSERT INTO lainaus (lainanum, astun, tyonum) VALUES ({currentLainanum}, \"{astun}\", \"{tyonum}\")";

                        using MySqlCommand insertLainausCommand = new(insertLainausQuery, db.connection);

                        insertLainausCommand.ExecuteNonQuery();
                    }

                    // Lisätään lainarivi lainatulle kirjalle

                    CreateNewLainarivi(kirjanNimi);

                    return true;
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
        }

        public static bool CheckUserDetails()
        {
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
                            return !string.IsNullOrEmpty(loso) && loso != "NotSpecified"
                                   && !string.IsNullOrEmpty(pno) && pno != "00000"
                                   && !string.IsNullOrEmpty(ptp) && ptp != "NotSpecified";
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
            //Luodaan uusi lainanumero

            string newLoanCount = "";

            string currentYear = DateTime.Now.ToString("yy");

            string currentMonth = DateTime.Now.ToString("MM");

            if (!string.IsNullOrEmpty(lainanum))
            {
                int loanCount = int.Parse(lainanum.Substring(lainanum.Length - 3)); //check debug

                if (loanCount < 999)
                {
                    string lastLainanumYear = lainanum.Substring(0, 2);

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

        public static void CreateRivinum()
        {
            // Luodaan uusi rivinumero uudelle lainariville
            if (rivinum != currentLainanum + "01")
            {
                rivinum = currentLainanum + "01";
            }
            else
            {
                string lainanumPart = rivinum[0..7];
                string rivinumPart = (int.Parse(rivinum[7..9]) + 1).ToString("D2");

                rivinum = lainanumPart + rivinumPart;
            }
        }

        public static bool CreateNewLainarivi(string bookName)
        {
            try
            {
                string tunnus = "";

                string querySelectLainakohde = $"SELECT lainakohde.tunnus FROM Lainakohde INNER JOIN Kirja ON Lainakohde.ktun = Kirja.isbn WHERE Kirja.nimi = \"{bookName}\" AND Lainakohde.tila = 'lainattavissa' LIMIT 1";

                using (MySqlCommand command = new(querySelectLainakohde, db.connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tunnus = reader.GetString(0);

                            OpenConfirmMessage("lainaus", bookName);
                        }
                        else
                        {
                            FormManager.OpenConfirmMessage("joLainassa");

                            return false;
                        }
                    }
                }

                CreateRivinum();

                if (rivinum != "" && currentLainanum != "" && tunnus != "")
                {
                    string queryInsertLainarivi = $"INSERT INTO lainarivi (rivinum, ltunnus, kohdetun) VALUES (\"{rivinum}\", \"{currentLainanum}\", \"{tunnus}\")"; //lainanum can now be wrong users if two users make a new loan at the same time

                    using MySqlCommand insertLainariviCommand = new(queryInsertLainarivi, db.connection);
                    insertLainariviCommand.ExecuteNonQuery();

                    string updateLainakohdeQuery = $"UPDATE lainakohde SET tila = 'lainattu' WHERE tunnus = \"{tunnus}\"";

                    using MySqlCommand updateLainakohdeCommand = new(updateLainakohdeQuery, db.connection);
                    updateLainakohdeCommand.ExecuteNonQuery();

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lainausta tehdessä tapahtui virhe. Yritä myöhemmin uudelleen");
                MessageBox.Show($"Tietokantavirhe: {ex.Message}"); //Dont show to user
            }

            return false;
        }

        public static string FindLastLainanum()
        {
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
            Home home = Home.Instance;
            home.Show();

            callerForm.Hide();
        }

        public static void OpenAccountDetails(string username, string userType)
        {
            AccountDetails accountDetails= new AccountDetails(username, userType);
            accountDetails.Show();

            foreach (Form form in Application.OpenForms)
            {

                if (form.Name != accountDetails.Name)
                {
                    form.Hide();
                }
            }
        }

        public static string ValidateUsername(string username)
        {
            switch (username)
            {
                case null:
                case "":
                    MessageBox.Show("Käyttäjätunnus on on tyhjä");
                    return "";
                case string s when s.Contains(' '):
                    MessageBox.Show("Käyttäjätunnus ei saa sisältää välilyöntejä");
                    return "";
                case string s when s.Length < 5:
                    MessageBox.Show("Käyttäjätunnus on liian lyhyt.\r\nKäyttäjätunnuksen tulee olla 5-20 merkkiä pitkä.");
                    return "";
                case string s when s.Length > 20:
                    MessageBox.Show("Käyttäjätunnus on liian pitkä.\r\nKäyttäjätunnuksen tulee olla 5-20 merkkiä pitkä.");
                    return "";
                case string s when !Regex.IsMatch(s, "^[a-zA-Z0-9_]+$"):
                    MessageBox.Show("Käyttäjätunnus on virheellinen.\r\nKäyttäjätunnus saa sisältää vain kirjaimia, numeroita ja alaviivoja.");
                    return "";
            }
            return username;
        }

        public static string ValidatePassword(string password)
        {
            switch (password)
            {
                case null:
                case "":
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

        public static string ValidateName(string name, string nameType)
        {
            string err;

            switch (name)
            {
                case string s when s.Length < 2:
                    err = nameType == "etunimi" ? "Etunimi on liian lyhyt. \r\nEtunimen tulee olla vähintään 2 kirjainta" :
                                                                    "Sukunimi on liian lyhyt. \r\nSukunimen tulee olla vähintään 2 kirjainta";
                    MessageBox.Show(err);
                    return "";
                case string s when nameType == "etunimi" && s.Length > 15:
                    MessageBox.Show("Etunimi on liian pitkä. \r\nEtunimen tulee olla enintään 15 kirjainta");
                    return "";
                case string s when nameType == "sukunimi" && s.Length > 30:
                    MessageBox.Show("Sukunimi on liian pitkä. \r\nSukunimen tulee olla enintään 30 kirjainta");
                    return "";
                case string s when s.Contains(' '):
                    err = nameType == "etunimi" ? "Etunimi ei saa sisältää välilyöntejä" :
                                                                    "Sukunimi ei saa sisältää välilyöntejä";
                    MessageBox.Show(err);
                    return "";
                case string s when !Regex.IsMatch(s, "^[a-zA-Z-]+$"):
                    err = nameType == "etunimi" ? "Virheellinen etunimi. \r\nNimi voi sisältää vain kirjaimia sekä yhden väliviivan." :
                                                                    "Virheellinen sukunimi. \r\nNimi voi sisältää vain kirjaimia sekä yhden väliviivan.";
                    MessageBox.Show(err);
                    return "";
                default:
                    return name;
            }
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

            try
            {
                db.OpenConnection();

                fileName = Path.GetFileName(filePath) + ".txt";

                string queryUpdateDesc = $"UPDATE kirja SET kuvaus = \"{fileName}\" WHERE nimi = \"{bookName}\"";

                using MySqlCommand updateDescCommand = new(queryUpdateDesc, db.connection);

                updateDescCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Tietokantavirhe: {ex.Message}");
            }
            finally
            {
                db.CloseConnection();
            }
            return fileName;
        }
    }
}

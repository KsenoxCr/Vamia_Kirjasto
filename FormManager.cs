using MySql.Data.MySqlClient;
using System.ComponentModel;
using System.Data;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Kirjasto_ohjelma
{
    public static class FormManager
    {
        private static DatabaseAccess db = DatabaseAccess.GetInstance();

        private static int lainausCount = 0;

        private static string lainanum = findLastLainanum();

        private static string currentLainanum = "";

        public static void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        public static void AddMouseEnterAndLeave(Label[] labels)
        {
            foreach (System.Windows.Forms.Label label in labels)
            {
                label.MouseEnter += (sender, e) => label.Font = new Font("Impact", 14F, FontStyle.Regular, GraphicsUnit.Point);
                label.MouseLeave += (sender, e) => label.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point);
            }
        }

        public static void controlClicked(object sender, EventArgs e, Control control)
        {
            string name = "";

            name = "";

            foreach (Control c in control.Parent.Controls)
            {
                if (c is Label label && label.Name.StartsWith("nimi"))
                {
                    name = label.Text;
                }
            }

            if ((control is PictureBox picbox && picbox.Name.StartsWith("kirja")) || (control is Button && (control.Text == "Katso")))
            {
                openBookInfo(name);
            }
            else if (control is Button btn)
            {
                if (!string.IsNullOrEmpty(name))
                {
                    if (btn.Text == "Lainaa")
                    {
                        CreateNewLoan(name);
                    }
                    else if (btn.Text == "Poista")
                    {
                        OkMessage("varmistus", name);
                    }
                }
            }
        }
        public static void OkMessage(string msgType, string bookName = "")
        {
            if (msgType == "varmistus" || msgType == "lainaus" || msgType == "poisto")
            {
                ConfirmMessage OkMessage = new ConfirmMessage(msgType, bookName);
                OkMessage.Show();
            } else
            {
                ConfirmMessage OkMessage = new ConfirmMessage(msgType);
                OkMessage.Show();
            }
        }

        private static void openBookInfo(string bookName)
        {
            BookInfo bookInfo = new BookInfo(bookName);
            bookInfo.Show();
        }

        public static bool CreateNewLoan(string kirjanNimi)
        {
            try
            {
                db.OpenConnection();

                //Check if user has defined their posting address
                if (!checkUserDetails())
                {
                    ConfirmMessage confirmMessage = new ConfirmMessage("viimeistele");
                    confirmMessage.Show();

                    return false;
                } 
                else
                {
                    string newLainanum = "";

                    bool isStaff = User.IsStaff;
                    string astun = isStaff ? "XXXXXXX" : User.Asnum;

                    string tyonum = isStaff ? User.Asnum : "XXXXXX";

                    if (string.IsNullOrEmpty(currentLainanum))
                    {

                        currentLainanum = createLainanum();

                        string insertLainausQuery = $"INSERT INTO lainaus (lainanum, astun, tyonum) VALUES ({currentLainanum}, \"{astun}\", \"{tyonum}\")";

                        using (MySqlCommand insertLainausCommand = new MySqlCommand(insertLainausQuery, db.connection))
                        {
                            insertLainausCommand.ExecuteNonQuery();
                        }
                    }

                    addLainarivi(kirjanNimi);

                    OkMessage("lainaus", kirjanNimi);

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                return false;
            }
            finally
            {
                db.CloseConnection();
            }
        }
        public static bool checkUserDetails()
        {
            string loso = "";
            string pno = "";
            string ptp = "";

            bool isStaff = User.IsStaff;

            if (db.connection.State == ConnectionState.Open)
            {
                try
                {
                    string details = isStaff ? "ptp" : "loso, pno, ptp";
                    string userType = isStaff ? "henkilokunta" : "asiakas";
                    string astun = isStaff ? "tyonum" : "asnum";

                    //Dictionary<bool, string> details = new Dictionary<bool, string>
                    //{
                    //    { true, "ptp" },
                    //    { false, "loso, pno, ptp" }
                    //};

                    string query = $"SELECT {details}, puh FROM {userType} WHERE {astun} = \"{User.Asnum}\"";

                    using (MySqlCommand command = new MySqlCommand(query, db.connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if (isStaff)
                                {
                                    ptp = reader.GetString(0);
                                    return !string.IsNullOrEmpty(ptp) && ptp != "NotSpecified";
                                }
                                else
                                {
                                    loso = reader.GetString(0);
                                    pno = reader.GetString(1);
                                    ptp = reader.GetString(2);
                                    return !string.IsNullOrEmpty(loso) && loso != "NotSpecified"
                                           && !string.IsNullOrEmpty(pno) && pno != "00000"
                                           && !string.IsNullOrEmpty(ptp) && ptp != "NotSpecified";
                                }
                            }
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
        public static string createLainanum()
        {
            string lastLainanum = lainanum;

            string newLoanCount = "";

            string currentYear = DateTime.Now.ToString("yy");

            string currentMonth = DateTime.Now.ToString("MM");

            if (!string.IsNullOrEmpty(lastLainanum))
            {
                int loanCount = int.Parse(lastLainanum.Substring(lastLainanum.Length - 3)); //check debug

                if (loanCount < 999)
                {
                    string lastLainanumYear = lastLainanum.Substring(0, 2);

                    if (currentYear == lastLainanumYear)
                    {
                        string lastLainanumMonth = lastLainanum.Substring(2, 2);

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
                MessageBox.Show("Tietokantavirhe: Yhtäkään aikaisempaa lainausta ei löytynyt");

                newLoanCount = "001";
            }
            
            return currentYear + currentMonth + newLoanCount;
        }    
        public static bool addLainarivi(string bookName)
        {
            string tunnus = "";

            if (db.connection.State == ConnectionState.Open)
            {
                try
                {
                    string query = $"SELECT lainakohde.tunnus FROM Lainakohde INNER JOIN Kirja ON Lainakohde.ktun = Kirja.isbn WHERE Kirja.nimi = \"{bookName}\" AND Lainakohde.tila = 'lainattavissa' LIMIT 1";

                    using (MySqlCommand command = new MySqlCommand(query, db.connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                tunnus = reader.GetString(0);
                            }
                            else
                            {
                                MessageBox.Show("Kirja on jo lainassa");

                                return false;
                            }
                        }
                    }

                    string insertLainariviQuery = $"INSERT INTO lainarivi (ltunnus, kohdetun) VALUES (\"{currentLainanum}\", \"{tunnus}\")"; //lainanum can now be wrong users if two users make a new loan at the same time

                    using (MySqlCommand insertLainariviCommand = new MySqlCommand(insertLainariviQuery, db.connection))
                    {
                        insertLainariviCommand.ExecuteNonQuery();
                    }

                    string updateLainakohdeQuery = $"UPDATE lainakohde SET tila = 'lainattu' WHERE tunnus = \"{tunnus}\"";

                    using (MySqlCommand updateLainakohdeCommand = new MySqlCommand(updateLainakohdeQuery, db.connection))
                    {
                        updateLainakohdeCommand.ExecuteNonQuery();

                        return true;
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

            return false;
        }
        public static string findLastLainanum()
        {
            string lastLainanum = "";

            if (db.connection.State != ConnectionState.Open)
            {
                string query = "SELECT lainanum FROM lainaus ORDER BY lainanum DESC LIMIT 1;";

                try
                {
                    db.OpenConnection();

                    using (MySqlCommand command = new MySqlCommand(query, db.connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lastLainanum = reader.GetString(0);
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

            return lastLainanum;
        }

        public static void toggleMenu(Panel menu)
        {

            if (menu.Tag == "Closed")
            {
                menu.Tag = "Open";

                menu.Location = new Point(0, 79);

            }
            else
            {
                menu.Tag = "Closed";

                menu.Location = new Point(-125, 79);
            }
        }
        public static void backToHome(Form form)
        {
            Home home = new Home();
            home.Show();

            form.Hide();
        }

        public static void openAccountDetails(string username, string userType)
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
        public static IEnumerable<Control> EnumerateControls(this Control control)
        {
            yield return control;

            foreach (Control childControl in control.Controls)
            {
                yield return childControl;

                foreach (Control descendant in childControl.EnumerateControls())
                {
                    yield return descendant;
                }
            }
        }
        public static string ValidateUsername(string username)
        {
            switch (username)
            {
                /*
                case null:
                case "":
                    MessageBox.Show("Käyttäjätunnus on on tyhjä");
                    return false; */
                case string s when s.Contains(" "):
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
            //MessageBox.Show("Test: käyttäjätunnus OK");
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
                case string s when s.Contains(" "):
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
            string err = "";

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
                case string s when s.Contains(" "):
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
    }
}

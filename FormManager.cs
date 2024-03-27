using MySql.Data.MySqlClient;
using System.ComponentModel;
using System.Data;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Kirjasto_ohjelma
{
    public static class FormManager
    {
        private static int lainausCount = 0;

        private static string lainanum = findLastLainanum();

        private static string currentLainanum = "";

        private static DatabaseAccess db = DatabaseAccess.GetInstance();

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
                        OkMessage("lainaus");

                    }
                    else if (btn.Text == "Poista")
                    {
                        OkMessage("varmistus", name);
                    }
                }
            }
        }
        private static void OkMessage(string msgType, string boookName = "")
        {
            if (msgType == "varmistus")
            {
                ConfirmMessage OkMessage = new ConfirmMessage(msgType, boookName);
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

        private static void CreateNewLoan(string kirjanNimi)
        {
            string newLainanum = "";

            bool isStaff = User.IsStaff;
            string astun = isStaff ? "XXXXXXX" : User.Asnum;

            string tyonum = isStaff ? User.Asnum : "XXXXXX"; 

            

            if (db.connection.State != ConnectionState.Open)
            {
                try
                {
                    db.OpenConnection();

                    if (lainausCount == 0)
                    {
                        newLainanum = createLainanum();
                       
                        string currentDate = DateTime.Now.ToString("yyyy-MM-dd");

                        string insertLainausQuery = $"INSERT INTO lainaus (lainanum, astun, tyonum, pvm) VALUES ({newLainanum}, {astun} , {tyonum}, {currentDate})";

                        using (MySqlCommand insertLainausCommand = new MySqlCommand(insertLainausQuery, db.connection))
                        {
                            insertLainausCommand.ExecuteNonQuery();
                        }

                        addLainarivi(kirjanNimi);
                    }
                    else  // loanCount is not 0
                    {
                        addLainarivi(kirjanNimi);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    db.CloseConnection();
                }

                currentLainanum = newLainanum;

                lainausCount++;

                AccountDetails accDetails = AccountDetails.Instance;

                Control lainauksetPanel = accDetails.Controls["lainauksetPanel"] as Control;
                Control footer = accDetails.Controls["footer"] as Control;

                lainauksetPanel.Controls.Remove(lainauksetPanel.Controls["eiLainauksia"]);

                Label kirjauduUlos = (Label)accDetails.Controls["Menu"].Controls["kirjaudu_ulos"];

                int loanCount = lainauksetPanel.Controls.Count;

                int x = 25;
                int y = loanCount * 100 + 25;

                if (loanCount > 0)
                {
                    lainauksetPanel.Height += 100;
                    footer.Location = new Point(0, footer.Location.Y + 125);
                    accDetails.Height += 50;
                    kirjauduUlos.Location = new Point(kirjauduUlos.Location.X, kirjauduUlos.Location.Y + 100);
                }

                GroupBox uusiLainaus = new GroupBox
                {
                    Size = new Size(441, 75),
                    Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point),
                    Location = new Point(x, y),
                    BackColor = Color.Beige,
                    Visible = true,
                    Name = "lainaus" + (loanCount + 1)
                };

                Label lainatunnus = new Label
                {
                    Text = "Kirjan isbn",
                    Location = new Point(15, 25)
                };

                Label lainatutKirjat = new Label();
                lainatutKirjat = new Label
                {
                    Text = "Kirjat (lista)",
                    Location = new Point((uusiLainaus.Width / 2) - (lainatutKirjat.Width / 2), 25)
                };

                Label pvm = new Label();
                pvm = new Label
                {
                    Text = "DD/MM/YYYY",
                    Location = new Point(uusiLainaus.Width - lainatunnus.Location.X - pvm.Width, lainatunnus.Location.Y)
                };

                uusiLainaus.Controls.Add(pvm);
                uusiLainaus.Controls.Add(lainatunnus);
                uusiLainaus.Controls.Add(lainatutKirjat);
                lainauksetPanel.Controls.Add(uusiLainaus);
            }
        }

        public static string createLainanum()
        {
            string lastLainanum = "";

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
        public static void addLainarivi(string bookName)
        {
            if (currentLainanum != "")
            {
                if (db.connection.State != ConnectionState.Open)
                {
                    string query = $"SELECT lainakohde.tunnus FROM Lainakohde INNER JOIN Kirja ON Lainakohde.ktun = Kirja.isbn WHERE Kirja.nimi = {bookName} AND Lainakohde.tila = 'lainattavissa' LIMIT 1";

                    try
                    {
                        db.OpenConnection();

                        using (MySqlCommand command = new MySqlCommand(query, db.connection))
                        {
                            using (MySqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    string tunnus = reader.GetString(0);

                                    string insertLainariviQuery = $"INSERT INTO lainarivi (lainanum, tunnus) VALUES ({lainanum}, {tunnus})"; //lainanum can now be wrong users if two users make a new loan at the same time

                                    using (MySqlCommand insertLainariviCommand = new MySqlCommand(insertLainariviQuery, db.connection))
                                    {
                                        insertLainariviCommand.ExecuteNonQuery();

                                        //Update Lainakohde tila
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Kirja on lainattu");
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
    }
}

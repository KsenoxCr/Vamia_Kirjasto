using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using System.Web;
using Mysqlx.Crud;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using K4os.Compression.LZ4.Streams;
using System.Security.Cryptography;
using Mysqlx.Session;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Reflection.Metadata.Ecma335;
using System.Diagnostics.Eventing.Reader;
using Google.Protobuf.WellKnownTypes;


namespace Kirjasto_ohjelma
{
    public partial class Register : Form
    {
        private DatabaseAccess db = DatabaseAccess.GetInstance();

        bool menuOpen = false;

        private static Register _instance = null;
        private static readonly object _lock = new object();

        const int keySize = 64;
        const int iterations = 350000;
        HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

        public Register()
        {
            InitializeComponent();

            this.FormClosing += FormManager.Form_FormClosing;

            FormManager.AddMouseEnterAndLeave(new System.Windows.Forms.Label[] { tuki, palautteet });

        }

        public static Register Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Register();
                    }
                    return _instance;
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FormManager.toggleMenu(Menu);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LogIn login = new LogIn();
            login.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = FormManager.ValidateUsername(kayttajatunnus.Text.ToLower());
            string firstname = FormManager.ValidateName(etunimi.Text.ToLower(), "etunimi");
            string surname = FormManager.ValidateName(sukunimi.Text.ToLower(), "sukunimi");
            string password = FormManager.ValidatePassword(salasana.Text);
            string passwordAgain = salasanaUudelleen.Text;

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(firstname) && !string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(username))
            {
                if (password != passwordAgain)
                {
                    MessageBox.Show("Salasanat eivät täsmää");
                }
                else
                {
                    string passwordHash = HashPasword(salasana.Text, out var salt);
                    string saltToHex = Convert.ToHexString(salt);

                    string asnum = CreateAsnum();

                    if (!string.IsNullOrEmpty(asnum))
                    {
                        string query = "INSERT INTO Asiakas (asnum, enimi, snimi, loso, pno, ptp, puh, kayttajatunnus, salasana, salt) " +
                "VALUES (@asnum, @enimi, @snimi, @loso, @pno, @ptp, @puh, @kayttajatunnus, @salasana, @salt)";


                        //MessageBox.Show($"Test: Query: {query}");

                        try
                        {
                            db.OpenConnection();

                            MySqlCommand command = new MySqlCommand(query, db.connection);

                            command.Parameters.AddWithValue("@asnum", asnum);
                            command.Parameters.AddWithValue("@enimi", FirstCharToUpper(firstname));
                            command.Parameters.AddWithValue("@snimi", FirstCharToUpper(surname));
                            command.Parameters.AddWithValue("@loso", "NotSpecified");
                            command.Parameters.AddWithValue("@pno", "00000");
                            command.Parameters.AddWithValue("@ptp", "NotSpecified");
                            command.Parameters.AddWithValue("@puh", "NotSpecified");
                            command.Parameters.AddWithValue("@kayttajatunnus", username);
                            command.Parameters.AddWithValue("@salasana", passwordHash);
                            command.Parameters.AddWithValue("@salt", saltToHex);

                            command.ExecuteNonQuery();

                            //MessageBox.Show("Test: Tili lisätty tietokantaan");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Tietokantavirhe: {ex.Message}");
                        }
                        finally
                        {
                            db.CloseConnection();

                            LogIn.Instance.Show();

                            ConfirmMessage poistoConfirmMSG = new ConfirmMessage("tunnusLuotu");
                            poistoConfirmMSG.Show();

                            this.Hide();
                        }
                    }
                }
            }
        }

        private string FirstCharToUpper(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return char.ToUpper(input[0]) + input.Substring(1).ToLower();
        }

        private void tuki_Click(object sender, EventArgs e)
        {
            FeedBackForm tukiForm = new FeedBackForm(tuki.Name);
            tukiForm.Show();
        }

        private void palautteet_Click(object sender, EventArgs e)
        {
            FeedBackForm palauteForm = new FeedBackForm(palautteet.Name);
            palauteForm.Show();
        }
        public string CreateAsnum()
        {
            //Finding last asnum from database

            string newAsnum = "";

            int customerNumber = 0;

            string newCustomerNumber = "";

            string lastAsnum = "";

            string lastAsnumYear = "";

            string currentYear = DateTime.Now.ToString("yy");

            if (db.connection.State != ConnectionState.Open)
            {
                string query = "SELECT asnum FROM Asiakas WHERE asnum <> \"XXXXXXX\" ORDER BY SUBSTRING(asnum, -2) DESC, CAST(SUBSTRING(asnum, 3) AS UNSIGNED) DESC LIMIT 1;";

                try
                {
                    db.OpenConnection();

                    using (MySqlCommand command = new MySqlCommand(query, db.connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lastAsnum = reader.GetString(0);
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

                if (!string.IsNullOrEmpty(lastAsnum))
                {
                    customerNumber = int.Parse(lastAsnum.Substring(2, 3));

                    lastAsnumYear = lastAsnum.Substring(5);

                    if (customerNumber < 999)
                    {
                        if (currentYear == lastAsnumYear)
                        {
                            newCustomerNumber = (customerNumber + 1).ToString("D3");
                        } 
                        else if (int.Parse(currentYear) > int.Parse(lastAsnumYear))
                        {
                            newCustomerNumber = "001";
                        }
                        

                        newAsnum = "AS" + newCustomerNumber + currentYear;
                    }
                    else
                    {
                        MessageBox.Show("Tietokantavirhe: Vuoden asiakas määrä on ylittynyt");
                    }
                } 
                else
                {
                    MessageBox.Show("Tietokantavirhe: Yhtäkään asnum ei löytynyt");

                    newAsnum = "AS001" + currentYear;
                }
            }

            //MessageBox.Show("Test: NewAsnum: "+newAsnum);

            return newAsnum;
        }

        string HashPasword(string password, out byte[] salt)
        {
            salt = RandomNumberGenerator.GetBytes(keySize);

            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                iterations,
                hashAlgorithm,
                keySize);

            return Convert.ToHexString(hash);
        }
    }
}

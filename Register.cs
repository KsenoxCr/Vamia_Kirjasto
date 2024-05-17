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
        private readonly DatabaseAccess db = DatabaseAccess.GetInstance();

        private static Register _instance = null;
        private static readonly object _lock = new();

        private const int keySize = 64;
        private const int iterations = 350000;
        private readonly HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

        public Register()
        {
            InitializeComponent();

            this.FormClosing += FormManager.FormClosing;

            FormManager.AddMouseEnterAndLeave(new System.Windows.Forms.Label[] { tuki, palautteet });
        }

        public static Register Instance
        {
            // Tehdään rekisteröitymissivusta singleton

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

        private void Register_Load(object sender, EventArgs e)
        {
            FormManager.AddPlaceholder(kayttajatunnus, "käyttäjätunnus");
            FormManager.AddPlaceholder(etunimi, "etunimi");
            FormManager.AddPlaceholder(sukunimi, "sukunimi");
            FormManager.AddPlaceholder(salasana, "salasana");
            FormManager.AddPlaceholder(salasanaUudelleen, "salasana uudelleen");
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            // Avataan tai suljetaan valikko

            FormManager.ToggleMenu(Menu, timerRegister);
        }

        private void TimerRegister_Tick(object sender, EventArgs e)
        {
            // Valikon animaation ajastin

            FormManager.timerTick(timerRegister, Menu);
        }

        private void Logo_Click(object sender, EventArgs e)
        {
            // Palataan kirjautumissivulle

            FormManager.OpenLogin(this);
        }

        private void LuoTunnusBtn_Click(object sender, EventArgs e)
        {
            // Luodaan uusi käyttäjä ja tallennetaan se tietokantaan

            string username = FormManager.ValidateName(kayttajatunnus.Text.ToLower(), "käyttäjätunnus", kayttajatunnus);
            string firstname = FormManager.ValidateName(etunimi.Text.ToLower(), "etunimi", etunimi);
            string surname = FormManager.ValidateName(sukunimi.Text.ToLower(), "sukunimi", sukunimi);
            string password = FormManager.ValidatePassword(salasana.Text);
            string passwordAgain = salasanaUudelleen.Text;

            if (username != "" && firstname != "" && surname != "" && password != "")
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

                    if (asnum != "")
                    {
                        string query = "INSERT INTO Asiakas (asnum, enimi, snimi, loso, pno, ptp, puh, kayttajatunnus, salasana, salt) " +
                "VALUES (@asnum, @enimi, @snimi, @loso, @pno, @ptp, @puh, @kayttajatunnus, @salasana, @salt)";

                        try
                        {
                            db.OpenConnection();

                            using MySqlCommand command = new(query, db.connection);

                            command.Parameters.AddWithValue("@asnum", asnum);
                            command.Parameters.AddWithValue("@enimi", FirstCharToUpper(firstname));
                            command.Parameters.AddWithValue("@snimi", FirstCharToUpper(surname));
                            command.Parameters.AddWithValue("@loso", "Ei Määritetty");
                            command.Parameters.AddWithValue("@pno", "00000");
                            command.Parameters.AddWithValue("@ptp", "Ei Määritetty");
                            command.Parameters.AddWithValue("@puh", "Ei Määritetty");
                            command.Parameters.AddWithValue("@kayttajatunnus", username);
                            command.Parameters.AddWithValue("@salasana", passwordHash);
                            command.Parameters.AddWithValue("@salt", saltToHex);

                            command.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Tietokantavirhe: {ex.Message}");
                        }
                        finally
                        {
                            db.CloseConnection();

                            FormManager.OpenLogin(this);
                            FormManager.OpenConfirmMessage("tunnusLuotu");
                        }
                    }
                }
            }
        }

        private static string FirstCharToUpper(string input)
        {
            // Ensimmäinen kirjain isoksi ja loput pieneksi

            return char.ToUpper(input[0]) + input.Substring(1).ToLower();
        }

        private void Tuki_Click(object sender, EventArgs e)
        {
            // Avataan tukisivu

            FormManager.OpenContact("tuki");
        }

        private void Palautteet_Click(object sender, EventArgs e)
        {
            // Avataan palautesivu

            FormManager.OpenContact("palaute");
        }

        public string CreateAsnum()
        {
            //Luodaan uusi asiakasnumero

            string lastAsnum = "";
            string newAsnum = "";

            string currentYear = DateTime.Now.ToString("yy");

            try
            {
                db.OpenConnection();

                string queryLastAsnum = "SELECT asnum FROM Asiakas WHERE asnum <> \"TTXXXXX\" ORDER BY SUBSTRING(asnum, -2) DESC, CAST(SUBSTRING(asnum, 3) AS UNSIGNED) DESC LIMIT 1;";

                using MySqlCommand command = new(queryLastAsnum, db.connection);
                using MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    lastAsnum = reader.GetString(0);
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
                int customerNumber = int.Parse(lastAsnum.Substring(2, 3));
                string newCustomerNumber = "";

                string lastAsnumYear = lastAsnum[5..];

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

                    return "";
                }
            }
            else
            {
                MessageBox.Show("Tietokantavirhe: Yhtäkään asnum ei löytynyt");

                newAsnum = "AS001" + currentYear;
            }

            return newAsnum;
        }

        private string HashPasword(string password, out byte[] salt)
        {
            // Hashataan salasana

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

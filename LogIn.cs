using Microsoft.VisualBasic.Devices;
using MySql.Data.MySqlClient;
using System.Data;
using System.Drawing.Design;
using System.Net;
using System.Security.Cryptography;

namespace Kirjasto_ohjelma
{
    public partial class Login : Form
    {
        private readonly DatabaseAccess db = DatabaseAccess.GetInstance();

        private static Login _instance = null;
        private static readonly object _lock = new object();

        HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

        public Login()
        {
            InitializeComponent();

            FormManager.AddMouseEnterAndLeave(new System.Windows.Forms.Label[] { tuki, palautteet });
        }

        public static Login Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Login();
                    }
                    return _instance;
                }
            }
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            FormManager.ToggleMenu(Menu);
        }

        private void Login_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(InputUsername.Text) && !string.IsNullOrEmpty(InputPassword.Text))
            {
                string[] loginCredentials = FindUser();

                if (loginCredentials.All(c => !string.IsNullOrEmpty(c)))
                {
                    string asnum = loginCredentials[0];
                    string hashedPassword = loginCredentials[1];
                    string saltHex = loginCredentials[2];

                    bool isStaff = loginCredentials[3] == "staff";

                    if (VerifyPassword(InputPassword.Text, hashedPassword, saltHex))
                    {
                        User.Username = InputUsername.Text;
                        User.Asnum = asnum;
                        User.IsStaff = isStaff;

                        FormManager.ToHome(this);
                    } 
                    else
                    {
                        MessageBox.Show("Virheellinen salasana");
                    }
                }

            }
            else
            {
                MessageBox.Show("Täytä molemmat kentät");
            }
        }
        private string[] FindUser()
        {
            string[] credentials = new string[4];

            InputUsername.Text.Trim().ToLower();

            //Etsitään käyttäjä (asiakas) ja sen tiedot tietokannasta

            try
            {
                db.OpenConnection();

                string asiakasQuery = $"SELECT asnum, salasana, salt FROM asiakas WHERE kayttajatunnus = @username";

                using MySqlCommand command = new(asiakasQuery, db.connection);

                command.Parameters.AddWithValue("@username", InputUsername.Text);

                using MySqlDataReader asiakasReader = command.ExecuteReader();

                if (asiakasReader.Read())
                {
                    credentials[0] = asiakasReader.GetString(0);
                    credentials[1] = asiakasReader.GetString(1);
                    credentials[2] = asiakasReader.GetString(2);

                    credentials[3] = "customer";
                }
                else //Etsitään käyttäjä (henkilökunta) ja sen tiedot tietokannasta
                {
                    asiakasReader.Close();

                    string henkilokuntaQuery = $"SELECT tyonum, salasana, salt FROM henkilokunta WHERE kayttajatunnus = @username";

                    using MySqlCommand henkilokuntaCommand = new(henkilokuntaQuery, db.connection);

                    henkilokuntaCommand.Parameters.AddWithValue("@username", InputUsername.Text);

                    using MySqlDataReader henkilokuntaReader = henkilokuntaCommand.ExecuteReader();

                    if (henkilokuntaReader.Read())
                    {
                        credentials[0] = henkilokuntaReader.GetString(0);
                        credentials[1] = henkilokuntaReader.GetString(1);
                        credentials[2] = henkilokuntaReader.GetString(2);

                        credentials[3] = "staff";
                    }
                    else
                    {
                        MessageBox.Show("Käyttäjätunnusta ei löydy");
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

            return credentials;
        }

        private void CreateAccount_Click(object sender, EventArgs e)
        {
            Register register = Register.Instance;
            register.Show();
            this.Hide();
        }

        private void Support_Click(object sender, EventArgs e)
        {
            FormManager.OpenContact("tuki");
        }

        private void Feedback_Click(object sender, EventArgs e)
        {
            FormManager.OpenContact("palaute");
        }
        private bool VerifyPassword(string password, string hashedPassword, string saltHex)
        {
            const int keySize = 64;
            const int iterations = 350000;

            if (hashedPassword.Length == keySize * 2 && saltHex.Length == keySize * 2)
            {
                // Convert salt from hexadecimal string to byte array
                byte[] salt = Enumerable.Range(0, saltHex.Length)   
                    .Where(x => x % 2 == 0)
                    .Select(x => Convert.ToByte(saltHex.Substring(x, 2), 16))
                    .ToArray();

                var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, hashAlgorithm, keySize);

                return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(hashedPassword));
            }
            else
            {
                // Compare the stored password with the parameter password
                if (password == hashedPassword)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
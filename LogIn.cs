using Microsoft.VisualBasic.Devices;
using MySql.Data.MySqlClient;
using System.Data;
using System.Security.Cryptography;

namespace Kirjasto_ohjelma
{
    public partial class LogIn : Form
    {
        private DatabaseAccess db = DatabaseAccess.GetInstance();

        //bool menuOpen = false;

        private static LogIn _instance = null;
        private static readonly object _lock = new object();

        const int keySize = 64;
        const int iterations = 350000;
        HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

        public LogIn()
        {
            InitializeComponent();

            FormManager.AddMouseEnterAndLeave(new System.Windows.Forms.Label[] { tuki, palautteet });
        }

        public static LogIn Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new LogIn();
                    }
                    return _instance;
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FormManager.toggleMenu(Menu);
        }

        private void kirjauduSisään_Click(object sender, EventArgs e)
        {
            string hashedPassword = "";
            string saltHex = "";

            bool isStaff = henkilokunta.Checked ? true : false;

            if (!string.IsNullOrEmpty(InputUsername.Text) && !string.IsNullOrEmpty(InputPassword.Text))
            {

                InputUsername.Text = InputUsername.Text.Trim().ToLower();

                string userType = isStaff ? "henkilokunta" : "asiakas";

                string query = $"SELECT salasana, salt FROM {userType} WHERE kayttajatunnus = @username";

                try
                {
                    db.OpenConnection();

                    using (MySqlCommand command = new MySqlCommand(query, db.connection))
                    {
                        // Use parameters for security
                        command.Parameters.AddWithValue("@username", InputUsername.Text);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                hashedPassword = reader.GetString(0);
                                saltHex = reader.GetString(1);
                            }
                            else
                            {
                                MessageBox.Show("Käyttäjätunnusta ei löydy");
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

                if (hashedPassword != "" && saltHex != "")
                {
                    if (VerifyPassword(userType, InputPassword.Text, hashedPassword, saltHex))
                    {
                        User.Username = InputUsername.Text;
                        User.IsStaff = isStaff;

                        Home userHome = new Home();
                        userHome.Show();

                        //MessageBox.Show(InputUsername.Text + " Kirjautui sisään");

                        this.Hide();
                    }
                }
            }
            else
            {
                MessageBox.Show("Täytä molemmat kentät");
            }
        }

        private void luoTunnusBtn_Click(object sender, EventArgs e)
        {
            Register register = Register.Instance;
            register.Show();
            this.Hide();
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
        private bool VerifyPassword(string userType, string password, string hashedPassword, string saltHex)
        {
           

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
                // Query database for the password
                string queryPassword = $"SELECT salasana FROM {userType} WHERE kayttajatunnus = @username";

                try
                {
                    db.OpenConnection();

                    using (MySqlCommand command = new MySqlCommand(queryPassword, db.connection))
                    {
                        // Use parameter for security
                        command.Parameters.AddWithValue("@username", InputUsername.Text);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string storedPassword = reader.GetString(0);

                                // Compare the stored password with the parameter password
                                if (password == storedPassword)
                                {
                                    return true;
                                }
                                else
                                {
                                    MessageBox.Show("Virheellinen salasana");

                                    return false;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Tietokantavirhe (2): {ex.Message}");
                }
                finally
                {
                    db.CloseConnection();
                }

                return false;
            }
        }
    }
}
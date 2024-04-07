using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Cms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kirjasto_ohjelma
{
    public partial class ChangeValue : Form
    {
        private DatabaseAccess db = DatabaseAccess.GetInstance();

        private string _action;
        private string _valueType;
        private bool isStaff = User.IsStaff;

        public ChangeValue(string action, string valueType)
        {
            InitializeComponent();

            this._valueType = valueType;
            this._action = action;

            //DESIGN {

            switch (_valueType)
            {
                case "enimi":
                    vaihdaLabel.Text = _action == "set" ? "Määritä etunimi" : "Vaihda etunimi";
                    uusiLabel.Text = "Uusi etunimi";
                    break;
                case "snimi":
                    vaihdaLabel.Text = _action == "set" ? "Määritä sukunimi" : "Vaihda sukunimi";
                    uusiLabel.Text = "Uusi sukunimi";
                    break;
                case "kayttajatunnus":
                    vaihdaLabel.Text = _action == "set" ? "Määritä käyttäjätunnus" : "Vaihda käyttäjätunnus";
                    uusiLabel.Text = "Uusi käyttäjätunnus";
                    break;
                case "salasana":
                    vaihdaLabel.Text = _action == "set" ? "Määritä salasana" : "Vaihda salasana";
                    uusiLabel.Text = "Uusi salasana";
                    vaihdaTB.PasswordChar = '*';
                    break;
                case "loso":
                    vaihdaLabel.Text = _action == "set" ? "Määritä lähiosoite" : "Vaihda lähiosoite";
                    uusiLabel.Text = "Uusi lähiosoite";
                    break;
                case "pno":
                    vaihdaLabel.Text = _action == "set" ? "Määritä postinumero" : "Vaihda postinumero";
                    uusiLabel.Text = "Uusi postinumero";
                    break;
                case "ptp":
                    vaihdaLabel.Text = _action == "set" ? "Määritä postitoimipaikka" : "Vaihda postitoimipaikka";
                    vaihdaLabel.Font = new Font("Impact", 10F);
                    uusiLabel.Text = "Uusi postitoimipaikka";
                    uusiLabel.Font = new Font("Impact", 8F);
                    break;
                case "puh":
                    vaihdaLabel.Text = _action == "set" ? "Määritä puhelinnumero" : "Vaihda puhelinnumero";
                    vaihdaLabel.Font = new Font("Impact", 12F);
                    uusiLabel.Text = "Uusi puhelinnumero";
                    uusiLabel.Font = new Font("Impact", 10F);
                    break;
            }

            //} DESIGN 

            int spacing = 10;

            // Set the location of vaihdaLabel
            vaihdaLabel.Location = new Point(
                (this.Width - vaihdaLabel.Width) / 2,
                20
            );

            // Set the location and size of uusiLabel and vaihdaTB
            uusiLabel.Location = new Point(
                (this.Width - uusiLabel.Width - vaihdaTB.Width - spacing) / 2,
                this.Height / 2 - uusiLabel.Height / 2
            );

            vaihdaTB.Location = new Point(
                uusiLabel.Width + spacing + (this.Width - uusiLabel.Width - vaihdaTB.Width - spacing) / 2,
                uusiLabel.Location.Y  
            );

            // Set the location of vaihdaBtn
            vaihdaBtn.Location = new Point(
                (this.Width - vaihdaBtn.Width) / 2,
                this.Height - vaihdaBtn.Height - 15
            );

        }

        private void vaihdaBtn_Click(object sender, EventArgs e)
        {
            string valueToChange = "";

            switch (_valueType)
            {
                case "enimi":
                    valueToChange = FormManager.ValidateName(vaihdaTB.Text, "etunimi");
                    break;
                case "snimi":
                    valueToChange = FormManager.ValidateName(vaihdaTB.Text, "sukunimi");
                    break;
                case "kayttajatunnus":
                    valueToChange = FormManager.ValidateUsername(vaihdaTB.Text);
                    break;
                case "salasana":
                    valueToChange = FormManager.ValidatePassword(vaihdaTB.Text);
                    break;
                case "loso":
                    valueToChange = ValidateLoso(vaihdaTB.Text);
                    break;
                case "pno":
                    valueToChange = ValidatePno(vaihdaTB.Text);
                    break;
                case "ptp":
                    valueToChange = ValidatePtp(vaihdaTB.Text);
                    break;
                case "puh":
                    valueToChange = ValidatePuh(vaihdaTB.Text);
                    break;
            }

            if (!string.IsNullOrEmpty(valueToChange))
            {
                try
                {
                    db.OpenConnection();

                    string userType = User.IsStaff ? "henkilokunta" : "asiakas";

                    string asnumType = User.IsStaff ? "tyonum" : "asnum";

                    string query = $"UPDATE {userType} SET {_valueType} = @value WHERE {asnumType} = @asnum";

                    using (MySqlCommand command = new MySqlCommand(query, db.connection))
                    {
                        command.Parameters.AddWithValue("@value", valueToChange);
                        command.Parameters.AddWithValue("@asnum", User.Asnum);

                        command.ExecuteNonQuery();
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
                string action = _action == "set" ? "määritys" : "vaihto";

                ConfirmMessage confirmMessage = new ConfirmMessage(action, _valueType);
                confirmMessage.Show();

                this.Close();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public string ValidateLoso(string loso)
        {
            if (loso.Length > 45)
            {
                MessageBox.Show("Lähiosoite on liian pitkä.\r\nLähiosoite voi olla maksimissaan 45 merkkiä pitkä");
                return "";
            }
            else if (loso.Any(c => !char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c)))
            {
                MessageBox.Show("Lähiosoite sisältää erikoismerkkejä. Sallitut merkit ovat kirjaimet, numerot ja välilyönnit.");
                return "";
            }

            return loso;
        }
        public string ValidatePno(string pno)
        {
            if (pno.Any(c => !char.IsDigit(c)))
            {
                MessageBox.Show("Postinumero saa sisältää vain numeroita");
                return "";
            }
            else if (pno.Length != 5)
            {
                MessageBox.Show("Postinumeron tulee olla tasan 5 numeroa pitkä");
                return "";
            }

            return pno;
        }
        public string ValidatePtp(string ptp)
        {
            if (ptp.Length > 30)
            {
                MessageBox.Show("Postitoimipaikka on liian pitkä.\r\nPostitoimipaikka voi olla maksimissaan 30 merkkiä pitkä");
                return "";
            }
            else if (ptp.Any(c => !char.IsLetter(c) && !char.IsWhiteSpace(c)))
            {
                MessageBox.Show("Postitoimipaikka sisältää erikoismerkkejä. Sallitut merkit ovat kirjaimet ja välilyönnit.");
                return "";
            }

            return ptp;
        }
        public string ValidatePuh(string puh)
        {
            if (puh.Any(c => !char.IsDigit(c)))
            {
                MessageBox.Show("Puhelinnumero saa sisältää vain numeroita");
                return "";
            }
            else if (puh.Length < 8)
            {
                MessageBox.Show("Puhelinnumero on liian lyhyt");
                return "";
            }

            return puh;
        }
    }
}

using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Cms;
using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.ComboBox;
using TextBox = System.Windows.Forms.TextBox;

namespace Kirjasto_ohjelma
{
    public partial class ChangeValue : Form
    {
        private readonly DatabaseAccess db = DatabaseAccess.GetInstance();

        private readonly string _action;
        private readonly string _valueType;
        private AccountDetails _accDetails;

        private string enimi = "";
        private string snimi = "";

        private readonly string[] countryCodes = { "CN", "IN", "US", "ID", "BR", "PK", "NG", "BD", "RU", "JP", "MX", "PH", "ET", "EG",
                                      "VN", "DE", "IR", "TR", "CD", "TH", "GB", "FR", "TZ", "ZA", "MM", "KE", "CO", "IT",
                                      "PL", "UA", "EG", "UZ", "SA", "IQ", "AF", "YE", "MZ", "MW", "NE", "VN", "MX", "NP",
                                      "TD", "GA", "MY", "MM", "BI", "GH", "EC", "RW", "LK", "SN", "ML", "YEM", "CA", "CG",
                                      "ZW", "MR", "CI", "BT", "BW", "KM", "SL", "FJ", "LA", "TG", "CF", "GQ", "MK", "ER",
                                      "GF", "GM", "GW", "KN", "MP", "MH", "LI", "TV", "VC", "WS", "ST", "SC", "KI", "NR",
                                      "CU", "TL", "PW", "FM", "NU", "TK", "TO", "CK", "NI", "PG", "AG", "SB", "DM", "LC",
                                      "MV", "GR", "KR", "BQ", "CW", "AW", "SX", "MF", "MQ", "BL", "PM", "JE", "GG", "IM" };


        public ChangeValue(string action, string valueType, AccountDetails accDetails = null)
        {
            InitializeComponent();

            this._valueType = valueType;
            this._action = action;
            this._accDetails = accDetails;

            Design();
        }

        private void Design()
        {
            // Ulkoasun määrittely

            string value = "";

            switch (_valueType)
            {
                case "enimi":
                    value = "etunimi";
                    break;
                case "snimi":
                    value = "sukunimi";
                    break;
                case "kayttajatunnus":
                    value = _valueType;
                    break;
                case "salasana":
                    value = _valueType;
                    break;
                case "loso":
                    value = "lähiosoite";
                    break;
                case "pno":
                    value = "postinumero";
                    break;
                case "ptp":
                    value = "postitoimipaikka";

                    vaihdaLabel.Font = new Font("Impact", 10F);
                    uusiLabel.Font = new Font("Impact", 8F);
                    break;
                case "puh":
                    value = "puhelinnumero";

                    vaihdaLabel.Font = new Font("Impact", 12F);
                    uusiLabel.Font = new Font("Impact", 10F);
                    break;
                case "kirjailija":
                    value = _valueType;
                    break;
            }

            DisplayLabels(value);

            int spacing = 10;

            vaihdaLabel.Location = new Point(
                (this.Width - vaihdaLabel.Width) / 2,
                20
            );

            uusiLabel.Location = new Point(
                (this.Width - uusiLabel.Width - vaihdaTB.Width - spacing) / 2,
                this.Height / 2 - uusiLabel.Height / 2
            );

            vaihdaTB.Location = new Point(
                uusiLabel.Width + spacing + (this.Width - uusiLabel.Width - vaihdaTB.Width - spacing) / 2,
                uusiLabel.Location.Y
            );

            vaihdaBtn.Location = new Point(
                (this.Width - vaihdaBtn.Width) / 2,
                this.Height - vaihdaBtn.Height - 15
            );
        }

        private void DisplayLabels(string value)
        {
            if ( value == "kirjailija")
            {
                vaihdaLabel.Text = _action == "set" ? "Lisää uusi kirjailija" : "Muokkaa kirjailijan tietoja";
                this.Height *= 2;

                uusiLabel.Visible = false;
                vaihdaTB.Visible = false;

                string[] cols = { "Etunimi", "Sukunimi", "Syntymävuosi" };

                int y = uusiLabel.Top;
                int margin = 10;

                //if (_action == "edit")
                //{
                //    LoadAuthorDetails(kirtu);
                //}

                for (int i = 0; i < cols.Length; i++)
                {
                    Label label = new()
                    {
                        Name = $"{cols[i]}Label",
                        Text = $"{cols[i]}:",
                        Font = new Font("Impact", 10F),
                        Location = new Point(20, y),                                                                             
                    };  

                    TextBox textBox = new()
                    {
                        Name = $"{cols[i]}TB",
                        Location = new Point(label.Right + margin, y),
                        Size = new Size(100, 20),
                    };

                    this.Controls.Add(label);
                    this.Controls.Add(textBox);

                    y = label.Bottom + margin;

                    string placeHolder = enimi != "" && snimi != "" ? (i == 0 ? enimi : snimi) : cols[i];

                    FormManager.AddPlaceholder(textBox, placeHolder);
                }

                Label Kansalaisuus = new()
                {
                    Name = "KansalaisuusLabel",
                    Text = "Kansalaisuus:",
                    Font = new Font("Impact", 10F),
                    Location = new Point(20, y),
                };

                ComboBox kansalaisuusCB = new()
                {
                    Name = "KansalaisuusCB",
                    Text = "Valitse kansalaisuus",
                    Location = new Point(Kansalaisuus.Right + margin, y),
                    Size = new Size(100, 20),
                };

                foreach (string code in countryCodes)
                {
                    kansalaisuusCB.Items.Add(code);
                }

                this.Controls.Add(Kansalaisuus);

                this.Height = Kansalaisuus.Bottom + vaihdaBtn.Height + (3 * margin);

                vaihdaBtn.Location = new Point(vaihdaBtn.Left, this.Bottom - margin);

                vaihdaBtn.Text = _action == "set" ? "Lisää kirjailija" : "Muokkaa kirjailijaa";
            }
            else
            {
                vaihdaLabel.Text = _action == "set" ? $"Määritä {value}" : $"Vaihda {value}";
                uusiLabel.Text = $"Uusi {value}";   

                FormManager.AddPlaceholder(vaihdaTB, value);
            }
        }

        public void LoadAuthorDetails(string authorID)
        {
            try
            {
                db.OpenConnection();

                string query = $"SELECT enimi, snimi FROM kirjailija WHERE kirtunnus = {authorID}";

                using MySqlCommand command = new(query, db.connection);
                using MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    enimi = reader.GetString(0);
                    snimi = reader.GetString(1);
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

        private void Change_Click(object sender, EventArgs e)
        {
            string valueToChange = "";

            if (_valueType == "kirjailija")
            {
                // Tarkistetaan, että kaikki arvot ovat sopivia

                Control etunimiTB = this.Controls.Find("EtunimiTB", true)[0];
                Control sukunimiTB = this.Controls.Find("SukunimiTB", true)[0];

                string enimi = FormManager.ValidateName(etunimiTB.Text, "etunimi", (TextBox)etunimiTB);
                string snimi = FormManager.ValidateName(sukunimiTB.Text, "sukunimi", (TextBox)sukunimiTB);
                int syntymavuosi = FormManager.ValidateNumber(this.Controls.Find("SyntymävuosiTB", true)[0].Text, "syntymävuosi");
                string kansalaisuus = this.Controls.Find("KansalaisuusCB", true)[0].Text;

                if (enimi != "" && snimi != "" && syntymavuosi != 0 && kansalaisuus != "Valitse kansalaisuus")
                {
                    // Luodaan uusi kirjailijan tunnus
                    string newKirtu = CreateKirtu(snimi, kansalaisuus, syntymavuosi);

                    // Lisätään kirjailijan tiedot tietokantaan
                    if (newKirtu != "")
                    {
                        if (AddAuthorToDatabase(newKirtu, enimi, snimi))
                        {
                            FormManager.OpenConfirmMessage("kirjailija", $"{enimi} {snimi}");
                        }
                    }
                }
            }
            else if (_valueType == "salasana")
            {
                valueToChange = FormManager.ValidatePassword(vaihdaTB.Text);
            }
            else
            {
                valueToChange = FormManager.ValidateName(vaihdaTB.Text, _valueType, vaihdaTB);
            }

            if (valueToChange == "")
            {
                vaihdaTB.Text = "";
            }
            else
            {
                if (UpdateSelectedDetail(valueToChange))
                {
                    _accDetails?.LoadAccountDetails(User.Asnum);

                    string actionType = _action == "set" ? "määritys" : "vaihto";

                    FormManager.OpenConfirmMessage(actionType, _valueType);

                    this.Close();
                }
            }
        }

        public bool UpdateSelectedDetail(string value)
        {
            try
            {
                db.OpenConnection();

                string userType = User.IsStaff ? "henkilokunta" : "asiakas";

                string userNum = User.IsStaff ? "tyonum" : "asnum";

                string query = $"UPDATE {userType} SET {_valueType} = @value WHERE {userNum} = @usernum";

                using MySqlCommand command = new(query, db.connection);
                command.Parameters.AddWithValue("@value", value);
                command.Parameters.AddWithValue("@usernum", User.Asnum);

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

        public bool AddAuthorToDatabase(string kirtu, string etunimi, string sukunimi)
        {
            try
            {
                db.OpenConnection();

                string query = "INSERT INTO kirjailija (kirtu, enimi, snimi) " +
                    "VALUES (@kirtu, @enimi, @snimi)";

                using MySqlCommand command = new(query, db.connection);

                command.Parameters.AddWithValue("@enimi", etunimi);
                command.Parameters.AddWithValue("@enimi", etunimi);
                command.Parameters.AddWithValue("@snimi", sukunimi);

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
        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public string CreateKirtu(string surname, string countryCode, int birthYear)
        {
            string kirtu = "KT" + countryCode;
            int count = 1;
            string century = RoundDownToNearest100(birthYear).ToString();

            string centuryCode = century switch
            {
                "1800" => "A",
                "1900" => "B",
                "2000" => "C",
                _ => "X"
            };

            string firstLetter = surname[..1];  

            kirtu += centuryCode + firstLetter;

            count += FindAuthorMatches(kirtu);

            kirtu += count.ToString("D2");

            return kirtu;
        }

        public static int RoundDownToNearest100(int number)
        {
            int divided = Math.DivRem(number, 100, out int remainder);
            return remainder > 0 ? divided * 100 : number;
        }

        public int FindAuthorMatches(string kirtu)
        {
            try
            {
                db.OpenConnection();

                string query = $"SELECT COUNT(*) FROM kirjailija WHERE kirtu LIKE '{kirtu}%'";

                using MySqlCommand command = new(query, db.connection);
                using MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return reader.GetInt32(0);
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

            return 0;
        }
    }
}

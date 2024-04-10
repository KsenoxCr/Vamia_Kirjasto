using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;

namespace Kirjasto_ohjelma
{
    public partial class ConfirmMessage : Form
    {
        private DatabaseAccess db = DatabaseAccess.GetInstance();

        private string? _type;
        private string? _value;
        private string? _ktun;

        public ConfirmMessage(string type)
        {
            InitializeComponent();

            this._type = type;
        }
        public ConfirmMessage(string type, string value)
        {
            InitializeComponent();

            this._type = type;
            this._value = value;
        }
        public ConfirmMessage(string type, string value, string ktun)
        {
            InitializeComponent();

            this._type = type;
            this._value = value;
            this._ktun = ktun;
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            switch (_type)
            {
                case "ehdotus":
                    label1.Text = "Kiitos ehdotuksesta!";
                    label2.Text = "Ilmoitamme teille sähköpostitse kun \r\nkirja on lisätty valikoimaamme";
                    break;
                case "lainaus":
                    label1.Text = "Lainaus onnistui";
                    label2.Text = _value + "\r\n on lainattu (lainausaika) saakka";
                    break;
                case "muokkaus":
                    label1.Text = "Muokkaus onnistui";
                    label2.Text = "Muokkaukset: \r\n(tähän lista muokatuista osioista)";
                    break;
                case "poistettu":
                    label1.Text = "Kirja poistettu";
                    label2.Text = _value + " on poistettu valikoimasta";
                    break;
                case "tuki":
                    label1.Text = "Kiitos yhteydenotostasi";
                    label2.Text = "Vastaamme sinulle sähköpostitse \r\nmahdollisimman pian";
                    break;
                case "palaute":
                    label1.Text = "Kiitos palautteesta";
                    label2.Text = "Mielipiteesi on tärkeä";
                    break;
                case "tunnusLuotu":
                    label1.Text = "Tili luotu";
                    label2.Text = "Voit nyt kirjautua sisään";
                    break;
                case "määritys":
                    label1.Text = "Määritys onnistui";
                    label2.Text = _value + " tallennettu";
                    break;
                case "vaihto":
                    label1.Text = "Vaihto onnistui";
                    label2.Text = _value + " tallennettu";
                    break;
                case "viimeistele":
                    label1.Text = "Lainaus epäonnistui";
                    label2.Text = "Viimeistele profiilisi ennen lainausta";
                    break;
                case "poisto":
                    label1.Text = "Oletko varma?";
                    label2.Text = "Haluatko varmasti \r\n poistaa kirjan:\r\n" + _value + " valikoimasta?";

                    this.Size = new Size(this.Width, this.Height + 50);

                    Button kylla = new()
                    {
                        Name = "Kylla",
                        Text = "kyllä",
                        BackColor = Color.Bisque,
                      
                        FlatStyle = FlatStyle.Flat,
                        //FlatAppearance.BorderColor = Color.Tan,
                        //MouseDownBackColor = Color.BurlyWood,
                        //MouseOverBackColor = Color.Tan,

                        Height = 45,
                        Width = 90,
                        Location = new Point(30, 135),
                        Font = new Font("Impact", 10F),
                    };

                    Button ei = new()
                    {
                        Name = "Ei",
                        Text = "En",
                        BackColor = Color.Red,

                        FlatStyle = FlatStyle.Flat,
                        //FlatAppearance.BorderColor = Color.Tan,
                        //MouseDownBackColor = Color.BurlyWood,
                        //MouseOverBackColor = Color.Tan,

                        Height = 45,
                        Width = 90,
                        Location = new Point(130, 135),
                        Font = new Font("Impact", 10F),
                    };

                    kylla.Click += button_Clicked;
                    ei.Click += button_Clicked;

                    this.Controls.Add(kylla);
                    this.Controls.Add(ei);
                    break;
                default:
                    label1.Text = "Pahoittelut!";
                    label2.Text = "jokin meni pieleen. \r\n Yritä myöhemmin uudelleen";
                    break;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void button_Clicked(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;

            if (clickedButton.Text == "Kyllä")
            {
                try
                {
                    db.OpenConnection();

                    string query = $"DELETE FROM kirja WHERE nimi = {_value}";

                    using MySqlCommand command = new(query, db.connection);

                    int rows = command.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        string newQuery = $"DELETE FROM lainakohde WHERE ktun = \"{_ktun}\"";

                        using MySqlCommand newCommand = new(newQuery, db.connection);

                        newCommand.ExecuteNonQuery();
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

                FormManager.openConfirmMessage("poisto", _value);

                this.Close();
            }
            else
            {
                this.Close();
            }
        }
    }
}

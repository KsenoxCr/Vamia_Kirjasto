using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Kirjasto_ohjelma
{
    public partial class ConfirmMessage : Form
    {
        private DatabaseAccess db = DatabaseAccess.GetInstance();

        private string? _type;
        private string? _value = "";

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
                case "poisto":
                    label1.Text = "Kirja poistettu";
                    label2.Text = _value + " on poistettu valikoimasta";
                    break;
                case "tukilähetys":
                    label1.Text = "Kiitos yhteydenotostasi";
                    label2.Text = "Vastaamme sinulle sähköpostitse \r\nmahdollisimman pian";
                    break;
                case "palautelähetys":
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
                case "varmistus":
                    label1.Text = "Oletko varma?";
                    label2.Text = "Haluatko varmasti \r\n poistaa kirjan:\r\n" + _value + " valikoimasta?";

                    this.MaximumSize = new Size(this.Width, this.Height + 50);
                    this.MinimumSize = new Size(this.Width, this.Height + 50);
                    basicButton kylla = new basicButton("Kyllä", "beige", 45, 90, 30, 135, 10F);
                    basicButton ei = new basicButton("En", "red", 45, 90, 130, 135, 10F);

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

        private void pictureBox2_Click(object sender, EventArgs e)
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

                    using (MySqlCommand command = new MySqlCommand(query, db.connection))
                    {
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

                ConfirmMessage poistoConfirmMSG = new ConfirmMessage("poisto");
                poistoConfirmMSG.Show();

                this.Close();

            }
            else 
            {
                this.Close();
            }
        }
    }
}

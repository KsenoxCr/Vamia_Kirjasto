using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kirjasto_ohjelma
{
    public partial class ContactUs : Form
    {
        private readonly DatabaseAccess db = DatabaseAccess.GetInstance();

        private string _contactType;

        public ContactUs(string contactType)
        {
            InitializeComponent();
            _contactType = contactType;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            // Määritellään otsikko ja napin nimi sen mukaan, onko kyseessä tukipyynnön vai palautteen lähettäminen

            if (_contactType == "tuki")
            {
                otsikko.Text = "Ota Yhteyttä";
                otsikko.Font = new Font("Impact", 14F);
                lahetaBtn.Name = "lähetäBtnTuki";
            }
            else if (_contactType == "palautteet")
            {
                otsikko.Text = "Anna palautetta";
                otsikko.Font = new Font("Impact", 16F);
                lahetaBtn.Name = "lähetäBtnPalautteet";
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            // Suljetaan yhteydenottoikkuna

            this.Close();
        }

        private void Send_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(aiheTB.Text) || string.IsNullOrEmpty(sisaltoTB.Text))
            {
                MessageBox.Show("Täytä molemmat kentät");
            }
            else
            {
                if (ValidateMessage(aiheTB.Text, sisaltoTB.Text))
                {
                    // Lähetetään tukipyyntö tai palaute

                    SendContactMessage(aiheTB.Text, sisaltoTB.Text, _contactType);
                }
            }
        }

        private static bool ValidateMessage(string topic, string content)
        {
            // Tarkistetaan että aihe ja sisältö ovat sopivan pituisia

            string error = "";

            if (topic.Length < 3 || topic.Length > 30)
            {
                error = "Aiheen pituus pitää olla 3-30 merkkiä";
            }

            if (content.Length < 15)
            {
                error = "Sisältö on liian lyhyt";
            }

            if (error != "")
            {
                MessageBox.Show(error);
                return false;
            }

            return true;
        }

        private void SendContactMessage(string topic, string content, string typeOfContact)
        {
            // Lähetetään tukipyynnön tai palautteen tiedot tietokantaan

            try
            {
                db.OpenConnection();

                string tableName = typeOfContact == "tuki" ? "tiketit" : "palautteet";
                    
                string query = $"INSERT INTO {tableName} (astun, aihe, sisalto) VALUES (@astun, @aihe, @sisalto)";

                using MySqlCommand command = new(query, db.connection);
                command.Parameters.AddWithValue("@astun", !string.IsNullOrEmpty(User.Asnum) ? User.Asnum : "XXXXXXX");
                command.Parameters.AddWithValue("@aihe", topic);
                command.Parameters.AddWithValue("@sisalto", content);

                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("tietokantavirhe:" + ex.Message);
                string type = _contactType == "tuki" ? "tukipyynnön" : "palautteen";
                MessageBox.Show("Virhe " + type + "lähetyksessä. Yritä myöhemmin uudelleen.");
            }
            finally
            {
                db.CloseConnection();
            }

            // Avataan ponnahdusikkuna, joka kertoo että viesti on lähetetty

            FormManager.OpenConfirmMessage(_contactType);

            this.Close();
        }
    }
}


using MySql.Data.MySqlClient;
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
    public partial class ContactUs : Form
    {
        private DatabaseAccess db = DatabaseAccess.GetInstance();

        private string _contactType;

        public ContactUs(string contactType)
        {
            InitializeComponent();
            _contactType = contactType;
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            if (_contactType == "tuki")
            {
                otsikko.Text = "Ota Yhteyttä";
                otsikko.Font = new Font("Impact", 14F, FontStyle.Regular, GraphicsUnit.Point);
                lahetaBtn.Name = "lähetäBtnTuki";
            }
            else if (_contactType == "palautteet")
            {
                otsikko.Text = "Anna palautetta";
                otsikko.Font = new Font("Impact", 16F, FontStyle.Regular, GraphicsUnit.Point);
                lahetaBtn.Name = "lähetäBtnPalautteet";
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (User.Asnum.StartsWith("AS")) //Might not be necessary as feedback form is not shown to staff
            {
                if(!string.IsNullOrEmpty(aiheTB.Text) && !string.IsNullOrEmpty(sisaltoTB.Text)) {

                    if (aiheTB.Text.Length > 30)
                    {
                        MessageBox.Show("Aihe on liian pitkä");
                    } 
                    else if (sisaltoTB.Text.Length > 250)
                    {
                        MessageBox.Show("Sisältö on liian pitkä");
                    }
                    else
                    {
                        try
                        {
                            db.OpenConnection();

                            string query = $"INSERT INTO Palautteet (astun, aihe, sisalto) VALUES (@astun, @aihe, @sisalto)";

                            using (MySqlCommand command = new MySqlCommand(query, db.connection))
                            {
                                command.Parameters.AddWithValue("@astun", User.Asnum);
                                command.Parameters.AddWithValue("@aihe", aiheTB.Text);
                                command.Parameters.AddWithValue("@sisalto", sisaltoTB.Text);

                                command.ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("tietokantavirhe:" + ex.Message);
                            string type = _contactType == "tuki" ? "tukipyynnön" : "palautteen";
                            MessageBox.Show("Virhe " + _contactType + "lähetyksessä. Yritä myöhemmin uudelleen.");
                        }
                        finally
                        {
                            db.CloseConnection();
                        }

                        ConfirmMessage lähetäOk = new ConfirmMessage(_contactType);
                        lähetäOk.Show();

                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Täytä molemmat kentät");
                }
            }   
            else
            {
                MessageBox.Show("Henkilökunta ei voi käyttää tätä toimintoa");
            }
        }
    }
}

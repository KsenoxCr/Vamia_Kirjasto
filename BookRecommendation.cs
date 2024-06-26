﻿using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kirjasto_ohjelma
{
    public partial class BookRecommendation : Form
    {
        private readonly DatabaseAccess db = DatabaseAccess.GetInstance();

        public BookRecommendation()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Suggest_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(ehdotusTB.Text))
            {
                MessageBox.Show("Ehdotus ei voi olla tyhjä");
            } 
            else if (ehdotusTB.Text.Length > 50)
            {
                MessageBox.Show("Ehdotus on liian pitkä");
            } 
            else
            {
                AddSuggestion();
            }
        }
        private void AddSuggestion()
        {
            try
            {
                db.OpenConnection();

                // Create possibility for staff to use this feature

                string query = $"INSERT INTO Ehdotukset (astun, ehdotus) VALUES (@astun, @ehdotus)";

                using MySqlCommand command = new MySqlCommand(query, db.connection);
                command.Parameters.AddWithValue("@astun", User.Asnum);
                command.Parameters.AddWithValue("@ehdotus", ehdotusTB.Text);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("tietokantavirhe:" + ex.Message);
                MessageBox.Show("Virhe ehdotuksen lähetyksessä. Yritä myöhemmin uudelleen.");
            }
            finally
            {
                db.CloseConnection();
            }

            ConfirmMessage ehdotusOk = new ConfirmMessage("ehdotus");
            ehdotusOk.Show();

            this.Close();
        }
    }
}

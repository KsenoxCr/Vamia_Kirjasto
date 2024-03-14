using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kirjasto_ohjelma
{
    public partial class UserHome : Form
    {
        bool menuOpen = false;

        public bool IsStaff { get; }

        public UserHome(bool isStaff)
        {
            InitializeComponent();

            this.IsStaff = isStaff;

            this.FormClosing += FormManager.Form_FormClosing;           

            FormManager.AddMouseEnterAndLeave(new System.Windows.Forms.Label[] { oma_tili, tuki, palautteet, ehdota_kirjaa, kirjauduUlos, asiakkaat });

            tuki.Visible = !IsStaff;
            palautteet.Visible = !IsStaff;
            ehdota_kirjaa.Visible = !IsStaff;

            asiakkaat.Visible = IsStaff;
            asiakkaat.Location = tuki.Location;

            foreach (Control control in groupBox1.Controls)
            {
                if (control is Panel kirjaPanel)
                {
                    foreach (Control innerControl in kirjaPanel.Controls)
                    {
                        if (innerControl is Button && innerControl.Name.StartsWith("lainaaBtn"))
                        {
                            innerControl.Text = IsStaff ? "Katso" : "Lainaa";
                        }
                    }
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            FormManager.toggleMenu(Menu);

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            ControlsAreClickable(sender, e, this, "kirja", "picturebox");
            ControlsAreClickable(sender, e, this, "lainaaBtn", "button");
        }

        private void kirjauduUlos_Click(object sender, EventArgs e)
        {
            LogIn login = new LogIn();
            login.Show();
            this.Hide();
        }

        private void ehdota_kirjaa_Click(object sender, EventArgs e)
        {
            BookRecommendation bookRecom = new BookRecommendation();
            bookRecom.Show();
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

        private void label3_Click(object sender, EventArgs e)
        {

            AccountDetails accDetails = AccountDetails.Instance;

            accDetails.Show();

            foreach (Form form in Application.OpenForms)
            {

                if (form.Name != accDetails.Name)
                {
                    form.Hide();
                }
            }
        }

        private void asiakkaat_Click(object sender, EventArgs e)
        {

        }

        public void ControlsAreClickable(object sender, EventArgs e, Control control, string controlName, string controlType)
        {
            List<Control> FindAllControls(Control control, string type)
            {
                List<Control> controls = new List<Control>();

                if (type.ToLower() == "button")
                {
                    controls.AddRange(control.Controls.OfType<System.Windows.Forms.Button>());
                }
                else if (type.ToLower() == "picturebox")
                {
                    controls.AddRange(control.Controls.OfType<System.Windows.Forms.PictureBox>());
                }

                foreach (Control childControl in control.Controls)
                {
                    controls.AddRange(FindAllControls(childControl, type));
                }

                return controls;
            }


            var allSpecifiedControls = FindAllControls(control, controlType);

            var clickableControls = allSpecifiedControls.Where(pb => pb.Name.StartsWith(controlName) && pb.Name.Length > controlName.Length);

            if (clickableControls.Any())
            {
                foreach (var clickableControl in clickableControls)
                {
                    clickableControl.Click += (sender, e) => FormManager.controlClicked(sender, e, clickableControl, this.IsStaff);
                }
            }
        }
    }
}

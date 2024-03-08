using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kirjasto_ohjelma
{
    public partial class UserHome : Form
    {
        bool menuOpen = false;

        private static UserHome _instance = null;
        private static readonly object _lock = new object();

        public string formType  { get; set; }

        public UserHome()
        {
            InitializeComponent();

            this.FormClosing += FormManager.Form_FormClosing;

            System.Windows.Forms.Label[] labels = { oma_tili, tuki, palautteet, ehdota_kirjaa, kirjauduUlos, };

            FormManager.AddMouseEnterAndLeave(labels);

            formType = "Main";
        }

        public static UserHome Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new UserHome();
                    }
                    return _instance;
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

                FormManager.toggleMenu(Menu);

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            FormManager.ControlsAreClickable(sender, e, this, "kirja", "picturebox");
            FormManager.ControlsAreClickable(sender, e, this, "lainaaBtn", "button");
        }

        private void kirjauduUlos_Click(object sender, EventArgs e)
        {
            LogIn login1 = new LogIn();
            login1.Show();
            this.Hide();
        }

        private void sijainti_Click(object sender, EventArgs e)
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
    }
}

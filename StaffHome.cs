using Microsoft.VisualBasic.Devices;
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
    public partial class StaffHome : Form
    {
        bool menuOpen = false;

        private static StaffHome _instance = null;
        private static readonly object _lock = new object();

        public StaffHome()
        {
            InitializeComponent();

            this.FormClosing += FormManager.Form_FormClosing;

            Label[] labels = { oma_tili, asiakkaat, kirjaudu_ulos };

            FormManager.AddMouseEnterAndLeave(labels);

        }

        public static StaffHome Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new StaffHome();
                    }
                    return _instance;
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FormManager.toggleMenu(Menu);
        }

        private void label28_Click(object sender, EventArgs e)
        {
            LogIn login = LogIn.Instance;
            login.Show();
            this.Hide();
        }

        private void Ehdota_kirjaa_Click(object sender, EventArgs e)
        {
            BookRecommendation bookRecom = new BookRecommendation();
            bookRecom.Show();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            FormManager.ControlsAreClickable(sender, e, this, "kirja", "picturebox");
            FormManager.ControlsAreClickable(sender, e, this, "lainaaBtn", "button");
            FormManager.ControlsAreClickable(sender, e, this, "poistaBtn", "button");
        }

        private void oma_tili_Click(object sender, EventArgs e)
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

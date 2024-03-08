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
    public partial class AccountDetails : Form
    {
        public bool menuOpen = false;

        private static AccountDetails _instance = null;
        private static readonly object _lock = new object();

        private AccountDetails()
        {
            InitializeComponent();

            this.FormClosing += FormManager.Form_FormClosing;

            Label[] labels = { kirjat, asiakkaat, kirjaudu_ulos };
            FormManager.AddMouseEnterAndLeave(labels);
        }

        public static AccountDetails Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new AccountDetails();
                    }
                    return _instance;
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (menuOpen == false)
            {
                menuOpen = true;

                Menu.Location = new Point(0, 79);

            }
            else
            {
                menuOpen = false;

                Menu.Location = new Point(-120, 79);
            }
        }

        private void label28_Click(object sender, EventArgs e)
        {
            LogIn login = new LogIn();
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

            if (LogIn.Instance.Height > 730)
            {
                AutoScroll = true;
            }
        }

        private void kirjat_Click(object sender, EventArgs e)
        {
            UserHome userHome = UserHome.Instance;
            userHome.Show();

            this.Hide();
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            FormManager.toggleMenu(Menu);
        }
    }
}

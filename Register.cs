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
    public partial class Register : Form
    {

        bool menuOpen = false;

        private static Register _instance = null;
        private static readonly object _lock = new object();

        public Register()
        {
            InitializeComponent();

            this.FormClosing += FormManager.Form_FormClosing;

            FormManager.AddMouseEnterAndLeave(new System.Windows.Forms.Label[] { tuki, palautteet });

        }

        public static Register Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Register();
                    }
                    return _instance;
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FormManager.toggleMenu(Menu);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LogIn login = new LogIn();
            login.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (username != null & email != null & password != null & passwordAgain != null)
            {
                UserHome userHome = new UserHome(false);
                userHome.Show();
                this.Hide();
            }
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
    }
}

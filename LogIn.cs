using Microsoft.VisualBasic.Devices;

namespace Kirjasto_ohjelma
{
    public partial class LogIn : Form
    {

        bool menuOpen = false;


        private static LogIn _instance = null;
        private static readonly object _lock = new object();

        public LogIn()
        {
            InitializeComponent();

            FormManager.AddMouseEnterAndLeave(new System.Windows.Forms.Label[] { tuki, palautteet });
        }

        public static LogIn Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new LogIn();
                    }
                    return _instance;
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FormManager.toggleMenu(Menu);
        }

        private void kirjauduSisään_Click(object sender, EventArgs e)
        {
            // Query database for username and password

            if (username != null & Password != null)
            {
                UserHome userHome = new UserHome(henkilokunta.Checked ? true : false);
                userHome.Show();
                
                this.Hide();
            }
        }

        private void luoTunnusBtn_Click(object sender, EventArgs e)
        {
            Register register1 = Register.Instance;
            register1.Show();
            this.Hide();
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
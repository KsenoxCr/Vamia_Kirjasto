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

            System.Windows.Forms.Label[] labels = { tuki, palautteet };

            FormManager.AddMouseEnterAndLeave(labels);

            /*
            kirjauduSis‰‰nBtn.MouseEnter += (sender, e) => FormManager.MouseEnterButton(sender, e, kirjauduSis‰‰nBtn);
            kirjauduSis‰‰nBtn.MouseLeave += (sender, e) => FormManager.MouseLeaveButton(sender, e, kirjauduSis‰‰nBtn);

            luoTunnusBtn.MouseEnter += (sender, e) => FormManager.MouseEnterButton(sender, e, luoTunnusBtn);
            luoTunnusBtn.MouseLeave += (sender, e) => FormManager.MouseLeaveButton(sender, e, luoTunnusBtn); */

            //string connectionString = 'SERVER="localhost; PORT=3306; DATABASE="kirjasto"; UID="root"; PASSWORD="AWPDl0re"';
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

        private void kirjauduSis‰‰n_Click(object sender, EventArgs e)
        {
            if (username != null & Password != null)
            {
                if (henkilokunta.Checked == true)
                {
                    StaffHome staffHome = StaffHome.Instance;
                    staffHome.Show();

                }
                else
                {
                    UserHome userHome = UserHome.Instance;
                    userHome.Show();
                }
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
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
    public partial class BookInfo : Form
    {
        public string UserType { get; set; }

        public BookInfo(string userType)
        {
            InitializeComponent();

            this.UserType = userType;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (UserType.ToLower() == "staff")
            {
                muokkaaBtn.Visible = true;
                poistaBtn.Visible = true;
            } 
            else if (UserType.ToLower() == "customer")
            {
                muokkaaBtn.Visible = false;
                poistaBtn.Visible = false;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConfirmMessage lainausConfirmMSG = new ConfirmMessage("lainaus");
            lainausConfirmMSG.Show();

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConfirmMessage muokkausConfirmMSG = new ConfirmMessage("muokkaus");
            muokkausConfirmMSG.Show();

            this.Close();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            ConfirmMessage varmistusConfirmMSG = new ConfirmMessage("varmistus");
            varmistusConfirmMSG.Show();

            this.Close();
        }
    }
}

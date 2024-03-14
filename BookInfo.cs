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

            muokkaaBtn.Visible = UserType.ToLower() == "staff";
            poistaBtn.Visible = UserType.ToLower() == "staff";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConfirmMessage lainausOk = new ConfirmMessage("lainaus");
            lainausOk.Show();

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConfirmMessage muokkausOk = new ConfirmMessage("muokkaus");
            muokkausOk.Show();

            this.Close();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            ConfirmMessage varmistus = new ConfirmMessage("varmistus");
            varmistus.Show();

            this.Close();
        }
    }
}

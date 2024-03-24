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

        public BookInfo()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            muokkaaBtn.Visible = User.IsStaff;
            poistaBtn.Visible = User.IsStaff;
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

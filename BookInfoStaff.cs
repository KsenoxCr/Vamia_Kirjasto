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
    public partial class BookInfoStaff : Form
    {
        public BookInfoStaff()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConfirmMessage lainausConfirmMSG = new ConfirmMessage(lainaaBtn2.Name.ToString());
            lainausConfirmMSG.Show();

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConfirmMessage muokkausConfirmMSG = new ConfirmMessage(muokkaaBtn.Name.ToString());
            muokkausConfirmMSG.Show();

            this.Close();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            ConfirmMessage poistoConfirmMSG = new ConfirmMessage(poistaBtn.Name.ToString());
            poistoConfirmMSG.Show();

            this.Close();
        }
    }
}

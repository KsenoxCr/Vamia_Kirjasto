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
    public partial class BookRecommendation : Form
    {
        public BookRecommendation()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            ConfirmMessage ehdotusConfirmMSG = new ConfirmMessage(ehdotaBtn.Name.ToString());
            ehdotusConfirmMSG.Show();

            this.Close();
        }
    }
}

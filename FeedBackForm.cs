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
    public partial class FeedBackForm : Form
    {
        private string _sourceLabel;

        public FeedBackForm(string sourceLabel)
        {
            InitializeComponent();
            _sourceLabel = sourceLabel;
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            if (_sourceLabel == "tuki")
            {
                otsikko.Text = "Miten voimme auttaa?";
                otsikko.Font = new Font("Impact", 14F, FontStyle.Regular, GraphicsUnit.Point);
                lähetäBtn.Name = "lähetäBtnTuki";
            }
            else if (_sourceLabel == "palautteet")
            {
                otsikko.Text = "Anna palautetta";
                otsikko.Font = new Font("Impact", 16F, FontStyle.Regular, GraphicsUnit.Point);
                lähetäBtn.Name = "lähetäBtnPalautteet";
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            ConfirmMessage confirmMsg = new ConfirmMessage(lähetäBtn.Name.ToString());
            confirmMsg.Show();

            this.Close();
        }
    }
}

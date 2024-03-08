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

    public partial class ConfirmMessage : Form
    {
        private string? _sourceButton;
        private int? _sourceLabelID;

        public ConfirmMessage(string sourceButton)
        {
            InitializeComponent();
            _sourceLabelID = null;
            _sourceButton = sourceButton;
        }
        public ConfirmMessage(int sourceLabelID)
        {
            InitializeComponent();
            _sourceButton = null;
            _sourceLabelID = sourceLabelID;
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            if (_sourceButton == "ehdotaBtn")
            {
                label1.Text = "Kiitos ehdotuksesta!";
                label2.Text = "Ilmoitamme sähköpostitse kun \r\nkirja on lisätty valikoimaamme";
            }
            else if (_sourceButton == "lainaaBtn" || _sourceButton == "lainaaBtn2")
            {
                label1.Text = "Lainaus onnistui!";
                label2.Text = "(kirjan nimi) on lainattu \r\n(lainausaika) saakka";
            }
            else if (_sourceButton == "muokkaaBtn")
            {
                label1.Text = "Muokkaus onnistui!";
                label2.Text = "Muokkaukset: \r\n(tähän lista muokatuista osioista)";
            }
            else if (_sourceButton == "poistaBtn")
            {
                label1.Text = "Kirja poistettu!";
                label2.Text = "(Kirjan nimi) on poistettu valikoimasta";
            }
            else if (_sourceButton == "lähetäBtnTuki")
            {
                label1.Text = "Kiitos yhteydenotostasi!";
                label2.Text = "Vastaamme sinulle sähköpostitse \r\nmahdollisimman pian";
            }
            else if (_sourceButton == "lähetäBtnPalautteet")
            {
                label1.Text = "Kiitos palautteesta!";
                label2.Text = "Mielipiteesi on tärkeä";
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

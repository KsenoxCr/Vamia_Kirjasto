using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Kirjasto_ohjelma
{
    public static class FormManager
    {

        public static void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        public static void AddMouseEnterAndLeave(Label[] labels)
        {
            foreach (System.Windows.Forms.Label label in labels)
            {
                label.MouseEnter += (sender, e) => label.Font = new Font("Impact", 14F, FontStyle.Regular, GraphicsUnit.Point);
                label.MouseLeave += (sender, e) => label.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point);
            }
        }

        public static void controlClicked(object sender, EventArgs e, Control control)
        {
            if ((control is PictureBox picbox && picbox.Name.StartsWith("kirja")) || (control is Button && (control.Text == "Katso")))
            {
                openBookInfo();
            }
            else if (control is Button btn)
            {
                if (btn.Text == "Lainaa")
                {
                    string name = "";

                    foreach (Control c in btn.Parent.Controls)
                    {
                        if (c is Label label && label.Name.StartsWith("nimi"))
                        {
                            name = label.Text;
                        }
                    }

                    if (!string.IsNullOrEmpty(name))
                    {
                        CreateNewLoan(name);
                        OkMessage("lainaus");
                    }
                }
                else if (btn.Text == "Poista")
                {
                    OkMessage("varmistus");
                }
            }
        }
        private static void OkMessage(string msgType)
        {
            ConfirmMessage OkMessage = new ConfirmMessage(msgType);
            OkMessage.Show();
        }

        private static void openBookInfo()
        {
            BookInfo bookInfo = new BookInfo();
            bookInfo.Show();
        }

        private static void CreateNewLoan(string kirjanNimi)
        {
            AccountDetails accDetails = AccountDetails.Instance;

            Control lainauksetPanel = accDetails.Controls["lainauksetPanel"] as Control;
            Control footer = accDetails.Controls["footer"] as Control;

            lainauksetPanel.Controls.Remove(lainauksetPanel.Controls["eiLainauksia"]);

            Label kirjauduUlos = (Label)accDetails.Controls["Menu"].Controls["kirjaudu_ulos"];

            int loanCount = lainauksetPanel.Controls.Count;

            //function to find a specific number from array 

            int x = 25;
            int y = loanCount * 100 + 25;

            if (loanCount > 0)
            {
                lainauksetPanel.Height += 100;
                footer.Location = new Point(0, footer.Location.Y + 125);
                accDetails.Height += 50;
                kirjauduUlos.Location = new Point(kirjauduUlos.Location.X, kirjauduUlos.Location.Y + 100);
            }

            GroupBox uusiLainaus = new GroupBox
            {
                Size = new Size(441, 75),
                Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point),
                Location = new Point(x, y),
                BackColor = Color.Beige,
                Visible = true,
                Name = "lainaus" + (loanCount + 1)
            };

            Label lainatunnus = new Label
            {
                Text = "Kirjan isbn",
                Location = new Point(15, 25)
            };

            Label lainatutKirjat = new Label();
            lainatutKirjat = new Label
            {
                Text = "Kirjat (lista)",
                Location = new Point((uusiLainaus.Width / 2) - (lainatutKirjat.Width / 2), 25)
            };

            Label pvm = new Label();
            pvm = new Label
            {
                Text = "DD/MM/YYYY",
                Location = new Point(uusiLainaus.Width - lainatunnus.Location.X - pvm.Width, lainatunnus.Location.Y)
            };

            uusiLainaus.Controls.Add(pvm);
            uusiLainaus.Controls.Add(lainatunnus);
            uusiLainaus.Controls.Add(lainatutKirjat);
            lainauksetPanel.Controls.Add(uusiLainaus);
        }

        public static void toggleMenu(Panel menu)
        {

            if (menu.Tag == "Closed")
            {
                menu.Tag = "Open";

                menu.Location = new Point(0, 79);

            }
            else
            {
                menu.Tag = "Closed";

                menu.Location = new Point(-125, 79);
            }
        }
        public static IEnumerable<Control> EnumerateControls(this Control control)
        {
            yield return control;

            foreach (Control childControl in control.Controls)
            {
                yield return childControl;

                foreach (Control descendant in childControl.EnumerateControls())
                {
                    yield return descendant;
                }
            }
        }
    }
}

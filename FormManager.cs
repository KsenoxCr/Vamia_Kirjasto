using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

        public static void controlClicked(object sender, EventArgs e, Control control, bool isStaff)
        {

            if (control is PictureBox picbox)
            {

                openBookInfo(isStaff ? "staff" : "customer");

            } 
            else if (control is System.Windows.Forms.Button btn)
            {
                if(btn.Name.ToString().StartsWith("lainaaBtn"))
                {

                    if (btn.Parent.Name.ToString().Substring(0, 10) == "kirjaPanel" && btn.Parent.Name.Length > 10)
                    {

                        foreach (Control _control in btn.Parent.Controls)
                        {

                            if (_control.Name.StartsWith("nimi") && _control.Name.Length !< 6 && _control is Label)
                            {
                                if(isStaff)
                                {
                                    openBookInfo("staff");
                                }
                                else
                                {
                                    CreateNewLoan(_control.Text);
                                    OkMessage("lainaus");
                                }
                            }
                        }
                    }
                    else if (btn.Parent.Name.ToString() == "BookInfo")
                    {
                        foreach (Control _control in btn.Parent.Controls)
                        {
                            if (_control.Name.ToString().ToLower() == "kirjannimi") { }
                            {
                                CreateNewLoan(_control.Name.ToString().ToLower());
                                OkMessage("lainaus");
                            }
                        }
                    }

                }
                else if (btn.Name.StartsWith("poistaBtn"))
                {
                    //Lisää: "haluatko varmasti poistaa kirjan valikomaista?" -varoitus

                    OkMessage("varmistus");
                }
            }
        }
        private static void OkMessage(string msgType)
        {
            ConfirmMessage OkMessage = new ConfirmMessage(msgType);
            OkMessage.Show();
        }

        private static void openBookInfo(string userType)
        {
            BookInfo bookInfo = new BookInfo(userType);
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

            int positionX = 25;
            int positionY = loanCount * 100 + 25;

            if (loanCount > 0)
            {
                lainauksetPanel.Height += 100;
                footer.Location = new Point(0, footer.Location.Y + 125);
                accDetails.Height += 50;

                kirjauduUlos.Location = new Point(kirjauduUlos.Location.X, kirjauduUlos.Location.Y + 100);
            }

            GroupBox uusiLainaus = new GroupBox();
            uusiLainaus.Size = new Size(441, 75);
            uusiLainaus.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uusiLainaus.Location = new Point(positionX, positionY);
            uusiLainaus.BackColor = Color.Beige;
            uusiLainaus.Visible = true;
            uusiLainaus.Name = "lainaus" + (loanCount + 1);

            Label lainatunnus = new Label();
            lainatunnus.Text = "Kirjan isbn";
            lainatunnus.Location = new Point(15, 25);

            Label lainatutKirjat = new Label();
            lainatutKirjat.Text = "Kirjat (lista)";
            lainatutKirjat.Location = new Point((uusiLainaus.Width / 2) - (lainatutKirjat.Width / 2), 25);

            Label pvm = new Label();
            pvm.Text = "DD/MM/YYYY";
            pvm.Location = new Point(uusiLainaus.Width - lainatunnus.Location.X - pvm.Width, lainatunnus.Location.Y);


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
    }
}

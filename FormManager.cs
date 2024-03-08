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
                label.MouseEnter += (sender, e) => FormManager.MouseEnterLabel(sender, e, label);
                label.MouseLeave += (sender, e) => FormManager.MouseLeaveLabel(sender, e, label);
            }
        }

        static void MouseEnterLabel(object sender, EventArgs e, Label label)
        {
            label.Font = new Font("Impact", 14F, FontStyle.Regular, GraphicsUnit.Point);
        }

        static void MouseLeaveLabel(object sender, EventArgs e, Label label)
        {
            label.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point);
        }

        public static void controlClicked(object sender, EventArgs e, Control control)
        {

            if (control is PictureBox picbox)
            {
                if (picbox.Tag.ToString() == "asiakas")
                {
                    BookInfo UserBookInfo = new BookInfo();
                    UserBookInfo.Show();
                }
                else if (picbox.Tag.ToString() == "henkilökunta")
                {
                    BookInfoStaff staffBookInfo = new BookInfoStaff();
                    staffBookInfo.Show();
                }
            } 
            else if (control is System.Windows.Forms.Button btn)
            {
                if(btn.Name.ToString().Substring(0, 9) == "lainaaBtn" && btn.Name.ToString().Length > 9)
                {

                    if (btn.Parent.Name.ToString().Substring(0, 10) == "kirjaPanel" && btn.Parent.Name.Length > 10)
                    {

                        foreach (Control _control in btn.Parent.Controls)
                        {

                            if (_control.Name.Substring(0, 4).ToLower() == "nimi" && _control.Name.Length > 4 && _control is Label)
                            {

                                /*
                                int kirjaNum = Convert.ToInt32(_control.Name.Substring(4));
                                string kirjanNimi = "";


                                switch(kirjaNum)
                                {
                                    case 1: 

                                        break;

                                } */

                                CreateNewLoan(_control.Text);
                            }
                        }
                    }
                    else if (btn.Parent.Name.ToString() == "Form5")
                    {
                        foreach (Control _control in btn.Parent.Controls)
                        {
                            if (_control.Name.ToString().ToLower() == "kirjannimi") { }
                            {
                                CreateNewLoan(_control.Name.ToString().ToLower());
                            }
                        }
                    }

                    ConfirmMessage lainausConfirmMSG = new ConfirmMessage("lainaaBtn");
                    lainausConfirmMSG.Show();
                    
                }
                else if (btn.Name.ToString().Substring(0, 9) == "poistaBtn" && btn.Name.ToString().Length > 9)
                {
                    //Lisää: "haluatko varmasti poistaa kirjan valikomaista?" -varoitus

                    ConfirmMessage poistoConfirmMSG = new ConfirmMessage("poistaBtn");
                    poistoConfirmMSG.Show();
                }
            }
        }

        public static void ControlsAreClickable(object sender, EventArgs e, Control control, string controlName, string controlType) 
        {
            List<Control> FindAllControls(Control control, string type)
            {
                List<Control> controls = new List<Control>();

                if(type.ToLower() == "button")
                {
                    controls.AddRange(control.Controls.OfType<System.Windows.Forms.Button>());
                }
                else if(type.ToLower() == "picturebox")
                {
                    controls.AddRange(control.Controls.OfType<System.Windows.Forms.PictureBox>());
                }

                foreach (Control childControl in control.Controls)
                {
                    controls.AddRange(FindAllControls(childControl, type));
                }

                return controls;
            }


            var allSpecifiedControls = FindAllControls(control, controlType);

            var clickableControls = allSpecifiedControls.Where(pb => pb.Name.StartsWith(controlName) && pb.Name.Length > controlName.Length);

            if (clickableControls.Any())
            {
                //var bookNumbers = clickableControls.Select(pb => int.Parse(pb.Name.Substring(controlName.Length)));

                //var bookArray = new PictureBox[bookNumbers.Max() + 1];

                foreach (var clickableControl in clickableControls)
                {
                    //int index = int.Parse(clickableControl.Name.Substring(5)) - 1;
                    //bookArray[index] = clickableControl;
                    clickableControl.Click += (sender, e) => FormManager.controlClicked(sender, e, clickableControl);
                }
            }
        }
        private static void CreateNewLoan(string kirjanNimi)
        {
            AccountDetails accDetails = AccountDetails.Instance;

            Control lainauksetPanel = accDetails.Controls["lainauksetPanel"] as Control;
            Control footer = accDetails.Controls["footer"] as Control;
            

            int positionX = 25;
            int positionY = 25;

            lainauksetPanel.Controls.Remove(lainauksetPanel.Controls["eiLainauksia"]);

            int loanCount = lainauksetPanel.Controls.Count;

            if (loanCount >= 1)
            {

                for (int i = lainauksetPanel.Controls.Count - 1; i >= 0; i--)
                {
                    positionY += 100;
                    lainauksetPanel.Height += 100;
                }

                accDetails.Height += 125;


                int footerNewy = footer.Location.Y + 125;
                footer.Location = new Point(0, footerNewy);

                lainauksetPanel.Height += 100;
            }

            GroupBox uusiLainaus = new GroupBox();
            uusiLainaus.Size = new Size(441, 75);
            uusiLainaus.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uusiLainaus.Location = new Point(positionX, positionY);
            uusiLainaus.BackColor = Color.Beige;
            uusiLainaus.Visible = true;

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

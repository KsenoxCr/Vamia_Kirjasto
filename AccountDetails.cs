using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kirjasto_ohjelma
{
    public partial class AccountDetails : Form
    {
        DatabaseAccess db = DatabaseAccess.GetInstance();

        private string _username;
        private string _userType;
        private bool isStaff;

        private string asnum = "";

        private Label[] information;
        private Button[] infoButtons;

        public AccountDetails(string userName, string userType)
        {
            InitializeComponent();

            this._username = userName;
            this._userType = userType;
            isStaff = _userType == "staff" ? true : false;

            this.FormClosing += FormManager.Form_FormClosing;

            Label[] labels = { kirjat, asiakkaat, kirjaudu_ulos };
            FormManager.AddMouseEnterAndLeave(labels);

            information = new Label[] { enimi, snimi, kayttajatunnus, salasana, loso, pno, ptp, puh };
            infoButtons = new Button[] { vaihdaEnimi, vaihdaSnimi, vaihdaKtunnus, vaihdaSalasana, vaihdaLoso, vaihdaPno, vaihdaPtp, vaihdaPuh };
        }
        private void kirjauduUlos_Click(object sender, EventArgs e)
        {
            FormManager.openLogin(this);
        }
        public void info_buttonClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;


            string action = "";

            if (btn.Text == "vaihda")
            {
                action = "change";
            }
            else if (btn.Text == "määritä")
            {
                action = "set";
            }

            string valueType = btn.Parent.Name.Replace("Panel", "");

            ChangeValue changeValue = new ChangeValue(action, valueType);
            changeValue.Show();

            loadAccountDetails(_username);
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            loadAccountDetails(_username);
            loadLoans(asnum);

            if (_userType == "staff")
            {
                losoPanel.Visible = false;
                pnoPanel.Visible = false;

                ptpPanel.Location = losoPanel.Location;
                puhPanel.Location = pnoPanel.Location;
            }

            if (this.Height > 730)
            {
                AutoScroll = true; //Might not be needed
            }
        }

        private void kirjat_Click(object sender, EventArgs e)
        {
            FormManager.toHome(this);
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            FormManager.toggleMenu(Menu);
        }
        private void loadAccountDetails(string username)
        {
            string hashedPassword = "";
            string saltHex = "";

            try
            {
                db.OpenConnection();

                string query;

                if (isStaff)
                {
                    query = $"SELECT tyonum, tyonim, enimi, snimi, ptp, puh, salasana, salt FROM henkilokunta WHERE kayttajatunnus = \"{username}\"";
                }
                else
                {
                    query = $"SELECT asnum, enimi, snimi, loso, pno, ptp, puh, salasana, salt FROM asiakas WHERE kayttajatunnus = \"{username}\"";
                }

                using (MySqlCommand command = new MySqlCommand(query, db.connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            asnum = isStaff ? reader.GetString("tyonum") : reader.GetString("asnum");

                            kayttajatunnus.Text = _username;
                            enimi.Text = reader.GetString("enimi");
                            snimi.Text = reader.GetString("snimi");

                            hashedPassword = reader.GetString("salasana");
                            saltHex = reader.GetString("salt");
                            ptp.Text = reader.GetString("ptp");
                            puh.Text = reader.GetString("puh");

                            if (isStaff)
                            {
                                tyonim.Text = reader.GetString("tyonim");
                                vaihdaPno.Visible = false;

                            }
                            else
                            {
                                pno.Text = reader.GetString("pno");
                                loso.Text = reader.GetString("loso");
                                vaihdaPno.Visible = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Tietokantavirhe: {ex.Message}");
            }
            finally
            {
                db.CloseConnection();
            }

            for (int i = 0; i < information.Length; i++)
            {
                if (information[i].Text == "NotSpecified" || information[i].Text == "Ei Määritetty" || information[i].Text == "00000")
                {
                    information[i].Text = "ei määritetty";

                    infoButtons[i].Text = "Määritä";
                    infoButtons[i].Width += 5;
                    infoButtons[i].Left -= 5;
                }
                else
                {
                    infoButtons[i].Text = "Vaihda";
                    infoButtons[i].Size = new Size(60, 25);
                }
                infoButtons[i].Click += info_buttonClick;
            }
        }
        private void loadLoans(string asnum)
        {
            List<String> lainanums = new List<String>();

            try
            {
                db.OpenConnection();

                int lainausCount = 0;
                string userType = isStaff ? "tyonum" : "astun";

                string query = $"SELECT lainanum, pvm FROM lainaus WHERE {userType} = \"{asnum}\"";

                using (MySqlCommand command = new MySqlCommand(query, db.connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lainausCount++;

                            string lainanum = reader.GetString("lainanum");

                            DateTime pvmDate = reader.GetDateTime("pvm");
                            string pvm = pvmDate.ToString("dd-MM-yyyy");

                            Panel lainausPanel = new Panel()
                            {
                                Name = "lainausPanel" + lainausCount,
                                Size = new Size(460, 100),
                                BackColor = Color.FromArgb(255, 241, 220),
                                BorderStyle = BorderStyle.FixedSingle,
                            };
                            lainausPanel.Location = new Point((lainauksetPanel.Width - lainausPanel.Width) / 2, 30);

                            Label lainausLabel = new Label()
                            {
                                Name = "lainausLabel" + lainausCount,
                                Text = "Lainaus: " + pvm
                            };
                            lainausLabel.Location = new Point((lainausPanel.Width - lainausLabel.Width) / 2, 10);

                            lainausPanel.Controls.Add(lainausLabel);
                            lainauksetPanel.Controls.Add(lainausPanel);

                            lainanums.Append(lainanum);

                            lainauksetPanel.Height += 490;
                        }
                        if (lainausCount >= 1)
                        {
                            eiLainauksia.Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Tietokantavirhe: {ex.Message}");
            }
            finally
            {
                db.CloseConnection();
            }

            loadLoanRows(lainanums);
        }
        private void loadLoanRows(List<string> lainanums)
        {
            try
            {
                db.OpenConnection();

                foreach (string lainanum in lainanums)
                {
                    string lainariviQuery = $"SELECT lr.rivinum, k.nimi FROM lainarivi lr INNER JOIN lainakohde lk ON lk.tunnus = lr.kohdetun INNER JOIN kirja k ON k.isbn = lk.ktun WHERE lr.ltunnus = \"{lainanum}\"";

                    int lainariviCount = 0;

                    using (MySqlCommand lainariviCommand = new MySqlCommand(lainariviQuery, db.connection))
                    {
                        using (MySqlDataReader lainariviReader = lainariviCommand.ExecuteReader())
                        {
                            while (lainariviReader.Read())
                            {
                                lainariviCount++;

                                Panel lainariviPanel = new Panel()
                                {
                                    Name = "lainarivi" + lainariviCount,
                                    Size = new Size(460, 100),
                                    BackColor = Color.Transparent,
                                    BorderStyle = BorderStyle.FixedSingle,
                                };
                                int rivinum = lainariviReader.GetInt32("lr.rivinum");
                                string kirjanNimi = lainariviReader.GetString("k.nimi");

                                Label rivinumLabel = new Label()
                                {
                                    Name = "rivinumLabel" + lainariviCount,
                                    Text = "Rivi: " + rivinum
                                };
                                rivinumLabel.Location = new Point(lainariviPanel.Left + 10, (lainariviPanel.Height - rivinumLabel.Height) / 2);

                                Label kirjanNimiLabel = new Label()
                                {
                                    Name = "kirjanNimiLabel" + lainariviCount,
                                    Text = kirjanNimi
                                };
                                kirjanNimiLabel.Location = new Point(rivinumLabel.Right + 10, rivinumLabel.Top);

                                Control lainaPanel = lainauksetPanel.Controls[lainariviCount - 1];

                                lainaPanel.Controls.Add(lainariviPanel);
                                lainaPanel.Height += lainariviPanel.Height + 30;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Tietokantavirhe: {ex.Message}");
            }
            finally
            {
                db.CloseConnection();
            }
        }

        private void vaihtaSalasanaBtn_Click(object sender, EventArgs e)
        {

        }

        private void vaihdaKtunnusBtn_Click(object sender, EventArgs e)
        {

        }

        private void vaihdaPuh_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FormManager.toHome(this);
        }

        private void asiakkaat_Click(object sender, EventArgs e)
        {
            FormManager.openUserList(this);
        }
    }
}

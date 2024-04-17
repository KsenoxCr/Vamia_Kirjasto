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
using static System.Reflection.Metadata.BlobBuilder;

namespace Kirjasto_ohjelma
{
    public partial class AccountDetails : Form
    {
        private readonly DatabaseAccess db = DatabaseAccess.GetInstance();

        private readonly string _username;
        private readonly string _userType;
        private readonly bool isStaff;

        private string asnum = "";

        private readonly Label[] information;
        private readonly Button[] infoButtons;

        public AccountDetails(string userName, string userType)
        {
            InitializeComponent();

            this._username = userName;
            this._userType = userType;
            isStaff = _userType == "staff";

            this.FormClosing += FormManager.FormClosing;

            Label[] labels = { kirjat, asiakkaat, kirjaudu_ulos };
            FormManager.AddMouseEnterAndLeave(labels);

            information = new Label[] { enimi, snimi, kayttajatunnus, salasana, loso, pno, ptp, puh };
            infoButtons = new Button[] { vaihdaEnimi, vaihdaSnimi, vaihdaKtunnus, vaihdaSalasana, vaihdaLoso, vaihdaPno, vaihdaPtp, vaihdaPuh };
        }
        private void LogOut_Click(object sender, EventArgs e)
        {
            FormManager.OpenLogin(this);
        }

        public void ChangeValue_Click(object sender, EventArgs e)
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

            ChangeValue changeValue = new(action, valueType);
            changeValue.Show();

            LoadAccountDetails(_username);
        }

        private void Form_Load(object sender, EventArgs e)
        {
            LoadAccountDetails(_username);
            LoadLoans(asnum);

            losoPanel.Visible = !isStaff;
            pnoPanel.Visible = !isStaff;
            tyonimLabel.Visible = isStaff;
            tyonim.Visible = isStaff;

            ptpPanel.Location = isStaff ? losoPanel.Location : new Point(28, 283);
            puhPanel.Location = isStaff ? pnoPanel.Location : new Point(28, 248);
            tyonim.Location = new Point(tyonimLabel.Location.X + tyonimLabel.Width / 2 - tyonim.Width / 2, tyonim.Location.Y);

            if (this.Height > 730)
            {
                AutoScroll = true; //Might not be needed
            }
        }

        private void Books_Click(object sender, EventArgs e)
        {
            FormManager.ToHome(this);
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            FormManager.ToggleMenu(Menu, timerAcc);
        }

        private void LoadAccountDetails(string username)
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

                using MySqlCommand command = new(query, db.connection);
                using MySqlDataReader reader = command.ExecuteReader();

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
                infoButtons[i].Click += ChangeValue_Click;
            }
        }

        private void LoadLoans(string asnum)
        {
            List<String[]> loans = new();

            try
            {
                db.OpenConnection();

                string userType = isStaff ? "tyonum" : "astun";

                string queryLainanum = $"SELECT lainanum, pvm FROM lainaus WHERE {userType} = \"{asnum}\"";

                using MySqlCommand command = new(queryLainanum, db.connection);
                using MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string pvm = reader.GetDateTime("pvm").ToString("dd-MM-yyyy");

                    string[] loan = new string[]
                    {
                                reader["lainanum"] as string,
                                pvm
                    };

                    loans.Add(loan);
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

            LoadLoanRows(loans);
        }

        private void LoadLoanRows(List<string[]> lainanums)
        {
            List<string[]> loanRows = new();

            try
            {
                db.OpenConnection();

                foreach (string[] lainanum in lainanums)
                {
                    string lainariviQuery = $"SELECT lr.rivinum, k.nimi FROM lainarivi lr INNER JOIN lainakohde lk ON lk.tunnus = lr.kohdetun INNER JOIN kirja k ON k.isbn = lk.ktun WHERE lr.ltunnus = \"{lainanum[0]}\"";

                    using MySqlCommand lainariviCommand = new(lainariviQuery, db.connection);
                    using MySqlDataReader lainariviReader = lainariviCommand.ExecuteReader();

                    while (lainariviReader.Read())
                    {
                        string[] loanRow = new string[]
                        {
                                    lainariviReader.GetInt32("rivinum").ToString(),
                                    lainariviReader.GetString("nimi")
                        };

                        loanRows.Add(loanRow);
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

            displayLoans(lainanums, loanRows);
        }

        private void displayLoans(List<string[]> loans, List<string[]> loanRows)
        {
            int loanCount = 0;

            for (int i = 1; i < loans.Count; i++)
            {
                Panel lainausPanel = new()
                {
                    Name = "lainausPanel" + i,
                    Size = new Size(460, 200),
                    BackColor = Color.FromArgb(255, 241, 220),
                    BorderStyle = BorderStyle.FixedSingle,
                };
                lainausPanel.Location = new Point((lainauksetPanel.Width - lainausPanel.Width) / 2, 30);

                Label lainausLabel = new()
                {
                    Name = "lainausLabel" + i,
                    Text = "Lainaus: " + loans[i][1]
                };
                lainausLabel.Location = new Point((lainausPanel.Width - lainausLabel.Width) / 2, 10);

                lainausPanel.Controls.Add(lainausLabel);
                lainauksetPanel.Controls.Add(lainausPanel);

                lainauksetPanel.Height += 490;

                for (int j = 1; j < loanRows.Count; j++)
                {
                    Panel lainariviPanel = new()
                    {
                        Name = "lainarivi" + j,
                        Size = new Size(460, 100),
                        BackColor = Color.Transparent,
                        BorderStyle = BorderStyle.FixedSingle,
                    };

                    Label rivinumLabel = new()
                    {
                        Name = "rivinumLabel" + j,
                        Text = "Rivi: " + loanRows[j][0]
                    };
                    rivinumLabel.Location = new Point(lainariviPanel.Left + 10, (lainariviPanel.Height - rivinumLabel.Height) / 2);
                    lainariviPanel.Controls.Add(rivinumLabel);

                    Label kirjanNimiLabel = new()
                    {
                        Name = "kirjanNimiLabel" + j,
                        Text = loanRows[j][1],
                        Location = new Point(rivinumLabel.Right + 10, rivinumLabel.Top)
                    };
                    lainariviPanel.Controls.Add(kirjanNimiLabel);

                    Control lainaPanel = lainauksetPanel.Controls[j - 1];

                    lainaPanel.Controls.Add(lainariviPanel);
                    lainaPanel.Height += lainariviPanel.Height + 30;
                }
                loanCount++;
            }
            eiLainauksia.Visible = loanCount > 0;
        }

        private void ChangePassword_Click(object sender, EventArgs e)
        {

        }

        private void ChangeUsername_Click(object sender, EventArgs e)
        {

        }

        private void ChangeFirstName_Click(object sender, EventArgs e)
        {

        }

        private void ChangeLastName_Click(object sender, EventArgs e)
        {

        }

        private void ChangeAddress_Click(object sender, EventArgs e)
        {

        }

        private void ChangeCity_Click(object sender, EventArgs e)
        {

        }

        private void ChangePhoneNumber_Click(object sender, EventArgs e)
        {

        }

        private void ChangePostalCode_Click(object sender, EventArgs e)
        {

        }

        private void Logo_Click(object sender, EventArgs e)
        {
            FormManager.ToHome(this);
        }

        private void Customers_Click(object sender, EventArgs e)
        {
            FormManager.OpenUserList(this);
        }

        private void timerAccDe_Tick(object sender, EventArgs e)
        {
            FormManager.timerTick(timerAcc, Menu);
        }
    }
}

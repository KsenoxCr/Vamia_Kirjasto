using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
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

        private readonly string _asnum;
        private readonly string _userType;
        private readonly bool isStaff;

        private string asnum = "";

        private readonly List<Label> informations;
        private readonly List<Button> infoButtons;

        private Dictionary<Button, bool> hasClickEventAttached = new();

        public AccountDetails(string asnum)
        {
            InitializeComponent();

            this._asnum = asnum;
            
            isStaff = asnum.StartsWith("TT");

            this.FormClosing += FormManager.FormClosing;

            Label[] labels = { kirjat, asiakkaat, kirjaudu_ulos };
            FormManager.AddMouseEnterAndLeave(labels);

            informations = new() { enimi, snimi, kayttajatunnus, loso, pno, ptp, puh};
            infoButtons = new() { vaihdaEnimi, vaihdaSnimi, vaihdaKtunnus, vaihdaLoso, vaihdaPno, vaihdaPtp, vaihdaPuh };
        }

        private void LogOut_Click(object sender, EventArgs e)
        {
            // Avataan kirjautumisikkuna

            FormManager.OpenLogin(this);
        }

        public void ChangeValue_Click(object sender, EventArgs e)
        {
            // Avataan ikkuna, jossa voi vaihtaa käyttäjän tietoja

            Button btn = (Button)sender;


            string action = "";

            if (btn.Text == "vaihda")
            {
                action = "edit";
            }
            else if (btn.Text == "määritä")
            {
                action = "set";
            }

            string valueType = btn.Parent.Name.Replace("Panel", "");

            FormManager.OpenChangeValue(action, valueType, this);
        }

        private void Form_Load(object sender, EventArgs e)
        {
            Design();

            // Ladataan käyttäjän tiedot ja lainaukset tietokannasta

            LoadAccountDetails(_asnum);
            LoadLoans(_asnum);

            if (footer.Bottom > 810)
            {
                //this.Width = Header.Width - SystemInformation.VerticalScrollBarWidth;

                this.HorizontalScroll.Maximum = 0;

                AutoScroll = true; //Might not be needed
            }
        }

        private void Books_Click(object sender, EventArgs e)
        {
            // Avataan aloitusikkuna

            FormManager.ToHome(this);
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            // Näytetään tai piilotetaan valikko

            FormManager.ToggleMenu(Menu, timerAcc);
        }

        public void LoadAccountDetails(string asnum)
        {
            // haetaan käyttäjän tiedot tietokannasta ja näytetään ne käyttöliittymässä

            string hashedPassword = "";
            string saltHex = "";

            string[] accDetails = new string[8];

            try
            {
                db.OpenConnection();

                string query;

                if (isStaff)
                {
                    query = $"SELECT tyonum, tyonim, enimi, snimi, kayttajatunnus, ptp, puh FROM henkilokunta WHERE tyonum = \"{asnum}\"";
                }
                else
                {
                    query = $"SELECT asnum, enimi, snimi, kayttajatunnus, loso, pno, ptp, puh FROM asiakas WHERE asnum = \"{asnum}\"";
                }

                using MySqlCommand command = new(query, db.connection);
                using MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    asnum = isStaff ? reader.GetString("tyonum") : reader.GetString("asnum");

                    accDetails[0] = reader.GetString("enimi");
                    accDetails[1] = reader.GetString("snimi");
                    accDetails[2] = reader.GetString("kayttajatunnus");

                    if (isStaff)
                    {
                        accDetails[3] = reader.GetString("ptp");
                        accDetails[4] = reader.GetString("puh");

                        tyonim.Text = reader.GetString("tyonim");
                    }
                    else
                    {
                        accDetails[3] = reader.GetString("loso");
                        accDetails[4] = reader.GetString("pno");
                        accDetails[5] = reader.GetString("ptp");
                        accDetails[6] = reader.GetString("puh");
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

            // Lisätään eventhandlerit ja Näytetään oikea nappi tietojen muuttamiseen

            for (int i = 0; i < informations.Count; i++)
            {
                //MessageBox.Show($"Information[{i}].Name: {informations[i].Name}\r\nInformation[{i}].Text: {informations[i].Text}\r\naccDetails[{i}]: {accDetails[i]}");

                if (accDetails[i] == "NotSpecified" || accDetails[i].ToLower() == "ei määritetty" || accDetails[i] == "00000")
                {
                    informations[i].Text = "Ei määritetty";

                    infoButtons[i].Text = "Määritä";
                    infoButtons[i].Width = 60;
                }
                else
                {
                    FormManager.ShowPartOrFullText(informations[i], 16, accDetails[i], toolTip);

                    infoButtons[i].Text = "Vaihda";
                    infoButtons[i].Width = 55;
                    //infoButtons[i].Size = new Size(60, 25);
                }

                if (!hasClickEventAttached.ContainsKey(infoButtons[i]))
                {
                    infoButtons[i].Click += ChangeValue_Click;
                    hasClickEventAttached.Add(infoButtons[i], true);
                }
            }
        }

        private void LoadLoans(string asnum)
        {
            // Haetaan käyttäjän lainaukset tietokannasta

            List<String[]> loansDetails = new();

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

                    loansDetails.Add(loan);
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

            LoadLoanRows(loansDetails);
        }

        private void LoadLoanRows(List<string[]> loansDetails)
        {
            // Haetaan lainarivit tietokannasta

            List<List<string[]>> loans = new();
            List<string> dates = new();

            try
            {
                db.OpenConnection();

                foreach (string[] loan in loansDetails)
                {
                    string lainanum = loan[0];

                    string lainariviQuery = $"SELECT lr.rivinum, k.nimi FROM lainarivi lr INNER JOIN lainakohde lk ON lk.tunnus = lr.kohdetun INNER JOIN kirja k ON k.isbn = lk.ktun WHERE lr.ltunnus = \"{lainanum}\"";

                    using MySqlCommand lainariviCommand = new(lainariviQuery, db.connection);
                    using MySqlDataReader lainariviReader = lainariviCommand.ExecuteReader();

                    List<string[]> loanRows = new();

                    while (lainariviReader.Read())
                    {
                        string[] loanRow = new string[]
                        {
                                    lainariviReader.GetInt32("rivinum").ToString(),
                                    lainariviReader.GetString("nimi")
                        };

                        loanRows.Add(loanRow);
                    }

                    loans.Add(loanRows);

                    dates.Add(loan[1]);
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

            // Näytetään lainaukset käyttöliittymässä

            DisplayLoans(loans, dates);
        }

        private void DisplayLoans(List<List<string[]>> loans, List<string> dates)
        {
            int i;

            if (loans.Count > 0)
            {
                eiLainauksia.Visible = false;
            }

            for (i = 0; i < loans.Count; i++)
            {
                Panel loanPanel = new()
                {
                    Name = "loanPanel" + (i + 1),
                    Size = new Size(460, 60),
                    BackColor = Color.Tan,
                    BorderStyle = BorderStyle.FixedSingle
                };

                int loanPanelY;

                if (i > 0)
                {
                    loanPanelY = lainauksetPanel.Controls[i].Bottom + 10;
                }
                else
                {
                    loanPanelY = 30;
                }

                loanPanel.Location = new Point((lainauksetPanel.Width - loanPanel.Width) / 2, loanPanelY);

                string date = dates[i];

                Label loanLabel = new()
                {
                    Name = $"loanLabel{(i + 1)}",
                    Text = $"Lainaus {i + 1}: {date}",
                    Location = new Point(10, 10),
                    Font = new Font("Impact", 12F),
                    AutoSize = true
                };

                loanPanel.Controls.Add(loanLabel);
                lainauksetPanel.Controls.Add(loanPanel);

                for (int j = 0; j < loans[i].Count; j++)
                {
                    Panel loanRowPanel = new()
                    {
                        Name = $"loanRowPanel{j + 1}",
                        Size = new Size(loanPanel.Width - 30, 30),
                        BackColor = Color.FromArgb(255, 241, 220),
                        Font = new Font("Impact", 10F)
                    };
                    loanRowPanel.Location = new Point((loanPanel.Width - loanRowPanel.Width) / 2, loanLabel.Bottom + 15 + j * 35);

                    Label rowNumberLabel = new()
                    {
                        Name = $"rowNumberLabel{j + 1}",
                        Text = $"Kirja: {j + 1}",
                        AutoSize = true
                    };
                    rowNumberLabel.Location = new Point(10, (loanRowPanel.Height - rowNumberLabel.Height) / 2);

                    loanRowPanel.Controls.Add(rowNumberLabel);

                    Label bookNameLabel = new()
                    {
                        Name = $"bookNameLabel{j + 1}",
                        Text = loans[i][j][1],
                        Location = new Point(rowNumberLabel.Right + 10, rowNumberLabel.Top),
                        AutoSize = true
                    };
                    loanRowPanel.Controls.Add(bookNameLabel);

                    loanPanel.Controls.Add(loanRowPanel);
                    loanPanel.Height += loanRowPanel.Height + 5;
                }
            }

            lainauksetPanel.Height = lainauksetPanel.Controls[i].Bottom + 30;
            Menu.Height = lainauksetPanel.Bottom - Header.Height + 30;
            footer.Top = lainauksetPanel.Bottom + 30;
            //this.Height = footer.Bottom;
        }

        private void Logo_Click(object sender, EventArgs e)
        {
            FormManager.ToHome(this);
        }

        private void Customers_Click(object sender, EventArgs e)
        {
            FormManager.OpenUserList(this);
        }

        private void TimerAccDe_Tick(object sender, EventArgs e)
        {
            FormManager.timerTick(timerAcc, Menu);
        }

        private void footerLogo_Click(object sender, EventArgs e)
        {
            this.AutoScrollPosition = Point.Empty;
        }

        private void Design()
        {
            // Muotoillaan käyttöliittymä kirjautuneen käyttäjän oikeuksien sekä 
            // tarkasteltavan käyttäjän tilityypin mukaan

            asiakkaat.Visible = User.IsStaff;

            //MessageBox.Show($"asiakkaat.Visible: {asiakkaat.Visible}\r\nUser.IsStaff: {User.IsStaff}");

            kirjat.Top = asiakkaat.Visible ? asiakkaat.Bottom + 10 : asiakkaat.Top;
            kirjaudu_ulos.Top = kirjat.Bottom + 10;

            if (isStaff)
            {
                informations.Remove(pno);
                infoButtons.Remove(vaihdaPno);
                informations.Remove(loso);
                infoButtons.Remove(vaihdaLoso);

                ptpPanel.Top = lisatiedot.Bottom + 5;
                puhPanel.Top = ptpPanel.Bottom + 5;
                tyonimPanel.Top = puhPanel.Bottom + 5;

                tilinTiedotPanel.Height = tyonimPanel.Bottom + 30;

                losoPanel.Visible = false;
                pnoPanel.Visible = false;
            }
            else
            {
                tyonimPanel.Visible = false;

                tilinTiedotPanel.Height = puhPanel.Bottom + 30;
            }

            if (User.Asnum != _asnum)
            {
                foreach (Button btn in infoButtons)
                {
                    btn.Visible = false;
                }

                vaihdaSalasana.Visible = false;
            }
            else
            {
                vaihdaSalasana.Click += ChangeValue_Click;
            }

            lainaukset.Top = tilinTiedotPanel.Bottom + 50;
            lainauksetPanel.Top = lainaukset.Bottom + 50;
        }
    }
}

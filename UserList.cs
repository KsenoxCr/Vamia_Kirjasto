using Kirjasto_ohjelma.Properties;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kirjasto_ohjelma
{
    public partial class UserList : Form
    {
        private static UserList instance = null;
        private static readonly object _lock = new();

        private readonly DatabaseAccess db = DatabaseAccess.GetInstance();

        private string order = "ASC";
        private string orderBy = "a.asnum";
        private string limit = "";
        private string filter = "";
        private decimal totalCount = 0;

        private UserList()
        {
            InitializeComponent();

            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int x = (screenWidth - this.Width) / 2;
            Location = new Point(x, 0);

            FormManager.AddMouseEnterAndLeave(new Label[] { kirjat, kirjaudu_ulos });

            this.MaximumSize = new Size(1010, 1000);

            FormManager.SetDoubleBuffered(this);
            FormManager.SetDoubleBuffered(asiakkaatPanel);
        }

        public static UserList GetInstance()
        {
            lock (_lock)
            {
                if (instance == null)
                {
                    instance = new UserList();
                }
                return instance;
            }
        }

        private void Logo_Click(object sender, EventArgs e)
        {
            FormManager.ToHome(this);
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            // Avataan ja suljetaan valikko

            FormManager.ToggleMenu(Menu, timerUserList);
        }

        private void TimerUserList_Tick(object sender, EventArgs e)
        {
            // Valikon animaation ajastin

            FormManager.timerTick(timerUserList, Menu);
        }

        private void LogOut_Click(object sender, EventArgs e)
        {
            // Kirjaudutaan ulos ja palataan kirjautumissivulle

            FormManager.OpenLogin(this);
        }

        private void UserList_Load(object sender, EventArgs e)
        {
            LoadUsersFromDatabase();

            if (this.Height > 800)
            {
                this.HorizontalScroll.Maximum = 0;
                this.AutoScroll = true;
            }

            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

            this.Location = new Point(this.Left, (screenHeight - this.Height) / 2);
        }

        private void JarjestysCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (jarjestysCB.SelectedIndex)
            {
                case 0:
                    orderBy = "a.asnum";
                    break;
                case 1:
                    orderBy = "a.kayttajatunnus";
                    break;
                case 2:
                    orderBy = "a.enimi";
                    break;
                case 3:
                    orderBy = "a.snimi";
                    break;
                case 4:
                    orderBy = "lainaus_maara";
                    break;
                case 5:
                    orderBy = "kirjojen_maara";
                    break;
                case 6:
                    orderBy = "palautteiden_maara";
                    break;
            }

            LoadUsersFromDatabase();
        }

        private void NaytaCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (naytaCB.SelectedIndex)
            {
                case 0:
                    limit = "";
                    break;
                case 1:
                    if (totalCount > 0)
                    {
                        totalCount /= 2;
                        limit = $"LIMIT {(int)Math.Round(totalCount / 2, MidpointRounding.AwayFromZero) * 2}";
                    }
                    break;
                case 2:
                    limit = "LIMIT 10";
                    break;
                case 3:
                    limit = "LIMIT 20";
                    break;
                case 4:
                    limit = "LIMIT 50";
                    break;
                case 5:
                    limit = "LIMIT 100";
                    break;
            }

            LoadUsersFromDatabase();
        }

        private void OrderByBox_Click(object sender, EventArgs e)
        {
            string arrow = "";

            if (order == "ASC")
            {
                order = "DESC";

                arrow = "ArrowDownTransparentBg.png";
            }
            else
            {
                order = "ASC";

                arrow = "ArrowUpTransparentBg.png";
            }

            string rootPath = Directory.GetCurrentDirectory();
            string imagePath = Path.GetFullPath(Path.Combine(rootPath, @"Images\Icons", arrow));

            orderBox.BackgroundImage = Image.FromFile(imagePath);

            LoadUsersFromDatabase();
        }

        private void LoadUsersFromDatabase()
        {
            totalCount = 0;

            List<string[]> users = new();

            try
            {
                db.OpenConnection();

                string query = "SELECT a.asnum, a.kayttajatunnus, a.enimi, a.snimi, a.loso, a.pno, a.ptp, a.puh, "
                        + "(SELECT COUNT(*) FROM Lainaus WHERE astun = a.asnum) AS lainaus_maara, "
                        + "(SELECT COUNT(*) FROM Lainarivi WHERE ltunnus IN (SELECT lainanum FROM Lainaus WHERE astun = a.asnum)) AS kirjojen_maara, "
                        + "(SELECT COUNT(*) FROM Palautteet WHERE astun = a.asnum) AS palautteiden_maara "
                        + "FROM Asiakas AS a WHERE asnum <> \"XXXXXXX\" " + filter
                        + $"ORDER BY {orderBy} {order} " + limit;

                using MySqlCommand command = new(query, db.connection);
                using MySqlDataReader reader = command.ExecuteReader();

                users.Clear();

                while (reader.Read())
                {
                    string[] userInfo = new string[]
                    {
                                reader.GetString(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetString(3),
                                reader.GetString(4),
                                reader.GetString(5),
                                reader.GetString(6),
                                reader.GetString(7),
                                reader.GetInt32(8).ToString(),
                                reader.GetInt32(9).ToString(),
                                reader.GetInt32(10).ToString(),
                    };

                    users.Add(userInfo);

                    totalCount++;
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

            DisplayUsers(users);
        }

        private void DisplayUsers(List<string[]> userList)
        {
            // Näytetään käyttäjien tiedot

            asiakkaatPanel.SuspendLayout();

            if (asiakkaatPanel.Controls.Count != 0)
            {
                asiakkaatPanel.Controls.Clear();
            }

            this.Height = 490;
            asiakkaatPanel.Height = 75;
            Menu.Height = this.Height - Header.Height - footer.Height;
            footer.Top = 375;

            int newHeight = 0;

            for (int i = 0; i < userList.Count; i++)
            {
                int panelHeight = 50;
                int y = i * panelHeight;

                string[] info = userList[i];

                // Tallennetaan uudet korkeudet

                if (asiakkaatPanel.Controls.Count > 0)
                {
                    newHeight += panelHeight;
                }

                Panel userPanel = new()
                {
                    Name = info[1],
                    Size = new Size(infoPanel.Width, panelHeight),
                    BackColor = Color.FromArgb(255, 241, 220),
                    Font = new Font("Segoe UI", 10),
                    BorderStyle = BorderStyle.FixedSingle,
                    Location = new Point(infoPanel.Left, y)
                };
                userPanel.Click += User_Click;

                asiakkaatPanel.Controls.Add(userPanel);

                List<Control> infoLabels = new();

                foreach (Control control in infoPanel.Controls)
                {
                    infoLabels.Add(control);
                }
                infoLabels.Reverse(); //dependant on the creation order of the labels in the infoPanel

                int labelHeight = 35;

                for (int k = 0; k < info.Length; k++)
                {
                    Control column = infoLabels[k];

                    Label label = new()
                    {
                        Name = $"{userPanel.Name}info",
                        Text = info[k],
                        TextAlign = ContentAlignment.MiddleCenter,
                        Size = new Size(column.Width + 15, labelHeight),
                        Location = new Point(column.Left - 7, (userPanel.Height - labelHeight) / 2)
                    };

                    if (column.Text == "tunnus" || column.Text == "etunimi" || column.Text == "sukunimi" || column.Text == "lähiosoite" || column.Text == "paikkakunta" || column.Text == "puhelinnumero")
                    {
                        FormManager.ShowPartOrFullText(label, infoLabels[k].Text.Length + 3, label.Text, toolTip);
                    }

                    label.Click += User_Click;

                    userPanel.Controls.Add(label);
                }
            }

            // Päivitetään korkeudet uusilla korkeuksilla

            asiakkaatPanel.Height += newHeight;
            //Menu.Height = this.Height - Header.Height - footer.Height;
            Menu.Height = asiakkaatPanel.Bottom - Header.Height;
            footer.Top = Menu.Bottom + 30;
            this.Height = footer.Bottom + (footer.Height / 2);

            asiakkaatPanel.ResumeLayout();
        }

        private void User_Click(object sender, EventArgs e)
        {
            // Avataan klikatun käyttään tiedot

            string asnum = "";

            if (sender is Panel userPanel)
            {
                asnum = userPanel.Controls[0].Text;
            }
            else if (sender is Label userLabel)
            {
                asnum = userLabel.Parent.Controls[0].Text;
            }

            if (asnum != "")
            {
                FormManager.OpenAccountDetails(asnum);
            }
        }

        private void kirjat_Click(object sender, EventArgs e)
        {
            // Palataan aloitussivulle

            FormManager.ToHome(this);
        }

        private void hae_TextChanged(object sender, EventArgs e)
        {
            // Filtteröidään asiakkaita haun perusteella

            string search = hae.Text;

            filter = search != "" ? $"AND {orderBy} LIKE \"{search}%\" " : "";

            LoadUsersFromDatabase();
        }
    }
}

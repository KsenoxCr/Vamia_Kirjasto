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
        private string orderBy = "asnum";
        private string limit = "";
        private decimal totalCount = 0;

        private UserList()
        {
            InitializeComponent();

            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int x = (screenWidth - this.Width) / 2;
            Location = new Point(x, 0);
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
            FormManager.ToggleMenu(Menu, timerUserList);
        }

        private void TimerUserList_Tick(object sender, EventArgs e)
        {
            FormManager.ToggleMenu(Menu, timerUserList);
        }

        private void LogOut_Click(object sender, EventArgs e)
        {
            FormManager.ToHome(this);
        }

        private void UserList_Load(object sender, EventArgs e)
        {
            LoadUsersFromDatabase();

            if (this.Height > 800)
            {
                this.AutoScroll = true;
                this.Width += SystemInformation.VerticalScrollBarWidth;
            }
        }

        private void JarjestysCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (jarjestysCB.SelectedIndex)
            {
                case 0:
                    orderBy = "asnum";
                    break;
                case 1:
                    orderBy = "kayttajatunnus";
                    break;
                case 2:
                    orderBy = "enimi";
                    break;
                case 3:
                    orderBy = "snimi";
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

            string rootPath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..");
            string imagePath = Path.GetFullPath(Path.Combine(rootPath, "Images", arrow));

            orderBox.BackgroundImage = Image.FromFile(imagePath);

            LoadUsersFromDatabase();
        }
        private void LoadUsersFromDatabase()
        {
            List<string[]> users = new();

            try
            {
                db.OpenConnection();

                string query = "SELECT a.asnum, a.kayttajatunnus, a.enimi, a.snimi, a.loso, a.pno, a.ptp, a.puh, "
                        + "(SELECT COUNT(*) FROM Lainaus WHERE astun = a.asnum) AS lainaus_maara, "
                        + "(SELECT COUNT(*) FROM Lainarivi WHERE ltunnus IN (SELECT lainanum FROM Lainaus WHERE astun = a.asnum)) AS kirjojen_maara, "
                        + "(SELECT COUNT(*) FROM Palautteet WHERE astun = a.asnum) AS palautteiden_maara "
                        + "FROM Asiakas AS a WHERE asnum <> \"XXXXXXX\""
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
                                reader.GetInt32(5).ToString(),
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
            //Arvojen nollaus

            asiakkaatPanel.SuspendLayout();

            if (asiakkaatPanel.Controls.Count != 0)
            {
                asiakkaatPanel.Controls.Clear();
            }

            this.Height = 490;
            asiakkaatPanel.Height = 75;
            Menu.Height = this.Height - Header.Height - footer.Height;
            footer.Top = 375;


            int[] newHeights = new int[] { this.Height, asiakkaatPanel.Height, Menu.Height, footer.Top };

            for (int i = 0; i < userList.Count; i++)
            {
                int panelHeight = 50;
                int y = i * panelHeight;

                string[] info = userList[i];

                // Tallennetaan uudet korkeudet

                if (asiakkaatPanel.Controls.Count > 0)
                {
                    newHeights[0] += panelHeight;
                    newHeights[1] += panelHeight;
                    newHeights[2] += panelHeight;
                    newHeights[3] += panelHeight;
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
                userPanel.Click += UserPanel_Click;

                asiakkaatPanel.Controls.Add(userPanel);

                List<Control> infoLabels = new();

                foreach (Control control in infoPanel.Controls)
                {
                    infoLabels.Add(control); //dependant on the creation order of the labels in the infoPanel
                }
                infoLabels.Reverse();

                int labelHeight = 35;

                for (int k = 0; k < info.Length; k++)
                {
                    Label label = new()
                    {
                        //label.Name = labelsTopRow[i] + (i + 1);
                        Text = info[k],
                        TextAlign = ContentAlignment.MiddleCenter,
                        Size = new Size(infoLabels[k].Width, labelHeight),
                        Location = new Point(infoLabels[k].Left, (userPanel.Height - labelHeight) / 2)
                    };

                    userPanel.Controls.Add(label);
                }
            }

            // Päivitetään korkeudet uusilla korkeuksilla

            this.Height = newHeights[0];
            asiakkaatPanel.Height = newHeights[1];
            Menu.Height = newHeights[2];
            footer.Top = newHeights[3];

            asiakkaatPanel.ResumeLayout();
        }
        private void UserPanel_Click(object sender, EventArgs e)
        {
            // Avataan klikatun käyttään tiedot

            Panel userPanel = (Panel)sender;

            string username = userPanel.Name;

            FormManager.OpenAccountDetails(username, "customer");
        }
    }
}

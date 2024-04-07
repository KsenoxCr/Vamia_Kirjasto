using Kirjasto_ohjelma.Properties;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        private static readonly object _lock = new object();

        private DatabaseAccess db = DatabaseAccess.GetInstance();

        private string order = "ASC";
        private string orderBy = "asnum";

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
        private void logo_Click(object sender, EventArgs e)
        {
            FormManager.backToHome(this);
        }
        private void menuButton_Click(object sender, EventArgs e)
        {
            FormManager.toggleMenu(Menu);
        }

        private void kirjaudu_ulos_Click(object sender, EventArgs e)
        {
            FormManager.backToHome(this);
        }
        private void UserList_Load(object sender, EventArgs e)
        {
            loadUsersFromDatabase();

            if (this.Height > 800)
            {
                this.AutoScroll = true;
                this.Width += SystemInformation.VerticalScrollBarWidth;
            }
        }
        private void jarjestysCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "";

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

            loadUsersFromDatabase();
        }
        private void orderByBox_Click(object sender, EventArgs e)
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

            loadUsersFromDatabase();
        }
        private void loadUsersFromDatabase()
        {
            List<string[]> users = new List<string[]>();

            try
            {
                db.OpenConnection();

                string query = "SELECT a.asnum, a.kayttajatunnus, a.enimi, a.snimi, a.loso, a.pno, a.ptp, a.puh, "
                        + "(SELECT COUNT(*) FROM Lainaus WHERE astun = a.asnum) AS lainaus_maara, "
                        + "(SELECT COUNT(*) FROM Lainarivi WHERE ltunnus IN (SELECT lainanum FROM Lainaus WHERE astun = a.asnum)) AS kirjojen_maara, "
                        + "(SELECT COUNT(*) FROM Palautteet WHERE astun = a.asnum) AS palautteiden_maara "
                        + "FROM Asiakas AS a WHERE asnum <> \"XXXXXXX\""
                        + $"ORDER BY {orderBy} {order}";

                using (MySqlCommand command = new MySqlCommand(query, db.connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
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

            displayUsers(users);
        }
        private void displayUsers(List<string[]> userList)
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

                Panel userPanel = new Panel()
                {
                    Name = info[1],
                    Size = new Size(infoPanel.Width, panelHeight),
                    BackColor = Color.FromArgb(255, 241, 220),
                    Font = new Font("Segoe UI", 10),
                    BorderStyle = BorderStyle.FixedSingle
                };
                userPanel.Location = new Point(infoPanel.Left, y);
                userPanel.Click += userPanel_Click;

                asiakkaatPanel.Controls.Add(userPanel);

                List<Control> infoLabels = new List<Control>();

                foreach (Control control in infoPanel.Controls)
                {
                    infoLabels.Add(control); //dependant on the creation order of the labels in the infoPanel
                }
                infoLabels.Reverse();
                    
                int labelHeight = 35;

                for (int k = 0; k < info.Length; k++)
                {
                    Label label = new Label() 
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
        private void userPanel_Click(object sender, EventArgs e)
        {
            // Avataan klikatun käyttään tiedot

            Panel userPanel = (Panel)sender;

            string username = userPanel.Name;

            FormManager.openAccountDetails(username, "customer");
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            FormManager.backToHome(this);
        }
    }
}

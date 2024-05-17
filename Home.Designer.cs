namespace Kirjasto_ohjelma
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            tervetuloa = new Label();
            Header = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            pictureBox1 = new PictureBox();
            menuButton = new PictureBox();
            Menu = new Panel();
            username = new Label();
            lisaa_kirja = new Label();
            asiakkaat = new Label();
            oma_tili = new Label();
            kirjauduUlos = new Label();
            CopyrightLabel = new Label();
            ehdota_kirjaa = new Label();
            palautteet = new Label();
            tuki = new Label();
            label4 = new Label();
            haeKirjojaTB = new TextBox();
            Search = new PictureBox();
            haeKirjoja = new Label();
            selaaKirjoja = new Label();
            footer = new Panel();
            pictureBox15 = new PictureBox();
            panel16 = new Panel();
            panel17 = new Panel();
            kirjaFlowLayoutPanel = new FlowLayoutPanel();
            selausAsetukset = new Panel();
            jarjestys = new Label();
            jarjestysCB = new ComboBox();
            wholeUsername = new ToolTip(components);
            timerHome = new System.Windows.Forms.Timer(components);
            Header.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)menuButton).BeginInit();
            Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Search).BeginInit();
            footer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox15).BeginInit();
            panel16.SuspendLayout();
            selausAsetukset.SuspendLayout();
            SuspendLayout();
            // 
            // tervetuloa
            // 
            tervetuloa.AutoSize = true;
            tervetuloa.BackColor = Color.Transparent;
            tervetuloa.Font = new Font("Elephant", 20F, FontStyle.Regular, GraphicsUnit.Point);
            tervetuloa.Location = new Point(163, -76);
            tervetuloa.Name = "tervetuloa";
            tervetuloa.Size = new Size(501, 70);
            tervetuloa.TabIndex = 11;
            tervetuloa.Text = "Rajaton määrä jänittäviä seikkaluja\r\nja opettavaista tietoa taskussasi";
            tervetuloa.TextAlign = ContentAlignment.TopCenter;
            // 
            // Header
            // 
            Header.BackColor = Color.FromArgb(255, 241, 220);
            Header.Controls.Add(panel2);
            Header.Controls.Add(pictureBox1);
            Header.Controls.Add(menuButton);
            Header.Location = new Point(0, 0);
            Header.Name = "Header";
            Header.Size = new Size(798, 80);
            Header.TabIndex = 8;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel3);
            panel2.Location = new Point(31, 79);
            panel2.Name = "panel2";
            panel2.Size = new Size(121, 376);
            panel2.TabIndex = 3;
            // 
            // panel3
            // 
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(80, 376);
            panel3.TabIndex = 3;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(217, 20);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(302, 38);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // menuButton
            // 
            menuButton.Image = (Image)resources.GetObject("menuButton.Image");
            menuButton.Location = new Point(53, 23);
            menuButton.Name = "menuButton";
            menuButton.Size = new Size(35, 35);
            menuButton.TabIndex = 3;
            menuButton.TabStop = false;
            menuButton.Click += MenuButton_Click;
            // 
            // Menu
            // 
            Menu.BackColor = Color.FromArgb(255, 241, 220);
            Menu.Controls.Add(username);
            Menu.Controls.Add(lisaa_kirja);
            Menu.Controls.Add(asiakkaat);
            Menu.Controls.Add(oma_tili);
            Menu.Controls.Add(kirjauduUlos);
            Menu.Controls.Add(CopyrightLabel);
            Menu.Controls.Add(ehdota_kirjaa);
            Menu.Controls.Add(palautteet);
            Menu.Controls.Add(tuki);
            Menu.Location = new Point(-125, 79);
            Menu.Name = "Menu";
            Menu.Size = new Size(125, 1600);
            Menu.TabIndex = 13;
            Menu.Tag = "Closed";
            // 
            // username
            // 
            username.Font = new Font("Impact", 14F, FontStyle.Regular, GraphicsUnit.Point);
            username.ForeColor = Color.FromArgb(64, 0, 64);
            username.Location = new Point(8, 9);
            username.Name = "username";
            username.Size = new Size(114, 23);
            username.TabIndex = 25;
            username.Text = "Käyttäjänimi";
            // 
            // lisaa_kirja
            // 
            lisaa_kirja.AutoSize = true;
            lisaa_kirja.Cursor = Cursors.Hand;
            lisaa_kirja.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lisaa_kirja.Location = new Point(12, 308);
            lisaa_kirja.Name = "lisaa_kirja";
            lisaa_kirja.Size = new Size(76, 20);
            lisaa_kirja.TabIndex = 24;
            lisaa_kirja.Text = "Lisää kirja";
            lisaa_kirja.Click += AddBook_Click;
            // 
            // asiakkaat
            // 
            asiakkaat.AutoSize = true;
            asiakkaat.Cursor = Cursors.Hand;
            asiakkaat.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point);
            asiakkaat.Location = new Point(12, 278);
            asiakkaat.Name = "asiakkaat";
            asiakkaat.Size = new Size(73, 20);
            asiakkaat.TabIndex = 23;
            asiakkaat.Text = "Asiakkaat";
            asiakkaat.Click += Customers_Click;
            // 
            // oma_tili
            // 
            oma_tili.AutoSize = true;
            oma_tili.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point);
            oma_tili.Location = new Point(12, 40);
            oma_tili.Name = "oma_tili";
            oma_tili.Size = new Size(58, 20);
            oma_tili.TabIndex = 22;
            oma_tili.Text = "Oma tili";
            oma_tili.Click += Profile_Click;
            // 
            // kirjauduUlos
            // 
            kirjauduUlos.AutoSize = true;
            kirjauduUlos.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point);
            kirjauduUlos.Location = new Point(12, 70);
            kirjauduUlos.Name = "kirjauduUlos";
            kirjauduUlos.Size = new Size(96, 20);
            kirjauduUlos.TabIndex = 21;
            kirjauduUlos.Text = "Kirjaudu Ulos";
            kirjauduUlos.Click += LogOut_Click;
            // 
            // CopyrightLabel
            // 
            CopyrightLabel.AutoSize = true;
            CopyrightLabel.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            CopyrightLabel.Location = new Point(10, 400);
            CopyrightLabel.Name = "CopyrightLabel";
            CopyrightLabel.Size = new Size(48, 16);
            CopyrightLabel.TabIndex = 3;
            CopyrightLabel.Text = "Vamia ©";
            // 
            // ehdota_kirjaa
            // 
            ehdota_kirjaa.AutoSize = true;
            ehdota_kirjaa.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ehdota_kirjaa.Location = new Point(10, 188);
            ehdota_kirjaa.Name = "ehdota_kirjaa";
            ehdota_kirjaa.Size = new Size(95, 20);
            ehdota_kirjaa.TabIndex = 2;
            ehdota_kirjaa.Text = "Ehdota Kirjaa";
            ehdota_kirjaa.Click += SuggestBook_Click;
            // 
            // palautteet
            // 
            palautteet.AutoSize = true;
            palautteet.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point);
            palautteet.Location = new Point(12, 248);
            palautteet.Name = "palautteet";
            palautteet.Size = new Size(110, 20);
            palautteet.TabIndex = 1;
            palautteet.Text = "Anna Palautetta";
            palautteet.Click += Feedback_Click;
            // 
            // tuki
            // 
            tuki.AutoSize = true;
            tuki.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tuki.Location = new Point(10, 218);
            tuki.Name = "tuki";
            tuki.Size = new Size(36, 20);
            tuki.TabIndex = 0;
            tuki.Text = "Tuki";
            tuki.Click += Support_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Elephant", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(241, 95);
            label4.Name = "label4";
            label4.Size = new Size(342, 18);
            label4.TabIndex = 15;
            label4.Text = "Uppoudu kirjallisuuden kiehtovaan maailmaan!\r\n";
            // 
            // haeKirjojaTB
            // 
            haeKirjojaTB.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            haeKirjojaTB.Location = new Point(274, 197);
            haeKirjojaTB.Name = "haeKirjojaTB";
            haeKirjojaTB.PlaceholderText = "Etsi";
            haeKirjojaTB.Size = new Size(259, 34);
            haeKirjojaTB.TabIndex = 17;
            haeKirjojaTB.TextChanged += haeKirjojaTB_TextChanged;
            // 
            // Search
            // 
            Search.BackgroundImage = (Image)resources.GetObject("Search.BackgroundImage");
            Search.BorderStyle = BorderStyle.FixedSingle;
            Search.Location = new Point(499, 197);
            Search.Name = "Search";
            Search.Size = new Size(34, 34);
            Search.TabIndex = 18;
            Search.TabStop = false;
            // 
            // haeKirjoja
            // 
            haeKirjoja.AutoSize = true;
            haeKirjoja.BackColor = Color.Transparent;
            haeKirjoja.Font = new Font("Elephant", 16F, FontStyle.Regular, GraphicsUnit.Point);
            haeKirjoja.Location = new Point(294, 148);
            haeKirjoja.Name = "haeKirjoja";
            haeKirjoja.Size = new Size(138, 29);
            haeKirjoja.TabIndex = 19;
            haeKirjoja.Text = "Hae kirjoja";
            // 
            // selaaKirjoja
            // 
            selaaKirjoja.AutoSize = true;
            selaaKirjoja.BackColor = Color.Transparent;
            selaaKirjoja.Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point);
            selaaKirjoja.Location = new Point(172, 18);
            selaaKirjoja.Name = "selaaKirjoja";
            selaaKirjoja.Size = new Size(135, 29);
            selaaKirjoja.TabIndex = 2;
            selaaKirjoja.Text = "Selaa Kirjoja";
            selaaKirjoja.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // footer
            // 
            footer.BackColor = Color.FromArgb(255, 241, 220);
            footer.Controls.Add(pictureBox15);
            footer.Controls.Add(panel16);
            footer.Location = new Point(0, 500);
            footer.Name = "footer";
            footer.Size = new Size(795, 80);
            footer.TabIndex = 17;
            // 
            // pictureBox15
            // 
            pictureBox15.BackgroundImage = (Image)resources.GetObject("pictureBox15.BackgroundImage");
            pictureBox15.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox15.Location = new Point(24, 19);
            pictureBox15.Name = "pictureBox15";
            pictureBox15.Size = new Size(181, 46);
            pictureBox15.TabIndex = 4;
            pictureBox15.TabStop = false;
            pictureBox15.Click += FooterLogo_Click;
            // 
            // panel16
            // 
            panel16.Controls.Add(panel17);
            panel16.Location = new Point(31, 79);
            panel16.Name = "panel16";
            panel16.Size = new Size(121, 376);
            panel16.TabIndex = 3;
            // 
            // panel17
            // 
            panel17.Location = new Point(0, 0);
            panel17.Name = "panel17";
            panel17.Size = new Size(80, 376);
            panel17.TabIndex = 3;
            // 
            // kirjaFlowLayoutPanel
            // 
            kirjaFlowLayoutPanel.BackColor = Color.FromArgb(125, 255, 241, 220);
            kirjaFlowLayoutPanel.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point);
            kirjaFlowLayoutPanel.Location = new Point(117, 342);
            kirjaFlowLayoutPanel.Margin = new Padding(3, 2, 3, 2);
            kirjaFlowLayoutPanel.Name = "kirjaFlowLayoutPanel";
            kirjaFlowLayoutPanel.Size = new Size(560, 224);
            kirjaFlowLayoutPanel.TabIndex = 22;
            // 
            // selausAsetukset
            // 
            selausAsetukset.BackColor = Color.FromArgb(125, 255, 241, 220);
            selausAsetukset.Controls.Add(jarjestys);
            selausAsetukset.Controls.Add(jarjestysCB);
            selausAsetukset.Controls.Add(selaaKirjoja);
            selausAsetukset.Location = new Point(117, 253);
            selausAsetukset.Margin = new Padding(3, 2, 3, 2);
            selausAsetukset.Name = "selausAsetukset";
            selausAsetukset.Size = new Size(560, 94);
            selausAsetukset.TabIndex = 23;
            // 
            // jarjestys
            // 
            jarjestys.AutoSize = true;
            jarjestys.BackColor = Color.Transparent;
            jarjestys.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point);
            jarjestys.Location = new Point(340, 62);
            jarjestys.Name = "jarjestys";
            jarjestys.Size = new Size(68, 20);
            jarjestys.TabIndex = 4;
            jarjestys.Text = "Järjestys";
            jarjestys.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // jarjestysCB
            // 
            jarjestysCB.FormattingEnabled = true;
            jarjestysCB.Items.AddRange(new object[] { "A-Ö", "Ö-A", "Kirjailija A-Ö", "Kirjailija Ö-A ", "Sivut ↑", "Sivut ↓", "Julkaistu ↑", "Julkaistu ↓" });
            jarjestysCB.Location = new Point(429, 62);
            jarjestysCB.Margin = new Padding(3, 2, 3, 2);
            jarjestysCB.Name = "jarjestysCB";
            jarjestysCB.Size = new Size(116, 23);
            jarjestysCB.TabIndex = 3;
            jarjestysCB.Text = "A-Ö";
            jarjestysCB.SelectedIndexChanged += JarjestysCB_SelectedIndexChanged;
            // 
            // timerHome
            // 
            timerHome.Interval = 25;
            timerHome.Tick += TimerHome_Tick;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(800, 661);
            Controls.Add(selausAsetukset);
            Controls.Add(kirjaFlowLayoutPanel);
            Controls.Add(footer);
            Controls.Add(haeKirjoja);
            Controls.Add(Search);
            Controls.Add(label4);
            Controls.Add(haeKirjojaTB);
            Controls.Add(Menu);
            Controls.Add(tervetuloa);
            Controls.Add(Header);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Home";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kirjasto";
            Load += Home_Load;
            Header.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)menuButton).EndInit();
            Menu.ResumeLayout(false);
            Menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Search).EndInit();
            footer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox15).EndInit();
            panel16.ResumeLayout(false);
            selausAsetukset.ResumeLayout(false);
            selausAsetukset.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label tervetuloa;
        private Panel Header;
        private Panel panel2;
        private Panel panel3;
        private PictureBox pictureBox1;
        private PictureBox menuButton;
        private Panel Menu;
        private Label CopyrightLabel;
        private Label ehdota_kirjaa;
        private Label palautteet;
        private Label tuki;
        private Label label4;
        private TextBox haeKirjojaTB;
        private PictureBox Search;
        private Label haeKirjoja;
        private Label selaaKirjoja;
        private Panel footer;
        private Panel panel16;
        private Panel panel17;
        private PictureBox pictureBox15;
        private Label kirjauduUlos;
        private Label oma_tili;
        private Label asiakkaat;
        private FlowLayoutPanel kirjaFlowLayoutPanel;
        private Panel selausAsetukset;
        private Label jarjestys;
        private ComboBox jarjestysCB;
        private Label lisaa_kirja;
        private Label username;
        private ToolTip wholeUsername;
        private System.Windows.Forms.Timer timerHome;
    }
}
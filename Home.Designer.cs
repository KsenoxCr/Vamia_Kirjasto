﻿namespace Kirjasto_ohjelma
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            tervetuloa = new Label();
            Header = new Panel();
            pictureBox3 = new PictureBox();
            hae = new TextBox();
            panel2 = new Panel();
            panel3 = new Panel();
            pictureBox1 = new PictureBox();
            menuButton = new PictureBox();
            Menu = new Panel();
            asiakkaat = new Label();
            oma_tili = new Label();
            kirjauduUlos = new Label();
            label2 = new Label();
            ehdota_kirjaa = new Label();
            palautteet = new Label();
            tuki = new Label();
            label4 = new Label();
            haeIsompi = new TextBox();
            Search = new PictureBox();
            haeKirjoja = new Label();
            label6 = new Label();
            panel15 = new Panel();
            pictureBox15 = new PictureBox();
            panel16 = new Panel();
            panel17 = new Panel();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            kirjaFlowLayoutPanel = new FlowLayoutPanel();
            selausAsetukset = new Panel();
            järjestys = new Label();
            jarjestysCB = new ComboBox();
            Header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)menuButton).BeginInit();
            Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Search).BeginInit();
            panel15.SuspendLayout();
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
            tervetuloa.Location = new Point(186, -102);
            tervetuloa.Name = "tervetuloa";
            tervetuloa.Size = new Size(623, 86);
            tervetuloa.TabIndex = 11;
            tervetuloa.Text = "Rajaton määrä jänittäviä seikkaluja\r\nja opettavaista tietoa taskussasi";
            tervetuloa.TextAlign = ContentAlignment.TopCenter;
            // 
            // Header
            // 
            Header.BackColor = Color.FromArgb(255, 241, 220);
            Header.Controls.Add(pictureBox3);
            Header.Controls.Add(hae);
            Header.Controls.Add(panel2);
            Header.Controls.Add(pictureBox1);
            Header.Controls.Add(menuButton);
            Header.Location = new Point(-34, -243);
            Header.Margin = new Padding(3, 4, 3, 4);
            Header.Name = "Header";
            Header.Size = new Size(983, 107);
            Header.TabIndex = 8;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.White;
            pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.BorderStyle = BorderStyle.FixedSingle;
            pictureBox3.Location = new Point(807, 40);
            pictureBox3.Margin = new Padding(3, 4, 3, 4);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(26, 30);
            pictureBox3.TabIndex = 16;
            pictureBox3.TabStop = false;
            // 
            // hae
            // 
            hae.Location = new Point(697, 40);
            hae.Margin = new Padding(3, 4, 3, 4);
            hae.Name = "hae";
            hae.PlaceholderText = "Etsi";
            hae.Size = new Size(135, 27);
            hae.TabIndex = 4;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel3);
            panel2.Location = new Point(35, 105);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(138, 501);
            panel2.TabIndex = 3;
            // 
            // panel3
            // 
            panel3.Location = new Point(0, 0);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(91, 501);
            panel3.TabIndex = 3;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(183, 27);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(345, 51);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // menuButton
            // 
            menuButton.Image = (Image)resources.GetObject("menuButton.Image");
            menuButton.Location = new Point(61, 31);
            menuButton.Margin = new Padding(3, 4, 3, 4);
            menuButton.Name = "menuButton";
            menuButton.Size = new Size(40, 47);
            menuButton.TabIndex = 3;
            menuButton.TabStop = false;
            menuButton.Click += pictureBox2_Click;
            // 
            // Menu
            // 
            Menu.BackColor = Color.FromArgb(255, 241, 220);
            Menu.Controls.Add(asiakkaat);
            Menu.Controls.Add(oma_tili);
            Menu.Controls.Add(kirjauduUlos);
            Menu.Controls.Add(label2);
            Menu.Controls.Add(ehdota_kirjaa);
            Menu.Controls.Add(palautteet);
            Menu.Controls.Add(tuki);
            Menu.Location = new Point(0, -137);
            Menu.Margin = new Padding(3, 4, 3, 4);
            Menu.Name = "Menu";
            Menu.Size = new Size(143, 2133);
            Menu.TabIndex = 13;
            Menu.Tag = "Closed";
            // 
            // asiakkaat
            // 
            asiakkaat.AutoSize = true;
            asiakkaat.Cursor = Cursors.Hand;
            asiakkaat.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point);
            asiakkaat.Location = new Point(11, 181);
            asiakkaat.Name = "asiakkaat";
            asiakkaat.Size = new Size(92, 25);
            asiakkaat.TabIndex = 23;
            asiakkaat.Text = "Asiakkaat";
            asiakkaat.Click += asiakkaat_Click;
            // 
            // oma_tili
            // 
            oma_tili.AutoSize = true;
            oma_tili.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point);
            oma_tili.Location = new Point(11, 21);
            oma_tili.Name = "oma_tili";
            oma_tili.Size = new Size(73, 25);
            oma_tili.TabIndex = 22;
            oma_tili.Text = "Oma tili";
            oma_tili.Click += label3_Click;
            // 
            // kirjauduUlos
            // 
            kirjauduUlos.AutoSize = true;
            kirjauduUlos.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point);
            kirjauduUlos.Location = new Point(11, 900);
            kirjauduUlos.Name = "kirjauduUlos";
            kirjauduUlos.Size = new Size(119, 25);
            kirjauduUlos.TabIndex = 21;
            kirjauduUlos.Text = "Kirjaudu Ulos";
            kirjauduUlos.Click += kirjauduUlos_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(11, 2000);
            label2.Name = "label2";
            label2.Size = new Size(63, 19);
            label2.TabIndex = 3;
            label2.Text = "Vamia ©";
            // 
            // ehdota_kirjaa
            // 
            ehdota_kirjaa.AutoSize = true;
            ehdota_kirjaa.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ehdota_kirjaa.Location = new Point(11, 141);
            ehdota_kirjaa.Name = "ehdota_kirjaa";
            ehdota_kirjaa.Size = new Size(118, 25);
            ehdota_kirjaa.TabIndex = 2;
            ehdota_kirjaa.Text = "Ehdota Kirjaa";
            ehdota_kirjaa.Click += ehdota_kirjaa_Click;
            // 
            // palautteet
            // 
            palautteet.AutoSize = true;
            palautteet.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point);
            palautteet.Location = new Point(11, 101);
            palautteet.Name = "palautteet";
            palautteet.Size = new Size(139, 25);
            palautteet.TabIndex = 1;
            palautteet.Text = "Anna Palautetta";
            palautteet.Click += palautteet_Click;
            // 
            // tuki
            // 
            tuki.AutoSize = true;
            tuki.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tuki.Location = new Point(11, 63);
            tuki.Name = "tuki";
            tuki.Size = new Size(46, 25);
            tuki.TabIndex = 0;
            tuki.Text = "Tuki";
            tuki.Click += tuki_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Elephant", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(282, 11);
            label4.Name = "label4";
            label4.Size = new Size(400, 22);
            label4.TabIndex = 15;
            label4.Text = "Uppoudu äänikirjojen kiehtovaan maailmaan!\r\n";
            // 
            // haeIsompi
            // 
            haeIsompi.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            haeIsompi.Location = new Point(320, 162);
            haeIsompi.Margin = new Padding(3, 4, 3, 4);
            haeIsompi.Name = "haeIsompi";
            haeIsompi.PlaceholderText = "Etsi";
            haeIsompi.Size = new Size(295, 41);
            haeIsompi.TabIndex = 17;
            // 
            // Search
            // 
            Search.BackgroundImage = (Image)resources.GetObject("Search.BackgroundImage");
            Search.BorderStyle = BorderStyle.FixedSingle;
            Search.Location = new Point(577, 162);
            Search.Margin = new Padding(3, 4, 3, 4);
            Search.Name = "Search";
            Search.Size = new Size(39, 45);
            Search.TabIndex = 18;
            Search.TabStop = false;
            // 
            // haeKirjoja
            // 
            haeKirjoja.AutoSize = true;
            haeKirjoja.BackColor = Color.Transparent;
            haeKirjoja.Font = new Font("Elephant", 16F, FontStyle.Regular, GraphicsUnit.Point);
            haeKirjoja.Location = new Point(389, 97);
            haeKirjoja.Name = "haeKirjoja";
            haeKirjoja.Size = new Size(168, 35);
            haeKirjoja.TabIndex = 19;
            haeKirjoja.Text = "Hae kirjoja";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(188, 24);
            label6.Name = "label6";
            label6.Size = new Size(172, 37);
            label6.TabIndex = 2;
            label6.Text = "Selaa Kirjoja";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel15
            // 
            panel15.BackColor = Color.FromArgb(255, 241, 220);
            panel15.Controls.Add(pictureBox15);
            panel15.Controls.Add(panel16);
            panel15.Location = new Point(1, 1891);
            panel15.Margin = new Padding(3, 4, 3, 4);
            panel15.Name = "panel15";
            panel15.Size = new Size(983, 107);
            panel15.TabIndex = 17;
            // 
            // pictureBox15
            // 
            pictureBox15.BackgroundImage = (Image)resources.GetObject("pictureBox15.BackgroundImage");
            pictureBox15.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox15.Location = new Point(27, 25);
            pictureBox15.Margin = new Padding(3, 4, 3, 4);
            pictureBox15.Name = "pictureBox15";
            pictureBox15.Size = new Size(207, 61);
            pictureBox15.TabIndex = 4;
            pictureBox15.TabStop = false;
            // 
            // panel16
            // 
            panel16.Controls.Add(panel17);
            panel16.Location = new Point(35, 105);
            panel16.Margin = new Padding(3, 4, 3, 4);
            panel16.Name = "panel16";
            panel16.Size = new Size(138, 501);
            panel16.TabIndex = 3;
            // 
            // panel17
            // 
            panel17.Location = new Point(0, 0);
            panel17.Margin = new Padding(3, 4, 3, 4);
            panel17.Name = "panel17";
            panel17.Size = new Size(91, 501);
            panel17.TabIndex = 3;
            // 
            // kirjaFlowLayoutPanel
            // 
            kirjaFlowLayoutPanel.BackColor = Color.FromArgb(125, 255, 241, 220);
            kirjaFlowLayoutPanel.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point);
            kirjaFlowLayoutPanel.Location = new Point(201, 456);
            kirjaFlowLayoutPanel.Name = "kirjaFlowLayoutPanel";
            kirjaFlowLayoutPanel.Size = new Size(560, 390);
            kirjaFlowLayoutPanel.TabIndex = 22;
            // 
            // selausAsetukset
            // 
            selausAsetukset.BackColor = Color.FromArgb(125, 255, 241, 220);
            selausAsetukset.Controls.Add(järjestys);
            selausAsetukset.Controls.Add(jarjestysCB);
            selausAsetukset.Controls.Add(label6);
            selausAsetukset.Location = new Point(201, 337);
            selausAsetukset.Name = "selausAsetukset";
            selausAsetukset.Size = new Size(560, 125);
            selausAsetukset.TabIndex = 23;
            // 
            // järjestys
            // 
            järjestys.AutoSize = true;
            järjestys.BackColor = Color.Transparent;
            järjestys.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point);
            järjestys.Location = new Point(324, 83);
            järjestys.Name = "järjestys";
            järjestys.Size = new Size(84, 25);
            järjestys.TabIndex = 4;
            järjestys.Text = "Järjestys";
            järjestys.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // jarjestysCB
            // 
            jarjestysCB.FormattingEnabled = true;
            jarjestysCB.Items.AddRange(new object[] { "A-Z", "Z-A", "Kirjailija A-Z", "Kirjailija Z-A ", "Sivut ↑", "Sivut ↓", "Julkaistu ↑", "Julkaistu ↓" });
            jarjestysCB.Location = new Point(414, 83);
            jarjestysCB.Name = "jarjestysCB";
            jarjestysCB.Size = new Size(132, 28);
            jarjestysCB.TabIndex = 3;
            jarjestysCB.Text = "A-Z";
            jarjestysCB.SelectedIndexChanged += jarjestysCB_SelectedIndexChanged;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(914, 1055);
            Controls.Add(selausAsetukset);
            Controls.Add(kirjaFlowLayoutPanel);
            Controls.Add(panel15);
            Controls.Add(haeKirjoja);
            Controls.Add(Search);
            Controls.Add(label4);
            Controls.Add(haeIsompi);
            Controls.Add(Menu);
            Controls.Add(tervetuloa);
            Controls.Add(Header);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Home";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kirjasto";
            Load += Form3_Load;
            Header.ResumeLayout(false);
            Header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)menuButton).EndInit();
            Menu.ResumeLayout(false);
            Menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Search).EndInit();
            panel15.ResumeLayout(false);
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
        private Label label2;
        private Label ehdota_kirjaa;
        private Label palautteet;
        private Label tuki;
        private TextBox hae;
        private Label label4;
        private PictureBox pictureBox3;
        private TextBox haeIsompi;
        private PictureBox Search;
        private Label haeKirjoja;
        private Label label6;
        private Panel panel15;
        private Panel panel16;
        private Panel panel17;
        private PictureBox pictureBox15;
        private Label kirjauduUlos;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label oma_tili;
        private Label asiakkaat;
        private FlowLayoutPanel kirjaFlowLayoutPanel;
        private Panel selausAsetukset;
        private Label järjestys;
        private ComboBox jarjestysCB;
    }
}
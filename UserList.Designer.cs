namespace Kirjasto_ohjelma
{
    partial class UserList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserList));
            kayttajatLabel = new Label();
            Header = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            logo = new PictureBox();
            menuButton = new PictureBox();
            pictureBox3 = new PictureBox();
            hae = new TextBox();
            Menu = new Panel();
            kirjaudu_ulos = new Label();
            label2 = new Label();
            kirjat = new Label();
            footer = new Panel();
            pictureBox15 = new PictureBox();
            panel16 = new Panel();
            panel17 = new Panel();
            hakuPanel = new GroupBox();
            infoPanel = new Panel();
            Palautteet = new Label();
            label3 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            kirjatLabel = new Label();
            orderBox = new PictureBox();
            jarjestys = new Label();
            jarjestysCB = new ComboBox();
            label1 = new Label();
            asiakkaatPanel = new GroupBox();
            saveFileDialog1 = new SaveFileDialog();
            Header.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)menuButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            Menu.SuspendLayout();
            footer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox15).BeginInit();
            panel16.SuspendLayout();
            hakuPanel.SuspendLayout();
            infoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)orderBox).BeginInit();
            SuspendLayout();
            // 
            // kayttajatLabel
            // 
            kayttajatLabel.AutoSize = true;
            kayttajatLabel.BackColor = Color.Transparent;
            kayttajatLabel.Font = new Font("Elephant", 24F, FontStyle.Regular, GraphicsUnit.Point);
            kayttajatLabel.Location = new Point(1, 106);
            kayttajatLabel.MinimumSize = new Size(880, 30);
            kayttajatLabel.Name = "kayttajatLabel";
            kayttajatLabel.Size = new Size(880, 41);
            kayttajatLabel.TabIndex = 11;
            kayttajatLabel.Text = "Asiakkaat";
            kayttajatLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Header
            // 
            Header.BackColor = Color.FromArgb(255, 241, 220);
            Header.Controls.Add(panel2);
            Header.Controls.Add(logo);
            Header.Controls.Add(menuButton);
            Header.Location = new Point(-30, -1);
            Header.Name = "Header";
            Header.Size = new Size(925, 80);
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
            // logo
            // 
            logo.BackgroundImage = (Image)resources.GetObject("logo.BackgroundImage");
            logo.Location = new Point(326, 20);
            logo.Name = "logo";
            logo.Size = new Size(302, 38);
            logo.TabIndex = 3;
            logo.TabStop = false;
            logo.Click += logo_Click;
            // 
            // menuButton
            // 
            menuButton.BackgroundImage = (Image)resources.GetObject("menuButton.BackgroundImage");
            menuButton.Location = new Point(53, 23);
            menuButton.Name = "menuButton";
            menuButton.Size = new Size(35, 35);
            menuButton.TabIndex = 3;
            menuButton.TabStop = false;
            menuButton.Click += menuButton_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.White;
            pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.BorderStyle = BorderStyle.FixedSingle;
            pictureBox3.Location = new Point(102, 24);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(23, 23);
            pictureBox3.TabIndex = 16;
            pictureBox3.TabStop = false;
            // 
            // hae
            // 
            hae.Font = new Font("Impact", 10F, FontStyle.Regular, GraphicsUnit.Point);
            hae.Location = new Point(6, 24);
            hae.Name = "hae";
            hae.PlaceholderText = "Etsi";
            hae.Size = new Size(119, 24);
            hae.TabIndex = 4;
            // 
            // Menu
            // 
            Menu.BackColor = Color.FromArgb(255, 241, 220);
            Menu.Controls.Add(kirjaudu_ulos);
            Menu.Controls.Add(label2);
            Menu.Controls.Add(kirjat);
            Menu.Location = new Point(-125, 80);
            Menu.Name = "Menu";
            Menu.Size = new Size(125, 295);
            Menu.TabIndex = 13;
            Menu.Tag = "Closed";
            // 
            // kirjaudu_ulos
            // 
            kirjaudu_ulos.AutoSize = true;
            kirjaudu_ulos.Cursor = Cursors.Hand;
            kirjaudu_ulos.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point);
            kirjaudu_ulos.Location = new Point(10, 56);
            kirjaudu_ulos.Name = "kirjaudu_ulos";
            kirjaudu_ulos.Size = new Size(96, 20);
            kirjaudu_ulos.TabIndex = 22;
            kirjaudu_ulos.Text = "Kirjaudu Ulos";
            kirjaudu_ulos.Click += kirjaudu_ulos_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 1500);
            label2.Name = "label2";
            label2.Size = new Size(48, 16);
            label2.TabIndex = 3;
            label2.Text = "Vamia ©";
            // 
            // kirjat
            // 
            kirjat.AutoSize = true;
            kirjat.Cursor = Cursors.Hand;
            kirjat.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point);
            kirjat.Location = new Point(10, 26);
            kirjat.Name = "kirjat";
            kirjat.Size = new Size(45, 20);
            kirjat.TabIndex = 1;
            kirjat.Text = "Kirjat";
            // 
            // footer
            // 
            footer.BackColor = Color.FromArgb(255, 241, 220);
            footer.Controls.Add(pictureBox15);
            footer.Controls.Add(panel16);
            footer.Location = new Point(1, 375);
            footer.Name = "footer";
            footer.Size = new Size(894, 80);
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
            pictureBox15.Click += pictureBox15_Click;
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
            // hakuPanel
            // 
            hakuPanel.BackColor = Color.FromArgb(125, 255, 241, 220);
            hakuPanel.Controls.Add(infoPanel);
            hakuPanel.Controls.Add(orderBox);
            hakuPanel.Controls.Add(jarjestys);
            hakuPanel.Controls.Add(pictureBox3);
            hakuPanel.Controls.Add(jarjestysCB);
            hakuPanel.Controls.Add(label1);
            hakuPanel.Controls.Add(hae);
            hakuPanel.Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point);
            hakuPanel.Location = new Point(12, 162);
            hakuPanel.Name = "hakuPanel";
            hakuPanel.Size = new Size(872, 115);
            hakuPanel.TabIndex = 20;
            hakuPanel.TabStop = false;
            // 
            // infoPanel
            // 
            infoPanel.BackColor = Color.BlanchedAlmond;
            infoPanel.Controls.Add(Palautteet);
            infoPanel.Controls.Add(label3);
            infoPanel.Controls.Add(label12);
            infoPanel.Controls.Add(label11);
            infoPanel.Controls.Add(label10);
            infoPanel.Controls.Add(label9);
            infoPanel.Controls.Add(label8);
            infoPanel.Controls.Add(label6);
            infoPanel.Controls.Add(label5);
            infoPanel.Controls.Add(label4);
            infoPanel.Controls.Add(kirjatLabel);
            infoPanel.Location = new Point(6, 64);
            infoPanel.Name = "infoPanel";
            infoPanel.Size = new Size(857, 50);
            infoPanel.TabIndex = 0;
            // 
            // Palautteet
            // 
            Palautteet.AutoSize = true;
            Palautteet.Font = new Font("Impact", 11F, FontStyle.Regular, GraphicsUnit.Point);
            Palautteet.Location = new Point(774, 17);
            Palautteet.Name = "Palautteet";
            Palautteet.Size = new Size(76, 19);
            Palautteet.TabIndex = 11;
            Palautteet.Text = "Palautteet";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Impact", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(726, 17);
            label3.Name = "label3";
            label3.Size = new Size(42, 19);
            label3.TabIndex = 10;
            label3.Text = "kirjat";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Impact", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(644, 17);
            label12.Name = "label12";
            label12.Size = new Size(76, 19);
            label12.TabIndex = 9;
            label12.Text = "lainaukset";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Impact", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(530, 17);
            label11.Name = "label11";
            label11.Size = new Size(106, 19);
            label11.TabIndex = 9;
            label11.Text = "puhelinnumero";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Impact", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(435, 17);
            label10.Name = "label10";
            label10.Size = new Size(87, 19);
            label10.TabIndex = 9;
            label10.Text = "paikkakunta";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Impact", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(339, 17);
            label9.Name = "label9";
            label9.Size = new Size(90, 19);
            label9.TabIndex = 9;
            label9.Text = "postinumero";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Impact", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(260, 17);
            label8.Name = "label8";
            label8.Size = new Size(73, 19);
            label8.TabIndex = 9;
            label8.Text = "lähiosoite";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Impact", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(187, 17);
            label6.Name = "label6";
            label6.Size = new Size(67, 19);
            label6.TabIndex = 9;
            label6.Text = "sukunimi";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Impact", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(123, 17);
            label5.Name = "label5";
            label5.Size = new Size(58, 19);
            label5.TabIndex = 9;
            label5.Text = "etunimi";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Impact", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(64, 17);
            label4.Name = "label4";
            label4.Size = new Size(53, 19);
            label4.TabIndex = 9;
            label4.Text = "tunnus";
            // 
            // kirjatLabel
            // 
            kirjatLabel.AutoSize = true;
            kirjatLabel.Font = new Font("Impact", 11F, FontStyle.Regular, GraphicsUnit.Point);
            kirjatLabel.Location = new Point(6, 17);
            kirjatLabel.Name = "kirjatLabel";
            kirjatLabel.Size = new Size(52, 19);
            kirjatLabel.TabIndex = 0;
            kirjatLabel.Text = "asnum";
            kirjatLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // orderBox
            // 
            orderBox.BackColor = Color.Transparent;
            orderBox.BackgroundImage = (Image)resources.GetObject("orderBox.BackgroundImage");
            orderBox.BorderStyle = BorderStyle.FixedSingle;
            orderBox.Location = new Point(839, 24);
            orderBox.Margin = new Padding(0);
            orderBox.Name = "orderBox";
            orderBox.Size = new Size(24, 24);
            orderBox.TabIndex = 17;
            orderBox.TabStop = false;
            orderBox.Click += orderByBox_Click;
            // 
            // jarjestys
            // 
            jarjestys.AutoSize = true;
            jarjestys.BackColor = Color.Transparent;
            jarjestys.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point);
            jarjestys.Location = new Point(636, 24);
            jarjestys.Name = "jarjestys";
            jarjestys.Size = new Size(68, 20);
            jarjestys.TabIndex = 4;
            jarjestys.Text = "Järjestys";
            jarjestys.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // jarjestysCB
            // 
            jarjestysCB.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            jarjestysCB.FormattingEnabled = true;
            jarjestysCB.Items.AddRange(new object[] { "Asiakasnumero", "Kayttajatunnus", "Etunimi", "Sukunimi", "Lainaukset", "Lainatut kirjat", "Palautteet" });
            jarjestysCB.Location = new Point(710, 23);
            jarjestysCB.Margin = new Padding(3, 2, 3, 2);
            jarjestysCB.Name = "jarjestysCB";
            jarjestysCB.Size = new Size(116, 24);
            jarjestysCB.TabIndex = 3;
            jarjestysCB.Text = "A-Z";
            jarjestysCB.SelectedIndexChanged += jarjestysCB_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 21);
            label1.Name = "label1";
            label1.Size = new Size(0, 29);
            label1.TabIndex = 0;
            // 
            // asiakkaatPanel
            // 
            asiakkaatPanel.BackColor = Color.FromArgb(125, 255, 241, 220);
            asiakkaatPanel.Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point);
            asiakkaatPanel.Location = new Point(12, 275);
            asiakkaatPanel.Name = "asiakkaatPanel";
            asiakkaatPanel.Size = new Size(872, 75);
            asiakkaatPanel.TabIndex = 21;
            asiakkaatPanel.TabStop = false;
            // 
            // UserList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(884, 451);
            Controls.Add(asiakkaatPanel);
            Controls.Add(footer);
            Controls.Add(hakuPanel);
            Controls.Add(Menu);
            Controls.Add(kayttajatLabel);
            Controls.Add(Header);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UserList";
            StartPosition = FormStartPosition.Manual;
            Text = "Kirjasto";
            Load += UserList_Load;
            Header.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)logo).EndInit();
            ((System.ComponentModel.ISupportInitialize)menuButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            Menu.ResumeLayout(false);
            Menu.PerformLayout();
            footer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox15).EndInit();
            panel16.ResumeLayout(false);
            hakuPanel.ResumeLayout(false);
            hakuPanel.PerformLayout();
            infoPanel.ResumeLayout(false);
            infoPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)orderBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label kayttajatLabel;
        private Panel Header;
        private Panel panel2;
        private Panel panel3;
        private PictureBox logo;
        private PictureBox menuButton;
        private Panel Menu;
        private Label label2;
        private TextBox hae;
        private PictureBox pictureBox3;
        private GroupBox hakuPanel;
        private Panel footer;
        private Panel panel16;
        private Panel panel17;
        private PictureBox pictureBox15;
        private Label kirjaudu_ulos;
        private Label kirjat;
        private Button button1;
        private Label label1;
        private GroupBox asiakkaatPanel;
        private Label jarjestys;
        private ComboBox jarjestysCB;
        private PictureBox orderBox;
        private SaveFileDialog saveFileDialog1;
        private Panel infoPanel;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label kirjatLabel;
        private Label label3;
        private Label Palautteet;
    }
}
namespace Kirjasto_ohjelma
{
    partial class AccountDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountDetails));
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
            kirjaudu_ulos = new Label();
            label2 = new Label();
            kirjat = new Label();
            groupBox1 = new GroupBox();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label6 = new Label();
            lainaaBtn7 = new Button();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            footer = new Panel();
            pictureBox15 = new PictureBox();
            panel16 = new Panel();
            panel17 = new Panel();
            lainauksetPanel = new GroupBox();
            eiLainauksia = new Label();
            label16 = new Label();
            Header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)menuButton).BeginInit();
            Menu.SuspendLayout();
            groupBox1.SuspendLayout();
            footer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox15).BeginInit();
            panel16.SuspendLayout();
            lainauksetPanel.SuspendLayout();
            SuspendLayout();
            // 
            // tervetuloa
            // 
            tervetuloa.AutoSize = true;
            tervetuloa.BackColor = Color.Transparent;
            tervetuloa.Font = new Font("Elephant", 24F, FontStyle.Regular, GraphicsUnit.Point);
            tervetuloa.Location = new Point(1, 113);
            tervetuloa.MinimumSize = new Size(816, 30);
            tervetuloa.Name = "tervetuloa";
            tervetuloa.Size = new Size(816, 41);
            tervetuloa.TabIndex = 11;
            tervetuloa.Text = "Oma tilisi";
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
            Header.Location = new Point(-30, -1);
            Header.Name = "Header";
            Header.Size = new Size(860, 80);
            Header.TabIndex = 8;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.White;
            pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.BorderStyle = BorderStyle.FixedSingle;
            pictureBox3.Location = new Point(706, 30);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(23, 23);
            pictureBox3.TabIndex = 16;
            pictureBox3.TabStop = false;
            // 
            // hae
            // 
            hae.Location = new Point(610, 30);
            hae.Name = "hae";
            hae.PlaceholderText = "Etsi";
            hae.Size = new Size(119, 23);
            hae.TabIndex = 4;
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
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.Location = new Point(160, 20);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(302, 38);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
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
            // Menu
            // 
            Menu.BackColor = Color.FromArgb(255, 241, 220);
            Menu.Controls.Add(asiakkaat);
            Menu.Controls.Add(kirjaudu_ulos);
            Menu.Controls.Add(label2);
            Menu.Controls.Add(kirjat);
            Menu.Location = new Point(0, 79);
            Menu.Name = "Menu";
            Menu.Size = new Size(125, 1600);
            Menu.TabIndex = 13;
            Menu.Tag = "Closed";
            // 
            // asiakkaat
            // 
            asiakkaat.AutoSize = true;
            asiakkaat.Cursor = Cursors.Hand;
            asiakkaat.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point);
            asiakkaat.Location = new Point(10, 26);
            asiakkaat.Name = "asiakkaat";
            asiakkaat.Size = new Size(73, 20);
            asiakkaat.TabIndex = 23;
            asiakkaat.Text = "Asiakkaat";
            // 
            // kirjaudu_ulos
            // 
            kirjaudu_ulos.AutoSize = true;
            kirjaudu_ulos.Cursor = Cursors.Hand;
            kirjaudu_ulos.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point);
            kirjaudu_ulos.Location = new Point(10, 490);
            kirjaudu_ulos.Name = "kirjaudu_ulos";
            kirjaudu_ulos.Size = new Size(96, 20);
            kirjaudu_ulos.TabIndex = 22;
            kirjaudu_ulos.Text = "Kirjaudu Ulos";
            kirjaudu_ulos.Click += label28_Click;
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
            kirjat.Location = new Point(10, 55);
            kirjat.Name = "kirjat";
            kirjat.Size = new Size(45, 20);
            kirjat.TabIndex = 1;
            kirjat.Text = "Kirjat";
            kirjat.Click += kirjat_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(125, 255, 241, 220);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(lainaaBtn7);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(163, 180);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(491, 193);
            groupBox1.TabIndex = 20;
            groupBox1.TabStop = false;
            // 
            // button3
            // 
            button3.BackColor = Color.Bisque;
            button3.Cursor = Cursors.Hand;
            button3.FlatAppearance.BorderColor = Color.Tan;
            button3.FlatAppearance.BorderSize = 2;
            button3.FlatAppearance.MouseDownBackColor = Color.BurlyWood;
            button3.FlatAppearance.MouseOverBackColor = Color.Tan;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location = new Point(325, 138);
            button3.Name = "button3";
            button3.Size = new Size(64, 31);
            button3.TabIndex = 30;
            button3.Text = "Näytä";
            button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.Bisque;
            button2.Cursor = Cursors.Hand;
            button2.FlatAppearance.BorderColor = Color.Tan;
            button2.FlatAppearance.BorderSize = 2;
            button2.FlatAppearance.MouseDownBackColor = Color.BurlyWood;
            button2.FlatAppearance.MouseOverBackColor = Color.Tan;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(395, 138);
            button2.Name = "button2";
            button2.Size = new Size(64, 31);
            button2.TabIndex = 29;
            button2.Text = "Vaihda";
            button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.Bisque;
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderColor = Color.Tan;
            button1.FlatAppearance.BorderSize = 2;
            button1.FlatAppearance.MouseDownBackColor = Color.BurlyWood;
            button1.FlatAppearance.MouseOverBackColor = Color.Tan;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(395, 99);
            button1.Name = "button1";
            button1.Size = new Size(64, 31);
            button1.TabIndex = 28;
            button1.Text = "Vaihda";
            button1.UseVisualStyleBackColor = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Impact", 25F, FontStyle.Regular, GraphicsUnit.Point);
            label10.ForeColor = Color.FromArgb(0, 0, 64);
            label10.Location = new Point(166, 143);
            label10.Name = "label10";
            label10.Size = new Size(128, 42);
            label10.TabIndex = 27;
            label10.Text = "***********";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Impact", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label9.ForeColor = Color.FromArgb(0, 0, 64);
            label9.Location = new Point(171, 104);
            label9.Name = "label9";
            label9.Size = new Size(165, 22);
            label9.TabIndex = 26;
            label9.Text = "käyttäjä1@gmail.com";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Impact", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label8.ForeColor = Color.FromArgb(0, 0, 64);
            label8.Location = new Point(171, 68);
            label8.Name = "label8";
            label8.Size = new Size(77, 22);
            label8.TabIndex = 25;
            label8.Text = "Käyttäjä1";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Impact", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(21, 104);
            label6.Name = "label6";
            label6.Size = new Size(91, 22);
            label6.TabIndex = 24;
            label6.Text = "Sähköposti";
            // 
            // lainaaBtn7
            // 
            lainaaBtn7.BackColor = Color.Bisque;
            lainaaBtn7.Cursor = Cursors.Hand;
            lainaaBtn7.FlatAppearance.BorderColor = Color.Tan;
            lainaaBtn7.FlatAppearance.BorderSize = 2;
            lainaaBtn7.FlatAppearance.MouseDownBackColor = Color.BurlyWood;
            lainaaBtn7.FlatAppearance.MouseOverBackColor = Color.Tan;
            lainaaBtn7.FlatStyle = FlatStyle.Flat;
            lainaaBtn7.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lainaaBtn7.Location = new Point(395, 63);
            lainaaBtn7.Name = "lainaaBtn7";
            lainaaBtn7.Size = new Size(64, 31);
            lainaaBtn7.TabIndex = 7;
            lainaaBtn7.Text = "Vaihda";
            lainaaBtn7.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Impact", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(21, 143);
            label4.Name = "label4";
            label4.Size = new Size(77, 22);
            label4.TabIndex = 23;
            label4.Text = "Salasana";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Impact", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(21, 68);
            label3.Name = "label3";
            label3.Size = new Size(119, 22);
            label3.TabIndex = 22;
            label3.Text = "Käyttäjätunnus";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Impact", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(21, 24);
            label1.Name = "label1";
            label1.Size = new Size(117, 27);
            label1.TabIndex = 0;
            label1.Text = "Perustiedot";
            // 
            // footer
            // 
            footer.BackColor = Color.FromArgb(255, 241, 220);
            footer.Controls.Add(pictureBox15);
            footer.Controls.Add(panel16);
            footer.Location = new Point(1, 607);
            footer.Name = "footer";
            footer.Size = new Size(860, 80);
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
            // lainauksetPanel
            // 
            lainauksetPanel.BackColor = Color.FromArgb(125, 255, 241, 220);
            lainauksetPanel.Controls.Add(eiLainauksia);
            lainauksetPanel.Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lainauksetPanel.Location = new Point(163, 448);
            lainauksetPanel.Name = "lainauksetPanel";
            lainauksetPanel.Size = new Size(491, 125);
            lainauksetPanel.TabIndex = 31;
            lainauksetPanel.TabStop = false;
            // 
            // eiLainauksia
            // 
            eiLainauksia.AutoSize = true;
            eiLainauksia.BackColor = Color.Transparent;
            eiLainauksia.Font = new Font("Impact", 14F, FontStyle.Regular, GraphicsUnit.Point);
            eiLainauksia.Location = new Point(192, 54);
            eiLainauksia.Name = "eiLainauksia";
            eiLainauksia.Size = new Size(111, 23);
            eiLainauksia.TabIndex = 0;
            eiLainauksia.Text = "Ei Lainauksia";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.BackColor = Color.Transparent;
            label16.Font = new Font("Elephant", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label16.Location = new Point(209, 396);
            label16.MinimumSize = new Size(400, 30);
            label16.Name = "label16";
            label16.Size = new Size(400, 31);
            label16.TabIndex = 32;
            label16.Text = "Lainauksesi";
            label16.TextAlign = ContentAlignment.TopCenter;
            // 
            // Form10
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(800, 681);
            Controls.Add(label16);
            Controls.Add(lainauksetPanel);
            Controls.Add(footer);
            Controls.Add(groupBox1);
            Controls.Add(Menu);
            Controls.Add(tervetuloa);
            Controls.Add(Header);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form10";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kirjasto";
            Load += Form4_Load;
            Header.ResumeLayout(false);
            Header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)menuButton).EndInit();
            Menu.ResumeLayout(false);
            Menu.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            footer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox15).EndInit();
            panel16.ResumeLayout(false);
            lainauksetPanel.ResumeLayout(false);
            lainauksetPanel.PerformLayout();
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
        private TextBox hae;
        private PictureBox pictureBox3;
        private GroupBox groupBox1;
        private Label label1;
        private Button lainaaBtn7;
        private Panel footer;
        private Panel panel16;
        private Panel panel17;
        private PictureBox pictureBox15;
        private Label kirjaudu_ulos;
        private Label kirjat;
        private Label label3;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label6;
        private Label label4;
        private Button button3;
        private Button button2;
        private Button button1;
        private GroupBox lainauksetPanel;
        private Label label16;
        private Label asiakkaat;
        private Label eiLainauksia;
    }
}
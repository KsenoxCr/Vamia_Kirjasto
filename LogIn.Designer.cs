using System.Drawing.Drawing2D;

namespace Kirjasto_ohjelma
{
    partial class LogIn
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogIn));
            Header = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            pictureBox1 = new PictureBox();
            menuButton = new PictureBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            KirjauduSisaan = new GroupBox();
            label3 = new Label();
            henkilokunta = new CheckBox();
            kirjauduSisäänBtn = new Button();
            Password = new Label();
            username = new Label();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            Menu = new Panel();
            label2 = new Label();
            palautteet = new Label();
            tuki = new Label();
            groupBox1 = new GroupBox();
            luoTunnusBtn = new Button();
            label1 = new Label();
            tervetuloa = new Label();
            Header.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)menuButton).BeginInit();
            KirjauduSisaan.SuspendLayout();
            Menu.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // Header
            // 
            Header.BackColor = Color.FromArgb(255, 241, 220);
            Header.Controls.Add(panel2);
            Header.Controls.Add(pictureBox1);
            Header.Controls.Add(menuButton);
            Header.Location = new Point(0, 0);
            Header.Name = "Header";
            Header.Size = new Size(800, 80);
            Header.TabIndex = 0;
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
            pictureBox1.Location = new Point(248, 20);
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
            menuButton.Click += pictureBox2_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // KirjauduSisaan
            // 
            KirjauduSisaan.BackColor = Color.FromArgb(125, 255, 241, 220);
            KirjauduSisaan.Controls.Add(label3);
            KirjauduSisaan.Controls.Add(henkilokunta);
            KirjauduSisaan.Controls.Add(kirjauduSisäänBtn);
            KirjauduSisaan.Controls.Add(Password);
            KirjauduSisaan.Controls.Add(username);
            KirjauduSisaan.Controls.Add(textBox2);
            KirjauduSisaan.Controls.Add(textBox1);
            KirjauduSisaan.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point);
            KirjauduSisaan.Location = new Point(267, 203);
            KirjauduSisaan.Name = "KirjauduSisaan";
            KirjauduSisaan.RightToLeft = RightToLeft.No;
            KirjauduSisaan.Size = new Size(250, 237);
            KirjauduSisaan.TabIndex = 2;
            KirjauduSisaan.TabStop = false;
            KirjauduSisaan.Text = "Kirjaudu sisään";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Impact", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(24, 129);
            label3.Name = "label3";
            label3.Size = new Size(87, 18);
            label3.TabIndex = 5;
            label3.Text = "Henkilökunta:";
            // 
            // henkilokunta
            // 
            henkilokunta.AutoSize = true;
            henkilokunta.Font = new Font("Impact", 15F, FontStyle.Regular, GraphicsUnit.Point);
            henkilokunta.Location = new Point(124, 132);
            henkilokunta.Name = "henkilokunta";
            henkilokunta.Size = new Size(15, 14);
            henkilokunta.TabIndex = 4;
            henkilokunta.TextAlign = ContentAlignment.TopLeft;
            henkilokunta.UseVisualStyleBackColor = true;
            // 
            // kirjauduSisäänBtn
            // 
            kirjauduSisäänBtn.BackColor = Color.Bisque;
            kirjauduSisäänBtn.Cursor = Cursors.Hand;
            kirjauduSisäänBtn.FlatAppearance.BorderColor = Color.Tan;
            kirjauduSisäänBtn.FlatAppearance.BorderSize = 3;
            kirjauduSisäänBtn.FlatAppearance.MouseDownBackColor = Color.BurlyWood;
            kirjauduSisäänBtn.FlatAppearance.MouseOverBackColor = Color.Tan;
            kirjauduSisäänBtn.FlatStyle = FlatStyle.Flat;
            kirjauduSisäänBtn.Font = new Font("Impact", 10F, FontStyle.Regular, GraphicsUnit.Point);
            kirjauduSisäänBtn.Location = new Point(79, 168);
            kirjauduSisäänBtn.Name = "kirjauduSisäänBtn";
            kirjauduSisäänBtn.Size = new Size(100, 50);
            kirjauduSisäänBtn.TabIndex = 2;
            kirjauduSisäänBtn.Text = "Kirjaudu Sisään";
            kirjauduSisäänBtn.UseVisualStyleBackColor = false;
            kirjauduSisäänBtn.Click += kirjauduSisään_Click;
            // 
            // Password
            // 
            Password.AutoSize = true;
            Password.BackColor = Color.Transparent;
            Password.Font = new Font("Impact", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Password.Location = new Point(24, 94);
            Password.Name = "Password";
            Password.Size = new Size(64, 18);
            Password.TabIndex = 3;
            Password.Text = "Salasana:";
            // 
            // username
            // 
            username.AutoSize = true;
            username.BackColor = Color.Transparent;
            username.Font = new Font("Impact", 10F, FontStyle.Regular, GraphicsUnit.Point);
            username.Location = new Point(24, 49);
            username.Name = "username";
            username.Size = new Size(97, 18);
            username.TabIndex = 2;
            username.Text = "Käyttäjätunnus:";
            // 
            // textBox2
            // 
            textBox2.Cursor = Cursors.Hand;
            textBox2.Location = new Point(124, 88);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 27);
            textBox2.TabIndex = 1;
            // 
            // textBox1
            // 
            textBox1.Cursor = Cursors.Hand;
            textBox1.Location = new Point(124, 43);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 27);
            textBox1.TabIndex = 0;
            // 
            // Menu
            // 
            Menu.BackColor = Color.FromArgb(255, 241, 220);
            Menu.Controls.Add(label2);
            Menu.Controls.Add(palautteet);
            Menu.Controls.Add(tuki);
            Menu.Location = new Point(-125, 79);
            Menu.Name = "Menu";
            Menu.Size = new Size(125, 450);
            Menu.TabIndex = 3;
            Menu.Tag = "Closed";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(10, 400);
            label2.Name = "label2";
            label2.Size = new Size(48, 16);
            label2.TabIndex = 3;
            label2.Text = "Vamia ©";
            // 
            // palautteet
            // 
            palautteet.AutoSize = true;
            palautteet.Cursor = Cursors.Hand;
            palautteet.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point);
            palautteet.Location = new Point(10, 55);
            palautteet.Name = "palautteet";
            palautteet.Size = new Size(110, 20);
            palautteet.TabIndex = 1;
            palautteet.Text = "Anna Palautetta";
            palautteet.Click += palautteet_Click;
            // 
            // tuki
            // 
            tuki.AutoSize = true;
            tuki.Cursor = Cursors.Hand;
            tuki.FlatStyle = FlatStyle.Flat;
            tuki.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tuki.Location = new Point(10, 26);
            tuki.Name = "tuki";
            tuki.Size = new Size(36, 20);
            tuki.TabIndex = 0;
            tuki.Text = "Tuki";
            tuki.Click += tuki_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(125, 255, 241, 220);
            groupBox1.Controls.Add(luoTunnusBtn);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(570, 203);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(160, 237);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Uusi käyttäjä";
            // 
            // luoTunnusBtn
            // 
            luoTunnusBtn.BackColor = Color.Bisque;
            luoTunnusBtn.Cursor = Cursors.Hand;
            luoTunnusBtn.FlatAppearance.BorderColor = Color.Tan;
            luoTunnusBtn.FlatAppearance.BorderSize = 3;
            luoTunnusBtn.FlatAppearance.MouseDownBackColor = Color.Tan;
            luoTunnusBtn.FlatAppearance.MouseOverBackColor = Color.PeachPuff;
            luoTunnusBtn.FlatStyle = FlatStyle.Flat;
            luoTunnusBtn.Font = new Font("Impact", 10F, FontStyle.Regular, GraphicsUnit.Point);
            luoTunnusBtn.Location = new Point(35, 168);
            luoTunnusBtn.Name = "luoTunnusBtn";
            luoTunnusBtn.Size = new Size(92, 50);
            luoTunnusBtn.TabIndex = 1;
            luoTunnusBtn.Text = "Luo uusi tunnus";
            luoTunnusBtn.UseVisualStyleBackColor = false;
            luoTunnusBtn.Click += luoTunnusBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Impact", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(35, 49);
            label1.Name = "label1";
            label1.Size = new Size(92, 36);
            label1.TabIndex = 0;
            label1.Text = "Eikö sinulla \r\nole tunnuksia?";
            // 
            // tervetuloa
            // 
            tervetuloa.AutoSize = true;
            tervetuloa.BackColor = Color.Transparent;
            tervetuloa.Font = new Font("Elephant", 20F, FontStyle.Regular, GraphicsUnit.Point);
            tervetuloa.ForeColor = Color.Black;
            tervetuloa.Location = new Point(238, 95);
            tervetuloa.Name = "tervetuloa";
            tervetuloa.Size = new Size(335, 105);
            tervetuloa.TabIndex = 6;
            tervetuloa.Text = "Laaja valikoima kirjoja,\r\naina mukanasi\r\n\r\n";
            tervetuloa.TextAlign = ContentAlignment.TopCenter;
            // 
            // form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(800, 511);
            Controls.Add(groupBox1);
            Controls.Add(tervetuloa);
            Controls.Add(Menu);
            Controls.Add(KirjauduSisaan);
            Controls.Add(Header);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Etusivu";
            Header.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)menuButton).EndInit();
            KirjauduSisaan.ResumeLayout(false);
            KirjauduSisaan.PerformLayout();
            Menu.ResumeLayout(false);
            Menu.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel Header;
        private ContextMenuStrip contextMenuStrip1;
        private GroupBox KirjauduSisaan;
        private PictureBox pictureBox1;
        private TextBox textBox1;
        private Label Password;
        private Label username;
        private TextBox textBox2;
        private PictureBox menuButton;
        private Panel panel2;
        private Panel panel3;
        private Panel Menu;
        private Label tuki;
        private GroupBox groupBox1;
        private Button luoTunnusBtn;
        private Label label1;
        private Label tervetuloa;
        private Button kirjauduSisäänBtn;
        private Label palautteet;
        private Label lbl_varjoteksti1;
        private Label lbl_varjoteksti2;
        private Label label2;
        private Label label3;
        private CheckBox henkilokunta;
    }
}
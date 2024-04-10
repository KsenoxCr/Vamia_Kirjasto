using System.Drawing.Drawing2D;

namespace Kirjasto_ohjelma
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
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
            InputPassword = new TextBox();
            InputUsername = new TextBox();
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
            Header.Margin = new Padding(3, 4, 3, 4);
            Header.Name = "Header";
            Header.Size = new Size(914, 107);
            Header.TabIndex = 0;
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
            pictureBox1.Location = new Point(283, 27);
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
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
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
            KirjauduSisaan.Controls.Add(InputPassword);
            KirjauduSisaan.Controls.Add(InputUsername);
            KirjauduSisaan.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point);
            KirjauduSisaan.Location = new Point(305, 271);
            KirjauduSisaan.Margin = new Padding(3, 4, 3, 4);
            KirjauduSisaan.Name = "KirjauduSisaan";
            KirjauduSisaan.Padding = new Padding(3, 4, 3, 4);
            KirjauduSisaan.RightToLeft = RightToLeft.No;
            KirjauduSisaan.Size = new Size(286, 316);
            KirjauduSisaan.TabIndex = 2;
            KirjauduSisaan.TabStop = false;
            KirjauduSisaan.Text = "Kirjaudu sisään";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Impact", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(27, 172);
            label3.Name = "label3";
            label3.Size = new Size(107, 21);
            label3.TabIndex = 5;
            label3.Text = "Henkilökunta:";
            // 
            // henkilokunta
            // 
            henkilokunta.AutoSize = true;
            henkilokunta.Font = new Font("Impact", 15F, FontStyle.Regular, GraphicsUnit.Point);
            henkilokunta.Location = new Point(142, 176);
            henkilokunta.Margin = new Padding(3, 4, 3, 4);
            henkilokunta.Name = "henkilokunta";
            henkilokunta.Size = new Size(18, 17);
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
            kirjauduSisäänBtn.Location = new Point(90, 224);
            kirjauduSisäänBtn.Margin = new Padding(3, 4, 3, 4);
            kirjauduSisäänBtn.Name = "kirjauduSisäänBtn";
            kirjauduSisäänBtn.Size = new Size(114, 67);
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
            Password.Location = new Point(27, 125);
            Password.Name = "Password";
            Password.Size = new Size(80, 21);
            Password.TabIndex = 3;
            Password.Text = "Salasana:";
            // 
            // username
            // 
            username.AutoSize = true;
            username.BackColor = Color.Transparent;
            username.Font = new Font("Impact", 10F, FontStyle.Regular, GraphicsUnit.Point);
            username.Location = new Point(27, 65);
            username.Name = "username";
            username.Size = new Size(121, 21);
            username.TabIndex = 2;
            username.Text = "Käyttäjätunnus:";
            // 
            // InputPassword
            // 
            InputPassword.Cursor = Cursors.Hand;
            InputPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            InputPassword.Location = new Point(142, 117);
            InputPassword.Margin = new Padding(3, 4, 3, 4);
            InputPassword.Name = "InputPassword";
            InputPassword.PasswordChar = '*';
            InputPassword.Size = new Size(114, 34);
            InputPassword.TabIndex = 1;
            InputPassword.Text = "Työntekijä0501!";
            // 
            // InputUsername
            // 
            InputUsername.Cursor = Cursors.Hand;
            InputUsername.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            InputUsername.Location = new Point(142, 57);
            InputUsername.Margin = new Padding(3, 4, 3, 4);
            InputUsername.Name = "InputUsername";
            InputUsername.Size = new Size(114, 34);
            InputUsername.TabIndex = 0;
            InputUsername.Text = "Akseli_M";
            // 
            // Menu
            // 
            Menu.BackColor = Color.FromArgb(255, 241, 220);
            Menu.Controls.Add(label2);
            Menu.Controls.Add(palautteet);
            Menu.Controls.Add(tuki);
            Menu.Location = new Point(-143, 105);
            Menu.Margin = new Padding(3, 4, 3, 4);
            Menu.Name = "Menu";
            Menu.Size = new Size(143, 600);
            Menu.TabIndex = 3;
            Menu.Tag = "Closed";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(11, 533);
            label2.Name = "label2";
            label2.Size = new Size(63, 19);
            label2.TabIndex = 3;
            label2.Text = "Vamia ©";
            // 
            // palautteet
            // 
            palautteet.AutoSize = true;
            palautteet.Cursor = Cursors.Hand;
            palautteet.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point);
            palautteet.Location = new Point(11, 73);
            palautteet.Name = "palautteet";
            palautteet.Size = new Size(139, 25);
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
            tuki.Location = new Point(11, 35);
            tuki.Name = "tuki";
            tuki.Size = new Size(46, 25);
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
            groupBox1.Location = new Point(651, 271);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(183, 316);
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
            luoTunnusBtn.Location = new Point(40, 224);
            luoTunnusBtn.Margin = new Padding(3, 4, 3, 4);
            luoTunnusBtn.Name = "luoTunnusBtn";
            luoTunnusBtn.Size = new Size(105, 67);
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
            label1.Location = new Point(40, 65);
            label1.Name = "label1";
            label1.Size = new Size(116, 42);
            label1.TabIndex = 0;
            label1.Text = "Eikö sinulla \r\nole tunnuksia?";
            // 
            // tervetuloa
            // 
            tervetuloa.AutoSize = true;
            tervetuloa.BackColor = Color.Transparent;
            tervetuloa.Font = new Font("Elephant", 20F, FontStyle.Regular, GraphicsUnit.Point);
            tervetuloa.ForeColor = Color.Black;
            tervetuloa.Location = new Point(272, 127);
            tervetuloa.Name = "tervetuloa";
            tervetuloa.Size = new Size(418, 129);
            tervetuloa.TabIndex = 6;
            tervetuloa.Text = "Laaja valikoima kirjoja,\r\naina mukanasi\r\n\r\n";
            tervetuloa.TextAlign = ContentAlignment.TopCenter;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(914, 681);
            Controls.Add(groupBox1);
            Controls.Add(tervetuloa);
            Controls.Add(Menu);
            Controls.Add(KirjauduSisaan);
            Controls.Add(Header);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Login";
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
        private TextBox InputUsername;
        private Label Password;
        private Label username;
        private TextBox InputPassword;
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
        private Label label2;
        private Label label3;
        private CheckBox henkilokunta;
    }
}
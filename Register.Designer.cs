namespace Kirjasto_ohjelma
{
    partial class Register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            Header = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            pictureBox1 = new PictureBox();
            menuButton = new PictureBox();
            label2 = new Label();
            panel1 = new Panel();
            passwordAgainLabel = new Label();
            passwordAgain = new TextBox();
            emailLabel = new Label();
            email = new TextBox();
            button1 = new Button();
            usernameLabel = new Label();
            passwordLabel = new Label();
            username = new TextBox();
            password = new TextBox();
            Menu = new Panel();
            label3 = new Label();
            palautteet = new Label();
            tuki = new Label();
            Header.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)menuButton).BeginInit();
            panel1.SuspendLayout();
            Menu.SuspendLayout();
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
            pictureBox1.Location = new Point(286, 20);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(302, 38);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
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
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Impact", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(310, 110);
            label2.Name = "label2";
            label2.Size = new Size(202, 34);
            label2.TabIndex = 12;
            label2.Text = "Luo uusi käyttäjä";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(125, 255, 241, 220);
            panel1.Controls.Add(passwordAgainLabel);
            panel1.Controls.Add(passwordAgain);
            panel1.Controls.Add(emailLabel);
            panel1.Controls.Add(email);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(usernameLabel);
            panel1.Controls.Add(passwordLabel);
            panel1.Controls.Add(username);
            panel1.Controls.Add(password);
            panel1.Location = new Point(286, 166);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 253);
            panel1.TabIndex = 13;
            // 
            // passwordAgainLabel
            // 
            passwordAgainLabel.AutoSize = true;
            passwordAgainLabel.BackColor = Color.Transparent;
            passwordAgainLabel.Font = new Font("Impact", 10F, FontStyle.Regular, GraphicsUnit.Point);
            passwordAgainLabel.Location = new Point(24, 118);
            passwordAgainLabel.Name = "passwordAgainLabel";
            passwordAgainLabel.Size = new Size(68, 36);
            passwordAgainLabel.TabIndex = 12;
            passwordAgainLabel.Text = "Salasana \r\nuudelleen:";
            // 
            // passwordAgain
            // 
            passwordAgain.Cursor = Cursors.Hand;
            passwordAgain.Location = new Point(124, 125);
            passwordAgain.Name = "passwordAgain";
            passwordAgain.Size = new Size(100, 23);
            passwordAgain.TabIndex = 11;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.BackColor = Color.Transparent;
            emailLabel.Font = new Font("Impact", 10F, FontStyle.Regular, GraphicsUnit.Point);
            emailLabel.Location = new Point(24, 48);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(72, 18);
            emailLabel.TabIndex = 10;
            emailLabel.Text = "sähköposti";
            // 
            // email
            // 
            email.Cursor = Cursors.Hand;
            email.Location = new Point(124, 47);
            email.Name = "email";
            email.Size = new Size(100, 23);
            email.TabIndex = 9;
            // 
            // button1
            // 
            button1.BackColor = Color.Bisque;
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderColor = Color.Tan;
            button1.FlatAppearance.BorderSize = 3;
            button1.FlatAppearance.MouseDownBackColor = Color.BurlyWood;
            button1.FlatAppearance.MouseOverBackColor = Color.Tan;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Impact", 10F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(77, 176);
            button1.Name = "button1";
            button1.Size = new Size(100, 50);
            button1.TabIndex = 6;
            button1.Text = "Luo uusi tunnus";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.BackColor = Color.Transparent;
            usernameLabel.Font = new Font("Impact", 10F, FontStyle.Regular, GraphicsUnit.Point);
            usernameLabel.Location = new Point(24, 15);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(97, 18);
            usernameLabel.TabIndex = 7;
            usernameLabel.Text = "Käyttäjätunnus:";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.BackColor = Color.Transparent;
            passwordLabel.Font = new Font("Impact", 10F, FontStyle.Regular, GraphicsUnit.Point);
            passwordLabel.Location = new Point(24, 83);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(64, 18);
            passwordLabel.TabIndex = 8;
            passwordLabel.Text = "Salasana:";
            // 
            // username
            // 
            username.Cursor = Cursors.Hand;
            username.Location = new Point(124, 14);
            username.Name = "username";
            username.Size = new Size(100, 23);
            username.TabIndex = 4;
            // 
            // password
            // 
            password.Cursor = Cursors.Hand;
            password.Location = new Point(124, 82);
            password.Name = "password";
            password.Size = new Size(100, 23);
            password.TabIndex = 5;
            // 
            // Menu
            // 
            Menu.BackColor = Color.FromArgb(255, 241, 220);
            Menu.Controls.Add(label3);
            Menu.Controls.Add(palautteet);
            Menu.Controls.Add(tuki);
            Menu.Location = new Point(-125, 79);
            Menu.Name = "Menu";
            Menu.Size = new Size(125, 373);
            Menu.TabIndex = 14;
            Menu.Tag = "Closed";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(10, 335);
            label3.Name = "label3";
            label3.Size = new Size(48, 16);
            label3.TabIndex = 3;
            label3.Text = "Vamia ©";
            // 
            // palautteet
            // 
            palautteet.AutoSize = true;
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
            tuki.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tuki.Location = new Point(10, 26);
            tuki.Name = "tuki";
            tuki.Size = new Size(36, 20);
            tuki.TabIndex = 0;
            tuki.Text = "Tuki";
            tuki.Click += tuki_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(800, 450);
            Controls.Add(Menu);
            Controls.Add(panel1);
            Controls.Add(label2);
            Controls.Add(Header);
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Uusi käyttäjä";
            Header.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)menuButton).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            Menu.ResumeLayout(false);
            Menu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel Header;
        private Panel panel2;
        private Panel panel3;
        private PictureBox pictureBox1;
        private PictureBox menuButton;
        private Label label2;
        private Panel panel1;
        private Button button1;
        private Label usernameLabel;
        private Label passwordLabel;
        private TextBox username;
        private TextBox password;
        private Label emailLabel;
        private TextBox email;
        private Label passwordAgainLabel;
        private TextBox passwordAgain;
        private Panel Menu;
        private Label label3;
        private Label palautteet;
        private Label tuki;
    }
}
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
            label1 = new Label();
            sukunimi = new TextBox();
            passwordAgainLabel = new Label();
            salasanaUudelleen = new TextBox();
            emailLabel = new Label();
            etunimi = new TextBox();
            button1 = new Button();
            usernameLabel = new Label();
            passwordLabel = new Label();
            kayttajatunnus = new TextBox();
            salasana = new TextBox();
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
            Header.Margin = new Padding(3, 4, 3, 4);
            Header.Name = "Header";
            Header.Size = new Size(914, 107);
            Header.TabIndex = 8;
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
            pictureBox1.Location = new Point(327, 27);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(345, 51);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
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
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Impact", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(354, 147);
            label2.Name = "label2";
            label2.Size = new Size(251, 42);
            label2.TabIndex = 12;
            label2.Text = "Luo uusi käyttäjä";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(125, 255, 241, 220);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(sukunimi);
            panel1.Controls.Add(passwordAgainLabel);
            panel1.Controls.Add(salasanaUudelleen);
            panel1.Controls.Add(emailLabel);
            panel1.Controls.Add(etunimi);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(usernameLabel);
            panel1.Controls.Add(passwordLabel);
            panel1.Controls.Add(kayttajatunnus);
            panel1.Controls.Add(salasana);
            panel1.Location = new Point(327, 221);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(297, 337);
            panel1.TabIndex = 13;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Impact", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(27, 110);
            label1.Name = "label1";
            label1.Size = new Size(77, 21);
            label1.TabIndex = 14;
            label1.Text = "Sukunimi";
            // 
            // sukunimi
            // 
            sukunimi.Cursor = Cursors.Hand;
            sukunimi.Location = new Point(142, 109);
            sukunimi.Margin = new Padding(3, 4, 3, 4);
            sukunimi.Name = "sukunimi";
            sukunimi.Size = new Size(114, 27);
            sukunimi.TabIndex = 13;
            // 
            // passwordAgainLabel
            // 
            passwordAgainLabel.AutoSize = true;
            passwordAgainLabel.BackColor = Color.Transparent;
            passwordAgainLabel.Font = new Font("Impact", 10F, FontStyle.Regular, GraphicsUnit.Point);
            passwordAgainLabel.Location = new Point(27, 189);
            passwordAgainLabel.Name = "passwordAgainLabel";
            passwordAgainLabel.Size = new Size(86, 42);
            passwordAgainLabel.TabIndex = 12;
            passwordAgainLabel.Text = "Salasana \r\nuudelleen:";
            // 
            // salasanaUudelleen
            // 
            salasanaUudelleen.Cursor = Cursors.Hand;
            salasanaUudelleen.Location = new Point(142, 199);
            salasanaUudelleen.Margin = new Padding(3, 4, 3, 4);
            salasanaUudelleen.Name = "salasanaUudelleen";
            salasanaUudelleen.PasswordChar = '*';
            salasanaUudelleen.Size = new Size(114, 27);
            salasanaUudelleen.TabIndex = 11;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.BackColor = Color.Transparent;
            emailLabel.Font = new Font("Impact", 10F, FontStyle.Regular, GraphicsUnit.Point);
            emailLabel.Location = new Point(27, 64);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(63, 21);
            emailLabel.TabIndex = 10;
            emailLabel.Text = "Etunimi";
            // 
            // etunimi
            // 
            etunimi.Cursor = Cursors.Hand;
            etunimi.Location = new Point(142, 63);
            etunimi.Margin = new Padding(3, 4, 3, 4);
            etunimi.Name = "etunimi";
            etunimi.Size = new Size(114, 27);
            etunimi.TabIndex = 15;
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
            button1.Location = new Point(79, 250);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(114, 67);
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
            usernameLabel.Location = new Point(27, 20);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(121, 21);
            usernameLabel.TabIndex = 7;
            usernameLabel.Text = "Käyttäjätunnus:";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.BackColor = Color.Transparent;
            passwordLabel.Font = new Font("Impact", 10F, FontStyle.Regular, GraphicsUnit.Point);
            passwordLabel.Location = new Point(27, 158);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(80, 21);
            passwordLabel.TabIndex = 8;
            passwordLabel.Text = "Salasana:";
            // 
            // kayttajatunnus
            // 
            kayttajatunnus.Cursor = Cursors.Hand;
            kayttajatunnus.Location = new Point(142, 19);
            kayttajatunnus.Margin = new Padding(3, 4, 3, 4);
            kayttajatunnus.Name = "kayttajatunnus";
            kayttajatunnus.Size = new Size(114, 27);
            kayttajatunnus.TabIndex = 4;
            // 
            // salasana
            // 
            salasana.Cursor = Cursors.Hand;
            salasana.Location = new Point(142, 156);
            salasana.Margin = new Padding(3, 4, 3, 4);
            salasana.Name = "salasana";
            salasana.PasswordChar = '*';
            salasana.Size = new Size(114, 27);
            salasana.TabIndex = 5;
            // 
            // Menu
            // 
            Menu.BackColor = Color.FromArgb(255, 241, 220);
            Menu.Controls.Add(label3);
            Menu.Controls.Add(palautteet);
            Menu.Controls.Add(tuki);
            Menu.Location = new Point(-143, 105);
            Menu.Margin = new Padding(3, 4, 3, 4);
            Menu.Name = "Menu";
            Menu.Size = new Size(143, 497);
            Menu.TabIndex = 14;
            Menu.Tag = "Closed";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(11, 447);
            label3.Name = "label3";
            label3.Size = new Size(63, 19);
            label3.TabIndex = 3;
            label3.Text = "Vamia ©";
            // 
            // palautteet
            // 
            palautteet.AutoSize = true;
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
            tuki.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tuki.Location = new Point(11, 35);
            tuki.Name = "tuki";
            tuki.Size = new Size(46, 25);
            tuki.TabIndex = 0;
            tuki.Text = "Tuki";
            tuki.Click += tuki_Click;
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(914, 600);
            Controls.Add(Menu);
            Controls.Add(panel1);
            Controls.Add(label2);
            Controls.Add(Header);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Register";
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
        private TextBox kayttajatunnus;
        private TextBox salasana;
        private Label passwordAgainLabel;
        private TextBox salasanaUudelleen;
        private Panel Menu;
        private Label label3;
        private Label palautteet;
        private Label tuki;
        private Label label1;
        private TextBox sukunimi;
        private Label emailLabel;
        private TextBox etunimi;
    }
}
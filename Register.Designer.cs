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
            logo = new PictureBox();
            menuButton = new PictureBox();
            label2 = new Label();
            panel1 = new Panel();
            label1 = new Label();
            sukunimi = new TextBox();
            passwordAgainLabel = new Label();
            salasanaUudelleen = new TextBox();
            emailLabel = new Label();
            etunimi = new TextBox();
            luoTunnusBtn = new Button();
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
            ((System.ComponentModel.ISupportInitialize)logo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)menuButton).BeginInit();
            panel1.SuspendLayout();
            Menu.SuspendLayout();
            SuspendLayout();
            // 
            // Header
            // 
            Header.BackColor = Color.FromArgb(255, 241, 220);
            Header.Controls.Add(panel2);
            Header.Controls.Add(logo);
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
            // logo
            // 
            logo.Image = (Image)resources.GetObject("logo.Image");
            logo.Location = new Point(286, 20);
            logo.Name = "logo";
            logo.Size = new Size(302, 38);
            logo.TabIndex = 3;
            logo.TabStop = false;
            logo.Click += logo_Click;
            // 
            // menuButton
            // 
            menuButton.Image = (Image)resources.GetObject("menuButton.Image");
            menuButton.Location = new Point(53, 23);
            menuButton.Name = "menuButton";
            menuButton.Size = new Size(35, 35);
            menuButton.TabIndex = 3;
            menuButton.TabStop = false;
            menuButton.Click += menuButton_Click;
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
            panel1.Controls.Add(label1);
            panel1.Controls.Add(sukunimi);
            panel1.Controls.Add(passwordAgainLabel);
            panel1.Controls.Add(salasanaUudelleen);
            panel1.Controls.Add(emailLabel);
            panel1.Controls.Add(etunimi);
            panel1.Controls.Add(luoTunnusBtn);
            panel1.Controls.Add(usernameLabel);
            panel1.Controls.Add(passwordLabel);
            panel1.Controls.Add(kayttajatunnus);
            panel1.Controls.Add(salasana);
            panel1.Location = new Point(286, 166);
            panel1.Name = "panel1";
            panel1.Size = new Size(260, 253);
            panel1.TabIndex = 13;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Impact", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(24, 82);
            label1.Name = "label1";
            label1.Size = new Size(61, 18);
            label1.TabIndex = 14;
            label1.Text = "Sukunimi";
            // 
            // sukunimi
            // 
            sukunimi.Cursor = Cursors.Hand;
            sukunimi.Location = new Point(124, 82);
            sukunimi.Name = "sukunimi";
            sukunimi.Size = new Size(100, 23);
            sukunimi.TabIndex = 13;
            // 
            // passwordAgainLabel
            // 
            passwordAgainLabel.AutoSize = true;
            passwordAgainLabel.BackColor = Color.Transparent;
            passwordAgainLabel.Font = new Font("Impact", 10F, FontStyle.Regular, GraphicsUnit.Point);
            passwordAgainLabel.Location = new Point(24, 142);
            passwordAgainLabel.Name = "passwordAgainLabel";
            passwordAgainLabel.Size = new Size(68, 36);
            passwordAgainLabel.TabIndex = 12;
            passwordAgainLabel.Text = "Salasana \r\nuudelleen:";
            // 
            // salasanaUudelleen
            // 
            salasanaUudelleen.Cursor = Cursors.Hand;
            salasanaUudelleen.Location = new Point(124, 149);
            salasanaUudelleen.Name = "salasanaUudelleen";
            salasanaUudelleen.PasswordChar = '*';
            salasanaUudelleen.Size = new Size(100, 23);
            salasanaUudelleen.TabIndex = 11;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.BackColor = Color.Transparent;
            emailLabel.Font = new Font("Impact", 10F, FontStyle.Regular, GraphicsUnit.Point);
            emailLabel.Location = new Point(24, 48);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(50, 18);
            emailLabel.TabIndex = 10;
            emailLabel.Text = "Etunimi";
            // 
            // etunimi
            // 
            etunimi.Cursor = Cursors.Hand;
            etunimi.Location = new Point(124, 47);
            etunimi.Name = "etunimi";
            etunimi.Size = new Size(100, 23);
            etunimi.TabIndex = 15;
            // 
            // luoTunnusBtn
            // 
            luoTunnusBtn.BackColor = Color.Bisque;
            luoTunnusBtn.Cursor = Cursors.Hand;
            luoTunnusBtn.FlatAppearance.BorderColor = Color.Tan;
            luoTunnusBtn.FlatAppearance.BorderSize = 3;
            luoTunnusBtn.FlatAppearance.MouseDownBackColor = Color.BurlyWood;
            luoTunnusBtn.FlatAppearance.MouseOverBackColor = Color.Tan;
            luoTunnusBtn.FlatStyle = FlatStyle.Flat;
            luoTunnusBtn.Font = new Font("Impact", 10F, FontStyle.Regular, GraphicsUnit.Point);
            luoTunnusBtn.Location = new Point(69, 188);
            luoTunnusBtn.Name = "luoTunnusBtn";
            luoTunnusBtn.Size = new Size(100, 50);
            luoTunnusBtn.TabIndex = 6;
            luoTunnusBtn.Text = "Luo uusi tunnus";
            luoTunnusBtn.UseVisualStyleBackColor = false;
            luoTunnusBtn.Click += luoTunnusBtn_Click;
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
            passwordLabel.Location = new Point(24, 118);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(64, 18);
            passwordLabel.TabIndex = 8;
            passwordLabel.Text = "Salasana:";
            // 
            // kayttajatunnus
            // 
            kayttajatunnus.Cursor = Cursors.Hand;
            kayttajatunnus.Location = new Point(124, 14);
            kayttajatunnus.Name = "kayttajatunnus";
            kayttajatunnus.Size = new Size(100, 23);
            kayttajatunnus.TabIndex = 4;
            // 
            // salasana
            // 
            salasana.Cursor = Cursors.Hand;
            salasana.Location = new Point(124, 117);
            salasana.Name = "salasana";
            salasana.PasswordChar = '*';
            salasana.Size = new Size(100, 23);
            salasana.TabIndex = 5;
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
            // Register
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(800, 450);
            Controls.Add(Menu);
            Controls.Add(panel1);
            Controls.Add(label2);
            Controls.Add(Header);
            Name = "Register";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Uusi käyttäjä";
            Header.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)logo).EndInit();
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
        private PictureBox logo;
        private PictureBox menuButton;
        private Label label2;
        private Panel panel1;
        private Button luoTunnusBtn;
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
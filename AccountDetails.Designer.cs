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
            footer = new Panel();
            pictureBox15 = new PictureBox();
            panel16 = new Panel();
            panel17 = new Panel();
            label2 = new Label();
            kirjat = new Label();
            groupBox1 = new GroupBox();
            enimiPanel = new Panel();
            vaihdaEnimi = new Button();
            label5 = new Label();
            enimi = new Label();
            snimiPanel = new Panel();
            vaihdaSnimi = new Button();
            snimi = new Label();
            snimiLabel = new Label();
            kayttajatunnusPanel = new Panel();
            vaihdaKtunnus = new Button();
            label3 = new Label();
            kayttajatunnus = new Label();
            salasanaPanel = new Panel();
            vaihdaSalasana = new Button();
            label4 = new Label();
            salasana = new Label();
            puhPanel = new Panel();
            puhLabel = new Label();
            puh = new Label();
            vaihdaPuh = new Button();
            ptpPanel = new Panel();
            ptpLabel = new Label();
            ptp = new Label();
            vaihdaPtp = new Button();
            label1 = new Label();
            pnoPanel = new Panel();
            pnoLabel = new Label();
            pno = new Label();
            vaihdaPno = new Button();
            losoPanel = new Panel();
            loso = new Label();
            losoLabel = new Label();
            vaihdaLoso = new Button();
            tyonim = new Label();
            tyonimLabel = new Label();
            lisatiedot = new Label();
            lainauksetPanel = new GroupBox();
            eiLainauksia = new Label();
            label16 = new Label();
            Header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)menuButton).BeginInit();
            Menu.SuspendLayout();
            footer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox15).BeginInit();
            panel16.SuspendLayout();
            groupBox1.SuspendLayout();
            enimiPanel.SuspendLayout();
            snimiPanel.SuspendLayout();
            kayttajatunnusPanel.SuspendLayout();
            salasanaPanel.SuspendLayout();
            puhPanel.SuspendLayout();
            ptpPanel.SuspendLayout();
            pnoPanel.SuspendLayout();
            losoPanel.SuspendLayout();
            lainauksetPanel.SuspendLayout();
            SuspendLayout();
            // 
            // tervetuloa
            // 
            tervetuloa.AutoSize = true;
            tervetuloa.BackColor = Color.Transparent;
            tervetuloa.Font = new Font("Elephant", 24F, FontStyle.Regular, GraphicsUnit.Point);
            tervetuloa.Location = new Point(1, 105);
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
            pictureBox1.Click += Logo_Click;
            // 
            // menuButton
            // 
            menuButton.BackgroundImage = (Image)resources.GetObject("menuButton.BackgroundImage");
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
            Menu.Controls.Add(asiakkaat);
            Menu.Controls.Add(kirjaudu_ulos);
            Menu.Controls.Add(footer);
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
            asiakkaat.Click += Customers_Click;
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
            kirjaudu_ulos.Click += LogOut_Click;
            // 
            // footer
            // 
            footer.BackColor = Color.FromArgb(255, 241, 220);
            footer.Controls.Add(pictureBox15);
            footer.Controls.Add(panel16);
            footer.Location = new Point(0, 654);
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
            kirjat.Click += Books_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(125, 255, 241, 220);
            groupBox1.Controls.Add(enimiPanel);
            groupBox1.Controls.Add(snimiPanel);
            groupBox1.Controls.Add(kayttajatunnusPanel);
            groupBox1.Controls.Add(salasanaPanel);
            groupBox1.Controls.Add(puhPanel);
            groupBox1.Controls.Add(ptpPanel);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(pnoPanel);
            groupBox1.Controls.Add(losoPanel);
            groupBox1.Controls.Add(tyonim);
            groupBox1.Controls.Add(tyonimLabel);
            groupBox1.Controls.Add(lisatiedot);
            groupBox1.Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(163, 162);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(491, 370);
            groupBox1.TabIndex = 20;
            groupBox1.TabStop = false;
            // 
            // enimiPanel
            // 
            enimiPanel.BackColor = Color.Transparent;
            enimiPanel.Controls.Add(vaihdaEnimi);
            enimiPanel.Controls.Add(label5);
            enimiPanel.Controls.Add(enimi);
            enimiPanel.Location = new Point(28, 36);
            enimiPanel.Name = "enimiPanel";
            enimiPanel.Size = new Size(309, 35);
            enimiPanel.TabIndex = 55;
            // 
            // vaihdaEnimi
            // 
            vaihdaEnimi.BackColor = Color.Bisque;
            vaihdaEnimi.Cursor = Cursors.Hand;
            vaihdaEnimi.FlatAppearance.BorderColor = Color.Tan;
            vaihdaEnimi.FlatAppearance.BorderSize = 2;
            vaihdaEnimi.FlatAppearance.MouseDownBackColor = Color.BurlyWood;
            vaihdaEnimi.FlatAppearance.MouseOverBackColor = Color.Tan;
            vaihdaEnimi.FlatStyle = FlatStyle.Flat;
            vaihdaEnimi.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            vaihdaEnimi.Location = new Point(250, 5);
            vaihdaEnimi.Name = "vaihdaEnimi";
            vaihdaEnimi.Size = new Size(55, 25);
            vaihdaEnimi.TabIndex = 48;
            vaihdaEnimi.Text = "Vaihda";
            vaihdaEnimi.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Impact", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(5, 9);
            label5.Name = "label5";
            label5.Size = new Size(59, 19);
            label5.TabIndex = 43;
            label5.Text = "Etunimi:";
            // 
            // enimi
            // 
            enimi.AutoSize = true;
            enimi.BackColor = Color.Transparent;
            enimi.Font = new Font("Impact", 11F, FontStyle.Regular, GraphicsUnit.Point);
            enimi.ForeColor = Color.FromArgb(0, 0, 64);
            enimi.Location = new Point(130, 9);
            enimi.Name = "enimi";
            enimi.Size = new Size(58, 19);
            enimi.TabIndex = 45;
            enimi.Text = "etunimi";
            // 
            // snimiPanel
            // 
            snimiPanel.BackColor = Color.Transparent;
            snimiPanel.Controls.Add(vaihdaSnimi);
            snimiPanel.Controls.Add(snimi);
            snimiPanel.Controls.Add(snimiLabel);
            snimiPanel.Location = new Point(28, 72);
            snimiPanel.Name = "snimiPanel";
            snimiPanel.Size = new Size(309, 35);
            snimiPanel.TabIndex = 54;
            // 
            // vaihdaSnimi
            // 
            vaihdaSnimi.BackColor = Color.Bisque;
            vaihdaSnimi.Cursor = Cursors.Hand;
            vaihdaSnimi.FlatAppearance.BorderColor = Color.Tan;
            vaihdaSnimi.FlatAppearance.BorderSize = 2;
            vaihdaSnimi.FlatAppearance.MouseDownBackColor = Color.BurlyWood;
            vaihdaSnimi.FlatAppearance.MouseOverBackColor = Color.Tan;
            vaihdaSnimi.FlatStyle = FlatStyle.Flat;
            vaihdaSnimi.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            vaihdaSnimi.Location = new Point(250, 5);
            vaihdaSnimi.Name = "vaihdaSnimi";
            vaihdaSnimi.Size = new Size(55, 25);
            vaihdaSnimi.TabIndex = 48;
            vaihdaSnimi.Text = "Vaihda";
            vaihdaSnimi.UseVisualStyleBackColor = false;
            // 
            // snimi
            // 
            snimi.AutoSize = true;
            snimi.BackColor = Color.Transparent;
            snimi.Font = new Font("Impact", 11F, FontStyle.Regular, GraphicsUnit.Point);
            snimi.ForeColor = Color.FromArgb(0, 0, 64);
            snimi.Location = new Point(130, 9);
            snimi.Name = "snimi";
            snimi.Size = new Size(67, 19);
            snimi.TabIndex = 45;
            snimi.Text = "sukunimi";
            // 
            // snimiLabel
            // 
            snimiLabel.AutoSize = true;
            snimiLabel.BackColor = Color.Transparent;
            snimiLabel.Font = new Font("Impact", 11F, FontStyle.Regular, GraphicsUnit.Point);
            snimiLabel.Location = new Point(5, 9);
            snimiLabel.Name = "snimiLabel";
            snimiLabel.Size = new Size(71, 19);
            snimiLabel.TabIndex = 44;
            snimiLabel.Text = "Sukunimi:";
            // 
            // kayttajatunnusPanel
            // 
            kayttajatunnusPanel.BackColor = Color.Transparent;
            kayttajatunnusPanel.Controls.Add(vaihdaKtunnus);
            kayttajatunnusPanel.Controls.Add(label3);
            kayttajatunnusPanel.Controls.Add(kayttajatunnus);
            kayttajatunnusPanel.Location = new Point(28, 108);
            kayttajatunnusPanel.Name = "kayttajatunnusPanel";
            kayttajatunnusPanel.Size = new Size(309, 35);
            kayttajatunnusPanel.TabIndex = 53;
            // 
            // vaihdaKtunnus
            // 
            vaihdaKtunnus.BackColor = Color.Bisque;
            vaihdaKtunnus.Cursor = Cursors.Hand;
            vaihdaKtunnus.FlatAppearance.BorderColor = Color.Tan;
            vaihdaKtunnus.FlatAppearance.BorderSize = 2;
            vaihdaKtunnus.FlatAppearance.MouseDownBackColor = Color.BurlyWood;
            vaihdaKtunnus.FlatAppearance.MouseOverBackColor = Color.Tan;
            vaihdaKtunnus.FlatStyle = FlatStyle.Flat;
            vaihdaKtunnus.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            vaihdaKtunnus.Location = new Point(250, 5);
            vaihdaKtunnus.Name = "vaihdaKtunnus";
            vaihdaKtunnus.Size = new Size(55, 25);
            vaihdaKtunnus.TabIndex = 48;
            vaihdaKtunnus.Text = "Vaihda";
            vaihdaKtunnus.UseVisualStyleBackColor = false;
            vaihdaKtunnus.Click += ChangeUsername_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Impact", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(5, 9);
            label3.Name = "label3";
            label3.Size = new Size(109, 19);
            label3.TabIndex = 22;
            label3.Text = "Käyttäjätunnus:";
            // 
            // kayttajatunnus
            // 
            kayttajatunnus.AutoSize = true;
            kayttajatunnus.BackColor = Color.Transparent;
            kayttajatunnus.Font = new Font("Impact", 11F, FontStyle.Regular, GraphicsUnit.Point);
            kayttajatunnus.ForeColor = Color.FromArgb(0, 0, 64);
            kayttajatunnus.Location = new Point(130, 9);
            kayttajatunnus.Name = "kayttajatunnus";
            kayttajatunnus.Size = new Size(68, 19);
            kayttajatunnus.TabIndex = 25;
            kayttajatunnus.Text = "Käyttäjä1";
            // 
            // salasanaPanel
            // 
            salasanaPanel.BackColor = Color.Transparent;
            salasanaPanel.Controls.Add(vaihdaSalasana);
            salasanaPanel.Controls.Add(label4);
            salasanaPanel.Controls.Add(salasana);
            salasanaPanel.Location = new Point(28, 144);
            salasanaPanel.Name = "salasanaPanel";
            salasanaPanel.Size = new Size(309, 35);
            salasanaPanel.TabIndex = 52;
            // 
            // vaihdaSalasana
            // 
            vaihdaSalasana.BackColor = Color.Bisque;
            vaihdaSalasana.Cursor = Cursors.Hand;
            vaihdaSalasana.FlatAppearance.BorderColor = Color.Tan;
            vaihdaSalasana.FlatAppearance.BorderSize = 2;
            vaihdaSalasana.FlatAppearance.MouseDownBackColor = Color.BurlyWood;
            vaihdaSalasana.FlatAppearance.MouseOverBackColor = Color.Tan;
            vaihdaSalasana.FlatStyle = FlatStyle.Flat;
            vaihdaSalasana.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            vaihdaSalasana.Location = new Point(250, 5);
            vaihdaSalasana.Name = "vaihdaSalasana";
            vaihdaSalasana.Size = new Size(55, 25);
            vaihdaSalasana.TabIndex = 47;
            vaihdaSalasana.Text = "Vaihda";
            vaihdaSalasana.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Impact", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(5, 9);
            label4.Name = "label4";
            label4.Size = new Size(71, 19);
            label4.TabIndex = 23;
            label4.Text = "Salasana:";
            // 
            // salasana
            // 
            salasana.AutoSize = true;
            salasana.BackColor = Color.Transparent;
            salasana.Font = new Font("Impact", 30F, FontStyle.Regular, GraphicsUnit.Point);
            salasana.ForeColor = Color.FromArgb(0, 0, 64);
            salasana.Location = new Point(120, 9);
            salasana.Name = "salasana";
            salasana.Size = new Size(108, 48);
            salasana.TabIndex = 27;
            salasana.Text = "********";
            // 
            // puhPanel
            // 
            puhPanel.BackColor = Color.Transparent;
            puhPanel.Controls.Add(puhLabel);
            puhPanel.Controls.Add(puh);
            puhPanel.Controls.Add(vaihdaPuh);
            puhPanel.Location = new Point(28, 319);
            puhPanel.Name = "puhPanel";
            puhPanel.Size = new Size(309, 35);
            puhPanel.TabIndex = 54;
            // 
            // puhLabel
            // 
            puhLabel.AutoSize = true;
            puhLabel.BackColor = Color.Transparent;
            puhLabel.Font = new Font("Impact", 11F, FontStyle.Regular, GraphicsUnit.Point);
            puhLabel.Location = new Point(5, 9);
            puhLabel.Name = "puhLabel";
            puhLabel.Size = new Size(109, 19);
            puhLabel.TabIndex = 40;
            puhLabel.Text = "Puhelinnumero:";
            // 
            // puh
            // 
            puh.AutoSize = true;
            puh.BackColor = Color.Transparent;
            puh.Font = new Font("Impact", 11F, FontStyle.Regular, GraphicsUnit.Point);
            puh.ForeColor = Color.FromArgb(0, 0, 64);
            puh.Location = new Point(130, 9);
            puh.Name = "puh";
            puh.Size = new Size(91, 19);
            puh.TabIndex = 39;
            puh.Text = "ei määritetty";
            // 
            // vaihdaPuh
            // 
            vaihdaPuh.BackColor = Color.Bisque;
            vaihdaPuh.Cursor = Cursors.Hand;
            vaihdaPuh.FlatAppearance.BorderColor = Color.Tan;
            vaihdaPuh.FlatAppearance.BorderSize = 2;
            vaihdaPuh.FlatAppearance.MouseDownBackColor = Color.BurlyWood;
            vaihdaPuh.FlatAppearance.MouseOverBackColor = Color.Tan;
            vaihdaPuh.FlatStyle = FlatStyle.Flat;
            vaihdaPuh.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            vaihdaPuh.Location = new Point(250, 5);
            vaihdaPuh.Name = "vaihdaPuh";
            vaihdaPuh.Size = new Size(55, 25);
            vaihdaPuh.TabIndex = 50;
            vaihdaPuh.Text = "Vaihda";
            vaihdaPuh.UseVisualStyleBackColor = false;
            vaihdaPuh.Click += ChangePhoneNumber_Click;
            // 
            // ptpPanel
            // 
            ptpPanel.BackColor = Color.Transparent;
            ptpPanel.Controls.Add(ptpLabel);
            ptpPanel.Controls.Add(ptp);
            ptpPanel.Controls.Add(vaihdaPtp);
            ptpPanel.Location = new Point(28, 283);
            ptpPanel.Name = "ptpPanel";
            ptpPanel.Size = new Size(309, 35);
            ptpPanel.TabIndex = 53;
            // 
            // ptpLabel
            // 
            ptpLabel.AutoSize = true;
            ptpLabel.BackColor = Color.Transparent;
            ptpLabel.Font = new Font("Impact", 11F, FontStyle.Regular, GraphicsUnit.Point);
            ptpLabel.Location = new Point(5, 9);
            ptpLabel.Name = "ptpLabel";
            ptpLabel.Size = new Size(119, 19);
            ptpLabel.TabIndex = 34;
            ptpLabel.Text = "postitoimipaikka:";
            // 
            // ptp
            // 
            ptp.AutoSize = true;
            ptp.BackColor = Color.Transparent;
            ptp.Font = new Font("Impact", 11F, FontStyle.Regular, GraphicsUnit.Point);
            ptp.ForeColor = Color.FromArgb(0, 0, 64);
            ptp.Location = new Point(130, 9);
            ptp.Name = "ptp";
            ptp.Size = new Size(91, 19);
            ptp.TabIndex = 38;
            ptp.Text = "ei määritetty";
            // 
            // vaihdaPtp
            // 
            vaihdaPtp.BackColor = Color.Bisque;
            vaihdaPtp.Cursor = Cursors.Hand;
            vaihdaPtp.FlatAppearance.BorderColor = Color.Tan;
            vaihdaPtp.FlatAppearance.BorderSize = 2;
            vaihdaPtp.FlatAppearance.MouseDownBackColor = Color.BurlyWood;
            vaihdaPtp.FlatAppearance.MouseOverBackColor = Color.Tan;
            vaihdaPtp.FlatStyle = FlatStyle.Flat;
            vaihdaPtp.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            vaihdaPtp.Location = new Point(250, 5);
            vaihdaPtp.Name = "vaihdaPtp";
            vaihdaPtp.Size = new Size(55, 25);
            vaihdaPtp.TabIndex = 49;
            vaihdaPtp.Text = "Vaihda";
            vaihdaPtp.UseVisualStyleBackColor = false;
            vaihdaPtp.Click += ChangeCity_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Impact", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(23, 6);
            label1.Name = "label1";
            label1.Size = new Size(117, 27);
            label1.TabIndex = 0;
            label1.Text = "Perustiedot";
            // 
            // pnoPanel
            // 
            pnoPanel.BackColor = Color.Transparent;
            pnoPanel.Controls.Add(pnoLabel);
            pnoPanel.Controls.Add(pno);
            pnoPanel.Controls.Add(vaihdaPno);
            pnoPanel.Location = new Point(28, 248);
            pnoPanel.Name = "pnoPanel";
            pnoPanel.Size = new Size(309, 35);
            pnoPanel.TabIndex = 52;
            // 
            // pnoLabel
            // 
            pnoLabel.AutoSize = true;
            pnoLabel.BackColor = Color.Transparent;
            pnoLabel.Font = new Font("Impact", 11F, FontStyle.Regular, GraphicsUnit.Point);
            pnoLabel.Location = new Point(5, 9);
            pnoLabel.Name = "pnoLabel";
            pnoLabel.Size = new Size(93, 19);
            pnoLabel.TabIndex = 33;
            pnoLabel.Text = "postinumero:";
            // 
            // pno
            // 
            pno.AutoSize = true;
            pno.BackColor = Color.Transparent;
            pno.Font = new Font("Impact", 11F, FontStyle.Regular, GraphicsUnit.Point);
            pno.ForeColor = Color.FromArgb(0, 0, 64);
            pno.Location = new Point(130, 9);
            pno.Name = "pno";
            pno.Size = new Size(91, 19);
            pno.TabIndex = 37;
            pno.Text = "ei määritetty";
            // 
            // vaihdaPno
            // 
            vaihdaPno.BackColor = Color.Bisque;
            vaihdaPno.Cursor = Cursors.Hand;
            vaihdaPno.FlatAppearance.BorderColor = Color.Tan;
            vaihdaPno.FlatAppearance.BorderSize = 2;
            vaihdaPno.FlatAppearance.MouseDownBackColor = Color.BurlyWood;
            vaihdaPno.FlatAppearance.MouseOverBackColor = Color.Tan;
            vaihdaPno.FlatStyle = FlatStyle.Flat;
            vaihdaPno.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            vaihdaPno.Location = new Point(250, 5);
            vaihdaPno.Name = "vaihdaPno";
            vaihdaPno.Size = new Size(55, 25);
            vaihdaPno.TabIndex = 48;
            vaihdaPno.Text = "Vaihda";
            vaihdaPno.UseVisualStyleBackColor = false;
            vaihdaPno.Click += ChangePostalCode_Click;
            // 
            // losoPanel
            // 
            losoPanel.BackColor = Color.Transparent;
            losoPanel.Controls.Add(loso);
            losoPanel.Controls.Add(losoLabel);
            losoPanel.Controls.Add(vaihdaLoso);
            losoPanel.Location = new Point(28, 212);
            losoPanel.Name = "losoPanel";
            losoPanel.Size = new Size(309, 35);
            losoPanel.TabIndex = 51;
            // 
            // loso
            // 
            loso.AutoSize = true;
            loso.BackColor = Color.Transparent;
            loso.Font = new Font("Impact", 11F, FontStyle.Regular, GraphicsUnit.Point);
            loso.ForeColor = Color.FromArgb(0, 0, 64);
            loso.Location = new Point(130, 9);
            loso.Name = "loso";
            loso.Size = new Size(91, 19);
            loso.TabIndex = 36;
            loso.Text = "ei määritetty";
            // 
            // losoLabel
            // 
            losoLabel.AutoSize = true;
            losoLabel.BackColor = Color.Transparent;
            losoLabel.Font = new Font("Impact", 11F, FontStyle.Regular, GraphicsUnit.Point);
            losoLabel.Location = new Point(5, 9);
            losoLabel.Name = "losoLabel";
            losoLabel.Size = new Size(76, 19);
            losoLabel.TabIndex = 32;
            losoLabel.Text = "lähiosoite:";
            // 
            // vaihdaLoso
            // 
            vaihdaLoso.BackColor = Color.Bisque;
            vaihdaLoso.Cursor = Cursors.Hand;
            vaihdaLoso.FlatAppearance.BorderColor = Color.Tan;
            vaihdaLoso.FlatAppearance.BorderSize = 2;
            vaihdaLoso.FlatAppearance.MouseDownBackColor = Color.BurlyWood;
            vaihdaLoso.FlatAppearance.MouseOverBackColor = Color.Tan;
            vaihdaLoso.FlatStyle = FlatStyle.Flat;
            vaihdaLoso.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            vaihdaLoso.Location = new Point(250, 5);
            vaihdaLoso.Name = "vaihdaLoso";
            vaihdaLoso.Size = new Size(55, 25);
            vaihdaLoso.TabIndex = 47;
            vaihdaLoso.Text = "Vaihda";
            vaihdaLoso.UseVisualStyleBackColor = false;
            vaihdaLoso.Click += ChangeAddress_Click;
            // 
            // tyonim
            // 
            tyonim.AutoSize = true;
            tyonim.BackColor = Color.Transparent;
            tyonim.Font = new Font("Impact", 11F, FontStyle.Regular, GraphicsUnit.Point);
            tyonim.ForeColor = Color.FromArgb(0, 0, 64);
            tyonim.Location = new Point(375, 66);
            tyonim.Name = "tyonim";
            tyonim.Size = new Size(73, 19);
            tyonim.TabIndex = 42;
            tyonim.Text = "työntekijä";
            // 
            // tyonimLabel
            // 
            tyonimLabel.AutoSize = true;
            tyonimLabel.BackColor = Color.Transparent;
            tyonimLabel.Font = new Font("Impact", 11F, FontStyle.Regular, GraphicsUnit.Point);
            tyonimLabel.Location = new Point(376, 36);
            tyonimLabel.Name = "tyonimLabel";
            tyonimLabel.Size = new Size(72, 19);
            tyonimLabel.TabIndex = 41;
            tyonimLabel.Text = "työnimike";
            // 
            // lisatiedot
            // 
            lisatiedot.AutoSize = true;
            lisatiedot.BackColor = Color.Transparent;
            lisatiedot.Font = new Font("Impact", 16F, FontStyle.Regular, GraphicsUnit.Point);
            lisatiedot.Location = new Point(23, 182);
            lisatiedot.Name = "lisatiedot";
            lisatiedot.Size = new Size(100, 27);
            lisatiedot.TabIndex = 31;
            lisatiedot.Text = "Lisatiedot";
            // 
            // lainauksetPanel
            // 
            lainauksetPanel.BackColor = Color.FromArgb(125, 255, 241, 220);
            lainauksetPanel.Controls.Add(eiLainauksia);
            lainauksetPanel.Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lainauksetPanel.Location = new Point(163, 579);
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
            label16.Location = new Point(211, 535);
            label16.MinimumSize = new Size(400, 30);
            label16.Name = "label16";
            label16.Size = new Size(400, 31);
            label16.TabIndex = 32;
            label16.Text = "Lainauksesi";
            label16.TextAlign = ContentAlignment.TopCenter;
            // 
            // AccountDetails
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(800, 811);
            Controls.Add(label16);
            Controls.Add(lainauksetPanel);
            Controls.Add(groupBox1);
            Controls.Add(Menu);
            Controls.Add(tervetuloa);
            Controls.Add(Header);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AccountDetails";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kirjasto";
            Load += Form_Load;
            Header.ResumeLayout(false);
            Header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)menuButton).EndInit();
            Menu.ResumeLayout(false);
            Menu.PerformLayout();
            footer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox15).EndInit();
            panel16.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            enimiPanel.ResumeLayout(false);
            enimiPanel.PerformLayout();
            snimiPanel.ResumeLayout(false);
            snimiPanel.PerformLayout();
            kayttajatunnusPanel.ResumeLayout(false);
            kayttajatunnusPanel.PerformLayout();
            salasanaPanel.ResumeLayout(false);
            salasanaPanel.PerformLayout();
            puhPanel.ResumeLayout(false);
            puhPanel.PerformLayout();
            ptpPanel.ResumeLayout(false);
            ptpPanel.PerformLayout();
            pnoPanel.ResumeLayout(false);
            pnoPanel.PerformLayout();
            losoPanel.ResumeLayout(false);
            losoPanel.PerformLayout();
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
        private Panel footer;
        private Panel panel16;
        private Panel panel17;
        private PictureBox pictureBox15;
        private Label kirjaudu_ulos;
        private Label kirjat;
        private Label label3;
        private Label salasana;
        private Label kayttajatunnus;
        private Label label4;
        private GroupBox lainauksetPanel;
        private Label label16;
        private Label asiakkaat;
        private Label eiLainauksia;
        private Label pnoLabel;
        private Label losoLabel;
        private Label lisatiedot;
        private Label ptpLabel;
        private Label puh;
        private Label ptp;
        private Label pno;
        private Label loso;
        private Label puhLabel;
        private Label tyonim;
        private Label tyonimLabel;
        private Label snimiLabel;
        private Label snimi;
        private Button vaihdaPuh;
        private Button vaihdaPtp;
        private Button vaihdaPno;
        private Button vaihdaLoso;
        private Panel losoPanel;
        private Panel pnoPanel;
        private Panel puhPanel;
        private Panel ptpPanel;
        private Panel salasanaPanel;
        private Button vaihdaSalasana;
        private Panel kayttajatunnusPanel;
        private Panel snimiPanel;
        private Button vaihdaSnimi;
        private Panel enimiPanel;
        private Button vaihdaEnimi;
        private Label label5;
        private Label enimi;
        private Button vaihdaKtunnus;
    }
}
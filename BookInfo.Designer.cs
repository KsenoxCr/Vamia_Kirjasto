namespace Kirjasto_ohjelma
{
    partial class BookInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookInfo));
            kansikuva = new PictureBox();
            panel1 = new Panel();
            kuvaus = new TextBox();
            panel2 = new Panel();
            kirjanTiedot = new Panel();
            kustantaja = new TextBox();
            julkaistu = new TextBox();
            sivumaara = new TextBox();
            genre = new TextBox();
            kustantajaLabel = new Label();
            label9 = new Label();
            label6 = new Label();
            genreLabel = new Label();
            pictureBox2 = new PictureBox();
            poistaBtn = new Button();
            muokkaaBtn = new Button();
            lainaaBtn = new Button();
            nimi = new TextBox();
            kirjailija = new Label();
            ((System.ComponentModel.ISupportInitialize)kansikuva).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            kirjanTiedot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // kansikuva
            // 
            kansikuva.BackgroundImageLayout = ImageLayout.Center;
            kansikuva.Location = new Point(17, 20);
            kansikuva.Margin = new Padding(3, 4, 3, 4);
            kansikuva.Name = "kansikuva";
            kansikuva.Size = new Size(217, 333);
            kansikuva.TabIndex = 0;
            kansikuva.TabStop = false;
            kansikuva.Click += BookCover_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.PeachPuff;
            panel1.Controls.Add(kuvaus);
            panel1.Location = new Point(272, 111);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(325, 555);
            panel1.TabIndex = 3;
            // 
            // kuvaus
            // 
            kuvaus.Location = new Point(15, 19);
            kuvaus.Margin = new Padding(3, 4, 3, 4);
            kuvaus.Multiline = true;
            kuvaus.Name = "kuvaus";
            kuvaus.ReadOnly = true;
            kuvaus.ScrollBars = ScrollBars.Vertical;
            kuvaus.Size = new Size(292, 513);
            kuvaus.TabIndex = 0;
            kuvaus.Text = resources.GetString("kuvaus.Text");
            // 
            // panel2
            // 
            panel2.BackColor = Color.PeachPuff;
            panel2.Controls.Add(kansikuva);
            panel2.Location = new Point(14, 111);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(251, 373);
            panel2.TabIndex = 4;
            // 
            // kirjanTiedot
            // 
            kirjanTiedot.BackColor = Color.PeachPuff;
            kirjanTiedot.Controls.Add(kustantaja);
            kirjanTiedot.Controls.Add(julkaistu);
            kirjanTiedot.Controls.Add(sivumaara);
            kirjanTiedot.Controls.Add(genre);
            kirjanTiedot.Controls.Add(kustantajaLabel);
            kirjanTiedot.Controls.Add(label9);
            kirjanTiedot.Controls.Add(label6);
            kirjanTiedot.Controls.Add(genreLabel);
            kirjanTiedot.Location = new Point(14, 493);
            kirjanTiedot.Margin = new Padding(3, 4, 3, 4);
            kirjanTiedot.Name = "kirjanTiedot";
            kirjanTiedot.Size = new Size(251, 172);
            kirjanTiedot.TabIndex = 5;
            // 
            // kustantaja
            // 
            kustantaja.BackColor = Color.PeachPuff;
            kustantaja.BorderStyle = BorderStyle.None;
            kustantaja.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            kustantaja.Location = new Point(119, 124);
            kustantaja.Margin = new Padding(3, 4, 3, 4);
            kustantaja.Name = "kustantaja";
            kustantaja.ReadOnly = true;
            kustantaja.Size = new Size(115, 27);
            kustantaja.TabIndex = 22;
            kustantaja.Text = "Kustantaja";
            // 
            // julkaistu
            // 
            julkaistu.BackColor = Color.PeachPuff;
            julkaistu.BorderStyle = BorderStyle.None;
            julkaistu.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            julkaistu.Location = new Point(139, 91);
            julkaistu.Margin = new Padding(3, 4, 3, 4);
            julkaistu.Name = "julkaistu";
            julkaistu.ReadOnly = true;
            julkaistu.Size = new Size(95, 27);
            julkaistu.TabIndex = 21;
            julkaistu.Text = "2000";
            // 
            // sivumaara
            // 
            sivumaara.BackColor = Color.PeachPuff;
            sivumaara.BorderStyle = BorderStyle.None;
            sivumaara.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            sivumaara.Location = new Point(75, 55);
            sivumaara.Margin = new Padding(3, 4, 3, 4);
            sivumaara.Name = "sivumaara";
            sivumaara.ReadOnly = true;
            sivumaara.Size = new Size(152, 27);
            sivumaara.TabIndex = 20;
            sivumaara.Text = "0";
            // 
            // genre
            // 
            genre.BackColor = Color.PeachPuff;
            genre.BorderStyle = BorderStyle.None;
            genre.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            genre.Location = new Point(82, 20);
            genre.Margin = new Padding(3, 4, 3, 4);
            genre.Name = "genre";
            genre.ReadOnly = true;
            genre.Size = new Size(152, 27);
            genre.TabIndex = 19;
            genre.Text = "genre";
            // 
            // kustantajaLabel
            // 
            kustantajaLabel.AutoSize = true;
            kustantajaLabel.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point);
            kustantajaLabel.Location = new Point(17, 124);
            kustantajaLabel.Name = "kustantajaLabel";
            kustantajaLabel.Size = new Size(103, 25);
            kustantajaLabel.TabIndex = 16;
            kustantajaLabel.Text = "Kustantaja:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(17, 91);
            label9.Name = "label9";
            label9.Size = new Size(125, 25);
            label9.TabIndex = 13;
            label9.Text = "Julkaisuvuosi:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(17, 57);
            label6.Name = "label6";
            label6.Size = new Size(56, 25);
            label6.TabIndex = 12;
            label6.Text = "Sivut:";
            // 
            // genreLabel
            // 
            genreLabel.AutoSize = true;
            genreLabel.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point);
            genreLabel.Location = new Point(17, 24);
            genreLabel.Name = "genreLabel";
            genreLabel.Size = new Size(64, 25);
            genreLabel.TabIndex = 6;
            genreLabel.Text = "Genre:";
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox2.Location = new Point(567, 15);
            pictureBox2.Margin = new Padding(3, 4, 3, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(46, 53);
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            pictureBox2.Click += Close_Click;
            // 
            // poistaBtn
            // 
            poistaBtn.BackColor = Color.OrangeRed;
            poistaBtn.Cursor = Cursors.Hand;
            poistaBtn.FlatAppearance.BorderColor = Color.DarkRed;
            poistaBtn.FlatAppearance.BorderSize = 2;
            poistaBtn.FlatAppearance.MouseDownBackColor = Color.Red;
            poistaBtn.FlatAppearance.MouseOverBackColor = Color.OrangeRed;
            poistaBtn.FlatStyle = FlatStyle.Flat;
            poistaBtn.Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point);
            poistaBtn.Location = new Point(438, 673);
            poistaBtn.Margin = new Padding(3, 4, 3, 4);
            poistaBtn.Name = "poistaBtn";
            poistaBtn.Size = new Size(159, 68);
            poistaBtn.TabIndex = 11;
            poistaBtn.Text = "Poista";
            poistaBtn.UseVisualStyleBackColor = false;
            poistaBtn.Visible = false;
            poistaBtn.Click += Delete_Click;
            // 
            // muokkaaBtn
            // 
            muokkaaBtn.BackColor = Color.Orange;
            muokkaaBtn.Cursor = Cursors.Hand;
            muokkaaBtn.FlatAppearance.BorderColor = Color.Goldenrod;
            muokkaaBtn.FlatAppearance.BorderSize = 2;
            muokkaaBtn.FlatAppearance.MouseDownBackColor = Color.Peru;
            muokkaaBtn.FlatAppearance.MouseOverBackColor = Color.Orange;
            muokkaaBtn.FlatStyle = FlatStyle.Flat;
            muokkaaBtn.Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point);
            muokkaaBtn.Location = new Point(272, 673);
            muokkaaBtn.Margin = new Padding(3, 4, 3, 4);
            muokkaaBtn.Name = "muokkaaBtn";
            muokkaaBtn.Size = new Size(159, 68);
            muokkaaBtn.TabIndex = 12;
            muokkaaBtn.Text = "Muokkaa";
            muokkaaBtn.UseVisualStyleBackColor = false;
            muokkaaBtn.Visible = false;
            muokkaaBtn.Click += Edit_Click;
            // 
            // lainaaBtn
            // 
            lainaaBtn.BackColor = Color.Bisque;
            lainaaBtn.Cursor = Cursors.Hand;
            lainaaBtn.FlatAppearance.BorderColor = Color.Tan;
            lainaaBtn.FlatAppearance.BorderSize = 2;
            lainaaBtn.FlatAppearance.MouseDownBackColor = Color.BurlyWood;
            lainaaBtn.FlatAppearance.MouseOverBackColor = Color.Tan;
            lainaaBtn.FlatStyle = FlatStyle.Flat;
            lainaaBtn.Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lainaaBtn.Location = new Point(14, 673);
            lainaaBtn.Margin = new Padding(3, 4, 3, 4);
            lainaaBtn.MaximumSize = new Size(343, 68);
            lainaaBtn.MinimumSize = new Size(122, 68);
            lainaaBtn.Name = "lainaaBtn";
            lainaaBtn.Size = new Size(251, 68);
            lainaaBtn.TabIndex = 14;
            lainaaBtn.Text = "Lainaa";
            lainaaBtn.UseVisualStyleBackColor = true;
            lainaaBtn.Click += Lend_Click;
            // 
            // nimi
            // 
            nimi.BackColor = Color.FromArgb(255, 241, 220);
            nimi.BorderStyle = BorderStyle.None;
            nimi.Font = new Font("Impact", 25F, FontStyle.Regular, GraphicsUnit.Point);
            nimi.Location = new Point(64, 5);
            nimi.Margin = new Padding(3, 4, 3, 4);
            nimi.Name = "nimi";
            nimi.ReadOnly = true;
            nimi.Size = new Size(496, 51);
            nimi.TabIndex = 23;
            nimi.Text = "Kirjan Nimi";
            nimi.TextAlign = HorizontalAlignment.Center;
            // 
            // kirjailija
            // 
            kirjailija.AutoSize = true;
            kirjailija.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point);
            kirjailija.Location = new Point(272, 64);
            kirjailija.Name = "kirjailija";
            kirjailija.Size = new Size(80, 25);
            kirjailija.TabIndex = 24;
            kirjailija.Text = "Kirjailija";
            // 
            // BookInfo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 241, 220);
            ClientSize = new Size(626, 757);
            ControlBox = false;
            Controls.Add(kirjailija);
            Controls.Add(nimi);
            Controls.Add(lainaaBtn);
            Controls.Add(muokkaaBtn);
            Controls.Add(poistaBtn);
            Controls.Add(pictureBox2);
            Controls.Add(kirjanTiedot);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximumSize = new Size(628, 759);
            MinimumSize = new Size(628, 759);
            Name = "BookInfo";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Load += BookInfo_Load;
            ((System.ComponentModel.ISupportInitialize)kansikuva).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            kirjanTiedot.ResumeLayout(false);
            kirjanTiedot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox kansikuva;
        private Panel panel1;
        private TextBox kuvaus;
        private Panel panel2;
        private Panel kirjanTiedot;
        private Label label9;
        private Label label6;
        private Label kustantajaLabel;
        private Label genreLabel;
        private PictureBox pictureBox2;
        private Button poistaBtn;
        private Button muokkaaBtn;
        private Button lainaaBtn;
        private TextBox genre;
        private TextBox kustantaja;
        private TextBox julkaistu;
        private TextBox sivumaara;
        private TextBox nimi;
        private Label kirjailija;
    }
}
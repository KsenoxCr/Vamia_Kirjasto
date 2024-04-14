namespace Kirjasto_ohjelma
{
    partial class ContactUs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContactUs));
            otsikko = new Label();
            pictureBox2 = new PictureBox();
            aiheTB = new TextBox();
            label2 = new Label();
            sisaltoTB = new TextBox();
            label3 = new Label();
            panel1 = new Panel();
            lahetaBtn = new Button();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // otsikko
            // 
            otsikko.AutoSize = true;
            otsikko.Font = new Font("Impact", 16F, FontStyle.Regular, GraphicsUnit.Point);
            otsikko.Location = new Point(-19, 20);
            otsikko.MaximumSize = new Size(300, 30);
            otsikko.MinimumSize = new Size(300, 30);
            otsikko.Name = "otsikko";
            otsikko.Size = new Size(300, 30);
            otsikko.TabIndex = 0;
            otsikko.Text = "Ota Yhteyttä";
            otsikko.TextAlign = ContentAlignment.TopCenter;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox2.Location = new Point(223, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(25, 25);
            pictureBox2.TabIndex = 9;
            pictureBox2.TabStop = false;
            pictureBox2.Click += Close_Click;
            // 
            // aiheTB
            // 
            aiheTB.Location = new Point(15, 33);
            aiheTB.Name = "aiheTB";
            aiheTB.Size = new Size(170, 23);
            aiheTB.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(79, 6);
            label2.Name = "label2";
            label2.Size = new Size(36, 20);
            label2.TabIndex = 11;
            label2.Text = "Aihe";
            // 
            // sisaltoTB
            // 
            sisaltoTB.Location = new Point(15, 87);
            sisaltoTB.MaxLength = 250;
            sisaltoTB.MinimumSize = new Size(170, 170);
            sisaltoTB.Multiline = true;
            sisaltoTB.Name = "sisaltoTB";
            sisaltoTB.Size = new Size(170, 170);
            sisaltoTB.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(70, 64);
            label3.Name = "label3";
            label3.Size = new Size(54, 20);
            label3.TabIndex = 13;
            label3.Text = "Sisältö";
            // 
            // panel1
            // 
            panel1.BackColor = Color.PeachPuff;
            panel1.Controls.Add(lahetaBtn);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(sisaltoTB);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(aiheTB);
            panel1.Location = new Point(27, 65);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 312);
            panel1.TabIndex = 14;
            // 
            // lahetaBtn
            // 
            lahetaBtn.BackColor = Color.NavajoWhite;
            lahetaBtn.Cursor = Cursors.Hand;
            lahetaBtn.FlatAppearance.BorderColor = Color.Tan;
            lahetaBtn.FlatAppearance.BorderSize = 2;
            lahetaBtn.FlatAppearance.MouseDownBackColor = Color.BurlyWood;
            lahetaBtn.FlatAppearance.MouseOverBackColor = Color.Tan;
            lahetaBtn.FlatStyle = FlatStyle.Flat;
            lahetaBtn.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lahetaBtn.Location = new Point(57, 263);
            lahetaBtn.MaximumSize = new Size(80, 40);
            lahetaBtn.MinimumSize = new Size(80, 40);
            lahetaBtn.Name = "lahetaBtn";
            lahetaBtn.Size = new Size(80, 40);
            lahetaBtn.TabIndex = 15;
            lahetaBtn.Text = "Lähetä";
            lahetaBtn.UseVisualStyleBackColor = false;
            lahetaBtn.Click += Send_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(93, 238);
            label4.Name = "label4";
            label4.Size = new Size(90, 16);
            label4.TabIndex = 14;
            label4.Text = "Max 250 merkkiä";
            // 
            // FeedBackForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 241, 220);
            ClientSize = new Size(250, 400);
            ControlBox = false;
            Controls.Add(panel1);
            Controls.Add(pictureBox2);
            Controls.Add(otsikko);
            FormBorderStyle = FormBorderStyle.None;
            MaximumSize = new Size(250, 400);
            MinimumSize = new Size(250, 400);
            Name = "FeedBackForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form6";
            Load += Form_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label otsikko;
        private PictureBox pictureBox2;
        private TextBox aiheTB;
        private Label label2;
        private TextBox sisaltoTB;
        private Label label3;
        private Panel panel1;
        private Button lahetaBtn;
        private Label label4;
    }
}
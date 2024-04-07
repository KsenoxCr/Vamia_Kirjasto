namespace Kirjasto_ohjelma
{
    partial class BookRecommendation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookRecommendation));
            label1 = new Label();
            ehdotusTB = new TextBox();
            ehdotaBtn = new Button();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Impact", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(44, 37);
            label1.Name = "label1";
            label1.Size = new Size(165, 34);
            label1.TabIndex = 0;
            label1.Text = "Ehdota kirjaa ";
            // 
            // ehdotusTB
            // 
            ehdotusTB.Location = new Point(44, 83);
            ehdotusTB.Name = "ehdotusTB";
            ehdotusTB.Size = new Size(161, 23);
            ehdotusTB.TabIndex = 1;
            // 
            // ehdotaBtn
            // 
            ehdotaBtn.BackColor = Color.Bisque;
            ehdotaBtn.Cursor = Cursors.Hand;
            ehdotaBtn.FlatAppearance.BorderColor = Color.Tan;
            ehdotaBtn.FlatAppearance.BorderSize = 2;
            ehdotaBtn.FlatAppearance.MouseDownBackColor = Color.BurlyWood;
            ehdotaBtn.FlatAppearance.MouseOverBackColor = Color.Tan;
            ehdotaBtn.FlatStyle = FlatStyle.Flat;
            ehdotaBtn.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ehdotaBtn.Location = new Point(89, 123);
            ehdotaBtn.Name = "ehdotaBtn";
            ehdotaBtn.Size = new Size(71, 31);
            ehdotaBtn.TabIndex = 8;
            ehdotaBtn.Text = "Ehdota";
            ehdotaBtn.UseVisualStyleBackColor = false;
            ehdotaBtn.Click += button2_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox2.Location = new Point(208, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(30, 30);
            pictureBox2.TabIndex = 9;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // BookRecommendation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 241, 220);
            ClientSize = new Size(250, 175);
            ControlBox = false;
            Controls.Add(pictureBox2);
            Controls.Add(ehdotaBtn);
            Controls.Add(ehdotusTB);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            MaximumSize = new Size(250, 175);
            MinimumSize = new Size(250, 175);
            Name = "BookRecommendation";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form6";
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox ehdotusTB;
        private Button ehdotaBtn;
        private PictureBox pictureBox2;
    }
}
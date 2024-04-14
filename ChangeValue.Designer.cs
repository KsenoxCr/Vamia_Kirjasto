namespace Kirjasto_ohjelma
{
    partial class ChangeValue
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeValue));
            closeBtn = new PictureBox();
            uusiLabel = new Label();
            vaihdaBtn = new Button();
            vaihdaLabel = new Label();
            vaihdaTB = new TextBox();
            ((System.ComponentModel.ISupportInitialize)closeBtn).BeginInit();
            SuspendLayout();
            // 
            // closeBtn
            // 
            closeBtn.BackgroundImage = (Image)resources.GetObject("closeBtn.BackgroundImage");
            closeBtn.BackgroundImageLayout = ImageLayout.Zoom;
            closeBtn.Location = new Point(208, 12);
            closeBtn.Name = "closeBtn";
            closeBtn.Size = new Size(30, 30);
            closeBtn.TabIndex = 9;
            closeBtn.TabStop = false;
            closeBtn.Click += Close_Click;
            // 
            // uusiLabel
            // 
            uusiLabel.AutoSize = true;
            uusiLabel.Font = new Font("Impact", 11F, FontStyle.Regular, GraphicsUnit.Point);
            uusiLabel.Location = new Point(28, 68);
            uusiLabel.Name = "uusiLabel";
            uusiLabel.Size = new Size(46, 19);
            uusiLabel.TabIndex = 10;
            uusiLabel.Text = "uusi x";
            // 
            // vaihdaBtn
            // 
            vaihdaBtn.BackColor = Color.Bisque;
            vaihdaBtn.Cursor = Cursors.Hand;
            vaihdaBtn.FlatAppearance.BorderColor = Color.Tan;
            vaihdaBtn.FlatAppearance.BorderSize = 3;
            vaihdaBtn.FlatAppearance.MouseDownBackColor = Color.BurlyWood;
            vaihdaBtn.FlatAppearance.MouseOverBackColor = Color.Tan;
            vaihdaBtn.FlatStyle = FlatStyle.Flat;
            vaihdaBtn.Font = new Font("Impact", 10F, FontStyle.Regular, GraphicsUnit.Point);
            vaihdaBtn.Location = new Point(85, 107);
            vaihdaBtn.Name = "vaihdaBtn";
            vaihdaBtn.Size = new Size(76, 31);
            vaihdaBtn.TabIndex = 11;
            vaihdaBtn.Text = "Vaihda";
            vaihdaBtn.UseVisualStyleBackColor = false;
            vaihdaBtn.Click += Change_Click;
            // 
            // vaihdaLabel
            // 
            vaihdaLabel.AutoSize = true;
            vaihdaLabel.Font = new Font("Impact", 13F, FontStyle.Regular, GraphicsUnit.Point);
            vaihdaLabel.Location = new Point(91, 33);
            vaihdaLabel.Name = "vaihdaLabel";
            vaihdaLabel.Size = new Size(70, 22);
            vaihdaLabel.TabIndex = 12;
            vaihdaLabel.Text = "Vaihda x";
            // 
            // vaihdaTB
            // 
            vaihdaTB.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            vaihdaTB.Location = new Point(80, 68);
            vaihdaTB.Name = "vaihdaTB";
            vaihdaTB.Size = new Size(100, 23);
            vaihdaTB.TabIndex = 13;
            // 
            // ChangeValue
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 241, 220);
            ClientSize = new Size(250, 150);
            ControlBox = false;
            Controls.Add(vaihdaTB);
            Controls.Add(vaihdaLabel);
            Controls.Add(vaihdaBtn);
            Controls.Add(uusiLabel);
            Controls.Add(closeBtn);
            FormBorderStyle = FormBorderStyle.None;
            MaximumSize = new Size(250, 150);
            MinimumSize = new Size(250, 150);
            Name = "ChangeValue";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form6";
            ((System.ComponentModel.ISupportInitialize)closeBtn).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox closeBtn;
        private Label uusiLabel;
        private Button vaihdaBtn;
        private Label vaihdaLabel;
        private TextBox vaihdaTB;
        private Button button1;
    }
}
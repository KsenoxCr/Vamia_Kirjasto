namespace Kirjasto_ohjelma
{
    partial class ConfirmMessage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfirmMessage));
            label1 = new Label();
            closeButton = new PictureBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)closeButton).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Impact", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(1, 45);
            label1.MinimumSize = new Size(250, 27);
            label1.Name = "label1";
            label1.Size = new Size(250, 27);
            label1.TabIndex = 0;
            label1.Text = "x";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // closeButton
            // 
            closeButton.BackgroundImage = (Image)resources.GetObject("closeButton.BackgroundImage");
            closeButton.BackgroundImageLayout = ImageLayout.Zoom;
            closeButton.Location = new Point(208, 12);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(30, 30);
            closeButton.TabIndex = 9;
            closeButton.TabStop = false;
            closeButton.Click += closeButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Impact", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(1, 86);
            label2.MinimumSize = new Size(250, 18);
            label2.Name = "label2";
            label2.Size = new Size(250, 18);
            label2.TabIndex = 10;
            label2.Text = "x";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ConfirmMessage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 241, 220);
            ClientSize = new Size(250, 150);
            ControlBox = false;
            Controls.Add(label2);
            Controls.Add(closeButton);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            MaximumSize = new Size(250, 600);
            MinimumSize = new Size(250, 150);
            Name = "ConfirmMessage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form6";
            Load += Form8_Load;
            ((System.ComponentModel.ISupportInitialize)closeButton).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private PictureBox closeButton;
        private Label label2;
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kirjasto_ohjelma
{
    public partial class basicButton : Button
    {
        public basicButton(string text, string color, int height, int width, int locationX, int locationY, float fontSize)
        {
            InitializeComponent();

            if (color == "beige") 
            {
                this.BackColor = Color.Bisque;
                this.FlatAppearance.BorderColor = Color.Tan;
                this.FlatAppearance.MouseDownBackColor = Color.BurlyWood;
                this.FlatAppearance.MouseOverBackColor = Color.Tan;
            }
            else if (color == "red")
            {
                this.BackColor = Color.Red;
                this.FlatAppearance.BorderColor = Color.Tan;
                this.FlatAppearance.MouseDownBackColor = Color.BurlyWood;
                this.FlatAppearance.MouseOverBackColor = Color.Tan;
            }
            else if (color == "orange")
            {
                this.BackColor = Color.Orange;
                this.FlatAppearance.BorderColor = Color.Tan;
                this.FlatAppearance.MouseDownBackColor = Color.BurlyWood;
                this.FlatAppearance.MouseOverBackColor = Color.Tan;
            }

            this.Size = new Size(width, height);
            this.Font = new Font("Impact", fontSize, FontStyle.Regular, GraphicsUnit.Point);

            this.Name = text;
            this.Text = text;
            this.FlatAppearance.BorderSize = 3;
            this.Cursor = Cursors.Hand;
            this.FlatStyle = FlatStyle.Flat;
            this.UseVisualStyleBackColor = false;

            this.Location = new Point(locationX, locationY);
        }
    }
}

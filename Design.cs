using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kirjasto_ohjelma
{
    public class Design
    {
        private readonly Form _form;

        public Design(Form form)
        {
            this._form = form;

            if (form is Home)
            {
                _form.haeKirjoja.Location = new Point((this.Width - haeKirjoja.Width) / 2, 75);

                _form.kirjaFlowLayoutPanel.Size = new Size(560, 292);
                _form.kirjaFlowLayoutPanel.Location = new Point(Menu.Width + 30, 342);

                _form.selausAsetukset.Location = new Point(kirjaFlowLayoutPanel.Left, kirjaFlowLayoutPanel.Top - selausAsetukset.Height);
                _form.selausAsetukset.Size = new Size(560, 94);

                _form.selaaKirjoja.Location = new Point((selaaKirjoja.Parent.Width - selaaKirjoja.Width) / 2, 20);
                _form.jarjestysCB.Location = new Point((jarjestysCB.Parent.Width - jarjestysCB.Width - 10), jarjestysCB.Parent.Height - jarjestysCB.Height - 10);
                _form.jarjestys.Location = new Point(jarjestysCB.Location.X - jarjestys.Width - 10, jarjestysCB.Location.Y);

                _form.Menu.Size = new Size(125, 715);
                _form.Menu.Location = new Point(0, 0);

                _form.footer.Location = new Point(0, Menu.Height);
                _form.footer.BringToFront();

                _form.kirjauduUlos.Location = new Point(12, Menu.Height - 50);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace week08.Abstractions
{
    public abstract class Toy : Label
    {
        public Toy()

        {
            AutoSize = false;
            Height = 50;
            Width = 50;
            Paint += Toy_Paint;


        }

        private void Toy_Paint(object sender, PaintEventArgs e)
        {
            DrawImage(e.Graphics);
        }

        public abstract void DrawImage(Graphics grafika);
        

        public void MoveToy()
        {
            Left += 1;


        }
    }
}

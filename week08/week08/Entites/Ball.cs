using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace week08.Entites
{
    public class Ball : Label
    {
        public Ball()

        {
            AutoSize = false;
            Height = 50;
            Width = 50;
            Paint += Ball_Paint;


        }

        private void Ball_Paint(object sender, PaintEventArgs e)
        {
            DrawImage(e.Graphics);
        }

        public void DrawImage(Graphics grafika)
        {

            grafika.FillEllipse(new SolidBrush(Color.Turquoise), 0, 0, Width, Height);

        
        }
        public void MoveBall()
        {
            Left += 1   ;


        }
    }
}

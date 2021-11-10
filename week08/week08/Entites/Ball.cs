using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using week08.Abstractions;

namespace week08.Entites
{
    public class Ball : Toy
    {
        public SolidBrush BallColor { get; private set; }
        public override void DrawImage(Graphics grafika)
        {

            grafika.FillEllipse(BallColor, 0, 0, Width, Height);


        }
        public Ball(Color c)
        {
            SolidBrush sb = new SolidBrush(c);
            sb = BallColor;




        }

    }
}

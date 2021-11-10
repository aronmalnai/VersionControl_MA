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
      
        public override void DrawImage(Graphics grafika)
        {

            grafika.FillEllipse(new SolidBrush(Color.Turquoise), 0, 0, Width, Height);

        
        }
      
    }
}

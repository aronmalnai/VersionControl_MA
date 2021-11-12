using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week08.Abstractions;
using System.Drawing;

namespace week08.Entites
{
    public class Present : Toy
    {
        public  SolidBrush PresentColor { get; set; }
        public SolidBrush PresentColor2 { get; set; }
        public Present(Color ribbon, Color box)
        {
            PresentColor = new SolidBrush(box);
            PresentColor2 = new SolidBrush(ribbon);


        }
        public override void DrawImage(Graphics grafika)
        {

            grafika.FillRectangle(PresentColor, 0, 0, Width, Height);           
            grafika.FillRectangle(PresentColor2, 0, (this.Height / 5) * 2, this.Width, this.Height / 5);
            grafika.FillRectangle(PresentColor2, (this.Width / 5) * 2, 0, this.Width / 5, this.Height);


        }

    }
}

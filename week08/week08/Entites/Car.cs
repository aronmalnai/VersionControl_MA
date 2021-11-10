using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week08.Abstractions;

namespace week08.Entites
{
    public class Car : Toy
    {
        public override void DrawImage(Graphics grafika)
        {
            Image imagefile = Image.FromFile("Images/car.png");
            grafika.DrawImage(imagefile, new Rectangle(0, 0, Width, Height));
        }
    }
}

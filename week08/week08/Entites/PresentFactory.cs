using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week08.Abstractions;

namespace week08.Entites
{
    class PresentFactory : IToyFactory
    {
        public Color color1 { get; set; }
        public Color color2 { get; set; }
        public Toy CreateNew()
        {
            Present p = new Present(color1,color2);
            return p;
        }
    }
}

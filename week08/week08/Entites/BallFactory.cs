using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week08.Abstractions;

namespace week08.Entites
{
    class BallFactory : IToyFactory
    {
        public Color Ballcolor { get; set; }
        public Toy CreateNew()
        {
            Ball b = new Ball(Ballcolor);
            return b;

            //return new Ball ez egyszrűbben

        
                   
        
        }
    }
}

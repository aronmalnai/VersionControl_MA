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

        public Toy CreateNew()
        {
            Ball b = new Ball();
            return b;

            //return new Ball ez egyszrűbben

        
                   
        
        }
    }
}

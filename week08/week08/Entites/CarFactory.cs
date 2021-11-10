using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week08.Abstractions;


namespace week08.Entites
{
    class CarFactory : ICarFactory
    {
        public Car CreateNew()
        {
            Car c = new Car();
            return c;
        
        }

       
    }
}

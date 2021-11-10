using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week08.Entites;

namespace week08.Abstractions
{
    public interface ICarFactory
    {
        Car CreateNew();
    }
}

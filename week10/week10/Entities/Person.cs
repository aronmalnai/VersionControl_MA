using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week10.Entities
{
  public  class Person
    {
        public int BirthYear { get; set; }
        public Gender Gender { get; set; }
        public int NoChildren { get; set; }
        public bool IsAlive { get; set; }

        public Person()
        {
            IsAlive = true;


        }
    }
}

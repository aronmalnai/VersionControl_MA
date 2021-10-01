using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserMaintenance.Entities
{
    public class User
    {
        public Guid ID { get; } = Guid.NewGuid();
        public string firstname { get; set; }

        public string lastname { get; set; }

        private int myVar;

        public string fullname
        {
            get
            {
                return string.Format("{0} {1}", lastname, firstname);
            }

        }

    }
}

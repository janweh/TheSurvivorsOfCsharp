using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp15.model
{
    public abstract class Storable
    {
        public abstract int ID { get; set;  }
        public Storable(string[] lines) { }
        public Storable() { }
        public override abstract string ToString();
    }
}


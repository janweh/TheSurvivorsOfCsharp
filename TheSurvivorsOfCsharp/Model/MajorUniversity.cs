using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheSurvivorsOfCsharp.Model
{
    public class MajorUniversity
    {
        public int ID { get; set; }
        public int MajorID { get; set; }
        public int UniversityID { get; set; }

        public virtual Major Major { get; set; }
        public virtual University University { get; set; }
    }
}

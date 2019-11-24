using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheSurvivorsOfCsharp.Model
{
    public class CourseMajor
    {
        public int ID { get; set; }
        public int CoursID { get; set; }
        public int MajorID { get; set; }

        public virtual Course Course { get; set; }
        public virtual Major Major { get; set; }
    }
}

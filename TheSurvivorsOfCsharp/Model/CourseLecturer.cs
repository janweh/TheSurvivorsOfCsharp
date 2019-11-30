using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheSurvivorsOfCsharp.Model
{
    public class CourseLecturer
    {
        public int ID { get; set; }
        public int CoursID { get; set; }
        public int LecturerID { get; set; }

        public virtual Course Course { get; set; }
        public virtual Lecturer Lecturer { get; set; }
    }
}

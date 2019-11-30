using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheSurvivorsOfCsharp.Model
{
    public class Lecturer
    {
        public int ID { get; set; }
        public string TitleAndName { get; set; }
        public int UniversityID { get; set; }

        public virtual University University { get; set; }
        public virtual ICollection<CourseLecturer> CourseLecturers { get; set; }
    }
}

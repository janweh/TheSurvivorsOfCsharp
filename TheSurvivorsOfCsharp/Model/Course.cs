using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheSurvivorsOfCsharp.Model
{
    public class Course
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Since { get; set; }
        public int? UniversityID { get; set; }
        public int LecturerID { get; set; }

        public virtual University University { get; set; }
        public virtual Lecturer Lecturer { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<CourseMajor> CourseMajors { get; set; }
    }
}

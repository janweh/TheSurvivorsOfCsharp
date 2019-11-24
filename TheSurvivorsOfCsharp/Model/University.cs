using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheSurvivorsOfCsharp.Model
{
    public class University
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Lecturer> Lecturers { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<MajorUniversity> MajorUniversities { get; set; }
    }
}

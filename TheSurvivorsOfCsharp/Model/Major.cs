using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheSurvivorsOfCsharp.Model
{
    public class Major
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MajorUniversity> MajorUniversities { get; set; }
        public virtual ICollection<CourseMajor> CourseMajors { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheSurvivorsOfCsharp.Model
{
    public class Rating
    {
        public int ID { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public int Grade { get; set; }
        public string Comment { get; set; }
        public int Semester { get; set; }
        public int OverallRating { get; set; }
        public int ContactHours { get; set; }
        public int SelfStudyHours { get; set; }
        public int Organized { get; set; }
        public int Learned { get; set; }
        public int Interesting { get; set; }
        public int Presentation { get; set; }
        public bool PassedFirstTime { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
}
}

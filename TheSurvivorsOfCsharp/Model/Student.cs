using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheSurvivorsOfCsharp.Model
{
    public class Student
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string AreaOfStudies { get; set; }
        public string Email { get; set; }
        public int UniversityID { get; set; }

        public virtual University University { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}

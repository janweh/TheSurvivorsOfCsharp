using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TheSurvivorsOfCsharp.Model;

namespace TheSurvivorsOfCsharp.Data
{
    public class TheSurvivorsOfCsharpContext : DbContext
    {
        public TheSurvivorsOfCsharpContext (DbContextOptions<TheSurvivorsOfCsharpContext> options)
            : base(options)
        {
        }


        public DbSet<TheSurvivorsOfCsharp.Model.Major> Major { get; set; }

        public DbSet<TheSurvivorsOfCsharp.Model.Rating> Rating { get; set; }

        public DbSet<TheSurvivorsOfCsharp.Model.Student> Student { get; set; }

        public DbSet<TheSurvivorsOfCsharp.Model.University> University { get; set; }

        public DbSet<TheSurvivorsOfCsharp.Model.CourseMajor> CourseMajor { get; set; }

        public DbSet<TheSurvivorsOfCsharp.Model.MajorUniversity> MajorUniversity { get; set; }

        public DbSet<TheSurvivorsOfCsharp.Model.Lecturer> Lecturer { get; set; }

        public DbSet<TheSurvivorsOfCsharp.Model.Course> Course { get; set; }

        public DbSet<TheSurvivorsOfCsharp.Model.CourseLecturer> CourseLecturer { get; set; }

    }
}

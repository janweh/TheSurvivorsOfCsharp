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


        public DbSet<Major> Major { get; set; }

        public DbSet<Rating> Rating { get; set; }

        public DbSet<Student> Student { get; set; }

        public DbSet<University> University { get; set; }

        public DbSet<CourseMajor> CourseMajor { get; set; }

        public DbSet<MajorUniversity> MajorUniversity { get; set; }

        public DbSet<Lecturer> Lecturer { get; set; }

        public DbSet<Course> Course { get; set; }

        public DbSet<CourseLecturer> CourseLecturer { get; set; }

    }
}

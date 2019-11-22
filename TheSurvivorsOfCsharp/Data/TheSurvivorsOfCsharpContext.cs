using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WindowsFormsApp15.model;

namespace TheSurvivorsOfCsharp.Data
{
    public class TheSurvivorsOfCsharpContext : DbContext
    {
        public TheSurvivorsOfCsharpContext (DbContextOptions<TheSurvivorsOfCsharpContext> options)
            : base(options)
        {
        }

        public DbSet<WindowsFormsApp15.model.Course> Course { get; set; }
    }
}

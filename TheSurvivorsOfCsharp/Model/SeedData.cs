using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheSurvivorsOfCsharp.Data;

namespace TheSurvivorsOfCsharp.Model
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new TheSurvivorsOfCsharpContext(
                serviceProvider.GetRequiredService
                <DbContextOptions<TheSurvivorsOfCsharpContext>>()))
            {
                if (context.University.Any()/* ||
                    context.Lecturer.Any() ||
                    context.Major.Any() ||
                    context.Student.Any() ||
                    context.Course.Any() ||
                    context.Rating.Any()*/)
                {
                    return;
                }

                University u1 = new University { Name = "Vilnius University" };
                University u2 = new University { Name = "Kaunas University" };
                context.University.AddRange(u1, u2);
                /*
                Lecturer l1 = new Lecturer
                {
                    TitleAndName = "Prof. dr. Algimantas Venčkauskas",
                    University = context.University.
                };
                Lecturer l2 = new Lecturer
                {
                    TitleAndName = "Donatas Kimutis",
                    University = u1
                };
                context.Lecturer.AddRange(
                    l1, l2
                    );*/
                context.SaveChanges();
            }
        }
    }
}

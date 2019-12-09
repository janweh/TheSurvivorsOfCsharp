using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheSurvivorsOfCsharp.Model;
using TheSurvivorsOfCsharp.Helpers;

namespace TheSurvivorsOfCsharp.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly Data.TheSurvivorsOfCsharpContext _context;

        public IndexModel(Data.TheSurvivorsOfCsharpContext context)
        {
            _context = context;
        }

        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToPage("/Courses/EntryPage");
        }

        public IList<Course> Course { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public SelectList Universities { get; set; }
        [BindProperty(SupportsGet = true)]
        public string University { get; set; }
        public SelectList Majors { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Major { get; set; }
        public SelectList Lecturers { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Lecturer { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> UniQuery = from u in _context.University
                                            orderby u.Name
                                          select u.Name;

            IQueryable<string> MajorQuery = from m in _context.Major
                                            orderby m.Name
                                            select m.Name;

            IQueryable<string> LecturerQuery = from l in _context.Lecturer
                                            orderby l.TitleAndName
                                            select l.TitleAndName;

            var courses = from c in _context.Course
                         select c;
            if (!string.IsNullOrEmpty(SearchString))
            {
                courses = courses.Where(s => s.Name.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(University))
            {
                courses = courses.Where(x => x.University.Name == University);
            }
            if (!string.IsNullOrEmpty(Major))
            {
                courses = from cM in _context.CourseMajor
                          join m in _context.Major
                          on cM.MajorID equals m.ID
                          join c in courses
                          on cM.CoursID equals c.ID
                          where m.Name == Major
                          select c;
            }
            if (!string.IsNullOrEmpty(Lecturer))
            {
                courses = from cL in _context.CourseLecturer
                          join l in _context.Lecturer
                          on cL.LecturerID equals l.ID
                          join c in courses
                          on cL.CoursID equals c.ID
                          where l.TitleAndName == Lecturer
                          select c;
            }


            Universities = new SelectList(await UniQuery.Distinct().ToListAsync());
            Majors = new SelectList(await MajorQuery.Distinct().ToListAsync());
            Lecturers = new SelectList(await LecturerQuery.Distinct().ToListAsync());
            Course = await courses
                .Include(c => c.University).ToListAsync();
        }

        public string SemesterName(Semester s)
        {
            return s.GetDescription();
        }
    }
}

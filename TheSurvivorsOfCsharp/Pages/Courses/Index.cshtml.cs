using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheSurvivorsOfCsharp.Data;
using TheSurvivorsOfCsharp.Model;

namespace TheSurvivorsOfCsharp.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly TheSurvivorsOfCsharp.Data.TheSurvivorsOfCsharpContext _context;

        public IndexModel(TheSurvivorsOfCsharp.Data.TheSurvivorsOfCsharpContext context)
        {
            _context = context;
        }

        public IList<Course> Course { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public SelectList Universities { get; set; }
        [BindProperty(SupportsGet = true)]
        public string University { get; set; }


        public async Task OnGetAsync()
        {
            IQueryable<string> UniQuery = from u in _context.University
                                            orderby u.Name
                                          select u.Name;

      

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


            Universities = new SelectList(await UniQuery.Distinct().ToListAsync());
            Course = await courses
                .Include(c => c.University).ToListAsync();
        }
    }
}

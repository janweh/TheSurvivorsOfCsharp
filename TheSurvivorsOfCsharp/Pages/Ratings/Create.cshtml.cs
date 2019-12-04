using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheSurvivorsOfCsharp.Data;
using TheSurvivorsOfCsharp.Helpers;
using TheSurvivorsOfCsharp.Model;

namespace TheSurvivorsOfCsharp.Pages.Ratings
{
    public class CreateModel : PageModel
    {
        private readonly TheSurvivorsOfCsharp.Data.TheSurvivorsOfCsharpContext _context;

        public CreateModel(TheSurvivorsOfCsharp.Data.TheSurvivorsOfCsharpContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Rating Rating { get; set; }
        [BindProperty]
        public Course Course { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Course = await _context.Course
                .Include(c => c.University).FirstOrDefaultAsync(m => m.ID == id);

            if (Course == null)
            {
                return NotFound();
            }

            ViewData["Grade"] = new SelectList(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            ViewData["OverallRating"] = new SelectList(new List<int> { 1, 2, 3, 4, 5 });
            ViewData["Organized"] = new SelectList(new List<int> { 1, 2, 3, 4, 5 });
            ViewData["Presentation"] = new SelectList(new List<int> { 1, 2, 3, 4, 5 });
            ViewData["Interesting"] = new SelectList(new List<int> { 1, 2, 3, 4, 5 });
            ViewData["Learned"] = new SelectList(new List<int> { 1, 2, 3, 4, 5 });

            var enumData = from Semester enumItem in Enum.GetValues(typeof(Semester))
                           select new
                           {
                               Value = (int)enumItem,
                               Text = enumItem.GetDescription()
                           };
            ViewData["Semester"] = new SelectList(enumData, "Value", "Text");

            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Rating.CourseID = Course.ID;
            Rating.StudentID = 1;
            Rating.Date = DateTime.Now;
            _context.Rating.Add(Rating);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Courses/Details", new { id = Course.ID });
        }
    }
}

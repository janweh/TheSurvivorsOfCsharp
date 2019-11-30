using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheSurvivorsOfCsharp.Data;
using TheSurvivorsOfCsharp.Model;

namespace TheSurvivorsOfCsharp.Pages.CourseLecturers
{
    public class DeleteModel : PageModel
    {
        private readonly TheSurvivorsOfCsharp.Data.TheSurvivorsOfCsharpContext _context;

        public DeleteModel(TheSurvivorsOfCsharp.Data.TheSurvivorsOfCsharpContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CourseLecturer CourseLecturer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CourseLecturer = await _context.CourseLecturer
                .Include(c => c.Lecturer).FirstOrDefaultAsync(m => m.ID == id);

            if (CourseLecturer == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CourseLecturer = await _context.CourseLecturer.FindAsync(id);

            if (CourseLecturer != null)
            {
                _context.CourseLecturer.Remove(CourseLecturer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

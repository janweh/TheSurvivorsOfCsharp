﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheSurvivorsOfCsharp.Data;
using TheSurvivorsOfCsharp.Model;

namespace TheSurvivorsOfCsharp.Pages.Universities
{
    public class EditModel : PageModel
    {
        private readonly TheSurvivorsOfCsharp.Data.TheSurvivorsOfCsharpContext _context;

        public EditModel(TheSurvivorsOfCsharp.Data.TheSurvivorsOfCsharpContext context)
        {
            _context = context;
        }

        [BindProperty]
        public University University { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            University = await _context.University.FirstOrDefaultAsync(m => m.ID == id);

            if (University == null)
            {
                return NotFound();
            }
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

            _context.Attach(University).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UniversityExists(University.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool UniversityExists(int id)
        {
            return _context.University.Any(e => e.ID == id);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TheSurvivorsOfCsharp.Data;
using TheSurvivorsOfCsharp.Model;

namespace TheSurvivorsOfCsharp.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly TheSurvivorsOfCsharp.Data.TheSurvivorsOfCsharpContext _context;

        public CreateModel(TheSurvivorsOfCsharp.Data.TheSurvivorsOfCsharpContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["UniversityID"] = new SelectList(_context.Set<University>(), "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Student.Add(Student);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Courses/EntryPage");
        }
    }
}

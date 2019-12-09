using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheSurvivorsOfCsharp.Data;
using TheSurvivorsOfCsharp.Model;

namespace TheSurvivorsOfCsharp.Pages
{
    public class ProfileModel : PageModel
    {
        [BindProperty]
        public Student student { get; set; }

        public string Msg;

        private readonly TheSurvivorsOfCsharpContext _context;

        public ProfileModel(TheSurvivorsOfCsharpContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            var username = HttpContext.Session.GetString("username");
            var email = HttpContext.Session.GetString("email");
            var university = HttpContext.Session.GetString("university");
            
            student = _context.Student.SingleOrDefault(a => a.UserName.Equals(username));
 

        }

        public IActionResult OnPost()
        {
            if(!string.IsNullOrEmpty(student.Password))
            {
              // student.Password = 
            }
            _context.Entry(student).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return RedirectToPage("Profile");
        }
    }
}
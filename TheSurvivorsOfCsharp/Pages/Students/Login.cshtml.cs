using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheSurvivorsOfCsharp.Model;
using TheSurvivorsOfCsharp.Data;
using Microsoft.AspNetCore.Http;

namespace TheSurvivorsOfCsharp.Pages.Students
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Student student { get; set; }

        public string Msg;

        private readonly TheSurvivorsOfCsharpContext _context;

        public LoginModel(TheSurvivorsOfCsharpContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            student = new Student();
        }

        public IActionResult OnPost()
        {
            var acc = login(student.UserName, student.Password);
            if(acc == null)
            {
                Msg = "invalid";
                return Page();
            }
            else
            {
                HttpContext.Session.SetString("username", acc.UserName);
                HttpContext.Session.SetInt32("ID", acc.ID);
                return RedirectToPage("/Courses/EntryPage");
            }
        }

        private Student login(string username, string password)
        {
            var student = _context.Student.SingleOrDefault(a => a.UserName.Equals(username));
            if(student != null)
            {
                if(student.Password.Equals(password))
                {
                    return student;
                }
            }
            return null;
        }
    }
}
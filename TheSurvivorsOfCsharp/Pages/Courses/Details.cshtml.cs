using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheSurvivorsOfCsharp.Data;
using TheSurvivorsOfCsharp.Model;
using WindowsFormsApp15.view;

namespace TheSurvivorsOfCsharp.Pages.Courses
{
    public class DetailsModel : PageModel
    {
        private readonly TheSurvivorsOfCsharp.Data.TheSurvivorsOfCsharpContext _context;

        public DetailsModel(TheSurvivorsOfCsharp.Data.TheSurvivorsOfCsharpContext context)
        {
            _context = context;
        }

        public Course Course { get; set; }
        public IEnumerable<Major> Majors { get; set; }
        public IEnumerable<Lecturer> Lecturers { get; set; }
        public List<Comment> Comments { get; set; }
        public string OverallRating { get; set; }
        public string ContactHours { get; set; }
        public string SelfStudyHours { get; set; }
        public string Organized { get; set; }
        public string Learned { get; set; }
        public string Interesting { get; set; }
        public string Presented { get; set; }

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

            SetRatingParameters(id);

            Majors = from cM in _context.CourseMajor
                     join m in _context.Major
                     on cM.MajorID equals m.ID
                     where cM.CoursID == id
                     select m;

            Lecturers = from cL in _context.CourseLecturer
                        join l in _context.Lecturer
                        on cL.LecturerID equals l.ID
                        where cL.CoursID == id
                        select l;

            return Page();
        }

        private void SetRatingParameters(int? id)
        {
            var ratings = _context.Rating.Where(r => r.CourseID == id);

            double overallRating = 0;
            double contactHours = 0;
            double selfStudyHours = 0;
            double organized = 0;
            double learned = 0;
            double interesting = 0;
            double presented = 0;

            Comments = new List<Comment>();

            foreach (Rating rating in ratings)
            {
                overallRating += rating.OverallRating;
                contactHours += rating.ContactHours;
                selfStudyHours += rating.SelfStudyHours;
                organized += rating.Organized;
                learned += rating.Learned;
                interesting += rating.Interesting;
                presented += rating.Presentation;

                if(rating.Comment != null && rating.Comment != "")
                {
                    Comments.Add(new Comment
                    {
                        Username = _context.Student.FirstOrDefault(s => s.ID == rating.StudentID).UserName,
                        Date = rating.Date.ToString("d"),
                        Rating = rating.ToString() + "/5",
                        Text = rating.Comment
                    }) ;
                }
            }

            int numberOfRatings = ratings.Count();

            OverallRating = (overallRating / numberOfRatings).ToString("0.##") + "/5";
            ContactHours = (contactHours / numberOfRatings).ToString("0.##");
            SelfStudyHours = (selfStudyHours / numberOfRatings).ToString("0.##");
            Organized = (organized / numberOfRatings).ToString("0.##") + "/5";
            Learned = (learned / numberOfRatings).ToString("0.##") + "/5";
            Interesting = (interesting / numberOfRatings).ToString("0.##") + "/5";
            Presented = (presented / numberOfRatings).ToString("0.##") + "/5";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheSurvivorsOfCsharp.Model;
using TheSurvivorsOfCsharp.Helpers;
using System.Web;
using System.Web.Helpers;

namespace TheSurvivorsOfCsharp.Pages.Courses
{
    public class StatisticsModel : PageModel
    {
        private readonly TheSurvivorsOfCsharp.Data.TheSurvivorsOfCsharpContext _context;

        public StatisticsModel(TheSurvivorsOfCsharp.Data.TheSurvivorsOfCsharpContext context)
        {
            _context = context;
        }

        public Course Course { get; set; }
        public IQueryable<Rating> Ratings { get; set; }
        public int ratingCount;

        public int[] overallRatings;
        public int[] organizedRatings;
        public int[] interestingRatings;
        public int[] presentedRatings;
        public int[] learnedRatings;
        public int[] contactHours;
        public int[] selfStudyHours;
        public int[] grades;
        public int[] gradesAndPassed;

        public string overallAverage;
        public string overallMedian;
        public string overallMostCommon;
        public string overallVariance;

        public string organizedAverage;
        public string organizedMedian;
        public string organizedMostCommon;
        public string organizedVariance;

        public string learnedAverage;
        public string learnedMedian;
        public string learnedMostCommon;
        public string learnedVariance;

        public string interestingAverage;
        public string interestingMedian;
        public string interestingMostCommon;
        public string interestingVariance;

        public string presentedAverage;
        public string presentedMedian;
        public string presentedMostCommon;
        public string presentedVariance;

        public string contactHoursAverage;
        public string contactHoursMedian;
        public string contactHoursMostCommon;
        public string contactHoursVariance;

        public string selfStudyHoursAverage;
        public string selfStudyHoursMedian;
        public string selfStudyHoursMostCommon;
        public string selfStudyHoursVariance;

        public string gradesAverage;
        public string gradesMedian;
        public string gradesMostCommon;
        public string gradesVariance;

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

            Ratings = from r in _context.Rating
                      where r.CourseID == id
                      select r;

            ratingCount = Ratings.Count();

            GetValuesFromCourses();

            return Page();
        }

        private void GetValuesFromCourses()
        {
            overallRatings = new int[5];
            organizedRatings = new int[5];
            interestingRatings = new int[5];
            presentedRatings = new int[5];
            learnedRatings = new int[5];
            List<int> contactHoursList = new List<int>();
            List<int> selfStudyHoursList = new List<int>();
            List<int> gradesList = new List<int>();
            List<Tuple<int, bool>> gradesAndPassedList = new List<Tuple<int, bool>>();
            foreach (Rating rating in Ratings)
            {
                overallRatings[rating.OverallRating - 1]++;
                organizedRatings[rating.Organized - 1]++;
                interestingRatings[rating.Interesting - 1]++;
                presentedRatings[rating.Presentation - 1]++;
                learnedRatings[rating.Learned - 1]++;
                contactHoursList.Add(rating.ContactHours);
                selfStudyHoursList.Add(rating.SelfStudyHours);
                gradesList.Add(rating.Grade);
                gradesAndPassedList.Add(new Tuple<int, bool>(rating.Grade, rating.PassedFirstTime));
            }

            contactHours = ComputeStatistics.GroupHours(contactHoursList);
            selfStudyHours = ComputeStatistics.GroupHours(selfStudyHoursList);
            grades = ComputeStatistics.GroupGrades(gradesList);
            gradesAndPassed = ComputeStatistics.GroupPassed(gradesAndPassedList);

            double tmp = ComputeStatistics.ComputeAverageGrouped(overallRatings);
            overallAverage = "Average: " + tmp.ToString("0.##");
            tmp = ComputeStatistics.ComputeMedianGrouped(overallRatings);
            overallMedian = "Median: " + tmp.ToString("0.##");
            tmp = ComputeStatistics.ComputeVarianceGrouped(overallRatings);
            overallVariance = "Variance: " + tmp.ToString("0.####");
            List<int> tmpList = ComputeStatistics.ComputeMostCommonGrouped(overallRatings);
            overallMostCommon = "Most common: " + string.Join(',', tmpList);

            tmp = ComputeStatistics.ComputeAverageGrouped(organizedRatings);
            organizedAverage = "Average: " + tmp.ToString("0.##");
            tmp = ComputeStatistics.ComputeMedianGrouped(organizedRatings);
            organizedMedian = "Median: " + tmp.ToString("0.##");
            tmp = ComputeStatistics.ComputeVarianceGrouped(organizedRatings);
            organizedVariance = "Variance: " + tmp.ToString("0.####");
            tmpList = ComputeStatistics.ComputeMostCommonGrouped(organizedRatings);
            organizedMostCommon = "Most common: " + string.Join(',', tmpList);

            tmp = ComputeStatistics.ComputeAverageGrouped(presentedRatings);
            presentedAverage = "Average: " + tmp.ToString("0.##");
            tmp = ComputeStatistics.ComputeMedianGrouped(presentedRatings);
            presentedMedian = "Median: " + tmp.ToString("0.##");
            tmp = ComputeStatistics.ComputeVarianceGrouped(presentedRatings);
            presentedVariance = "Variance: " + tmp.ToString("0.####");
            tmpList = ComputeStatistics.ComputeMostCommonGrouped(presentedRatings);
            presentedMostCommon = "Most common: " + string.Join(',', tmpList);

            tmp = ComputeStatistics.ComputeAverageGrouped(interestingRatings);
            interestingAverage = "Average: " + tmp.ToString("0.##");
            tmp = ComputeStatistics.ComputeMedianGrouped(interestingRatings);
            interestingMedian = "Median: " + tmp.ToString("0.##");
            tmp = ComputeStatistics.ComputeVarianceGrouped(interestingRatings);
            interestingVariance = "Variance: " + tmp.ToString("0.####");
            tmpList = ComputeStatistics.ComputeMostCommonGrouped(interestingRatings);
            interestingMostCommon = "Most common: " + string.Join(',', tmpList);

            tmp = ComputeStatistics.ComputeAverageGrouped(learnedRatings);
            learnedAverage = "Average: " + tmp.ToString("0.##");
            tmp = ComputeStatistics.ComputeMedianGrouped(learnedRatings);
            learnedMedian = "Median: " + tmp.ToString("0.##");
            tmp = ComputeStatistics.ComputeVarianceGrouped(learnedRatings);
            learnedVariance = "Variance: " + tmp.ToString("0.####");
            tmpList = ComputeStatistics.ComputeMostCommonGrouped(learnedRatings);
            learnedMostCommon = "Most common: " + string.Join(',', tmpList);

            tmp = ComputeStatistics.ComputeAverageSingles(contactHoursList);
            contactHoursAverage = "Average: " + tmp.ToString("0.##");
            tmp = ComputeStatistics.ComputeMedianSingles(contactHoursList);
            contactHoursMedian = "Median: " + tmp.ToString("0.##");
            tmp = ComputeStatistics.ComputeVarianceSingles(contactHoursList);
            contactHoursVariance = "Variance: " + tmp.ToString("0.####");
            tmpList = ComputeStatistics.ComputeMostCommonSingles(contactHoursList);
            contactHoursMostCommon = "Most common: " + string.Join(',', tmpList);

            tmp = ComputeStatistics.ComputeAverageSingles(selfStudyHoursList);
            selfStudyHoursAverage = "Average: " + tmp.ToString("0.##");
            tmp = ComputeStatistics.ComputeMedianSingles(selfStudyHoursList);
            selfStudyHoursMedian = "Median: " + tmp.ToString("0.##");
            tmp = ComputeStatistics.ComputeVarianceSingles(selfStudyHoursList);
            selfStudyHoursVariance = "Variance: " + tmp.ToString("0.####");
            tmpList = ComputeStatistics.ComputeMostCommonSingles(selfStudyHoursList);
            selfStudyHoursMostCommon = "Most common: " + string.Join(',', tmpList);

            tmp = ComputeStatistics.ComputeAverageSingles(gradesList);
            gradesAverage = "Average: " + tmp.ToString("0.##");
            tmp = ComputeStatistics.ComputeMedianSingles(gradesList);
            gradesMedian = "Median: " + tmp.ToString("0.##");
            tmp = ComputeStatistics.ComputeVarianceSingles(gradesList);
            gradesVariance = "Variance: " + tmp.ToString("0.####");
            tmpList = ComputeStatistics.ComputeMostCommonSingles(gradesList);
            gradesMostCommon = "Most common: " + string.Join(',', tmpList);
        }
    }
}

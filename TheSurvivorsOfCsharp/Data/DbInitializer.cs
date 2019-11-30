using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheSurvivorsOfCsharp.Model;

namespace TheSurvivorsOfCsharp.Data
{
    public class DbInitializer
    {
        public static void Initialize(TheSurvivorsOfCsharpContext context)
        {
            context.Database.EnsureCreated();

            if (context.Course.Any())
            {
                return;
            }

            var universities = new University[]
            {
                new University{ID=1, Name="Vilnius University"},
                new University{ID=2, Name="Kaunas University of Technology"},
                new University{ID=3, Name="Klaipėda University"},
                new University{ID=4, Name="Šiauliai University"}
            };
            foreach(University u in universities)
            {
                context.University.Add(u);
            }
            context.SaveChanges();

            var majors = new Major[]
            {
                new Major{ID=1, Name="Computer Sience"},
                new Major{ID=2, Name="Medicine"},
                new Major{ID=3, Name="Biology"},
                new Major{ID=4, Name="Business administration"},
                new Major{ID=5, Name="Economy"},
                new Major{ID=6, Name="Chemistry"},
                new Major{ID=7, Name="Physics"},
                new Major{ID=8, Name="Teaching"},
                new Major{ID=9, Name="Mathematics"}
            };
            foreach(Major m in majors)
            {
                context.Major.Add(m);
            }
            context.SaveChanges();

            var majorUniversities = new MajorUniversity[]
            {
                new MajorUniversity{UniversityID=1,MajorID=1},
                new MajorUniversity{UniversityID=1,MajorID=2},
                new MajorUniversity{UniversityID=1,MajorID=4},
                new MajorUniversity{UniversityID=1,MajorID=7},
                new MajorUniversity{UniversityID=1,MajorID=9},
                new MajorUniversity{UniversityID=2,MajorID=1},
                new MajorUniversity{UniversityID=2,MajorID=2},
                new MajorUniversity{UniversityID=2,MajorID=3},
                new MajorUniversity{UniversityID=2,MajorID=4},
                new MajorUniversity{UniversityID=3,MajorID=6},
                new MajorUniversity{UniversityID=3,MajorID=7},
                new MajorUniversity{UniversityID=3,MajorID=8},
                new MajorUniversity{UniversityID=1,MajorID=4},
                new MajorUniversity{UniversityID=1,MajorID=5},
                new MajorUniversity{UniversityID=1,MajorID=6}
            };
            foreach(MajorUniversity mU in majorUniversities)
            {
                context.MajorUniversity.Add(mU);
            }
            context.SaveChanges();

            var lecturers = new Lecturer[]
            {
                new Lecturer{ID=1, TitleAndName="Donatas Kimutis", UniversityID=1},
                new Lecturer{ID=2, TitleAndName="Vytautas Ašeris", UniversityID=1},
                new Lecturer{ID=3, TitleAndName="Eduardas Kutka", UniversityID=1},
                new Lecturer{ID=4, TitleAndName="Dr. Linas Bukauskas", UniversityID=1},
                new Lecturer{ID=5, TitleAndName="Dr. Agnė Brilingaitė", UniversityID=1},
                new Lecturer{ID=6, TitleAndName="prof.dr. Rasa Subačienė", UniversityID=1},
                new Lecturer{ID=7, TitleAndName="Birutė Vilčiauskaitė", UniversityID=1}
            };
            foreach(Lecturer l in lecturers)
            {
                context.Lecturer.Add(l);
            }
            context.SaveChanges();

            var courses = new Course[]
            {
                new Course{ID=1, Name="Applied object-oriented programming", UniversityID=1},
                new Course{ID=2, Name="Computer Networks", UniversityID=1},
                new Course{ID=3, Name="Database Management Systems", UniversityID=1},
                new Course{ID=4, Name="Accounting", UniversityID=1},
                new Course{ID=5, Name="Management", UniversityID=1}
            };
            foreach(Course c in courses)
            {
                context.Course.Add(c);
            }
            context.SaveChanges();

            var courselecturers = new CourseLecturer[]
            {
                new CourseLecturer{CoursID=1, LecturerID=1},
                new CourseLecturer{CoursID=1, LecturerID=2},
                new CourseLecturer{CoursID=2, LecturerID=3},
                new CourseLecturer{CoursID=3, LecturerID=4},
                new CourseLecturer{CoursID=3, LecturerID=5},
                new CourseLecturer{CoursID=4, LecturerID=6},
                new CourseLecturer{CoursID=5, LecturerID=7}
            };
            foreach(CourseLecturer cL in courselecturers)
            {
                context.CourseLecturer.Add(cL);
            }
            context.SaveChanges();

            var courseMajors = new CourseMajor[]
            {
                new CourseMajor{CoursID=1, MajorID=1},
                new CourseMajor{CoursID=2, MajorID=1},
                new CourseMajor{CoursID=3, MajorID=1},
                new CourseMajor{CoursID=4, MajorID=4},
                new CourseMajor{CoursID=5, MajorID=4}
            };
            foreach(CourseMajor cM in courseMajors)
            {
                context.CourseMajor.Add(cM);
            }
            context.SaveChanges();

            var students = new Student[]
            {
                new Student{ID=1, UserName="Jan Wehner", UniversityID=1, 
                    AreaOfStudies="Mathematics and computer sciences", Email="jan.wehner@tprs.stud.vu.lt",
                    Password="highlyEncryptedPassword"},
                new Student{ID=2, UserName="Bernadas", UniversityID=2, 
                    AreaOfStudies="Mathematics and computer sciences", Email="someemail@email.com",
                    Password="unbreakablepassword"},
                new Student{ID=3, UserName="Max Mustermann", UniversityID=1,
                    AreaOfStudies="Mathematics and computer sciences", Email="musteremail@gmail.com",
                    Password="password1"}
            };
            foreach(Student s in students)
            {
                context.Student.Add(s);
            }
            context.SaveChanges();

            var ratings = new Rating[]
            {
                new Rating{ StudentID=1, CourseID=1, OverallRating=5, Interesting=5, Learned=5, Organized=4,
                Presentation=3, ContactHours=4, SelfStudyHours=10, Semester=1, Comment="Good course", 
                Grade=8, PassedFirstTime=false, Date=DateTime.Now},
                new Rating{ StudentID=2, CourseID=1, OverallRating=5, Interesting=4, Learned=5, Organized=4,
                Presentation=4, ContactHours=3, SelfStudyHours=8, Semester=1, Comment="Nice course",
                Grade=9, PassedFirstTime=true, Date=DateTime.Now},
                new Rating{ StudentID=3, CourseID=1, OverallRating=3, Interesting=5, Learned=5, Organized=2,
                Presentation=4, ContactHours=4, SelfStudyHours=11, Semester=1, Comment="A nice course",
                Grade=3, PassedFirstTime=false, Date=DateTime.Now}
            };
            foreach(Rating r in ratings)
            {
                context.Rating.Add(r);
            }
            context.SaveChanges();
        }
    }
}

using SchoolCore.entities;
using System;

namespace SchoolCore {

    class Program {
        static void Main(string[] args) {

            School school = new School("University Juarez Autonome of Tabasco",1990);
            school.TypeSchool = TypeSchool.University;
            school.Country = "México";
            school.City = "Villahermosa,Tab";
            Console.WriteLine($"{school}");

            List<Course> course = new List<Course>();

            course.Add(new Course()
            {
                Name = "POO",
                Turn = Turn.Matutine
            });
            course.Add(new Course()
            {
                Name = "POO2",
                Turn = Turn.Vespertine
            });

            PrintCourses(course);
        }

        private static void PrintCourses(List<Course> courses)
        { 
            foreach (Course course in courses) {
                Console.WriteLine($"Name {course.Name}, Turn {course.Turn}, ID {course.Id}");
            }
          

        }
    }

}
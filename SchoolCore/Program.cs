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


            Course course = new Course() {
                Name = "POO",
                Turn = Turn.Matutine
            };
            Course course2 = new Course()
            {
                Name = "POO2",
                Turn = Turn.Vespertine
            };
            Console.WriteLine($"Name {course.Name}, Turn {course.Turn}, ID {course.Id}");
            Console.WriteLine($"Name {course2.Name}, Turn {course2.Turn}, ID {course2.Id}");
        }
    }

}
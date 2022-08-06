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

        }
    }

}
using SchoolCore.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCore.entities
{
    public class School : ObjSchoolBase,IPlace
    {

        public int AgeCreation { get; set; }

        public string Country { get; set; }

        public string City { get; set; }
        public string Direction {get;set;}
        public List<Course> Courses { get; set; }

        public TypeSchool TypeSchool { get; set; }

        public School(string name, int ageCreation) => (Name, AgeCreation) = (name, ageCreation);
        public School(string name,
            int ageCreation,
            TypeSchool type,
            string country = "",
            string city = ""
          )
        {
            (Name, AgeCreation) = (name, ageCreation);
            Country = country;
            City = city;
        }

        public override string ToString()
        {

            return $"Name {Name}, \n Type {TypeSchool},\n Country {Country}, \n City {City} ";
        }

        public void CleanDirection() {
            Printer.LineDraw(70);
            Console.WriteLine($"Cleanign School please whating...");

            foreach (Course course in Courses) {
                course.CleanDirection();
            }
            
            Console.WriteLine($"Course cleaning succefully...");
            Printer.LineDraw(70);

        }
    }
}

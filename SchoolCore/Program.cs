using SchoolCore.entities;
using SchoolCore.util;
using System;


namespace SchoolCore
{

    class Program
    {
        static void Main(string[] args)
        {

           SchoolEngine engine = new SchoolEngine();
            engine.InitializeData();

            PrintSchools(engine.School);
            PrintCourses(engine.School.Courses);
            PrintStudents(engine.School.Courses);
        }

        private static void PrintCourses(List<Course> courses)
        {
            Printer.LineDraw(70);
            Printer.Beep(10000,500,5);
            foreach (Course course in courses)
            {
                Console.WriteLine($"Name {course.Name}, Turn {course.Turn}, ID {course.Id}");
            }


        }

        private static void PrintSchools(School school)
        {
            Printer.LineDraw(70);
            Console.WriteLine($"Name {school.Name}, Country {school.Country}, City {school.City}");
        }

        private static void PrintStudents(List<Course> courses)
        {
            Printer.LineDraw(70);
            Printer.Beep(10000, 500, 5);
            foreach (Course course in courses)
            {
          
                Printer.LineDraw(70);
                Printer.Beep(10000, 500, 5);
                Console.WriteLine($"Name {course.Name}, Turn {course.Turn}, ID {course.Id}");
         
               
                foreach (Student student in course.Student) {
                    Printer.LineDraw(70);
                    Printer.Beep(10000, 500, 5);
                    Console.WriteLine($"Name {student.Name}, ID {student.StudentID}");
                    PrintStudentsEvaluation(student.Evaluation);
                }
              
            }
        }
        private static void PrintStudentsEvaluation(List<Evaluation> evaluation)
        {
      
                Printer.LineDraw(70);
                Printer.Beep(10000, 500, 5);
                foreach (Evaluation ev in evaluation)
                {
                    Console.WriteLine($"Name {ev.Name}, ID {ev.Note}");

                }

        
        }
    }

}
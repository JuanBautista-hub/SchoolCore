using SchoolCore.app;
using SchoolCore.entities;
using SchoolCore.util;
using System;


namespace SchoolCore
{

    class Program
    {
        static void Main(string[] args)
        {

            AppDomain.CurrentDomain.ProcessExit += ActionEvent;

            SchoolEngine engine = new SchoolEngine();
            engine.InitializeData();
            // engine.School.CleanDirection(); ;
            //var listPlace = engine.UseExampleDictionary();
            // engine.PrintDictionary(listPlace,true,false,false,false,true);
            var report = new Report(engine.UseExampleDictionary());
            var evaluation = report.GetTopAverage();
            foreach (var item in evaluation)
            {
                foreach (var item2 in item.Value)
                {
                    Printer.LineDraw(30);
                    Console.WriteLine($"Alumno:{item2.StudentName}");
                    Console.WriteLine($"Promedio:{item2.Average}");
                    Console.WriteLine($"Subject:{item2.Subject}");

                }
            }
        }

        private static void ActionEvent(object? sender, EventArgs e)
        {
            Console.Beep(300, 1000);
        }

        private static void PrintCourses(List<Course> courses)
        {
            Printer.LineDraw(70);
            Printer.Beep(10000, 500, 5);
            foreach (Course course in courses)
            {
                Console.WriteLine($"Name {course.Name}, Turn {course.Turn}, ID {course.UniqueID}");
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
                Console.WriteLine($"Name {course.Name}, Turn {course.Turn}, ID {course.UniqueID}");

                foreach (Student student in course.Student)
                {
                    Printer.LineDraw(70);
                    Printer.Beep(10000, 500, 5);
                    Console.WriteLine($"Name {student.Name}, ID {student.UniqueID}");
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
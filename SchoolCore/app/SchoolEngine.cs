using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolCore.entities;
namespace SchoolCore
{
    public class SchoolEngine
    {

        public School School { set; get; }

        public SchoolEngine()
        {

        }

        public void InitializeData()
        {
            School = new School("University Juarez Autonome of Tabasco", 1990)
            {
                TypeSchool = TypeSchool.University,
                Country = "México",
                City = "Villahermosa,Tab"
            };


            LoadCourses();
            GeneraSubjects();
            LoadEvaluations();

        }

        private void LoadCourses()
        {

            School.Courses = new List<Course>()
            {
              new Course()
            {
                Name = "POO",
                Turn = Turn.Matutine
            },
                new Course()
            {
                Name = "POO2",
                Turn = Turn.Vespertine
            }
            };

            //lambda
          /*  School.Courses.RemoveAll(cur =>
            {
                return cur.Name == "POO2";
            });*/
            Random rnd = new Random();
          
            foreach (var cour in School.Courses)
            {
                int cantRamdom = rnd.Next(5, 20);
                cour.Student = GenerateStudents(cantRamdom);

            }

        }

        private List<Student> GenerateStudents(int cant) {
            string[] name = {"Marcos","Raul","Jorge","Albert","Jhon","Elizabeth","Nicolas"};
            string[] fistApend = { "Ruiz","Martin","Alba","Maryin","Lorem","Ipsum","LoIP"};
            string[] name2 = { "Marcos", "Raul", "Jorge", "Albert", "Jhon", "Elizabeth", "Nicolas" };

            var alumnos = from n1 in name
                          from n2 in name2 from a1 in fistApend
                          select new Student { Name = $"{n1} {n2} {a1}" };
            return alumnos.OrderBy((al)=>al.StudentID).Take(cant).ToList();
        }
        private void GeneraSubjects() {
            foreach (var course in School.Courses)
            {

                List<Subject> ListSucject = new List<Subject>() {
                new Subject{ Name = "Introdution to JavaScrip"},
                   new Subject{ Name = "Algoritms"},
                      new Subject{ Name = "Introduction a the Software ingeniering"},


                };
                course.Subject = ListSucject;
         
            }

        }
        private void LoadEvaluations() {

         

            foreach (var cour in School.Courses)
            {
             
                foreach (var subj in cour.Subject) {
                    foreach (var alum in cour.Student) {
                        var rnd =new Random(System.Environment.TickCount);
                        for (int i = 0; i<5;i++) {

                            var ev = new Evaluation
                            {

                                Subject = subj,
                                Name = $"{subj.Name} Ev#{i + 1}",
                                Note = (float)(5 * rnd.NextDouble()),
                                Student = alum,
                            };
                            alum.Evaluation.Add(ev);
                        }

                    }
                }

            }

        }
    }
}

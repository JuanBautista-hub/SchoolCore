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
            LoadStudents();
            LoadSubjects();
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
            School.Courses.RemoveAll(cur =>
            {
                return cur.Name == "POO2";
            });

        }

        private void LoadStudents() {
            string[] name = {"Marcos","Raul","Jorge","Albert","Jhon","Elizabeth","Nicolas"};
            string[] fistApend = { "","","","","","",""};
            string[] name2 = { "Marcos", "Raul", "Jorge", "Albert", "Jhon", "Elizabeth", "Nicolas" };


        }
        private void LoadSubjects() {
            foreach (var course in School.Courses)
            {

                List<Subject> ListSucject = new List<Subject>() {
                new Subject{ Name = "Introdution to JavaScrip"},
                   new Subject{ Name = "Algoritms"},
                      new Subject{ Name = "Introduction a the Software ingeniering"},


                };
                course.Subject.AddRange(ListSucject);
            }
        }
        private void LoadEvaluations() { }
    }
}

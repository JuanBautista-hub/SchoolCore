using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolCore.entities;
namespace SchoolCore.app
{
    public sealed class SchoolEngine
    {
        public School School { set; get; }
        //sealed puedo instanciar pero no heredar
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

        #region
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

            Random rnd = new Random();

            foreach (var cour in School.Courses)
            {
                int cantRamdom = rnd.Next(5, 20);
                cour.Student = GenerateStudents(cantRamdom);

            }

        }

        private List<Student> GenerateStudents(int cant)
        {
            string[] name = { "Marcos", "Raul", "Jorge", "Albert", "Jhon", "Elizabeth", "Nicolas" };
            string[] fistApend = { "Ruiz", "Martin", "Alba", "Maryin", "Lorem", "Ipsum", "LoIP" };
            string[] name2 = { "Marcos", "Raul", "Jorge", "Albert", "Jhon", "Elizabeth", "Nicolas" };

            var alumnos = from n1 in name
                          from n2 in name2
                          from a1 in fistApend
                          select new Student { Name = $"{n1} {n2} {a1}" };
            return alumnos.OrderBy((al) => al.UniqueID).Take(cant).ToList();
        }

        private void GeneraSubjects()
        {
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

        private void LoadEvaluations()
        {
            var rnd = new Random();
            foreach (var cour in School.Courses)
            {
                foreach (var subj in cour.Subject)
                {
                    foreach (var alum in cour.Student)
                    {
             
                        for (int i = 1; i < 5; i++)
                        {

                            var ev = new Evaluation
                            {

                                Subject = subj,
                                Name = $"{subj.Name} Ev#{i + 1}",
                                Note = (float)(10 * rnd.NextDouble()),
                                Student = alum,
                            };
                            alum.Evaluation.Add(ev);
                        }

                    }
                }

            }

        }
        #endregion

        #region sobrecarga de methodo
        public IReadOnlyList<ObjSchoolBase> GetObjSchool(
          bool bringEvaluations = true,
          bool bringStudents = true,
          bool bringSubjects = true,
          bool bringCourses = true
         )
        {
            return GetObjSchool(out int dummy, out dummy, out dummy, out dummy);
        }

        public IReadOnlyList<ObjSchoolBase> GetObjSchool(
         out int countEvaluations,
         bool bringEvaluations = true,
         bool bringStudents = true,
         bool bringSubjects = true,
         bool bringCourses = true
         )
        {
            return GetObjSchool(out countEvaluations, out int dummy, out dummy, out dummy);
        }

        public IReadOnlyList<ObjSchoolBase> GetObjSchool(
          out int countEvaluations,
          out int countStudents,
          bool bringEvaluations = true,
          bool bringStudents = true,
          bool bringSubjects = true,
          bool bringCourses = true
          )
        {
            return GetObjSchool(out countEvaluations, out countStudents, out int dummy, out dummy);
        }

        public IReadOnlyList<ObjSchoolBase> GetObjSchool(
          out int countEvaluations,
          out int countStudents,
          out int countSubjects,
          bool bringEvaluations = true,
          bool bringStudents = true,
          bool bringSubjects = true,
          bool bringCourses = true
          )
        {
            return GetObjSchool(out countEvaluations, out countStudents, out countSubjects, out int dummy);
        }

        public IReadOnlyList<ObjSchoolBase> GetObjSchool(
           out int countEvaluations,
           out int countStudents,
           out int countSubjects,
           out int countCourses,
           bool bringEvaluations = true,
           bool bringStudents = true,
           bool bringSubjects = true,
           bool bringCourses = true
          )
        {

            var listObj = new List<ObjSchoolBase>();
            listObj.Add(School);
            countCourses = countSubjects = countStudents = countEvaluations = 0;

            if (bringCourses) listObj.AddRange(School.Courses);
            countCourses += School.Courses.Count();
            foreach (var obj in School.Courses)
            {
                if (bringSubjects) listObj.AddRange(obj.Subject);
                countSubjects += obj.Subject.Count();
                if (bringStudents) listObj.AddRange(obj.Student);
                countStudents += obj.Student.Count();
                if (bringEvaluations)
                {
                    foreach (var alumn in obj.Student)
                    {
                        countEvaluations += alumn.Evaluation.Count();
                        listObj.AddRange(alumn.Evaluation);
                    }
                }
            }
            return listObj.AsReadOnly();
        }
        #endregion

        public Dictionary<KeysDictionary, IEnumerable<ObjSchoolBase>> UseExampleDictionary()
        {
            var dict = new Dictionary<KeysDictionary, IEnumerable<ObjSchoolBase>>();
            dict.Add(KeysDictionary.School, new[] { School });
            dict.Add(KeysDictionary.Courses, School.Courses.Cast<ObjSchoolBase>());

            var listTemp = new List<Evaluation>();
            var listTempSubject = new List<Subject>();
            var listTempStudent = new List<Student>();

            foreach (var course in School.Courses)
            {
                listTempSubject.AddRange(course.Subject);
                listTempStudent.AddRange(course.Student);
                foreach (var stud in course.Student)
                {
                    listTemp.AddRange(stud.Evaluation);
                }
            }

            dict.Add(KeysDictionary.Subject, listTempSubject.Cast<ObjSchoolBase>());
            dict.Add(KeysDictionary.Student, listTempStudent.Cast<ObjSchoolBase>());
            dict.Add(KeysDictionary.Evaluation, listTemp.Cast<ObjSchoolBase>());

            return dict;
        }

        public void PrintDictionary(Dictionary<KeysDictionary, IEnumerable<ObjSchoolBase>> dicc,
            bool printSchool = false,
            bool printStudent = false,
            bool printCourse = false,
            bool printSubject = false,
            bool printEvaluation = false
            )
        {

            foreach (var item in dicc)
            {
                util.Printer.WriteTitle($"{item.Key.ToString()}");
                foreach (var element in item.Value)
                {
                  

                    switch (item.Key)
                    {
                        case KeysDictionary.School:
                            if(printSchool)
                                Console.WriteLine(element);
                            break;
                        case KeysDictionary.Student:
                            if (printStudent)
                                Console.WriteLine(element);
                            break;
                        case KeysDictionary.Evaluation:
                            if (printEvaluation)
                                Console.WriteLine(element);
                            break;
                        case KeysDictionary.Courses:
                            if (printCourse)
                                Console.WriteLine(element);
                            break;
                        case KeysDictionary.Subject:
                            if (printSubject)
                                Console.WriteLine(element);
                            break;
                    }
                }
            }
        }
    }
}

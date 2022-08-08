using SchoolCore.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCore.entities
{
    public class Course:ObjSchoolBase,IPlace
    {
        public Turn Turn { get; set; }
        public List<Subject> Subject { get; set; }
        public List<Student> Student { get; set; }
        public string Direction { get; set; }
        public void CleanDirection()
        {
            Console.WriteLine($"Cleanign course { Name} please whating...");

        }
    }
}

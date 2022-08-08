using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCore.entities
{
    public class Course:ObjSchoolBase
    {
        public Turn Turn { get; set; }
        public List<Subject> Subject { get; set; }
        public List<Student> Student { get; set; }
    }
}

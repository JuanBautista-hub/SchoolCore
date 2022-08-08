using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCore.entities
{
    public class Student
    {
        public string StudentID { get; set; }
        public string Name { get; set; }
        public List<Evaluation> Evaluation { get; set; }

        public Student()
        {
            StudentID = Guid.NewGuid().ToString();
            Evaluation = new List<Evaluation>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCore.entities
{
    public class Student: ObjSchoolBase
    {
        public List<Evaluation> Evaluation { get; set; } = new List<Evaluation>();

    }
}

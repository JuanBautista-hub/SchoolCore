using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCore.entities
{
    public class Evaluation:ObjSchoolBase
    {
        public Student Student { get; set; }
        public Subject Subject { get; set; }
        public float Note { get; set; }
        public override string ToString()
        {
            return $"Note :{Note}, Student:{Student.Name}";
        }

    }

}

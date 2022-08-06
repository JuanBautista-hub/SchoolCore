using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCore.entities
{
    public class Subject
    {
        public string SubjectD { get; set; }
        public string Name { get; set; }


        public Subject()
        {
            SubjectD = Guid.NewGuid().ToString();
        }
    }
}

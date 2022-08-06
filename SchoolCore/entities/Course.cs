using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCore.entities
{
    public class Course
    {
        public string Id { get; private set; }
        public string Name { get; set; }
        public Turn Turn { get; set; }
        public List<Subject> Subject { get; set; }
        public List<Student> Student { get; set; }

        public Course() {
            Id = Guid.NewGuid().ToString();
        }
    }
}

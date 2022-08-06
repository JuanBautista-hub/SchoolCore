using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCore.entities
{
    public class Evaluation
    {
        public string EvaluationID { get; set; }
        public string Name { get; set; }
        public Student Student { get; set; }
        public Subject Subject { get; set; }
        public float Note { get; set; }

        public Evaluation()
        {
            EvaluationID = Guid.NewGuid().ToString();
        }
    }
}

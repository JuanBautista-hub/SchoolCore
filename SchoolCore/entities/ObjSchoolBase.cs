using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCore.entities
{

    public abstract class ObjSchoolBase
    {
        //abstract no puedo instanciar solo es una idea si puedo heredad
        public string UniqueID { get; set; }
        public string Name { get; set; }

        public ObjSchoolBase()
        {
            UniqueID = Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            return $"Name:{Name}, UniqueID:{UniqueID}";
        }
    }
}

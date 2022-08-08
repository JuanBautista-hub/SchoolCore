using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCore.entities
{
    internal interface IPlace
    {

         string  Direction { get; set; }

        void CleanDirection();
    }

}

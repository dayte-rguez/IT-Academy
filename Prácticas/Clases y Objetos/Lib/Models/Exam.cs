using System;
using System.Collections.Generic;
using System.Text;

namespace Clases_y_Objetos.Lib.Models
{
    public class Exam: Entity //Inherits from Mother Class Entity
    {
        public Student Student { get; set; }
        public Subject Subject { get; set; }
        public double Mark { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}

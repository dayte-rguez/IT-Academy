using System;
using System.Collections.Generic;
using System.Text;

namespace Fase3_Clases.Lib.Models
{
    public class Exam: Entity
    {
        public Student Student { get; set; }
        public Subject Subject { set; get; }
        public double Grade { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}

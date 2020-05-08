using System;
using System.Collections.Generic;
using System.Text;

namespace Academy.Library.Models
{
    public class Exam: Entity
    {
        public DateTime DateStamp { get; set; }

        public Subject Subject { get; set; }

        public Student Student { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Clases_y_Objetos.Lib.Models
{
    public class Student: Entity //Inherits from Mother Class Entity
    {
        public string Name { get; set; }
        public string Dni { get; set; }
        public List<Exam> Exams { get; set; }

        public Student()
        {
            Exams = new List<Exam>();
        }

        public bool AddExam(Exam aExam)
        {
            aExam.Student = this;
            Exams.Add(aExam);

            return true;
        }
    }
}

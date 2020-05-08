using Fase3_Clases.Lib.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fase3_Clases.Lib.Models
{
    public class Student: Entity
    {
        public string Name { get; set; }
        public string DNI { get; set; }

        public List<Exam> Exams { get; set; }

        public Student()
        {
            Exams = new List<Exam>();
        }

        public bool DniIsValid(string aDni)
        {
            bool isValid;

            isValid = (!string.IsNullOrWhiteSpace(aDni)) && (aDni.Length == 9);
            if (!isValid)
            {
                Console.WriteLine("The DNI format is incorrect");
            }
            return isValid;
        }

        public bool NameIsValid(string aName)
        {
            return !string.IsNullOrWhiteSpace(aName);
        }

        public bool Save()
        {
            var success = false;

            if (DniIsValid(this.DNI) && NameIsValid(this.Name))
            {
                if (this.ID == Guid.Empty)
                {
                    success = DBContext.AddStudent(this);
                }
            }
            return success;
        }
        public bool AddExam(Exam aExam)
        {
            aExam.Student = this;
            Exams.Add(aExam);

            return true;
        }
    }
}

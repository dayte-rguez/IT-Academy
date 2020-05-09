using Academy.Library.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Academy.Library.Models
{
    public class Student : User
    {
        /* A Student is a child of User, which in turn is child of Entity.
         * Therefore a Student properties are :
         * - ID (from Entity)
         * - Name (from User)
         * - DNI 
         * - A list of exams
         * This class has the responsability of the validation of name and dni and to save the 
         * Student to the DB, whether it means to add a new student or to update an existing one */
        public string Dni { get; set; }
        /* For the list of exams property, only the get accesor is defined, since the exams 
         * will be effectively added (set) through the DBContext.
         * The idea is to present only the list of exams related to the student in question,
         * so, to have it, it is only needed to GET it from the DB */
        public bool IsValid
        {
            get => DniIsValid(Dni) && NameIsValid(Name);
        }
        public List<Exam> Exams
        {
            get
            {
                /* Search the DB for the List of exams matching the present student */
                return DBContext.Exams.Values.Where(e => e.Student.Id == this.Id).ToList();
            }
        }

        public static bool DniIsValid(string aDni)
        {
            return !(string.IsNullOrWhiteSpace(aDni)) && (aDni.Length == 9);
        }

        public static bool NameIsValid(string aName)
        {
            return !string.IsNullOrWhiteSpace(aName);
        }

        //public bool StudentIsValid()
        //{
        //    return DniIsValid(this.Dni) && NameIsValid(this.Name);
        //}

        public bool Save()
        {
            if (!IsValid) return false;

            if (this.Id == Guid.Empty)
            {
                DBContext.AddStudent(this);
            }
            else
            {
                DBContext.UpdateStudent(this);
            }

            return true;
        }

        public bool Delete()
        {
            if (Id == Guid.Empty)
            {
                return false;
            }
            else
            {
                return DBContext.DeleteStudent(Id);
            }
        }

        public bool Show()
        {
            if (Id == Guid.Empty)
            {
                return false;
            }
            var student = DBContext.ShowStudent(Id, out bool succes);
            if (succes)
            {
                this.Dni = student.Dni;
                this.Name = student.Name;
            }
            return succes;
        }
    }
}

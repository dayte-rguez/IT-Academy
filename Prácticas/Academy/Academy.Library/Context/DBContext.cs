using Academy.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Academy.Library.Context
{
    public class DBContext
    {
        #region Repositories
        /* These dictionaries are the DB */
        public static Dictionary<Guid, Exam> Exams { get; set; } = new Dictionary<Guid, Exam>();
        public static Dictionary<Guid, Student> Students { get; set; } = new Dictionary<Guid, Student>();
        public static Dictionary<Guid, Subject> Subjects { get; set; } = new Dictionary<Guid, Subject>();

        #endregion

        #region Indexes
        /* The GUI does not know anything about the Students Guid (ID),
         * it relates each student with its DNI, hence, a dictionary correlating DNI with Student is mandatory */
        public static Dictionary<string, Student> StudentByDNI = new Dictionary<string, Student>();
        #endregion

        #region Student CRUD
        public static bool AddStudent(Student aStudent)
        {
            /* Although Student.Save makes sure the ID is empty before invoking AddStudent,
             * this is a public method that can be invoked at any time, 
             * therefore, prevent errors on "primary keys" before commiting to the "DB" */
            if (aStudent.Id != Guid.Empty) return false;

            /* Generate the "primary key" */
            aStudent.Id = Guid.NewGuid();
            /* Update the students "table" */
            Students.Add(aStudent.Id, aStudent);
            /* Update the DNI-Student relation */
            StudentByDNI.Add(aStudent.Dni, aStudent);
            return true;
        }

        public static bool UpdateStudent(Student aStudent)
        {
            /* Although Student.Save makes sure the ID is not empty before invoking UpdateStudent,
             * this is a public method that can be invoked at any time, 
             * therefore, prevent errors on "primary keys" before commiting to the "DB" */
            if ((aStudent.Id != Guid.Empty)
                && Students.ContainsKey(aStudent.Id))
            {
                var studentToUpdate = Students[aStudent.Id];
                if (studentToUpdate != aStudent)
                {
                    Students[aStudent.Id] = aStudent;
                    if (studentToUpdate.Dni != aStudent.Dni)
                    {
                        StudentByDNI.Remove(studentToUpdate.Dni);
                        StudentByDNI.Add(aStudent.Dni, aStudent);
                    }
                }
                return true;
            }
            else return AddStudent(aStudent);
        }
        public static bool DeleteStudent(Guid aId)
        {
            if (Students.ContainsKey(aId))
            {
                var dni = Students[aId].Dni;
                return (Students.Remove(aId) && StudentByDNI.Remove(dni));
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}

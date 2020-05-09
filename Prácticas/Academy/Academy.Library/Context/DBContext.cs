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
                    StudentByDNI[aStudent.Dni] = aStudent;
                }
                return true;
            }
            else return AddStudent(aStudent);
        }
        public static bool DeleteStudent(Guid aId)
        {
            if (aId == Guid.Empty || !Students.ContainsKey(aId))
            {
                return false;
            }
            var dni = Students[aId].Dni;
            return (Students.Remove(aId) && StudentByDNI.Remove(dni));
        }
        public static Student ShowStudent(Guid aId, out bool succes)
        {
            if (aId == Guid.Empty || !Students.ContainsKey(aId))
            {
                succes = false;
                return null;
                
            }
            succes = true;
            return Students[aId];
        }
        #endregion

        #region Subject CRUD
        public static bool AddSubject(Subject aSubject)
        {
            if (aSubject.Id != Guid.Empty)
            {
                return false;
            }
            aSubject.Id = new Guid();
            Subjects.Add(aSubject.Id, aSubject);
            return true;
        }
        public static bool UpdateSubject(Subject aSubject)
        {
            if (aSubject.Id == Guid.Empty || !Subjects.ContainsKey(aSubject.Id))
            {
                return false;
            }
            if (aSubject != Subjects[aSubject.Id])
            {
                Subjects[aSubject.Id] = aSubject;
            }
            return true;
        }
        public static bool DeleteSubject(Guid aId)
        {
            if (aId == Guid.Empty || !Subjects.ContainsKey(aId))
            {
                return false;
            }
            return Subjects.Remove(aId);
        }
        public static bool ShowSubject(Guid aId, out Subject aSubject)
        {
            if (aId == Guid.Empty || !Subjects.ContainsKey(aId))
            {
                aSubject = null;
                return false;
            }
            aSubject = Subjects[aId];
            return true;
        }
        #endregion

        #region Exam CRUD

        #endregion
    }
}

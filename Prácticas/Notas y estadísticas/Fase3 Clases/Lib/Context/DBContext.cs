using Fase3_Clases.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fase3_Clases.Lib.Context
{
    class DBContext
    {
        #region Repositories
        public static Dictionary<Guid, Student> Students { get; set; } = new Dictionary<Guid, Student>();
        #endregion Repositories

        #region Indexes
        public static Dictionary<string, Student> StudentsByDni { get; set; } = new Dictionary<string, Student>();
        #endregion Indexes

        #region Student CRUD
        public static bool AddStudent(Student aStudent)
        {
            var success = false;

            aStudent.ID = Guid.NewGuid();
            Students.Add(aStudent.ID, aStudent);
            StudentsByDni.Add(aStudent.DNI, aStudent);
            success = true;
            return success;
        }
        #endregion Student CRUD
    }
}

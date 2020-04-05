using System;
using System.Collections.Generic;
using System.Text;

namespace Clases_y_Objetos.Lib.Models
{
    public class Entity
    {
        /* Every Class in this project will inherit from this one, therefore
         * every Student, Exam, Subject will have an ID of type GUID
         * GUID: Global Unit Identifier, to distinguish each entity 
         * from the others in the DB. (e.g: each Student among Students, 
         * each Exam among Exams...)
         * 
         */
        public Guid Id { get; set; }
    }
}

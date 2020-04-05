using System;
using System.Collections.Generic;
using System.Text;

namespace Clases_y_Objetos.Lib.Models
{
    public class Subject: Entity //Inherits from Mother Class Entity
    {
        public string Name { get; set; }
        public string Teacher { get; set; }
    }
}

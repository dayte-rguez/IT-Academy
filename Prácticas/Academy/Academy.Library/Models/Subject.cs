using Academy.Library.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Academy.Library.Models
{
    public class Subject : Entity
    {
        public string Name { get; set; }

        public bool Save()
        {
            if (!string.IsNullOrEmpty(Name))
            {
                if (Id != Guid.Empty)
                {
                    return DBContext.UpdateSubject(this);
                }
                else
                {
                    return DBContext.AddSubject(this);
                }
            }
            else
            {
                return false;
            }
        }
        public bool Delete()
        {
            if (Id == Guid.Empty)
            {
                return false;
            }
            return DBContext.DeleteSubject(Id);
        }
    }
}

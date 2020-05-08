using System;
using System.Collections.Generic;
using System.Text;

namespace Academy.Library.Models
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
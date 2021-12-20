using System;
using System.Collections.Generic;

namespace SHFSGAMES.Models
{
    public partial class Employees
    {
        public Employees()
        {
            Events = new HashSet<Events>();
        }

        public int EmployeeId { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }


        public virtual ICollection<Events> Events { get; set; }
    }
}

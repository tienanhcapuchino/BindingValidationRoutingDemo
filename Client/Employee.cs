using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
     public class Employee
    {
        public int EmployeeId { get; set; }
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? Title { get; set; }
    }
}

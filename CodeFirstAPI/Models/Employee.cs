using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstAPI.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string EmployeeFirstName { get; set; }

        public string EmployeeLastName { get; set; }

        public decimal Salary { get; set; }

        public string Designation { get; set; }
        
    }
}

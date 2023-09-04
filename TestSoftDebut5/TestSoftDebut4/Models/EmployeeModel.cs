using System;
using System.ComponentModel.DataAnnotations;

namespace TestSoftDebut5.Models
{
    public class EmployeeModel
    {
        [Key]
        public string EmpNum { get; set; }
        public string EmpName { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public string Position { get; set; }
        public string DepNo { get; set; }
        public string HeadNo { get; set; }
    }
}

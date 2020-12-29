using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EFDemo.Models.Code_First
{
    [Table("tblEmployees")]
    public class Employee
    {
        //Scalar Properties
        public int Id { get; set; }
        [Column("First_Name")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Salary { get; set; }
        public int DepartmentId { get; set; }
        //Navigation Properties
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
    }
}
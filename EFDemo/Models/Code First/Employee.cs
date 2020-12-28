using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFDemo.Models.Code_First
{
    public class Employee
    {
        //Scalar Properties
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Salary { get; set; }

        //Navigation Properties
        public Department Department { get; set; }
    }
}
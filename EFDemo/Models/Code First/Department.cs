using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFDemo.Models.Code_First
{
    public class Department
    {
        //Scalar Properites
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        //Navigation property
        public List<Employee> Employees { get; set; }
    }
}
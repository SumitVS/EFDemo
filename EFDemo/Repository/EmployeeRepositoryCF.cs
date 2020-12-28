using EFDemo.Models.Code_First;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFDemo.Repository
{
    public class EmployeeRepositoryCF
    {
        public IEnumerable<Department> GetDepartments()
        {
            IEnumerable<Department> departments = new List<Department>();
            using (EmployeeDBContextCF DB = new EmployeeDBContextCF())
            {
                departments = DB.Departments.Include("Employees").ToList();
            }
            return departments;
        }
    }
}
using EFDemo.Models.Code_First;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        internal void InvokeStoreProcedure()
        {
           using(EmployeeDBContextCF DB=new EmployeeDBContextCF())
            {
                SqlParameter DepartmentID = new SqlParameter("@DepartmentID", 2);

                var department = DB.Departments
                    .SqlQuery("spGetDepartmentDetails @DepartmentID", DepartmentID)
                    .FirstOrDefault();

                var AnonymousType = DB.Database
                    .SqlQuery<spGetanonymousType_ResultType>("spGetanonymousType")
                    .ToList();

                var ScalarValue = DB.Database
                    .SqlQuery<string>("spGetScalarValue")
                    .FirstOrDefault();
                var Params = new SqlParameter()[];

                //pass multiple parameter
                var AffectedRows = DB.Database.ExecuteSqlCommand<int>("spCreateEmployee @FirstName @LastName @Gender @Salary @DepartmentID",
                    new SqlParameter("@FirstName", "Sumit");


            }
        }
    }
}
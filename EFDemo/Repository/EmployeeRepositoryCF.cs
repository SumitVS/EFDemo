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
            using (EmployeeDBContextCF DB = new EmployeeDBContextCF())
            {

                // Calling sp with single parameter and returning model
                SqlParameter DepartmentID = new SqlParameter("@DepartmentID", 2);
                var department = DB.Departments
                    .SqlQuery("spGetDepartmentDetails @DepartmentID", DepartmentID)
                    .FirstOrDefault();

                //calling sp without parameter and returning AnonymousType
                var AnonymousType = DB.Database
                    .SqlQuery<spGetanonymousType_ResultType>("spGetanonymousType")
                    .ToList();

                //Calling sp without parameter and returning string value
                var ScalarValueString = DB.Database
                    .SqlQuery<string>("spGetScalarValue")
                    .FirstOrDefault();

                //Calling sp without parameter and returning int value
                var ScalarValueInt = DB.Database
                    .SqlQuery<int>("spGetScalarValueInt")
                    .FirstOrDefault();




                //pass multiple parameter
                SqlParameter FirstName = new SqlParameter("@FirstName", "Sumit");
                SqlParameter LastName = new SqlParameter("@LastName", "Shitole");
                SqlParameter Gender = new SqlParameter("@Gender", "Male");
                SqlParameter Salary = new SqlParameter("@Salary", "5000");
                SqlParameter DepartmentId = new SqlParameter("@DepartmentID", "2");

                //var AffectedRows = DB.Database.SqlQuery<int>("spCreateEmployee @FirstName @LastName @Gender @Salary @DepartmentID",
                //    parameters.ToArray());

                //This Worked fine
                var AffectedRows = DB.Database.SqlQuery<int>("EXEC spCreateEmployee @FirstName,@LastName,@Gender,@Salary,@DepartmentID",
                    new object[] { FirstName, LastName, Gender, Salary, DepartmentId }).ToList();

                string CommandText = "spCreateEmployee @FirstName=@FirstName_Param,@LastName=@LastName_Param,";
                CommandText += "@Gender=@Gender_Param,@Salary=@Salary_Param,@DepartmentID=@DepartmentID_Param";
                var sqlparams = new[]
                {
                new SqlParameter("@FirstName_Param","SumitNew"),
                new SqlParameter("@LastName_Param", "ShitoleNew"),
                new SqlParameter("@Gender_Param", "GenderNew"),
                new SqlParameter("@Salary_Param", "55555"),
                new SqlParameter("@DepartmentID_Param", "3")
                };

                var AffectedRowsNew = DB.Database.SqlQuery<int>(CommandText, sqlparams).FirstOrDefault();
            }
        }
    }
}
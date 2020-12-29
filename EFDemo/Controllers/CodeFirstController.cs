using EFDemo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFDemo.Controllers
{
    public class CodeFirstController : Controller
    {
        EmployeeRepositoryCF employeeRepository;
        public CodeFirstController()
        {
             employeeRepository = new EmployeeRepositoryCF();
        }
        public ActionResult Index()
        {
            var model=employeeRepository.GetDepartments();
            return View(model);
        }

        public ActionResult InvokeStoreProcedure()
        {
            employeeRepository.InvokeStoreProcedure();
            return View();
        }
    }
}
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
            employeeRepository.GetDepartments();
            return View();
        }
    }
}
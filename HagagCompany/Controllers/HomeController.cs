using HagagCompany.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HagagCompany.Controllers
{
    public class HomeController : Controller
    {
        private readonly HagagCompanyContext hagagCompany;

        public HomeController(HagagCompanyContext hagag)
        {
            hagagCompany = hagag;
        }

        public IActionResult Dash()
        {

            ICollection<Employee> employees = hagagCompany.Employees.Take(10).ToList();
            return View(employees);
        }

    }
}

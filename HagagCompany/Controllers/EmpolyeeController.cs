using HagagCompany.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HagagCompany.Controllers
{
    public class EmpolyeeController : Controller
    {
        private readonly HagagCompanyContext hagagCompanyContext;
        public EmpolyeeController(HagagCompanyContext context)
        {
            hagagCompanyContext = context;
        }
       
        public async Task<IActionResult> Index(string searchString)
        {
            var employees = new List<Employee>();
            if (!string.IsNullOrEmpty(searchString))
            {
                employees = await hagagCompanyContext.Employees
                    .Where(employee => employee.FirstName.ToLower() == searchString.ToLower() || employee.LastName.ToLower() == searchString.ToLower())
                    .ToListAsync();
            }
            else
            {
                employees = await hagagCompanyContext.Employees.ToListAsync();
            }
            return View(employees);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            if(employee!= null)
            {

                hagagCompanyContext.Employees.Add(employee);
                hagagCompanyContext.SaveChanges();
            }
                return RedirectToAction("Index");
            
            
        }
        public IActionResult Dash()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            var employee = hagagCompanyContext.Employees.Where(empolyee => empolyee.EmpolyeeId == id).FirstOrDefault();
            return PartialView("_EditEmpolyeePartialView", employee);
        }
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            hagagCompanyContext.Employees.Update(employee);
            hagagCompanyContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var employee = hagagCompanyContext.Employees.Where(empolyee => empolyee.EmpolyeeId == id).FirstOrDefault();
            return PartialView("_DetailsEmpolyeePartialView", employee);
        }
    
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var employee = hagagCompanyContext.Employees.Where(e => e.EmpolyeeId == id).FirstOrDefault();
            if (employee != null)
            {
                hagagCompanyContext.Employees.Remove(employee);
                hagagCompanyContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }


    }
}

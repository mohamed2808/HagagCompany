using HagagCompany.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Web;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
namespace HagagCompany.Controllers
{

    public class LoginController : Controller
    {
        private readonly HagagCompanyContext hagagCompanyContext;
        public LoginController(HagagCompanyContext context)
        {
            hagagCompanyContext = context;
        }
      
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string userName, string password)
        {
            var currentUser = hagagCompanyContext.Users.Where(u => u.UserName.ToLower() == userName.ToLower() && u.Password.ToLower() == password.ToLower()).FirstOrDefault();
            if (currentUser != null)
            {
                return RedirectToAction("dash","Home");
            }
            return View(currentUser);

        }

    }
}
       
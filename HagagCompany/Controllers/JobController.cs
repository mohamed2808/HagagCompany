using HagagCompany.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HagagCompany.Controllers
{
    public class JobController : Controller
    {
        private readonly HagagCompanyContext hagagCompanyContext;
        public JobController(HagagCompanyContext context)
        {
            hagagCompanyContext = context;
        }
        public async Task<IActionResult> Index(string searchString)
        {
            var jobs = new List<Job>();
            if (!string.IsNullOrEmpty(searchString))
            {
                jobs = await hagagCompanyContext.Jobs
                    .Where(job => job.JobName.ToLower() == searchString.ToLower()).ToListAsync();
            }
            else
            {
                jobs = await hagagCompanyContext.Jobs.ToListAsync();
            }
            return View(jobs);
        }
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Job job)
        {

            if(job != null)
            {
                hagagCompanyContext.Jobs.Add(job);
                hagagCompanyContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var job = hagagCompanyContext.Jobs.Where(job => job.JobId == id).FirstOrDefault();
            return PartialView("_EditJobPartialView", job);
        }
        [HttpPost]
        public IActionResult Edit(Job job)
        {
            hagagCompanyContext.Jobs.Update(job);
            hagagCompanyContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var job = hagagCompanyContext.Jobs.Where(job => job.JobId == id).FirstOrDefault();
            return PartialView("_DetailsJobPartialView", job);
        }
       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var job = hagagCompanyContext.Jobs.Where(j => j.JobId == id).FirstOrDefault();
            if (job != null)
            {
                hagagCompanyContext.Jobs.Remove(job);
                hagagCompanyContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}

namespace ProjectRider.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Models;

    [ValidateInput(false)]
    public class ProjectController : Controller
    {
        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            using (var database = new ProjectRiderDbContext())
            {
                List<Project> tasks = database.Projects.ToList();

                return View(tasks);
            }
        }

        [HttpGet]
        [Route("create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Project project)
        {
            if (ModelState.IsValid)
            {
                using (var database = new ProjectRiderDbContext())
                {

                    database.Projects.Add(project);
                    database.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int id)
        {
            using (var database = new ProjectRiderDbContext())
            {
                var task = database.Projects.Where(t => t.Id == id).First();
                return View(task);
            }
        }

        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirm(int id, Project project)
        {
            if (ModelState.IsValid)
            {
                using (var database = new ProjectRiderDbContext())
                {
                    var task = database.Projects.FirstOrDefault(t => t.Id == project.Id);

                    task.Budget = project.Budget;
                    task.Title = project.Title;
                    task.Description = project.Description;

                    database.Entry(task).State = System.Data.Entity.EntityState.Modified;
                    database.SaveChanges();

                    return RedirectToAction("Index");
                }

            }
            return View();
        }

        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(int id)
        {
            using (var database = new ProjectRiderDbContext())
            {
                var project = database.Projects.Where(f => f.Id == id).First();

                if (project == null)
                {
                    return HttpNotFound();
                }

                return View(project);
            }
        }

        [HttpPost]
        [Route("delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id, Project reportModel)
        {
            

            using (var database = new ProjectRiderDbContext())
            {
                var project = database.Projects.Where(f => f.Id == id).First();

                if (project == null)
                {
                    return HttpNotFound();
                }

                database.Projects.Remove(project);
                database.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TeisterMask.Models;

namespace TeisterMask.Controllers
{
    [ValidateInput(false)]
    public class TaskController : Controller
    {
        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            using (var database = new TeisterMaskDbContext())
            {
                List<Task> tasks = database.Tasks.ToList();
                
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
        public ActionResult Create(Task task)
        {
            if (ModelState.IsValid)
            {
                using (var database = new TeisterMaskDbContext())
                {

                    database.Tasks.Add(task);
                    database.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(task);
        }

        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int id)
        {
            using (var database = new TeisterMaskDbContext())
            {
                var task = database.Tasks.Where(t => t.Id == id).First();
                return View(task);
            }
        }

        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirm(int id, Task taskModel)
        {
            if (ModelState.IsValid)
            {
                using (var database = new TeisterMaskDbContext())
                {
                    var task  = database.Tasks.FirstOrDefault(t => t.Id == taskModel.Id);

                    task.Status = taskModel.Status;
                    task.Title = taskModel.Title;

                    database.Entry(task).State = System.Data.Entity.EntityState.Modified;
                    database.SaveChanges();

                    return RedirectToAction("Index");
                }

            }
            return View(taskModel);
        }
    }
}
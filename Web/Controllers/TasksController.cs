using Domain.Entities;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class TasksController : Controller
    {
        TasksService taskService = new TasksService();
        UserService userService = new UserService();
        // GET: Tasks
        public ActionResult Index()
        {
            return View();
        }

        // GET: Tasks/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Tasks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tasks/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tasks/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Tasks/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tasks/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Tasks/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public void AddTask(String id,String email,String taskName)
        {
            int organizerId = 0;
            foreach(User u in userService.GetAll())
            {
                if (u.Email.Equals(email))
                {
                    organizerId = u.Id;
                }
            }
            Tasks task = new Tasks() {UserId= organizerId ,TaskTitle=taskName,EventId=Int32.Parse(id)};
            taskService.Add(task);
            taskService.Commit();
        }

    }
}

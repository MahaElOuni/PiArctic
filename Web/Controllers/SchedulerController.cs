using Domain.Entities;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class SchedulerController : Controller
    {
        EventService eventService = new EventService();
        SchedulerService schedulerService = new SchedulerService();
        // GET: Scheduler
        public ActionResult Index()
        {
            return View();
        }

        // GET: Scheduler/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Scheduler/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Scheduler/Create
        [HttpPost]
        public ActionResult Create(SchedulerViewModel svm)
        {
            Scheduler scheduler = new Scheduler();
            scheduler.Duration = svm.Duration;
            scheduler.ProgramName = svm.ProgramName;
           // scheduler.Event = eventService.GetById(1);
           
            schedulerService.Add(scheduler);
            schedulerService.Commit();
            try
            {
                // TODO: Add insert logic here

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Scheduler/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Scheduler/Edit/5
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

        // GET: Scheduler/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Scheduler/Delete/5
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
    }
}

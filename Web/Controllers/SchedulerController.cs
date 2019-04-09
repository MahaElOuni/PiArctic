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
        SchedulerService schedulerService = new SchedulerService();
        // GET: Scheduler
        public ActionResult Index()
        {
            List<SchedulerViewModel> l = new List<SchedulerViewModel>();
            foreach(Scheduler s in schedulerService.GetAll())
            {
                SchedulerViewModel se = new SchedulerViewModel();
                se.Duration = s.Duration;
                se.ProgramName = s.ProgramName;
                l.Add(se);

            }
            return View(l);
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

        // GET: Scheduler/Edit/5
        public ActionResult Edit(int id)
        {
            Scheduler s = schedulerService.GetById(id);
            SchedulerViewModel sm = new SchedulerViewModel();
            sm.Duration = s.Duration;
            sm.ProgramName = s.ProgramName;
           

            return View(sm);
        }

        // POST: Scheduler/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SchedulerViewModel svm)
        {
            Scheduler s = schedulerService.GetById(id);
            s.Duration = svm.Duration;
            s.ProgramName = svm.ProgramName;
            schedulerService.Update(s);
            schedulerService.Commit();
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("MyEvent","Event");
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

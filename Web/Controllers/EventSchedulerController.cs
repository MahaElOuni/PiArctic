using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class EventSchedulerController : Controller
    {
        // GET: EventScheduler
        public ActionResult Index()
        {
            return View();
        }

        // GET: EventScheduler/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EventScheduler/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventScheduler/Create
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

        // GET: EventScheduler/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EventScheduler/Edit/5
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

        // GET: EventScheduler/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EventScheduler/Delete/5
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

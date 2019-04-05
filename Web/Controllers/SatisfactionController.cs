using Domain.Entities;
using Microsoft.AspNet.Identity;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class SatisfactionController : Controller
    {
        SatisfactionService satisfactionService = new SatisfactionService();

        EventService eventService = new EventService();
        SchedulerService schedulerService = new SchedulerService();

        List<Scheduler> listScheduler = new List<Scheduler>();
        // GET: Satisfaction
        public ActionResult Index()
        {
            List<EventViewModel> listEvent = new List<EventViewModel>();
            var eventt = eventService.GetAll();
            foreach (var i in eventt)
            {
                if (i.Start >= DateTime.Today)
                {
                    EventViewModel eventModel = new EventViewModel();
                    eventModel.EventId = i.EventId;
                    eventModel.Title = i.Title;
                    eventModel.Start = i.Start;
                    eventModel.Description = i.Description;
                    eventModel.Address = i.Address;
                    eventModel.OrganizedBy = i.OrganizedBy;
                    listEvent.Add(eventModel);
                }
            }
            return View(listEvent);


        }

        public ActionResult Details(int id)
        {

            EventViewModel eventSchedulerModel = new EventViewModel();
            List<EventViewModel> listEventScheduler = new List<EventViewModel>();
            var eventt = eventService.GetAll();
            var schedulers = schedulerService.GetAll();
            foreach (var i in eventt)
            {
                if (i.EventId == id)
                {
                    eventSchedulerModel.EventId = i.EventId;
                    eventSchedulerModel.Title = i.Title;
                    eventSchedulerModel.DateString = i.Start.ToString("MM/dd/yyyy hh:mm:ss");
                    eventSchedulerModel.Description = i.Description;
                    eventSchedulerModel.Address = i.Address;
                    eventSchedulerModel.OrganizedBy = i.OrganizedBy;
                   

                }
            }
            return View(eventSchedulerModel);
        }

        public ActionResult liker(int id)
        {
            SatisfactionService ss = new SatisfactionService();
            SatisfactionViewModel svm = new SatisfactionViewModel();
            Satisfaction s = new Satisfaction();
            s.UserId = User.Identity.GetUserId<int>();
            s.EventId = id;
            s.status = 1;

            ss.Add(s);
            ss.Commit();

            return RedirectToAction("Details");

        }



       





        // GET: Satisfaction/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Satisfaction/Create
        [HttpPost]
        public ActionResult Create(SatisfactionViewModel svm)
        {
          

            return View();
            
        }

        // GET: Satisfaction/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Satisfaction/Edit/5
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

        // GET: Satisfaction/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Satisfaction/Delete/5
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

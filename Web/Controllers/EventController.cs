﻿using Domain.Entities;
using Newtonsoft.Json;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class EventController : Controller
    {
        EventService eventService = new EventService();
        SchedulerService schedulerService = new SchedulerService();

        List<Scheduler> listScheduler = new List<Scheduler>();

        // GET: Event
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

        // GET: Event/Details/5
        public ActionResult Details(int id)
        {
            EventViewModel eventSchedulerModel = new EventViewModel();
            List<EventViewModel> listEventScheduler = new List<EventViewModel>();
            int idEvent = 0;
            var eventt = eventService.GetAll();
            var schedulers = schedulerService.GetAll();
            foreach (var i in eventt)
            {
                if (i.EventId == id)
                {
                    //idEvent = id;
                    eventSchedulerModel.Title = i.Title;
                    eventSchedulerModel.DateString = i.Start.ToString("MM/dd/yyyy hh:mm:ss");
                    eventSchedulerModel.Description = i.Description;
                    eventSchedulerModel.Address = i.Address;
                    eventSchedulerModel.OrganizedBy = i.OrganizedBy;
                    foreach (Scheduler j in schedulers)
                    {

                        SchedulerViewModel se = new SchedulerViewModel() { Duration = "mmmm", ProgramName = "mmmmm" };
                        /* se.Duration = j.Duration;
                         se.ProgramName = j.ProgramName;*/
                        eventSchedulerModel.listScheduler.Add(se);

                    }

                    //listEventScheduler.Add(i.ListScheduler);
                    /* foreach(var j in i.ListScheduler)
                     {
                         eventSchedulerModel.SchedulerModel.Duration = j.Duration;
                         eventSchedulerModel.SchedulerModel.ProgramName = j.ProgramName;


                     }*/


                }

            }
            /* foreach(var i in schedulers)
             {
                 if (i.EventId == idEvent)
                 {
                     eventSchedulerModel.SchedulerModel.Duration = i.Duration;
                     eventSchedulerModel.SchedulerModel.ProgramName = i.ProgramName;
                 }
             }*/

            return View(eventSchedulerModel);
        }

        // GET: Event/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Event/Create
        [HttpPost]
        public ActionResult Create(EventSchedulerViewModel evm)
        {
            Event e = new Event();
            e.Title = evm.EventModel.Title;
            e.Address = evm.EventModel.Address;
            e.NumberPlaces = evm.EventModel.NumberPlaces;
            e.Price = evm.EventModel.Price;
            e.Description = evm.EventModel.Description;
            e.Start = evm.EventModel.Start;
            e.End = evm.EventModel.End;
            e.OrganizedBy = evm.EventModel.OrganizedBy;
            eventService.Add(e);
            eventService.Commit();

            foreach (Scheduler scheduler in listScheduler)
            {

                Scheduler s = new Scheduler() { Duration = scheduler.Duration, ProgramName = scheduler.ProgramName, EventId = e.EventId };
                schedulerService.Add(s);
                schedulerService.Commit();
            }
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


        // GET: Event/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Event/Edit/5
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

        // GET: Event/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Event/Delete/5
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
        // GET: Event/Create
        public ActionResult MyCalendar()
        {
            return View();
        }
        public JsonResult GetEvents()
        {
            var e = eventService.GetAll();


            return new JsonResult { Data = e, JsonRequestBehavior = JsonRequestBehavior.AllowGet };


        }

        [HttpPost]
        public List<Scheduler> getAllScheduler(String duration, String proName)
        {

            Scheduler scheduler = new Scheduler() { Duration = duration, ProgramName = proName };
            //Scheduler scheduler = new Scheduler() { Duration = duration, ProgramName = proName, EventId = 2 };

            /* schedulerService.Add(scheduler);
             schedulerService.Commit();*/
            listScheduler.Add(scheduler);
            return listScheduler;
        }



        public ActionResult Affiche()
        {
            //List<EventViewModel> listEvent = new List<EventViewModel>();
            var eventt = eventService.GetById(2);

            EventViewModel eventModel = new EventViewModel();
            eventModel.EventId = eventt.EventId;
            eventModel.Title = eventt.Title;
            eventModel.Start = eventt.Start;
            eventModel.Description = eventt.Description;
            eventModel.Address = eventt.Address;
            eventModel.OrganizedBy = eventt.OrganizedBy;
            // listEvent.Add(eventModel);

            return View(eventModel);
        }
    }

}

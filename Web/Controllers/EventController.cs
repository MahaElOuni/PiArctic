using Domain.Entities;
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
                      eventSchedulerModel.listScheduler = Affiche(id);
                      
                   }
              }
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
            int idUser=0;
            User u = new User();
            UserService userService = new UserService();
            foreach (User i in userService.GetAll())
            {
               if (i.UserName.Equals(User.Identity.Name))
               {
                    idUser = i.Id;
                   i.Role = "President";
                    userService.Update(i);
                   userService.Commit();
            
              }
          }
            Event e = new Event();
            
            e.UserId = idUser;
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

            foreach (Scheduler scheduler in schedulerService.GetAll())
            {
                if (scheduler.EventId == null) { 
                Scheduler s = new Scheduler() { Duration = scheduler.Duration, ProgramName = scheduler.ProgramName, EventId = e.EventId };
                schedulerService.Add(s);
                schedulerService.Commit();
                }
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
        public void getAllScheduler(String duration, String proName)
        {

            //Scheduler scheduler = new Scheduler() { Duration = duration, ProgramName = proName };
            Scheduler scheduler = new Scheduler() { Duration = duration, ProgramName = proName};

             schedulerService.Add(scheduler);
             schedulerService.Commit();
           /* listScheduler.Add(scheduler);
            return listScheduler;*/
        }



        public List<SchedulerViewModel> Affiche(int id)
        {
            List<SchedulerViewModel> listEvent = new List<SchedulerViewModel>();

            Event e1 = eventService.GetById(id);
            
            foreach(Scheduler s in e1.ListScheduler)
            {
                SchedulerViewModel sv = new SchedulerViewModel();
                
                sv.Duration = s.Duration;
                sv.ProgramName = s.ProgramName;
                listEvent.Add(sv);
            }
          

            return listEvent;
        }
        public ActionResult MyEvent()
        {
            int idUser = 0;
           
            UserService userService = new UserService();
            foreach (User i in userService.GetAll())
            {
                if (i.UserName.Equals(User.Identity.Name))
                {
                    idUser = i.Id;
                   

                }
            }
            List<EventViewModel> listEvent = new List<EventViewModel>();
            var eventt = eventService.GetAll();
            foreach (var i in eventt)
            {
                if (i.UserId==idUser )
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
    }

}

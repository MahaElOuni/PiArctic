using Domain.Entities;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using Service.Services;
using System;
using System.Collections.Generic;
using System.IO;
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
                    eventModel.Photo = i.Photo;
                    eventModel.Slogan = i.Slogan;
                    eventModel.Type = i.Type;
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
            List<SchedulerViewModel> listScheduer = new List<SchedulerViewModel>();
            EventService eventService = new EventService();
           
            var eventt = eventService.GetAll();
             
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
                    foreach (Scheduler s in i.ListScheduler)
                    {
                        SchedulerViewModel sv = new SchedulerViewModel();
                        sv.SchedulerId = s.SchedulerId;
                        sv.Duration = s.Duration;
                        sv.ProgramName = s.ProgramName;
                        listScheduer.Add(sv);
                    }

                    eventSchedulerModel.listScheduler = listScheduer;
                      
                   }
              }
              return View(eventSchedulerModel);
        }

        public ActionResult liker(int id)
        {
            SatisfactionService ss = new SatisfactionService();
            SatisfactionViewModel svm = new SatisfactionViewModel();
            Satisfaction s = new Satisfaction();
            s.UserId= User.Identity.GetUserId<int>();
            s.EventId = id;
            s.status = 1;

            ss.Add(s);
            ss.Commit();
            
            return RedirectToAction("Index");

        }
        public ActionResult disliker(int id)
        {
            SatisfactionService ss = new SatisfactionService();
            SatisfactionViewModel svm = new SatisfactionViewModel();
            Satisfaction s = new Satisfaction();
            s.UserId = User.Identity.GetUserId<int>();
            s.EventId = id;
            s.status = 2;

            ss.Add(s);
            ss.Commit();

            return RedirectToAction("Index");

        }

        public ActionResult statitique(int id)
        {
            double likes = 0;
            double dislikes = 0;

            SatisfactionService ss = new SatisfactionService();
            SatisfactionViewModel r = new SatisfactionViewModel();
            foreach (var item in ss.GetByIdEvent(id))
            {
                if (item.status == 1) { likes++; }
                else if (item.status == 2) { dislikes++; }

            }

            r.likes = likes;
            r.dislikes = dislikes;

            return View(r);
        }

        public ActionResult statittotal()
        {
            double likes = 0;
            double dislikes = 0;
            int nbr = 0;

            SatisfactionService ss = new SatisfactionService();
            SatisfactionViewModel r = new SatisfactionViewModel();
            foreach (var item in ss.GetAll())
            {
                if (item.status == 1) { likes ++; }
                else if (item.status == 2) { dislikes ++; }

            }

            nbr = ss.GetAll().Count();

            r.likes = Math.Round((likes / nbr) * 100);
            r.dislikes = Math.Round((dislikes / nbr) * 100);


            return View();
        }



        // GET: Event/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Event/Create
        [HttpPost]
        public ActionResult Create(EventSchedulerViewModel evm,HttpPostedFileBase file2)
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
            if (file2 != null && file2.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Content/Upload"), Path.GetFileName(file2.FileName));
                    file2.SaveAs(path);
                    ViewBag.Message = "Image uploaded successfully";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
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
            e.Photo = file2.FileName;
            e.Slogan = evm.EventModel.Slogan;
            e.Type = evm.EventModel.Type;
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
            Event e = eventService.GetById(id);
            EventViewModel eventModel = new EventViewModel();
            eventModel.Title = e.Title;
            eventModel.Address = e.Address;
            eventModel.NumberPlaces = e.NumberPlaces;
            eventModel.Start = e.Start;
            eventModel.End = e.End;
            eventModel.Price = e.Price;
            eventModel.Description = e.Description;
            eventModel.OrganizedBy = e.OrganizedBy;

            return View(eventModel);
        }

        // POST: Event/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EventViewModel eventModel)
        {
            Event e = eventService.GetById(id);
            e.Title=eventModel.Title;
            e.Address=eventModel.Address;
            e.NumberPlaces=eventModel.NumberPlaces;
            e.Start=eventModel.Start;
            e.End=eventModel.End;
            e.Price=eventModel.Price ;
            e.Description=eventModel.Description;
            e.OrganizedBy=eventModel.OrganizedBy;
            eventService.Update(e);
            eventService.Commit();


            try
            {
                // TODO: Add update logic here

                return RedirectToAction("MyEvent");
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
                sv.SchedulerId = s.SchedulerId;
                sv.Duration = s.Duration;
                sv.ProgramName = s.ProgramName;
                listEvent.Add(sv);
            }
          

            return listEvent;
        }
        public ActionResult MyEvent()
        {
            int idUser = 1;
           
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




        public ActionResult DetailsMyEvent(int id)
        {
            List<SchedulerViewModel> listScheduer = new List<SchedulerViewModel>();
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
                    foreach (Scheduler s in i.ListScheduler)
                    {
                        SchedulerViewModel sv = new SchedulerViewModel();
                        sv.SchedulerId = s.SchedulerId;
                        sv.Duration = s.Duration;
                        sv.ProgramName = s.ProgramName;
                        listScheduer.Add(sv);
                    }

                    eventSchedulerModel.listScheduler = listScheduer;

                }
            }
            return View(eventSchedulerModel);
        }
        [HttpPost]
        public void EditScheduler(String id,String duration,String progName)
        {
            var scheduler = schedulerService.GetById(3);
            scheduler.Duration = duration;
            scheduler.ProgramName = progName;
            schedulerService.Update(scheduler);
            schedulerService.Commit();
            //return RedirectToAction("Index","Event");
            
        }


    }

}

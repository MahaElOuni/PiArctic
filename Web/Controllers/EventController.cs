using Domain.Entities;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using Service.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
           
           
            var eventt = eventService.GetAll();
            UserService userService = new UserService();
            foreach (User i in userService.GetAll())
            {
                if (i.UserName.Equals(User.Identity.Name))
                {
                    eventSchedulerModel.UserId = i.Id;
                    eventSchedulerModel.UserEmail = i.Email;
                    eventSchedulerModel.UserRole = i.Role;


                }
            }

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
                    eventSchedulerModel.Photo = i.Photo;
                    eventSchedulerModel.Slogan = i.Slogan;
                    eventSchedulerModel.Type = i.Type;
                    foreach (Scheduler s in schedulerService.GetSchedulesByEvent(id))
                    {
                        SchedulerViewModel sv = new SchedulerViewModel();
                        sv.SchedulerId = s.SchedulerId;
                        sv.Duration = s.Duration;
                        sv.ProgramName = s.ProgramName;
                        sv.Speaker = s.Speaker;
                        sv.Photo = s.Photo;
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

            EventSchedulerViewModel evm = new EventSchedulerViewModel();
            UserService userService = new UserService();
            foreach (User i in userService.GetAll())
            {
                if (i.UserName.Equals(User.Identity.Name))
                {
                    evm.UserId = i.Id;
                    evm.UserEmail = i.Email;
                    evm.UserRole = i.Role;
                    

                }
            }

            return View(evm);
        }

        // POST: Event/Create
        [HttpPost]
        public ActionResult Create(EventSchedulerViewModel evm,HttpPostedFileBase file2)
        {

            int idUser=1;
           
            User u = new User();
            UserService userService = new UserService();
            if (ModelState.IsValid)

            {
                foreach (User i in userService.GetAll())
                {
                    if (i.UserName.Equals(User.Identity.Name))
                    {
                        idUser = i.Id;
                        i.Role = "President";
                        userService.Update(i);
                        userService.Commit();
                      /*  evm.EventModel.UserId = i.Id;
                        evm.EventModel.President.Email = i.Email;
                        evm.EventModel.President.Role = "President";*/

                    }
                }
                if (file2 != null && file2.ContentLength > 0 /*&& file1 != null && file1.ContentLength > 0*/)
                    try
                    {
                        string path = Path.Combine(Server.MapPath("~/Content/Upload"), Path.GetFileName(file2.FileName));
                        //string path1 = Path.Combine(Server.MapPath("~/Content/Upload"), Path.GetFileName(file1.FileName));
                        file2.SaveAs(path);
                        //file1.SaveAs(path1);
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
                foreach (User user in userService.GetParticipants())
                {
                    SendingMail("levio.lmp@gmail.com",user.Email, "New Event: " + e.Title, "There is new event may interest you Organized by: " + e.OrganizedBy + "  you can participate to this event by connecting to your account in ConsultTeck. Thank you for your trust");
                }
                foreach (Scheduler scheduler in schedulerService.GetAll())
                {
                    if (scheduler.EventId == null)
                    {
                        scheduler.EventId = e.EventId;
                        //scheduler.Photo = file1.FileName;

                        schedulerService.Update(scheduler);
                        schedulerService.Commit();
                    }
                }
                


            }

                    return RedirectToAction("Index");
            


        }


        // GET: Event/Edit/5
        public ActionResult Edit(int id)
        {

            Event e = eventService.GetById(id);
            EventViewModel eventModel = new EventViewModel();
            UserService userService = new UserService();
            foreach (User i in userService.GetAll())
            {
                if (i.UserName.Equals(User.Identity.Name))
                {
                    eventModel.UserId = i.Id;
                    eventModel.UserEmail = i.Email;
                    eventModel.UserRole = i.Role;


                }
            }
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
            eventService.Delete(eventService.GetById(id));
            eventService.Commit();
            return View("Index");
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
        public void getAllScheduler(String duration, String proName,String speaker,String filePath)
        {

            //Scheduler scheduler = new Scheduler() { Duration = duration, ProgramName = proName };
            string path = Path.Combine(Server.MapPath("~/Content/Upload"), Path.GetFileName(speaker));
           
            Scheduler scheduler = new Scheduler() { Duration = duration, ProgramName = proName,Speaker= speaker,Photo= Path.GetFileName(filePath) };

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
                    eventModel.Photo = i.Photo;
                    eventModel.Slogan = i.Slogan;
                    eventModel.Type = i.Type;
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
            UserService userService = new UserService();
            foreach (User i in userService.GetAll())
            {
                if (i.UserName.Equals(User.Identity.Name))
                {
                    eventSchedulerModel.UserId = i.Id;
                    eventSchedulerModel.UserEmail = i.Email;
                    eventSchedulerModel.UserRole = i.Role;


                }
            }
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
                    eventSchedulerModel.Photo = i.Photo;
                    eventSchedulerModel.Type = i.Type;
                    foreach (Scheduler s in schedulerService.GetSchedulesByEvent(id))
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
            var scheduler = schedulerService.GetById(Int32.Parse(id));
            scheduler.Duration = duration;
            scheduler.ProgramName = progName;
            schedulerService.Update(scheduler);
            schedulerService.Commit();
            //return RedirectToAction("Index","Event");
            
        }
        public void SendingMail(string From, string To, string Subject, string Body)
        {
            MailMessage mail = new MailMessage(From, To, Subject, Body);
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("levio.lmp@gmail.com", "eudfdldhubmzuscf");
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }


    }

}

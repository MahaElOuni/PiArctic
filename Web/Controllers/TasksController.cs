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
    public class TasksController : Controller
    {
        TasksService taskService = new TasksService();
        UserService userService = new UserService();
        EventService eventService = new EventService();
        // GET: Tasks
        public ActionResult Index()
        {

           
            int idOrganizer=0;

            UserService userService = new UserService();
           // userService.FindRoleByName(user.UserName);
            foreach (User i in userService.GetAll())
            {
                if (i.UserName.Equals(User.Identity.Name))
                {
                    idOrganizer = i.Id;
                   


                }
            }
            List<EventViewModel> listEvent = new List<EventViewModel>();
            var eventt = eventService.OrganizerEvents(idOrganizer);
            foreach (var i in eventt)
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
                    eventModel.ListTask = eventService.OrganizerTasks(i.EventId, idOrganizer);
                    listEvent.Add(eventModel);
                
            }
            return View(listEvent);
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


        public ActionResult MyTask()
        {

            return View();
        }
    }
}

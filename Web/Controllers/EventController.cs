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

        // GET: Event
        public ActionResult Index()
        {
            List<EventViewModel> listEvent = new List<EventViewModel>();
            var eventt = eventService.GetAll();
            foreach(var i in eventt)
            {
                if (i.Start >= DateTime.Today) { 
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
            EventViewModel eventModel = new EventViewModel();
            var eventt = eventService.GetAll();
            foreach (var i in eventt)
            {
                if (i.EventId==id)
                {
                   
                    eventModel.Title = i.Title;
                    eventModel.DateString = i.Start.ToString("MM/dd/yyyy hh:mm:ss");
                    eventModel.Description = i.Description;
                    eventModel.Address = i.Address;
                    eventModel.OrganizedBy = i.OrganizedBy;
                    
                }
            }
            return View(eventModel);
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
            e.End= evm.EventModel.End;
            e.ThemeColor = evm.EventModel.ThemeColor;
            e.IsFullDay = evm.EventModel.IsFullDay;
            e.OrganizedBy = evm.EventModel.OrganizedBy;
            
            eventService.Add(e);
            eventService.Commit();
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
    }
   
}

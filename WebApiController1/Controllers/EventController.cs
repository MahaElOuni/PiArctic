using Domain.Entities;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiController1.Controllers
{
    public class EventController : ApiController
    {
        EventService eventService = new EventService();
        // GET: api/Event
        [HttpGet]
        public IEnumerable<Event> Get()
        {

            return eventService.GetAll();

			

        }

        // GET: api/Event/5
        public Event Get(int id)
        {
            return eventService.GetById(id);
        }

        // POST: api/Event
        public void Post([FromBody]Event eventt)
        {
            Event e1 = new Event();
            e1.Title = eventt.Title;
            e1.Start = eventt.Start;
            e1.End = eventt.End;
            eventService.Add(e1);
            eventService.Commit();
        }

        // PUT: api/Event/5
        public void Put(int id, [FromBody]Event eventt)
        {
            Event e = eventService.GetById(id);
            e.Title = eventt.Title;
            e.Description = eventt.Description;
            e.Start = eventt.Start;
            e.End = eventt.End;
            e.IsFullDay = eventt.IsFullDay;
            e.OrganizedBy = eventt.OrganizedBy;
            e.Price = eventt.Price;
            e.Slogan = eventt.Slogan;
            e.NumberPlaces = eventt.NumberPlaces;
            e.ThemeColor = eventt.ThemeColor;
            eventService.Update(e);
            eventService.Commit();
        }

        // DELETE: api/Event/5
        public void Delete(int id)
        {
            eventService.Delete(eventService.GetById(id));
            eventService.Commit();
        }
        public List<Tasks> OrganizerTasks(int eventId, int organizerId)
        {
            Event e = Get(eventId);
            List<Tasks> tasks = new List<Tasks>();
            foreach (Tasks t in e.ListTask)
            {
                if (t.UserId == organizerId)
                {
                    tasks.Add(t);
                }
            }
            return tasks;
        }
        public IEnumerable<Event> OrganizerEvents(int organizerId)
        {
            List<Event> e = new List<Event>();

            TasksService taskService = new TasksService();
            var eventsId = taskService.GetMany().Where(o => o.UserId == organizerId).Select(o => o.EventId).Distinct();
            foreach (var i in eventsId)
            {
                e.Add(this.Get(i.Value));

            }
            return e;

        }
    }
}

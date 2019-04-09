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
            eventService.Add(eventt);
            eventService.Commit();
        }

        // PUT: api/Event/5
        public void Put(int id, [FromBody]string value)
        {
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

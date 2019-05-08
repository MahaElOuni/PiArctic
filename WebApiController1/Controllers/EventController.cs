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

        // GET: api/Event
        [HttpGet]
        public IEnumerable<Event> GetEventPresident(int id)
        {

            return eventService.GetAll().Where(e => e.UserId == id);
        }

        // GET: api/Event
        [HttpGet]
        public IEnumerable<Scheduler> GetScheduler(int id)
        {
            return eventService.getEventsScheduler(id);
        }

        // GET: api/Event
        [HttpGet]
        public IEnumerable<Satisfaction> GetEventLikers(int id)
        {
            List<Satisfaction> listSatisfaction = new List<Satisfaction>();
            SatisfactionService satisfactionService = new SatisfactionService();
            foreach (Satisfaction s in satisfactionService.GetMany().Where(e => e.EventId == id))
            {
                Satisfaction satisfaction = new Satisfaction { status = s.status };
                listSatisfaction.Add(satisfaction);
            }
            return listSatisfaction;
        }
        [HttpGet]
        public int GetParticipantNumber(int id)
        {
            FormService form = new FormService();

            return form.GetAll().Where(e => e.EventId == id).Count();
        }
        [HttpGet]
        public IEnumerable<Tasks> GetOrganizerTasks(int id)
        {
            TasksService tasks = new TasksService();
            List<Tasks> listTasks = new List<Tasks>();
            foreach (Tasks t in tasks.GetAll().Where(e => e.EventId == id))
            {
                Tasks task1 = new Tasks { UserId = t.UserId, TaskTitle = t.TaskTitle };
                listTasks.Add(task1);
            }

            return listTasks;
        }
        public String GetOrganizerEmail(int id)
        {
            UserService user = new UserService();
            return user.GetById(id).Email;
        }
        // POST: api/Event
        public void PostTask([FromBody]Tasks tasks)
        {
            TasksService taskService1 = new TasksService();
            Tasks t = new Tasks();
            t.TaskTitle = tasks.TaskTitle;
            t.UserId = tasks.UserId;
            t.EventId = tasks.EventId;
            taskService1.Add(t);
            taskService1.Commit();
        }
        // GET: api/Event/5
        public Event Get(int id)
        {
            return eventService.GetById(id);
        }
        public int GetOrganizerId(String email)
        {
            UserService user = new UserService();
            return user.GetAll().Where(e => e.Email.equals(email)).Select(e => e.Id);
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

        [HttpGet]
        public IEnumerable<Recommendation> GetRecomByEvent()
        {
            List<Recommendation> listR = new List<Recommendation>();

            foreach (Recommendation r in eventService.GetById(4).listRecommdendation)
            {
                Recommendation recimmendation = new Recommendation { EmailParticipent = r.EmailParticipent, Nom = r.Nom, Prenom = r.Prenom };
                listR.Add(recimmendation);
            }
            return listR;
        }
    }

}

using Domain.Entities;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPIController.Controllers
{
    public class EventController : ApiController
    {

        EventService e = new EventService();

        // GET: api/Event
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
            foreach (Satisfaction s in satisfactionService.GetMany().Where(e => e.EventId==id))
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

            return form.GetAll().Where(e=>e.EventId==id).Count();
        }
        [HttpGet]
        public IEnumerable<Tasks> GetOrganizerTasks(int id)
        {
            TasksService tasks = new TasksService();
            List<Tasks> listTasks = new List<Tasks>();
            foreach(Tasks t in tasks.GetAll().Where(e => e.EventId == id))
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

        // GET: api/Event/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Event
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Event/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Event/5
        public void Delete(int id)
        {
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

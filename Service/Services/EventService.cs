using Data.Infrastructure;
using Domain.Entities;
using Service.IServices;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class EventService : Service<Event>, IEventService
    {
        private static IDatabaseFactory dbfactor = new DatabaseFactory();
        private static IUnitOfWork uow = new UnitOfWork(dbfactor);
        IDatabaseFactory dbfactory = null;
        public EventService():base(uow)
        {

        }
        public List<Tasks> OrganizerTasks(int eventId,int organizerId)
        {
            Event e = this.GetById(eventId);
            List<Tasks> tasks = new List<Tasks>();
            foreach(Tasks t in e.ListTask)
            {
                if (t.UserId== organizerId)
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
            var eventsId=taskService.GetMany().Where(o => o.UserId== organizerId).Select(o=>o.EventId).Distinct();
            foreach(var i in eventsId)
            {
                e.Add(this.GetById(i.Value));

            }
            return e;
            
        }
        
    
    }
}

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
        public IEnumerable<Event> geteventByUser()
        {
            List<Event> list = new List<Event>();
            var ev = this.GetMany().Where(e => e.UserId == 2);
            foreach(Event i in ev)
            {
                Event eventt = new Event();
                eventt.Title = i.Title;
                eventt.Description = i.Description;
                eventt.Start = i.Start;
                eventt.End = i.End;
                eventt.IsFullDay = i.IsFullDay;
                eventt.ThemeColor = i.ThemeColor;
                list.Add(eventt);
            }

            return list;
        }
        public IEnumerable<Event> getEventParticipate(String email)
        {
            List<Event> listEvent = new List<Event>();
            FormService formService = new FormService();
            var eventsId = formService.GetMany().Where(f=>f.Mail.Equals(email)).Select(f=>f.EventId);
           foreach(var i in eventsId)
            {
                Event eventParticipant = this.GetById(i.Value);
                Event e = new Event();
                e.Title = eventParticipant.Title;
                e.Description = eventParticipant.Description;
                e.Start = eventParticipant.Start;
                e.End = eventParticipant.End;
                e.IsFullDay = eventParticipant.IsFullDay;
                e.ThemeColor = eventParticipant.ThemeColor;
                listEvent.Add(e);

            }
            return listEvent;
        }
        
    
    }
}

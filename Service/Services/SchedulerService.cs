﻿using Data.Infrastructure;
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
    public class SchedulerService : Service<Scheduler>, ISchedulerService
    {
        private static IDatabaseFactory dbfactor = new DatabaseFactory();
        private static IUnitOfWork uow = new UnitOfWork(dbfactor);
        IDatabaseFactory dbfactory = null;
        public SchedulerService() : base(uow)
        {

        }
       public IEnumerable<Scheduler> GetSchedulesByEvent(int eventId)
        {
            return this.GetMany().Where(e => e.EventId == eventId);
        }

    }
    
    
}

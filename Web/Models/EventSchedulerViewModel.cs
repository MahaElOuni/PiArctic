using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class EventSchedulerViewModel
    {
        public EventViewModel EventModel { get; set; }
        public SchedulerViewModel SchedulerModel { get; set; }
    }
}
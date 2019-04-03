using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class SchedulerViewModel
    {
        public int SchedulerId { get; set; }
        public String ProgramName { get; set; }
        public String Duration { get; set; }
        public int? EventId { get; set; }
        public EventViewModel Event { get; set; }
    }
}
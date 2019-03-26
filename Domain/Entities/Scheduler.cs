using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Scheduler
    {
        public int SchedulerId { get; set; }
        public String ProgramName { get; set; }
        public String Duration { get; set; }
        public virtual Event Event { get; set; }
    }
}

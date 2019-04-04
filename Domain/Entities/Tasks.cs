using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Tasks
    {
        public int TasksId { get; set; }
        public String TaskTitle { get; set; }
        public int? UserId { get; set; }
        public virtual Organizer Organizer { get; set; }
    }
}

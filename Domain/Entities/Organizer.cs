using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Organizer:User
    {
        public virtual ICollection<Task> ListTask { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Event
    {
        public int EventId { get; set; }
        public String Title { get; set; }
        public virtual ICollection<Recommendation> listRecommdendation { get; set; }
        public virtual ICollection<Ticket> ListTickets { get; set; }
    }
}

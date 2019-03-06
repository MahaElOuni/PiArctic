using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public enum Method
    {

    }
    public class Ticket
    {
        public int TicketId { get; set; }
        public Method Method { get; set; }
        public virtual Event Event { get; set; }
    }
}

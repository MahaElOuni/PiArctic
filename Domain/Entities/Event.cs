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
        public String Address { get; set; }
        public int NumberPlaces { get; set; }
        public float Price { get; set; }
        public String Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public String ThemeColor { get; set; }
        public Boolean IsFullDay { get; set; }
        public String OrganizedBy { get; set; }
        public int? UserId { get; set; }
        public virtual President President { get; set; }
        public virtual ICollection<Recommendation> listRecommdendation { get; set; }
        public virtual ICollection<Ticket> ListTickets { get; set; }
        public virtual ICollection<Form> Forms { get; set; }

        public virtual ICollection<Scheduler> ListScheduler { get; set; }

        public virtual ICollection<Reward> Rewards { get; set; }
        public virtual ICollection<Tasks> ListTask { get; set; }



    }
}

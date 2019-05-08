using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Organizer:User
    {
        public ICollection<Tasks> ListTask { get; set; }
        public virtual ICollection<Reward> ListReward { get; set; }
        public virtual ICollection<Recommendation> ListRecommendation { get; set; }

    }
}

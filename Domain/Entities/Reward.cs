using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Reward
    {
        [Key, Column(Order = 0)]
        public int RewardId { get; set; }

        public int Price1 { get; set; }
        public int Price2 { get; set; }
        public int Price3 { get; set; }
        public int EventId { get; set; }
        public  Event Event { get; set; }
       
        public virtual ICollection<User> User { get; set; }

        public String titre { get; set; }
    }
}

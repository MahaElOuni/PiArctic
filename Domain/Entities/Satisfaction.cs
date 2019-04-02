using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Satisfaction
    {
        public int SatisfactionId { get; set; }
        public String Contenu { get; set; }
        
        public DateTime DatePost { get; set; }
        public User User { get; set; }
        public Event Event { get; set; }
        public int statuss { get; set; }


    }
}

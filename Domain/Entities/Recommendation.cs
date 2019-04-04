using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public enum State
    {
        Accept, Refuse, InProgress
    }
    public class Recommendation
    {
        
        public int RecommendationId { get; set; }
        public int RecommendationNum { get; set; }
        public State Status { get; set; }
        //prop de navigation
     
        public int UserId { get; set; }

        public String EmailParticipent { get; set; }
        public virtual Participant Participant { get; set; }
        public int? EventId { get; set; }
        public virtual Event Event { get; set; }
      

        public String Nom { get; set; }
        public String Prenom { get; set; }
       
        public virtual ICollection<User> User { get; set; }


    }
}


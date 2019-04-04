using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public enum State
    {
        Accept, Refuse, InProgress
    }

    public class RecommendationViewModel
    {
        [Key, Column(Order = 1)]
        public int RecommendationId { get; set; }
        public int RecommendationNum { get; set; }
        public State Status { get; set; }
        //prop de navigation
        [Key, Column(Order = 2)]
        public int UserId { get; set; }
        [Key, Column(Order = 3)]
        public int EventId { get; set; }
        public String EmailParticipent { get; set; }
        public virtual Participant Participant { get; set; }
        public virtual Event Event { get; set; }


        public String Nom { get; set; }
        public String Prenom { get; set; }
        public virtual Reward Reward { get; set; }
        public int RewardId { get; set; }
        public virtual ICollection<User> User { get; set; }


    }
}
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
        public int RecommendationNum { get; set; }
        public State State { get; set; }
        //prop de navigation
        [Key, Column(Order = 2)]
        public int UserId { get; set; }
        [Key, Column(Order = 3)]
        public int EventId { get; set; }
        public virtual ParticipantViewModel Participant { get; set; }
        public virtual EventViewModel Event { get; set; }

    }
}
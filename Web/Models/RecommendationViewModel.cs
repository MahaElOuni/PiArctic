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
        public int RecommendationId { get; set; }
        public int RecommendationNum { get; set; }
      
        public String EmailParticipent { get; set; }

    }
}
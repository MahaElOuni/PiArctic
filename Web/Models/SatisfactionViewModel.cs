using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class SatisfactionViewModel
    {

        public int SatisfactionId { get; set; }
        public String Contenu { get; set; }

        public DateTime DatePost { get; set; }
        public User User { get; set; }
        public Event Event { get; set; }
    }
}
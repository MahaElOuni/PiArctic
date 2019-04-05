using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class SatisfactionViewModel
    {


        [Key]
        public int SatisfactionId { get; set; }
        public int? EventId { get; set; }
        public Event Event { get; set; }

        public int UserId { get; set; }
        [DefaultValue(0)]
        public int status { get; set; }
        public double likes { get; set; }
        public double dislikes { get; set; }



    }
}
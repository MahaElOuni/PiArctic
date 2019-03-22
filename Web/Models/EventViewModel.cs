using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class EventViewModel
    {
        public String Title { get; set; }
        public String Address { get; set; }
        [Display(Name = "Number of places")]
        public int NumberPlaces { get; set; }
        public float Price { get; set; }
        public String Description { get; set; }
        [Display(Name = "Date")]
        [DataType(DataType.DateTime)]
        public DateTime  Date { get; set; }
        public String OrganizedBy { get; set; }
    }
}
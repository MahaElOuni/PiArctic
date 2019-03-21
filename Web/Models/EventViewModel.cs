using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class EventViewModel
    {
        public String Title { get; set; }
        public String Address { get; set; }
        public int NumberPlaces { get; set; }
        public float Price { get; set; }
        public String Description { get; set; }
        public DateTime Date { get; set; }
        public String OrganizedBy { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class EventViewModel
    {
        public int EventId { get; set; }
        public String Title { get; set; }
        public String Address { get; set; }
        [Display(Name = "Number of places")]
        public int NumberPlaces { get; set; }
        public float Price { get; set; }
        public String Description { get; set; }
        [Display(Name = "Date")]
        [DataType(DataType.DateTime)]
        public DateTime Start { get; set; }
        [Display(Name = "End")]
        [DataType(DataType.DateTime)]
        public DateTime End { get; set; }
        [Display(Name = "End")]
        public String ThemeColor { get; set; }
        public Boolean IsFullDay { get; set; }
        public String OrganizedBy { get; set; }
        public String DateString { get; set; }
        public EventViewModel()
        {

        }
    }

}
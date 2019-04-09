using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class EventSchedulerViewModel
    {
        [Required(ErrorMessage = "You forgot to enter event title")]
        public EventViewModel EventModel { get; set; }
        public SchedulerViewModel SchedulerModel { get; set; }
        public int UserId { get; set; }
        public String UserEmail { get; set; }
        public String UserRole { get; set; }
    }
}
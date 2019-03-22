using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class FormViewModel
    {

        [Key, Column(Order = 0)]
        public int FormId { get; set; }
        public String Prenom { get; set; }
        public String Nom { get; set; }
        public int Age { get; set; }
        public String Profession { get; set; }
        public String Mail { get; set; }


        [Key, Column(Order = 1)]
        public int EventId { get; set; }
        //public DateTime Date { get; set; }
        public EventViewModel Event { get; set; }

       

    }
}
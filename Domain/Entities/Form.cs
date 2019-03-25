﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Form
    {
        [Key, Column(Order = 0)]
        public int FormId { get; set; }
        [Key, Column(Order = 1)]
        public String Prenom { get; set; }
        public String Nom { get; set; }
        public int Age { get; set; }
        public String Profession { get; set; }
        public String Mail { get; set; }

        public int EventId { get; set; }
        [Key, Column(Order = 2)]
        public int ParicipantId { get; set; }
        //public DateTime Date { get; set; }
        public Event Event { get; set; }
        public Participant Participant { get; set; }

       
    }
}
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

        public int FormId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime FormDate { get; set; }

        public int Age { get; set; }
        [EnumDataType(typeof(Sex))]
        public Sex Sex { get; set; }

        public String Profession { get; set; }
        [DataType(DataType.PhoneNumber)]
        public int PhoneNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public String Mail { get; set; }
        [EnumDataType(typeof(Countries))]
        public Countries countrie { get; set; }
        [DataType(DataType.MultilineText)]
        public String Adresse { get; set; }
        [DataType(DataType.PostalCode)]
        public String CodePostal { get; set; }
        [Key, Column(Order = 1)]
        public int EventId { get; set; }
        public Event Event { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }

        
       

    }
}
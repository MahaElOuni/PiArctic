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
        [EnumDataType(typeof(Sex))]
        public Sex Sex { get; set; }

        public int Age { get; set; }
        [DataType(DataType.MultilineText)]
        public String Profession { get; set; }
        [DataType(DataType.EmailAddress)]
        public String Mail { get; set; }
        [EnumDataType(typeof(Countries))]
        public Countries Countrie { get; set; }
        public String Address { get; set; }

        public UserModel UserModel { get; set; }
        public int UserId { get; set; }
        public EventViewModel EventView { get; set; }
        public int EventId { get; set; }



    }
}
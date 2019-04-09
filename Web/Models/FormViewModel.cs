using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public enum MethodeDePayemmentVM { OnTheBoxOffice, OnLine }
    public enum SexVM
    {
        Man, Women
    }


    public class FormViewModel
    {

        public String par { get; set; }
        public Boolean? Participant { get; set; }
        public int FormId { get; set; }
        [Required]
        public string Pseudo { get; set; }
        [DataType(DataType.ImageUrl)]
        public string photos { get; set; }
        [MaxLength(8), MinLength(8)]
        [Required]
        public string CIN { get; set; }

        [EnumDataType(typeof(Sex))]
        public SexVM? Sex { get; set; }
        public DateTime FormDate { get; set; }
        public int? Age { get; set; }
        [DataType(DataType.MultilineText)]
        public String Profession { get; set; }
        [DataType(DataType.EmailAddress)]
        public String Mail { get; set; }
        public string Countrie { get; set; }
        public String Address { get; set; }

        //[Display(Name = "EventId")]
        public int? EventId { get; set; }
        public virtual EventViewModel p { get; set; }

        public string Title { get; set; }
        public MethodeDePayemment MethodeDePayemment { get; set; }





    }


    public class IndexViewModel2
    {
        public string StripePublishableKey { get; set; }
    }

    public class ChargeViewModel
    {
        public string StripeToken { get; set; }
        public string StripeEmail { get; set; }
    }

    public class CustomViewModel
    {
        public string StripePublishableKey { get; set; }
        public string StripeToken { get; set; }
        public string StripeEmail { get; set; }
        public bool PaymentForHidden { get; set; }
        public string PaymentForHiddenCss
        {
            get
            {
                return PaymentForHidden ? "hidden" : "";
            }
        }
    }

}
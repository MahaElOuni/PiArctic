using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{

    public enum MethodeDePayemment { OnTheBoxOffice, OnLine }
    public enum Sex
    {
        Man, Women
    }

    public class Form
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int FormId { get; set; }
        [DataType(DataType.Date)]
        // [Required]

        public DateTime FormDate { get; set; }

        [Required]
        public string Pseudo { get; set; }
        [DataType(DataType.ImageUrl)]
        public string photos { get; set; }
        [MaxLength(8), MinLength(8)]
        [Required]
        public string CIN { get; set; }

        [EnumDataType(typeof(Sex))]
        public Sex? Sex { get; set; }

        public int? Age { get; set; }
        [DataType(DataType.MultilineText)]
        public String Profession { get; set; }
        [DataType(DataType.EmailAddress)]
        public String Mail { get; set; }

        public string Countrie { get; set; }
        public String Address { get; set; }
        public Boolean? Participant { get; set; }

        // [Key, Column(Order = 2)]
        public int? EventId { get; set; }
        public virtual Event Event { get; set; }
        public string Title { get; set; }
        public MethodeDePayemment MethodeDePayemment { get; set; }


    }
}

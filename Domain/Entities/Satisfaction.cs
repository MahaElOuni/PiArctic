using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Satisfaction
    {
        [Key]
        public int SatisfactionId { get; set; }
        public int? EventId { get; set; }
        public Event Event  { get; set; }
        
        public int UserId { get; set; }
        [DefaultValue(0)]
        public int status { get; set; }


    }
}

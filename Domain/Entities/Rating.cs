using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Rating
    {
        [Key]

        public int ratingid { get; set; }
        public String UserName { get; set; }
        public int nbrating { get; set; }
    }
}

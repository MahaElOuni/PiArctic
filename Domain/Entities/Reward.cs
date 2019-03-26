using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Reward
    {
        [Key, Column(Order = 0)]
        public int IdReward { get; set; }

        public int Price { get; set; }

        public  Event Event { get; set; }


        public String titre { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class RewardViewModel
    {
        public int IdReward { get; set; }

        public int Price { get; set; }
        public String titre { get; set; }
        public RewardViewModel()
        {

        }
    }
}
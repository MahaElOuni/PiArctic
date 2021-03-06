﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class RewardViewModel
    {
        public int IdReward { get; set; }

        public int Price1 { get; set; }
        public int Price2 { get; set; }
        public int Price3 { get; set; }

        public Event Event { get; set; }
        public virtual ICollection<User> User { get; set; }

        public String titre { get; set; }
        public RewardViewModel()
        {

        }
    }
}
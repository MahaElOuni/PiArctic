﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class President:User
    {
        
        public String Recommendation { get; set; }
        public String Logo { get; set; }
        public String PresidentName { get; set; }
        public virtual ICollection<Event> ListEvent { get; set; }
    }
}

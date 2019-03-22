using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Blog
    {
        public int BlogId { get; set; }
        public String Contenu { get; set; }
        public User User { get; set; }

    }
}

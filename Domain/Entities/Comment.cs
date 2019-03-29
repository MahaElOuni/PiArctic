using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int NbrLike { get; set; }
        public String Contenu { get; set; }
        public User User { get; set; }
        public int BlogId { get; set; }

    }
}

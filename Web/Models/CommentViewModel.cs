using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class CommentViewModel
    {
        public int CommentId { get; set; }
        public int NbrLike { get; set; }
        public String Contenu { get; set; }
    }
}
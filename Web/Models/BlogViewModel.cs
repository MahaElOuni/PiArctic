using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class BlogViewModel
    {
        public int BlogId { get; set; }
        public String Contenu { get; set; }
        public String Photo { get; set; }
        public DateTime DatePost { get; set; }
        public String Titre { get; set; }
    }
}
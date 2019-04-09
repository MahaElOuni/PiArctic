using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;

namespace Web.Models
{
	public class BlogViewModel
	{
		public int BlogId { get; set; }
		public String Contenu { get; set; }
		public String Photo { get; set; }
		public DateTime DatePost { get; set; }
		public int NbrLike { get; set; }
		public int NbrComment { get; set; }
		public virtual List<Blog> Blogs { get; set; }
		public String Des { get; set; }
		public String Titre { get; set; }
		public int? UserId { get; set; }
		public String ne { get; set; }
		public User User { get; set; }
		public virtual ICollection<CommentViewModel> Comments { get; set; }
	}
}
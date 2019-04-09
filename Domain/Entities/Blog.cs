using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class Blog
	{
		[Key]
		public int BlogId { get; set; }
		public String Contenu { get; set; }
		public int NbrLike { get; set; }
		public ICollection<Like> Likes { get; set; }
		public int NbrComment { get; set; }
		public String Des { get; set; }
		public String Titre { get; set; }
		public String Photo { get; set; }
		public DateTime DatePost { get; set; }
		public int? UserId { get; set; }
		public String ne { get; set; }
		public User User { get; set; }
		public virtual ICollection<Comment> Comments { get; set; }


	}
}

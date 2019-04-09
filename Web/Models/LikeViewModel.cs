using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
	public class LikeViewModel
	{

		public int LikeId { get; set; }
		public User User { get; set; }
		public int UserId { get; set; }
		public Blog Blog { get; set; }
		public int BlogId { get; set; }
	}
}
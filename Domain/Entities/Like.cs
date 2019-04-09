﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class Like
	{
		public int LikeId { get; set; }
		public User User { get; set; }
		public int UserId { get; set; }
		public Blog Blog { get; set; }
		public int BlogId { get; set; }
	}
}

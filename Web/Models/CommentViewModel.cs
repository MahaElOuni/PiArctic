﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;

namespace Web.Models
{
	public class CommentViewModel
	{
		public int CommentId { get; set; }
		public int NbrLike { get; set; }
		public String Contenu { get; set; }
		public int? UserId { get; set; }
		public Blog Blog { get; set; }
		public String nom { get; set; }
		public String Photoc { get; set; }
		public DateTime DateCom { get; set; }
		public int BlogId { get; set; }

	}
}
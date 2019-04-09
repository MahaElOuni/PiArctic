using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using Domain.Entities;
using Service.IServices;
using ServicePattern;

namespace Service.Services
{

	public class CommentService : Service<Comment>, ICommentService
	{
		private static IDatabaseFactory dbfactor = new DatabaseFactory();
		private static IUnitOfWork wow = new UnitOfWork(dbfactor);
		IDatabaseFactory dbfactory = null;
		public CommentService() : base(wow)
		{

		}
		public List<Comment> BlogComment(int id)
		{
			List<Comment> l = new List<Comment>();
			var a = GetAll();
			foreach (var i in a)
			{
				if (i.BlogId == id)
				{
					l.Add(i);
				}
			}
			return l;

		}
		
	}

}

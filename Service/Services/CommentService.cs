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
		private static IUnitOfWork uow = new UnitOfWork(dbfactor);
		IDatabaseFactory dbfactory = null;
		public CommentService() : base(uow)
		{

		}
		public List<Comment> nbrComment(int id)
		{

			List<Comment> list = uow.getRepository<Comment>().GetAll().ToList();
			list = list.FindAll(x => x.BlogId.Equals(id)).ToList();
			return list;
		}

	}

}

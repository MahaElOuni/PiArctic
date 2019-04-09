using Data.Infrastructure;
using Domain.Entities;
using Service.IServices;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
	public class LikeService : Service<Like>, ILikeService
	{
		private static IDatabaseFactory dbfactor = new DatabaseFactory();
		private static IUnitOfWork uow = new UnitOfWork(dbfactor);
		IDatabaseFactory dbfactory = null;
		public LikeService() : base(uow)
		{

		}
		public List<Like> nbrLike(int id)
		{

			List<Like> list = uow.getRepository<Like>().GetAll().ToList();
			list = list.FindAll(x => x.BlogId.Equals(id)).ToList();
			return list;


		}

	}
}

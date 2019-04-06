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
	public class BlogService : Service<Blog>, IBlogService
	{
		private static IDatabaseFactory dbfactor = new DatabaseFactory();
		private static IUnitOfWork wow = new UnitOfWork(dbfactor);
		IDatabaseFactory dbfactory = null;
		public BlogService() : base(wow)
		{

		}

	}
}

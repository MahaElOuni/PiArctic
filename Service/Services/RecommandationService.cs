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
    public class RecommandationService : Service<Recommendation>, IRecommandationService
    {
        private static IDatabaseFactory dbfactor = new DatabaseFactory();
        private static IUnitOfWork uow = new UnitOfWork(dbfactor);
        IDatabaseFactory dbfactory = null;
        public RecommandationService() : base(uow)
        {

        }

        public IEnumerable<Recommendation> ListOrgazateur(int id)
        {
            var list = GetAll().OrderByDescending(t => t.EventId==id);
           
                return list;
        }

    }
}

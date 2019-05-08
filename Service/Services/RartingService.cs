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
    public class RatingService : Service<Rating>, IRatingService
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);
        public RatingService() : base(ut)

        {
        }
    }
}

﻿using Data.Infrastructure;
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
   public class UserService : Service<User>,IUserService
    {
        private static IDatabaseFactory dbfactor = new DatabaseFactory();
        private static IUnitOfWork wow = new UnitOfWork(dbfactor);
        IDatabaseFactory dbfactory = null;
        public UserService() : base(wow)
        {

        }
    }
}

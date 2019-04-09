using Domain.Entities;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiController1.Controllers
{
    public class RewardController : ApiController
    {
        RewardService rewardService = new RewardService();
        // GET: api/Reward
        public IEnumerable<Reward> Get()
        {
            return rewardService.GetAll();
        }

        // GET: api/Reward/5
        public Reward Get(int id)
        {
            return rewardService.GetById(id);
        }

        // POST: api/Reward
        public void Post([FromBody]Reward r )
        {
            Reward rd = new Reward();
            rd.Price1 = r.Price1;
            rd.Price2 = r.Price2;
            rd.Price3 = r.Price3;
            rd.titre = r.titre;
            rewardService.Add(rd);
            rewardService.Commit();


        }

        // PUT: api/Reward/5
        public void Put(int id, [FromBody]Reward r)
        {
            Reward rd = rewardService.GetById(id);
            rd.Price1 = r.Price1;
            rd.Price2 = r.Price2;
            rd.Price3 = r.Price3;
            rd.titre = r.titre;
            rewardService.Update(rd);
            rewardService.Commit();

        }

        // DELETE: api/Reward/5
        public void Delete(int id)
        {
            rewardService.Delete(rewardService.GetById(id));
            rewardService.Commit();
            

        }
    }
}

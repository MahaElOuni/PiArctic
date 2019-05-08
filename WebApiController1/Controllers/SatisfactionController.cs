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
    public class SatisfactionController : ApiController
    {
        SatisfactionService satisfactionService = new SatisfactionService();
        EventService eventService = new EventService();
        // GET: api/Satisfaction
        public IEnumerable<Satisfaction> Get()
        {
            return satisfactionService.GetAll().AsEnumerable();
        }

        // GET: api/Satisfaction/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Satisfaction
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Satisfaction/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Satisfaction/5
        public void Delete(int id)
        {
        }

        // GET: api/Satisfaction
        [HttpGet]
        public IEnumerable<Satisfaction> EventLikers(int id)
        {
            List<Satisfaction> listSatisfaction = new List<Satisfaction>();
            SatisfactionService satisfactionService = new SatisfactionService();
            foreach (Satisfaction s in satisfactionService.GetMany().Where(e => e.EventId == 4))
            {
                Satisfaction satisfaction = new Satisfaction { status = s.status };
                listSatisfaction.Add(satisfaction);
            }
            return listSatisfaction;
        }
        
    }
}

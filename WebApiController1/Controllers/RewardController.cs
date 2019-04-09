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
        // GET: api/Reward
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Reward/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Reward
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Reward/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Reward/5
        public void Delete(int id)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiController1.Controllers
{
    public class RecommandationController : ApiController
    {
        // GET: api/Recommandation
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Recommandation/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Recommandation
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Recommandation/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Recommandation/5
        public void Delete(int id)
        {
        }
    }
}

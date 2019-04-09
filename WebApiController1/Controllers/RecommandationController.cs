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
    public class RecommandationController : ApiController
    {
        RecommandationService recommandationService = new RecommandationService();
        // GET: api/Recommandation
        public IEnumerable<Recommendation> Get()
        {
            return recommandationService.GetAll();
        }

        // GET: api/Recommandation/5
        public Recommendation Get(int id)
        {
            return recommandationService.GetById(id);
        }

        // POST: api/Recommandation
        public void Post([FromBody] Recommendation r)
        {
            Recommendation re = new Recommendation();
            re.Nom = r.Nom;
            re.Prenom = r.Prenom;
            re.EmailParticipent = r.EmailParticipent;
            recommandationService.Add(re);
            recommandationService.Commit();

        }

        // PUT: api/Recommandation/5
        public void Put(int id, [FromBody]Recommendation r)
        {
            Recommendation re = recommandationService.GetById(id);
            re.Nom = r.Nom;
            re.Prenom = r.Prenom;
            re.EmailParticipent = r.EmailParticipent;
            recommandationService.Update(re);
            recommandationService.Commit();
        }

        // DELETE: api/Recommandation/5
        public void Delete(int id)
        {
            recommandationService.Delete(recommandationService.GetById(id));
            recommandationService.Commit();
        }
    }
}

using Service.Services;
using Domain.Entities;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;

namespace WebApiController1.Controllers
{
    public class BlogAPIController : ApiController
    {
		BlogService blogService = new BlogService();
		RatingService rs = new RatingService();
		// GET: api/BlogAPI
		public IEnumerable<Blog> Get()
		{
			return blogService.GetAll();
		}

		// GET: api/BlogAPI/5
		public Blog Get(int id)
        {
			return blogService.GetById(id);
		}

        // POST: api/BlogAPI
        public void Post([FromBody]Blog b)
        {
			blogService.Add(b);
			blogService.Commit();
		}

        // PUT: api/BlogAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/BlogAPI/5
        public void Delete(int id)
        {
			blogService.Delete(blogService.GetById(id));
			blogService.Commit();
		}



        [Route("api/BlogAPI/rate")]
        [HttpPost]
        public IHttpActionResult ratings(Rating rat)
        {
            Rating r = new Rating();

            r.nbrating = rat.nbrating;
            r.UserName = rat.UserName;

            rs.Add(r);
            rs.Commit();
            return Ok("Create Success");
        }
        [Route("api/BlogAPI/GetAllrat")]
        [HttpGet]
        // GET: api/ReclamationApi
        public int GetAllRating()
        {

            int rattot = 0;
            List<Rating> myList = rs.GetAll().ToList();
            myList.ForEach(x => rattot = rattot + x.nbrating);
            rattot = rattot / myList.Count;
            return rattot;
        }
    }
}

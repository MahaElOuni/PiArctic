using Service.Services;
using System;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiController1.Controllers
{
    public class BlogAPIController : ApiController
    {
		BlogService blogService = new BlogService();
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
    }
}

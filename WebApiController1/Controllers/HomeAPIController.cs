using Domain.Entities;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web.Models;

namespace WebApiController1.Controllers
{
    public class HomeAPIController : ApiController
    {
        UserService userService = new UserService();
        UserModel userModel = new UserModel();
        // GET: api/HomeAPI
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/HomeAPI/5
        public void GetId(String email,String password )
        {
            int id = 0;
            var users = userService.GetAll();
            foreach (var i in users)
            {
                if (i.Email.Equals(email) && i.Password.Equals(password))
                {
                    id = i.Id;
                }

            }
        }
        [Route("api/UserId")]
        [HttpPost]
        public IHttpActionResult Index(String email, int id)
        {
            var users = userService.GetAll();

            if (email != null)
            {
                foreach (var i in users)
                {
                    if (i.Email.Equals(email))
                    {
                        userModel.UserId = i.Id;
                        userModel.Role = i.Role;
                    }
                }
                return Ok(userModel);
            }
            return Ok();

        }


        // POST: api/HomeAPI
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/HomeAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/HomeAPI/5
        public void Delete(int id)
        {
        }
    }
}

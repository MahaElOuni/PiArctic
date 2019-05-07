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
    public class AdminAPIController : ApiController
    {
        UserService us = new UserService();
        // GET: api/AdminAPI
        public IEnumerable<User> Get()
        {

            return us.GetAll();
        }

        // GET: api/AdminAPI/PendingUser

        [Route("PendingUser")]
        [HttpGet]
        public IEnumerable<User> Index()
        {
         
            return us.GetMany().Where(e => e.Etat=="Pending");
        }

        [Route("GetUserId")]
        [HttpGet]
        public User getById(int id)
        {
            return (User)us.getUser(id);
        }
        [Route("changeState")]
        [HttpGet]
        public void ChangeState(int id, String state)
        {
             us.ChangeStateById(id,state);
        }


        // POST: api/AdminAPI
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/AdminAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/AdminAPI/5
        public void Delete(int id)
        {
        }
    }
}

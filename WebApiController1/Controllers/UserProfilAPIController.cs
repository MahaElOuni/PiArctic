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
    public class UserProfilAPIController : ApiController
    {
        UserService userService = new UserService();
        // GET: api/UserProfilAPI
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/UserProfilAPI/5
      /*  [Route("Userdetails")]
        [HttpGet]*/
        public User Get(int id)
        {
            return userService.GetById(id);

            //UserModel userModel = new UserModel();
            //var user = userService.GetAll();
            //foreach (var i in user)
            //{
            //    if (i.Id == id)
            //    {

            //        userModel.UserId = i.Id;
            //        userModel.FName = i.FName;
            //        userModel.LName = i.LName;
            //        userModel.StreetName = i.StreetName;
            //        userModel.PhoneNumber = i.PhoneNumber;
            //        userModel.Email = i.Email;
            //        userModel.CIN = i.CIN;
            //        userModel.Role = i.Role;
            //        userModel.Photo = i.Photo;

            //    }
            //}

            //return Ok(userModel);
        }

        // POST: api/UserProfilAPI
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/UserProfilAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/UserProfilAPI/5
        public void Delete(int id)
        {
        }
    }
}

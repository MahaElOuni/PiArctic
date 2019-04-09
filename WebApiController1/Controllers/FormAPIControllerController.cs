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
    public class FormAPIControllerController : ApiController
    {
        FormService FS = new FormService();

        // GET: api/FormAPIController
        public IEnumerable<Form> Get()
        {
            return FS.GetAll().AsEnumerable();
        }

        // GET: api/FormAPIController/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/FormAPIController
        public void Post([FromBody]Form form)
        {

            Form f1 = new Form();
            f1.Pseudo = form.Pseudo;
            f1.FormDate = form.FormDate;
            f1.CIN = form.CIN;
            f1.MethodeDePayemment = form.MethodeDePayemment;
            FS.Add(f1);
            FS.Commit();
        }

        // PUT: api/FormAPIController/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/FormAPIController/5
        public void Delete(int id)
        {
        }
    }
}

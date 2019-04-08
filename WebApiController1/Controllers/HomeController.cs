using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace WebApiController1.Controllers
{
    public class HomeController : Controller
    {
        UserService userService = new UserService();
        UserModel userModel = new UserModel();
        public void getId(String email, String password)
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
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}

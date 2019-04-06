using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        UserService userService = new UserService();
        UserModel userModel = new UserModel();
        [HttpPost]
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
        public ActionResult Index(String email ,int id)
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
                return View(userModel);
            }
            else
            {
                return View();
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Blog()
        {
            ViewBag.Message = "Blog page.";

            return View();
        }
        public ActionResult BlogDetail()
        {
            ViewBag.Message = "Blog Detail.";

            return View();
        }

        public ActionResult LogIn()
        {
            ViewBag.Message = "Blog Detail.";

            return View();
        }

      
    }
}
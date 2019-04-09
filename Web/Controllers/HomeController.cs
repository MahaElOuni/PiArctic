using Domain.Entities;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
            RewardViewModel evm = new RewardViewModel();
            UserService userService = new UserService();
            foreach (User i in userService.GetAll())
            {
                if (i.UserName.Equals(User.Identity.Name))
                {
                    evm.UserId = i.Id;
                    evm.UserEmail = i.Email;
                    evm.UserRole = i.Role;


                }
            }


            return View(evm);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            RewardViewModel evm = new RewardViewModel();
            UserService userService = new UserService();
            foreach (User i in userService.GetAll())
            {
                if (i.UserName.Equals(User.Identity.Name))
                {
                    evm.UserId = i.Id;
                    evm.UserEmail = i.Email;
                    evm.UserRole = i.Role;


                }
            }


            SendingMail("levio.lmp@gmail.com", "khouloud.sma@esprit.tn", "Request problems", "problems ");

            return View(evm);
        }
        public void SendingMail(string From, string To, string Subject, string Body)
        {
            MailMessage mail = new MailMessage(From, To, Subject, Body);
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("levio.lmp@gmail.com", "eudfdldhubmzuscf");
            smtp.EnableSsl = true;
            smtp.Send(mail);
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
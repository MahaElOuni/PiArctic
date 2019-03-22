using Data;
using Domain.Entities;
using Microsoft.AspNet.Identity;
using Service.IServices;
using Service.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class PresidentController : Controller
    {
        IPresidentService Ps = new PresidentService();
        UserManager<User, int> _userManager = new UserManager<User, int>(new CustomUserStore(new Context()));
        public String RoleUser()
        {
            IUserService Us = new UserService();
            User u = new User();
            var id = Int16.Parse(User.Identity.GetUserId());
            return Ps.Get(t => t.Id == id).Role;
        }
        // GET: President
        public ActionResult Index()
        {
            if(RoleUser() == "User")
            {
                List<PresidentModel> List = new List<PresidentModel>();
                foreach(var item in Ps.GetAll())
                {
                    PresidentModel Pm = new PresidentModel();
                    Pm.Id = item.Id;
                    Pm.PresidentName = item.PresidentName;
                    Pm.Email = item.Email;
                    Pm.PhoneNumber = item.PhoneNumber;
                    Pm.StreetName = item.StreetName;
                    Pm.City = item.City;
                    Pm.Logo = item.Logo;
                    Pm.Photo = item.Photo;
                    List.Add(Pm);

                }
                return View(List);
            }
            else
            {
                return HttpNotFound();
            }
            
        }

        // GET: President/Details/5
        public ActionResult Details(int id)
        {
            if(RoleUser() == "User")
            {
                President P = new President();
                P = Ps.Get(t => t.Id == id);
                PresidentModel Pm = new PresidentModel();
                Pm.Id = P.Id;
                Pm.PresidentName = P.PresidentName;
                Pm.Email = P.Email;
                Pm.PhoneNumber = P.PhoneNumber;
                Pm.StreetName = P.StreetName;
                Pm.City = P.City;
                Pm.Logo = P.Logo;
                Pm.Photo = P.Photo;
                return View(Pm);
            }
            else
            {
                return HttpNotFound();
            }
            
        }
        public ActionResult ProfilePresident()
        {
            if (RoleUser() == "President")
            {
                President P = new President();
                var id = Int32.Parse(User.Identity.GetUserId());
                P = Ps.Get(t => t.Id == id);
                PresidentModel Pm = new PresidentModel();
                Pm.Id = P.Id;
                Pm.PresidentName = P.PresidentName;
                Pm.Email = P.Email;
                Pm.PhoneNumber = P.PhoneNumber;
                Pm.StreetName = P.StreetName;
                Pm.City = P.City;
                Pm.Photo = P.Photo;
                Pm.Logo = P.Logo;
                return View(Pm);
            }
             else
            {
                return HttpNotFound();
            }
        }

        // GET: President/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: President/Create
        [HttpPost]
        public ActionResult Create(PresidentModel Pm)
        {
            if (RoleUser() == "User")
            {
                President P = new President();
                P.PresidentName = Pm.PresidentName;
                P.Email = Pm.Email;
                P.PhoneNumber = Pm.PhoneNumber;
                P.StreetName = Pm.StreetName;
                P.City = Pm.City;
                P.Logo = "Logo.jpg";
                P.Photo = Pm.Photo;
                P.Role = "President";
                var mp = RandomStringGenerator();
                P.Password = mp;
                P.PasswordHash = _userManager.PasswordHasher.HashPassword(mp);
                P.LockoutEnabled = true;
                P.SecurityStamp = Guid.NewGuid().ToString();
                /********Mail*****/
                try
                {
                    MailMessage message = new MailMessage("smakhouloud@gmail.com", Pm.Email, "Hello", "Compte créé votre mail est : " + Pm.Email + ", Votre mp est: " + mp);
                    message.IsBodyHtml = true;
                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    client.EnableSsl = true;
                    client.Credentials = new System.Net.NetworkCredential("smakhouloud@gmail.com", "0720MB2326");
                    client.Send(message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }

                /*********Mail***********/
                Ps.Add(P);
                Ps.Commit();
                return RedirectToAction("index");
            }
            else
            {
                return HttpNotFound();
            }

            }
           
        

        // GET: President/Edit/5
        public ActionResult Edit(int id)
        {
            if (RoleUser() == "User")
            {
                President P = new President();
                P = Ps.Get(t => t.Id == id);
                PresidentModel Pm = new PresidentModel();
                Pm.Id = id;
                Pm.PresidentName = P.PresidentName;
                Pm.Email = P.Email;
                Pm.PhoneNumber = P.PhoneNumber;
                Pm.StreetName = P.StreetName;
                Pm.City = P.City;
                Pm.Logo = P.Logo;
                Pm.Photo = P.Photo;

                return View(Pm);
            }
            else
            {
                return HttpNotFound();
            }
        }

        // POST: President/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PresidentModel Pm)
        {
            if (RoleUser() == "User")
            {
                President P = new President();
                P = Ps.Get(t => t.Id == id);

                Pm.PresidentName = P.PresidentName;
                Pm.Email = P.Email;
                P.UserName = Pm.Email;
                Pm.PhoneNumber = P.PhoneNumber;
                Pm.StreetName = P.StreetName;
                Pm.City = P.City;
                Pm.Logo = P.Logo;
                Pm.Photo = P.Photo;

                Ps.Update(P);
                Ps.Commit();
                return RedirectToAction("Index");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // POST: changeIMG
        [HttpPost]
        public ActionResult EditImg(int id, HttpPostedFileBase file)
        {
            President c = new President();
            c = Ps.Get(t => t.Id == id);

            var fileName = "";
            if (file.ContentLength > 0)
            {
                fileName = Path.GetFileName(file.FileName);

                var path = Path.Combine(Server.MapPath("~/Content/Upload/"), file.FileName);
                file.SaveAs(path);
            }

            c.Logo = file.FileName;
            Ps.Update(c);
            Ps.Commit();
            return RedirectToAction("Details", new { id = c.Id });

        }

        // GET: President/Delete/5
        public ActionResult Delete(int id)
        {
            if (RoleUser() == "User")
            {
                President P = new President();
                P = Ps.Get(t => t.Id == id);
                PresidentModel Pm = new PresidentModel();
                Pm.Id = id;
                Pm.PresidentName = P.PresidentName;
                Pm.Email = P.Email;
                P.UserName = Pm.Email;
                Pm.PhoneNumber = P.PhoneNumber;
                Pm.StreetName = P.StreetName;
                Pm.City = P.City;
                Pm.Logo = P.Logo;
                Pm.Photo = P.Photo;
                return View(Pm);
            }
            else
            {
                return HttpNotFound();
            }
        }

        // POST: President/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, PresidentModel Pm)
        {
            if (RoleUser() == "User")
            {
                President c = new President();
                c = Ps.Get(t => t.Id == id);
                Ps.Delete(c);
                Ps.Commit();
                return RedirectToAction("Index");
            }
            else
            {
                return HttpNotFound();
            }
        }
        public static String RandomStringGenerator()
        {
            String randomString = Path.GetRandomFileName();
            randomString = randomString.Replace(".", string.Empty);
            return randomString;
        }
    }
}

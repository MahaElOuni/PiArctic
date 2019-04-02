using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class UserProfilController : Controller
    {
        UserService userService = new UserService();
        // GET: UserProfil
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserProfil/Details/5
        public ActionResult Details(int id)
        {
            UserModel userModel = new UserModel();
            var user = userService.GetAll();
            foreach (var i in user)
            {
                if (i.Id==id)
                {

                    userModel.UserId = i.Id;
                    userModel.FName = i.FName;
                    userModel.LName = i.LName;
                    userModel.StreetName = i.StreetName;
                    userModel.PhoneNumber = i.PhoneNumber;
                    userModel.Email = i.Email;
                    userModel.CIN = i.CIN;
                    userModel.Role = i.Role;
                    userModel.Photo = i.Photo;

                }
            }

            return View(userModel);
        }

        // GET: UserProfil/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserProfil/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserProfil/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserProfil/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserProfil/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserProfil/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

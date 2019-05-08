using Domain.Entities;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class AdminController : Controller
    {
        UserService us = new UserService();
        // GET: Admin
        public ActionResult Index()
        {
            ICollection<User> ListUser = us.GetAll().ToList();
            ICollection<User> ListUserPending = new List<User>();


            foreach (User um in ListUser)
            {
                if (um.Etat.Equals("Pending"))
                {
                    ListUserPending.Add(um);
                }
            }
            ViewBag.ap = "Approve";
            ViewBag.rj = "Reject";
            ViewBag.ad = "Admin";
            return View(ListUserPending);
        }

        public ActionResult Approve(int id)
        {
            us.ChangeStateById(id, "Approved");
            return RedirectToAction("Index");
        }

        public ActionResult Reject(int id)
        {
            us.ChangeStateById(id, "Rejected");
            return RedirectToAction("Index");
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            
            return View();
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
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


        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Edit/5
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

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
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

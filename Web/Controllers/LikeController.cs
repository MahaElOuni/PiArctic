using Domain.Entities;
using Microsoft.AspNet.Identity;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class LikeController : Controller
    {
        // GET: Like
        public ActionResult Index()
        {
            return View();
        }

        // GET: Like/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Like/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Like/Create
        [HttpPost]
        public ActionResult Create(LikeViewModel lvm , int idb)
        {
			LikeService likeService = new LikeService();
			Like l = new Like();
			l.UserId = User.Identity.GetUserId<int>();
			l.BlogId = idb;
			likeService.Add(l);
			likeService.Commit();


			return RedirectToAction("../Blog/Details");
            
        }
		public ActionResult Like(int id, LikeViewModel lvm)
		{
			LikeService likeService = new LikeService();
			Like l = new Like();
			l.UserId = User.Identity.GetUserId<int>();
			l.BlogId = id;
			likeService.Add(l);
			likeService.Commit();

			return RedirectToAction("../Blog/Details");
		}
        // GET: Like/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Like/Edit/5
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

        // GET: Like/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Like/Delete/5
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

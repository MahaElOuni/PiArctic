using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Entities;
using Service.Services;
using Web.Models;

namespace Web.Controllers
{
    public class BlogController : Controller
    {
        BlogService blogService = new BlogService();
        
        // GET: Blog
        public ActionResult Index()
        {
            return View();
        }

        // GET: Blog/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Blog/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blog/Create
        [HttpPost]
        public ActionResult Create(BlogViewModel bvm)
        {
            DateTime now = DateTime.Now;
            Blog b = new Blog();
            b.Titre = bvm.Titre;
            b.Contenu = bvm.Contenu;
            b.Photo = bvm.Photo;
            b.DatePost = now;

            
                return View();
           
        }

        // GET: Blog/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Blog/Edit/5
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

        // GET: Blog/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Blog/Delete/5
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

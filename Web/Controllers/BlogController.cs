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
            List<BlogViewModel> list = new List<BlogViewModel>();
            var a = blogService.GetAll();
            foreach (var i in a)
            {
                BlogViewModel bvm = new BlogViewModel();
                bvm.BlogId = i.BlogId;
                bvm.Titre = i.Titre;
                bvm.Contenu = i.Contenu;
                bvm.Photo = i.Photo;
                bvm.DatePost = i.DatePost; 
                list.Add(bvm);
            }
            
            return View(list);
        }

        // GET: Blog/Details/5
        
        public ActionResult Details(int id)
        {
            BlogViewModel bvm = new BlogViewModel();
            var blogs = blogService.GetAll();
            foreach (var i in blogs)
            {
                if (i.BlogId == id)
                {
                    bvm.BlogId = i.BlogId;
                    bvm.Titre= i.Titre;
                    bvm.DatePost= i.DatePost;
                    bvm.Contenu= i.Contenu;
                    bvm.Photo= i.Photo;

                }
            }
            return View(bvm);
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
            b.Contenu = bvm.Contenu;
            b.Titre = bvm.Titre;
            b.DatePost = now;
            b.Photo = bvm.Photo;
            blogService.Add(b);
            blogService.Commit();

            return RedirectToAction("Index");


        }

        // GET: Blog/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Blog/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, BlogViewModel bvm )
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
        public ActionResult Delete(int id,BlogViewModel bvm )
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

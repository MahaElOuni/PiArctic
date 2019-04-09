using System;
using System.Collections.Generic;
using System.IO;
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
		BlogViewModel bvm = new BlogViewModel();

		// GET: Blog
		public ActionResult Index()
		{
			List<BlogViewModel> list = new List<BlogViewModel>();
			var a = blogService.GetAll();
			foreach (var i in a)
			{
				BlogViewModel bvm = new BlogViewModel();
				bvm.ne = i.ne; 
				bvm.BlogId = i.BlogId;
				bvm.NbrLike = i.NbrLike;
				bvm.NbrComment = i.NbrComment;
				bvm.Titre = i.Titre;
				bvm.Contenu = i.Contenu;
				bvm.Photo = i.Photo;
				bvm.DatePost = i.DatePost;
				list.Add(bvm);
			}

			return View(list);
		}
		public List<CommentViewModel> Affiche(int id)
		{
			BlogService blogService = new BlogService();
			BlogViewModel bvm = new BlogViewModel();

			List<CommentViewModel> lc = new List<CommentViewModel>();
			lc.Clear();
			Blog b = blogService.GetById(id);
			if (b.Comments != null)
			{
				foreach (Comment c in b.Comments)
				{

					CommentViewModel cvm = new CommentViewModel();
					cvm.Contenu = c.Contenu;
					cvm.DateCom = c.DateCom;
					cvm.nom = c.nom;
					lc.Add(cvm);
				}

			}

			return lc;

		}
		public void like(int id)
		{

		}

		// GET: Blog/Details/5
		public ActionResult Details(int id)
		{
			BlogService blogService = new BlogService();
			BlogViewModel bvm = new BlogViewModel();

			var blogs = blogService.GetAll();
			foreach (var i in blogs)
			{
				if (i.BlogId == id)
				{
					bvm.ne = i.ne;
					bvm.BlogId = i.BlogId;
					bvm.Titre = i.Titre;
					bvm.NbrLike = i.NbrLike;
					bvm.NbrComment = i.NbrComment;
					bvm.DatePost = i.DatePost;
					bvm.Contenu = i.Contenu;
					bvm.Photo = i.Photo;
					bvm.Comments = Affiche(id);
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
		public ActionResult Create(BlogViewModel bvm, HttpPostedFileBase file2)
		{
			String e ="" ;
			int idUser = 0;
			User u = new User();
			UserService userService = new UserService();
			foreach (User i in userService.GetAll())
			{
				if (i.UserName.Equals(User.Identity.Name))
				{
					idUser = i.Id;
					e = i.FName;
				}
			}
            if (file2 != null && file2.ContentLength > 0 /*&& file1 != null && file1.ContentLength > 0*/)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Content/Upload"), Path.GetFileName(file2.FileName));
                    //string path1 = Path.Combine(Server.MapPath("~/Content/Upload"), Path.GetFileName(file1.FileName));
                    file2.SaveAs(path);
                    //file1.SaveAs(path1);
                    ViewBag.Message = "Image uploaded successfully";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
            DateTime now = DateTime.Now;
			Blog b = new Blog();
			b.ne = e;
			b.UserId = idUser;
			b.Contenu = bvm.Contenu;
            b.Photo = file2.FileName;
			b.Titre = bvm.Titre;
			b.NbrComment = 0;
			b.NbrLike = 0;
			b.DatePost = now;
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
		public ActionResult Edit(int id, BlogViewModel bvm)
		{
			Blog b = new Blog();
			b.BlogId = id;
			b.Contenu = bvm.Contenu;
			b.Titre = bvm.Titre;
			b.Photo = bvm.Photo;
			b.DatePost = bvm.DatePost;
			blogService.Update(b);
			blogService.Commit();
			return RedirectToAction("Index");
		}

		// GET: Blog/Delete/5
		public ActionResult Delete(int id, int userid)
		{
			var blogs = blogService.GetAll();
			foreach (var i in blogs)
			{
				if (i.BlogId == id && i.UserId== userid)
				{
					bvm.BlogId = i.BlogId;
					bvm.Titre = i.Titre;
					bvm.DatePost = i.DatePost;
					bvm.Contenu = i.Contenu;
					bvm.Photo = i.Photo;
					blogService.Delete(i);
					blogService.Commit();
				}
			}

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

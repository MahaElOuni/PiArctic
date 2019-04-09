using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Domain.Entities;
using Microsoft.AspNet.Identity;
using Service.Services;
using Web.Models;
using PagedList;
using PagedList.Mvc;
using System.Linq;

namespace Web.Controllers
{
	public class BlogController : Controller
	{
		BlogService blogService = new BlogService();
		BlogViewModel bvm = new BlogViewModel();

		// GET: Blog
		public ActionResult Index(int? page)
		{
			List<BlogViewModel> list = new List<BlogViewModel>();
			var a = blogService.GetAll();
			foreach (var i in a)
			{
				BlogViewModel bvm = new BlogViewModel();
				bvm.ne = i.ne;
				bvm.Des = i.Des;
				bvm.BlogId = i.BlogId;
				bvm.NbrLike = i.NbrLike;
				bvm.NbrComment = i.NbrComment;
				bvm.Titre = i.Titre;
				bvm.Contenu = i.Contenu;
				bvm.Photo = i.Photo;
				bvm.DatePost = i.DatePost;
				list.Add(bvm);
			}
			
			return View(list.ToList().ToPagedList(page ?? 1,3));
		}
		public List<CommentViewModel> Affiche(int id)
		{
			BlogService blogService = new BlogService();
			BlogViewModel bvm = new BlogViewModel();
			String p = "";
			User u = new User();
			UserService userService = new UserService();
			foreach (User i in userService.GetAll())
			{
				if (i.UserName.Equals(User.Identity.Name))
				{
					p = i.Photo;
				}
			}
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
					cvm.Photoc = p;
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
					bvm.Des = i.Des;
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
		public ActionResult Create(BlogViewModel bvm, HttpPostedFileBase Image)
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
			var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
			Image.SaveAs(path);
			DateTime now = DateTime.Now;
			Blog b = new Blog();
			b.ne = e;
			b.UserId = User.Identity.GetUserId<int>();
			b.Contenu = bvm.Contenu;
			b.Photo = Image.FileName;
			b.Des = bvm.Des; 
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

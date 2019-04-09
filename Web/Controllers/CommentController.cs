using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Entities;
using Service.IServices;
using Service.Services;
using Web.Models;

namespace Web.Controllers
{
	public class CommentController : Controller
	{
		CommentService commentService = new CommentService();
		CommentViewModel cvm = new CommentViewModel();
		ICommentService Icm;
		// GET: Comment
		public ActionResult Index()
		{
			return View();
		}
		public ActionResult ComBlog(int id)
		{
			CommentService commentService = new CommentService();
			CommentViewModel cvm = new CommentViewModel();
			List<CommentViewModel> lcmv = new List<CommentViewModel>();
			List<Comment> lc = new List<Comment>();
			lc = commentService.BlogComment(id);
			Icm = new CommentService();
			foreach (var i in lc)
			{
				cvm.Contenu = i.Contenu;
				lcmv.Add(cvm);
			}
			ViewBag.lcc = lcmv;
			return View();

		}

		// GET: Comment/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: Comment/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Comment/Create
		[HttpPost]
		public ActionResult Create(int id, CommentViewModel cvm)
		{
			DateTime nowc = DateTime.Now;
			int idUser = 0;
			String e = ""; 
			String p = ""; 
			User u = new User();
			UserService userService = new UserService();
			foreach (User i in userService.GetAll())
			{
				if (i.UserName.Equals(User.Identity.Name))
				{
					idUser = i.Id;
					e = i.FName;
					p = i.Photo;
					userService.Update(i);
					userService.Commit();
				}
			}
			Comment b = new Comment();
			b.nom = e;
			b.DateCom = nowc;
			b.UserId = idUser;
			b.BlogId = id;
			b.Photoc = p; 
			b.Contenu = cvm.Contenu;
			b.NbrLike = 0;
			commentService.Add(b);
			commentService.Commit();

			return RedirectToAction("../Blog/Details", new { id = b.BlogId });
		}

		// GET: Comment/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: Comment/Edit/5
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

		// GET: Comment/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: Comment/Delete/5
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

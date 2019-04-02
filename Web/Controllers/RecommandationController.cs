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
    public class RecommandationController : Controller
    {
        RecommandationService rs = new RecommandationService();
        // GET: Recommandation
        public ActionResult Index()
        {
            return View();
        }

        // GET: Recommandation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Recommandation/Create
        public ActionResult Create()
        {




            return View();
        }

        // POST: Recommandation/Create
        [HttpPost]
        public ActionResult Create(RecommendationViewModel rvm)
        {
            int i = 0;
            Recommendation r = new Recommendation();
            r.RecommendationId = rvm.RecommendationId;
            r.RecommendationNum = 1;
          //  r.Status = rvm.Status.;
            r.UserId = 1;
            r.EventId = 1;
            r.EmailParticipent = rvm.EmailParticipent;
            SendingMail("levio.lmp@gmail.com", r.EmailParticipent, "Request levio", "we accept with enevt ");
            rs.Add(r);
            rs.Commit();

            return View();

        }

        public ActionResult Createref(RecommendationViewModel rvm)
        {
            int i = 0;
            Recommendation r = new Recommendation();
            r.RecommendationId = rvm.RecommendationId;
            r.RecommendationNum = 0;
            //  r.Status = rvm.Status.;
            r.UserId = 1;
            r.EventId = 1;
            r.EmailParticipent = rvm.EmailParticipent;
            SendingMail("levio.lmp@gmail.com", r.EmailParticipent, "Request levio", "we reff with enevt ");
            rs.Add(r);
            rs.Commit();

            return View();

        }

        public void SendingMail(string From, string To, string Subject, string Body)
        {
            MailMessage mail = new MailMessage(From, To, Subject, Body);
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("levio.lmp@gmail.com", "eudfdldhubmzuscf");
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }



        // GET: Recommandation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Recommandation/Edit/5
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

        // GET: Recommandation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Recommandation/Delete/5
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

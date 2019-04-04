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
        public ActionResult Index(int id)
        {


            List<RecommendationViewModel> list = new List<RecommendationViewModel>();
            var r = rs.GetAll();
            foreach (var i in r)
            {
                RecommendationViewModel recommendationModel = new RecommendationViewModel();
                if (i.EventId == id)
                {
                    recommendationModel.EmailParticipent = i.EmailParticipent;
                    recommendationModel.Nom = i.Nom;
                    recommendationModel.Prenom = i.Prenom;
                    list.Add(recommendationModel);

                }

            }
            return View(list);
        }

        // GET: Recommandation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Recommandation/Create
        public ActionResult Create(int id, RecommendationViewModel rvm)
        {

            int i = 0;
            Recommendation r = new Recommendation();
            r.RecommendationId = rvm.RecommendationId;
            r.RecommendationNum = 1;
            //  r.Status = rvm.Status.;
            r.UserId = 1;
            r.EventId = rvm.EventId = id;
            r.Nom = rvm.Nom;
            r.Prenom = rvm.Prenom;
            r.EmailParticipent = rvm.EmailParticipent;
          
            rs.Add(r);
            rs.Commit();
            return View(rvm);

        }
        // POST: Recommandation/Create
        [HttpPost]
        public ActionResult Create(RecommendationViewModel rvm,int id)
        {
            int i = 0;
            Recommendation r = new Recommendation();
            r.RecommendationId = rvm.RecommendationId;
            r.RecommendationNum = 1;
          //  r.Status = rvm.Status.;
            r.UserId = 1;
            r.EventId = rvm.EventId = id;
            r.Nom = rvm.Nom;
            r.Prenom = rvm.Prenom;
            r.EmailParticipent = rvm.EmailParticipent;
            SendingMail("levio.lmp@gmail.com", r.EmailParticipent, "Request levio", "we accept with enevt ");
            rs.Add(r);
            rs.Commit();

            return View(rvm);

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

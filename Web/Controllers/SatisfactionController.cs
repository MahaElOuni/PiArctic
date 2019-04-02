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
    public class SatisfactionController : Controller
    {
        SatisfactionService satisfactionService = new SatisfactionService();
        // GET: Satisfaction
        public ActionResult Index()
        {
            List<SatisfactionViewModel> list = new List<SatisfactionViewModel>();
            var r = satisfactionService.GetAll();
            foreach (var i in r)
            {
                SatisfactionViewModel satisfactionModel = new SatisfactionViewModel();


                    satisfactionModel.Contenu = i.Contenu;
                    satisfactionModel.DatePost = i.DatePost;
                    
                    list.Add(satisfactionModel);

                
            }
            return View(list);
        }

        // GET: Satisfaction/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Satisfaction/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Satisfaction/Create
        [HttpPost]
        public ActionResult Create(SatisfactionViewModel svm)
        {
            Satisfaction s = new Satisfaction();
            s.Contenu = svm.Contenu;
            s.DatePost = svm.DatePost;
            satisfactionService.Add(s);
            satisfactionService.Commit();


            return View();
            
        }

        // GET: Satisfaction/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Satisfaction/Edit/5
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

        // GET: Satisfaction/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Satisfaction/Delete/5
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

        public ActionResult StatRequest()
        {
            double aimee = 0;
            double naimepase = 0;
           
            int nbr = 0;

            SatisfactionViewModel r = new SatisfactionViewModel();
            foreach (var item in satisfactionService.GetAll())
            {
                if (item.statuss == 2) { aimee++; }
                else if (item.statuss == 1) { naimepase++; }
                
            }

            nbr = satisfactionService.GetAll().Count();

            r.aime = Math.Round((aimee / nbr) * 100);
            r.naimepas = Math.Round((naimepase / nbr) * 100);
           

            return View(r);
        }
    }
}

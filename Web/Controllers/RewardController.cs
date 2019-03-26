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
    public class RewardController : Controller
    {

        RewardService rewardService = new RewardService();
        // GET: Reward


      
        public ActionResult Index()
        {
            
            return View();
        }

        // GET: Reward/Details/5
        public ActionResult Details()
        {
            RewardViewModel rewardModel = new RewardViewModel();
            var rewards = rewardService.GetAll();
            foreach (var i in rewards)
            {
               

                rewardModel.Price1 = i.Price1;
                rewardModel.Price2 = i.Price2;
                rewardModel.Price3 = i.Price3;
                rewardModel.titre = i.titre;
                rewardModel.ListOrganisateur = i.ListOrganisateur;

                
            }
            return View(rewardModel);
        }

        // GET: Reward/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reward/Create
        [HttpPost]
        public ActionResult Create(RewardViewModel rvm)
        {
            Reward r = new Reward();

            r.IdReward = rvm.IdReward;
            r.Price1 = rvm.Price1;
            r.Price2 = rvm.Price2;
            r.Price3 = rvm.Price3;
            r.titre = rvm.titre;
            rewardService.Add(r);
            rewardService.Commit();


          
                return View();
            
        }

        // GET: Reward/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Reward/Edit/5
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

        // GET: Reward/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reward/Delete/5
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

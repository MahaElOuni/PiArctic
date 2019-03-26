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
        public ActionResult Details(int id)
        {
            return View();
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
            r.Price = rvm.Price;
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

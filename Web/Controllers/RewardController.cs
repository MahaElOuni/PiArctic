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
            List<RewardViewModel> list = new List<RewardViewModel>();
            var r = rewardService.GetAll();
            foreach (var i in r)
            {
                RewardViewModel rewardModel = new RewardViewModel();
                if (i.IdReward == 1)
                {

                    rewardModel.Price1 = i.Price1;
                    rewardModel.Price2 = i.Price2;
                    rewardModel.Price3 = i.Price3;
                    rewardModel.titre = i.titre;
                    list.Add(rewardModel);

                }
            }
            return View(list);
        }
        
        // GET: Reward/Details/5
        public ActionResult Details(int id)
        {
            RewardViewModel rewardModel = new RewardViewModel();
            var r = rewardService.GetAll();
            foreach (var i in r)
            {
                if (i.IdReward == id)
                {

                    rewardModel.Price1 = i.Price1;
                    rewardModel.Price2 = i.Price2;
                    rewardModel.Price3 = i.Price3;
                    rewardModel.titre = i.titre;
                    

                }
            }
            return View(rewardModel);
        }

        // GET: Reward/Create
        public ActionResult Create(int id,RewardViewModel rvm )
        {
            Reward r = new Reward();

            r.Eventid = rvm.Eventid = id;
            r.Price1 = rvm.Price1;
            r.Price2 = rvm.Price2;
            r.Price3 = rvm.Price3;
            r.titre = rvm.titre;
            rewardService.Add(r);
            rewardService.Commit();

            return View(rvm);
        }

        // POST: Reward/Create
        [HttpPost]
        public ActionResult Create(RewardViewModel rvm,int id  )
        {
            Reward r = new Reward();

            r.Eventid = rvm.Eventid=id;
            r.Price1 = rvm.Price1;
            r.Price2 = rvm.Price2;
            r.Price3 = rvm.Price3;
            r.titre = rvm.titre;
            rewardService.Add(r);
            rewardService.Commit();


          
                return View(rvm);
            
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
            RewardViewModel rewardModel = new RewardViewModel();
           
            Reward rp = rewardService.GetById(id);
            Reward r = new Reward();
            {
               
                   
                    r.Price1 = rp.Price1;
                    r.Price2 = rp.Price2;
                    r.Price3 = rp.Price3;
                    r.titre = rp.titre;
                    rewardService.Delete(rewardService.GetById(id));
                    rewardService.Commit();
                }
            return View(r);
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

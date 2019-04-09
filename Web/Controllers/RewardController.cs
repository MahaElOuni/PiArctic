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
        public ActionResult Index(int id)
        {
           
            List<RewardViewModel> list = new List<RewardViewModel>();
            var r = rewardService.GetAll();

            foreach (var i in r)
            {
                RewardViewModel rewardModel = new RewardViewModel();
                if (i.EventId==id)
                {
                    rewardModel.RewardId = i.RewardId;
                    rewardModel.EventId = i.EventId;
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
                if (i.RewardId == id)
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
        public ActionResult Create()
        {
            RewardViewModel evm = new RewardViewModel();
            UserService userService = new UserService();
            foreach (User i in userService.GetAll())
            {
                if (i.UserName.Equals(User.Identity.Name))
                {
                    evm.UserId = i.Id;
                    evm.UserEmail = i.Email;
                    evm.UserRole = i.Role;


                }
            }

            return View(evm);
        }

        // POST: Reward/Create
        [HttpPost]
        public ActionResult Create(RewardViewModel rvm,int id  )
        {
            Reward r = new Reward();
            int idUser = 0;
            User u = new User();
            UserService userService = new UserService();
            foreach (User i in userService.GetAll())
            {
                if (i.UserName.Equals(User.Identity.Name))
                {
                    idUser = i.Id;
                    i.Role = "Orgonizor";
                    userService.Update(i);
                    userService.Commit();

                }
            }
            r.UserId = idUser;
            r.EventId = rvm.EventId=id;
            r.Price1 = rvm.Price1;
            r.Price2 = rvm.Price2;
            r.Price3 = rvm.Price3;
            r.titre = rvm.titre;
            rewardService.Add(r);
            rewardService.Commit();
            

          
                return View(rvm);
            
        }

        // GET: Reward/Edit/5
        public ActionResult Edit()

        {
          

            return View();
        }

        // POST: Reward/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, RewardViewModel rw)
        {

            Reward r = rewardService.GetById(id);
           
            
            r.Price1 = rw.Price1;
            r.Price2 = rw.Price2;
            r.Price3 = rw.Price3;
            r.titre = rw.titre;
            rewardService.Update(r);
            rewardService.Commit();

            return View();

        }

        // GET: Reward/Delete/5
       
        public ActionResult Delete(int id)
        {
            rewardService.Delete(rewardService.GetById(id));
            rewardService.Commit();

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

using Domain.Entities;
using Service.IServices;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class FormController : Controller
    {
        IFormService Fs = new FormService();
        UserService Us = new UserService();
        EventService Es = new EventService();
        // GET: Form
        public ActionResult Index()
        {
            List<FormViewModel> lists = new List<FormViewModel>();
            foreach (var item in Fs.GetAll())
            {
                FormViewModel dvm = new FormViewModel();
                dvm.EventView.Title = item.Event.Title;
                dvm.UserModel.FName = item.User.FName;
                dvm.UserModel.LName = item.User.LName;
                dvm.Sex = (Web.Models.Sex)item.Sex;
                dvm.Age = item.Age;
                dvm.Profession = item.Profession;
                dvm.Mail = item.Mail;
                dvm.Countrie = (Web.Models.Countries)item.Countrie;
                dvm.Address = item.Address;
            }
            return View(lists);
        }



        [HttpPost]
        public ActionResult Index(string searchString, string id)
        {

            List<FormViewModel> lists = new List<FormViewModel>();
            foreach (var item in Fs.GetAll())
            {
                FormViewModel dvm = new FormViewModel();
                dvm.EventView.Title = item.Event.Title;
                dvm.UserModel.FName = item.User.FName;
                dvm.UserModel.LName = item.User.LName;
                dvm.Sex = (Web.Models.Sex)item.Sex;
                dvm.Age = item.Age;
                dvm.Profession = item.Profession;
                dvm.Mail = item.Mail;
                dvm.Countrie = (Web.Models.Countries)item.Countrie;
                dvm.Address = item.Address;

            }
            // return View(lists);
            if (!String.IsNullOrEmpty(searchString))
            {
                lists = lists.Where(m => m.EventView.Title.Contains(searchString)).ToList();
            }
            if (!String.IsNullOrEmpty(id.ToString()))
            {
                lists = lists.Where(m => m.UserModel.CIN == id).ToList();
            }

            return View(lists);
        }

        // GET: Form/Details/5
        public ActionResult Details(int id)
        {


            var form = Fs.GetById(id);


            FormViewModel fvm = new FormViewModel();
            fvm.EventView.Title = form.Event.Title;
            fvm.UserModel.FName = form.User.FName;
            fvm.UserModel.LName = form.User.LName;
            fvm.Sex = (Web.Models.Sex)form.Sex;
            fvm.Age = form.Age;
            fvm.Profession = form.Profession;
            fvm.Mail = form.Mail;
            fvm.Countrie = (Web.Models.Countries)form.Countrie;
            fvm.Address = form.Address;



            return View(fvm);

        }

        



        // GET: Form/Create
        
        public ActionResult Create()
        {
            var Event = Es.GetAll();
            List<EventViewModel> lbvm = new List<EventViewModel>();
            foreach (var i in Event)
            {
                EventViewModel eventModel = new EventViewModel();
                eventModel.EventId = i.EventId;
                eventModel.Title = i.Title;
                eventModel.Start = i.Start;
                eventModel.Description = i.Description;
                eventModel.Address = i.Address;
                eventModel.OrganizedBy = i.OrganizedBy;


                lbvm.Add(eventModel);

            }

            ViewData["Biblio"] = new SelectList(lbvm, "EventId", "EventId");
            return View();
        }




        // POST: Form/Create
        [HttpPost]
        public ActionResult Create(FormViewModel FVM, int idEvent, int idUser )
        {

            Form d = new Form() { Sex = (Domain.Entities.Sex)FVM.Sex, Countrie= (Domain.Entities.Countries)FVM.Countrie };

            //d.Event.Title =FVM.EventView.Title;
            //d.User.FName = FVM.UserModel.FName;
            //d.User.LName = FVM.UserModel.LName;

            d.Age = FVM.Age;
            d.Profession = FVM.Profession;
            d.Mail = FVM.Mail;
            d.Address = FVM.Address;

            d.Event =  new Event { EventId = FVM.EventId };

            Fs.Add(d);
            Fs.Commit();
            return RedirectToAction("Index");

        }

        // GET: Form/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Form/Edit/5
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

        // GET: Form/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Form/Delete/5
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

using Domain.Entities;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using System.Net.Mail;
using System.IO;
using System.Diagnostics;
using System.Configuration;
using Service.IServices;
using Stripe;

namespace Web.Controllers
{
    public class FormController : Controller
    {
        
        IEventService ES = new Service.Services.EventService();
        IFormService FS = new FormService();

        // GET: Form
        public ActionResult Index(string searchString, string searchString2)
        {
            var ListFilms = new List<FormViewModel>();
            var listFilmsDomain = FS.GetAll();
            String part = null;
            foreach (Form f in listFilmsDomain)
            {
                if (f.FormDate.AddDays(1).Equals(DateTime.Today))
                {
                    if (f.Participant == false)
                    {

                        FS.Delete(f);
                        FS.Commit();
                    }
                }
                else
                {
                    if (f.Participant == false)
                    {
                        part = "Waiting";
                    }
                    if (f.Participant == true)
                    {
                        part = "Participant";
                    }
                    ListFilms.Add(new FormViewModel()
                    {
                        FormId = f.FormId,
                        EventId = f.EventId,
                        FormDate = f.FormDate,
                        Pseudo = f.Pseudo,
                        Title = f.Title,
                        // Participant = f.Participant,
                        CIN = f.CIN,
                        Sex = (SexVM)f.Sex,
                        Age = f.Age,
                        par = part,
                        Profession = f.Profession,
                        Mail = f.Mail,
                        Countrie = f.Countrie,
                        Address = f.Address,
                        MethodeDePayemment = f.MethodeDePayemment

                    });
                }


            }

            /*    if (!String.IsNullOrEmpty(searchString))
                {
                    ListFilms = ListFilms.Where(m => m.Pseudo.Contains(searchString)).ToList();
                }*/
            //if (!String.IsNullOrEmpty(searchString2))
            //{
            //    ListFilms = ListFilms.Where(m => m.Nom.Contains(searchString2)).ToList();
            //}

            return View(ListFilms);
            //return View();
        }
        public ActionResult PartivipantEnAttente()
        {
            var ListFilms = new List<FormViewModel>();
            var listFilmsDomain = FS.GetAll();
            String part = null;
            foreach (Form f in listFilmsDomain)
            {
                if (f.Participant == false)
                {
                    if (f.FormDate.AddDays(1).Equals(DateTime.Today))
                    {


                        FS.Delete(f);
                        FS.Commit();

                    }
                    else
                    {

                        part = "en attente";

                        ListFilms.Add(new FormViewModel()
                        {
                            FormId = f.FormId,
                            EventId = f.EventId,
                            FormDate = f.FormDate,
                            Pseudo = f.Pseudo,
                            Title = f.Title,
                            // Participant = f.Participant,
                            CIN = f.CIN,
                            Sex = (SexVM)f.Sex,
                            Age = f.Age,
                            par = part,
                            Profession = f.Profession,
                            Mail = f.Mail,
                            Countrie = f.Countrie,
                            Address = f.Address,
                            MethodeDePayemment = f.MethodeDePayemment

                        });
                    }
                }
            }






            return View(ListFilms);
            //return View();
        }
        public ActionResult Participant()
        {
            var ListFilms = new List<FormViewModel>();
            var listFilmsDomain = FS.GetAll();
            String part = null;
            foreach (Form f in listFilmsDomain)
            {
                if (f.Participant == true)


                {

                    part = "Participée";

                    ListFilms.Add(new FormViewModel()
                    {
                        FormId = f.FormId,
                        EventId = f.EventId,
                        FormDate = f.FormDate,
                        Pseudo = f.Pseudo,
                        Title = f.Title,
                        // Participant = f.Participant,
                        CIN = f.CIN,
                        Sex = (SexVM)f.Sex,
                        Age = f.Age,
                        par = part,
                        Profession = f.Profession,
                        Mail = f.Mail,
                        Countrie = f.Countrie,
                        Address = f.Address,
                        MethodeDePayemment = f.MethodeDePayemment

                    });
                }
            }







            return View(ListFilms);
            //return View();
        }

        // GET: Form/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Form/Create
        public ActionResult Create()
        {
            var producers = ES.GetAll();
            ViewBag.myproducer =
                new SelectList(producers, "Title", "Title");
            return View();

        }



        // POST: Form/Create
        [HttpPost]
        public ActionResult Create(FormViewModel mm, HttpPostedFileBase f)
        {
            Domain.Entities.Event e = ES.Get(a => a.Title == mm.Title);

            if (!ModelState.IsValid || f == null || f.ContentLength == 0)
            {
                RedirectToAction("Create");
            }
            mm.Participant = false;//en attente
            if (mm.MethodeDePayemment.Equals(MethodeDePayemment.OnLine))
            {
                mm.Participant = true;
            }
            if (e.NumberPlaces <= e.NumberPlaceReserve)
            {
                //Response.Write("<script>alert('Your request has been sent')</script>");
                return RedirectToAction("full");
            }


            Form dvm = new Form
            {
                // EventId=e.EventId,
                Title = e.Title,
                EventId = e.EventId,

                FormDate = DateTime.Today,
                Pseudo = mm.Pseudo,

                CIN = mm.CIN,
                Sex = (Sex)mm.Sex,
                Age = mm.Age,
                Profession = mm.Profession,
                Mail = mm.Mail,
                Countrie = mm.Countrie,
                Address = mm.Address,
                Participant = mm.Participant,
                MethodeDePayemment = (MethodeDePayemment)mm.MethodeDePayemment,
                photos = "aaa",


            };
            //Event ev = ES.GetById(e.EventId);
            //ev.NumberPlaceReserve = ev.NumberPlaceReserve + 1;

            /*  var fileName = "";
              if (f.ContentLength > 0)
              {
                  fileName = Path.GetFileName(f.FileName);
                  var path = Path.Combine(Server.MapPath("~/Content/Upload/"), f.FileName);
                  f.SaveAs(path);
              }
              dvm.photos = f.FileName;*/


            FS.Add(dvm);
            FS.Commit();

            if (mm.MethodeDePayemment.Equals(MethodeDePayemment.OnLine))
            {
                SendMail(dvm.Mail);
                return RedirectToAction("Index3");
            }
            SendMailAtt(dvm.Mail);
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
        public ActionResult Participer(int id)
        {
            Form f = FS.GetById(id);
            f.Participant = true;
            FS.Update(f);
            FS.Commit();

            return RedirectToAction("PartivipantEnAttente");
        }
        // GET: Form/Delete/5
        public ActionResult Delete(int id)
        {

            Form f = FS.GetById(id);
            FS.Delete(f);
            FS.Commit();

            return RedirectToAction("Index");


        }

        // POST: Form/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, FormViewModel c)
        {


            return RedirectToAction("Index");

        }

        public ActionResult Index2()
        {
            var stripePublishKey = ConfigurationManager.AppSettings["pk_test_yFYMtDKzGH2aZqo6S0g0YJTN002wivq7oZ"];
            ViewBag.StripePublishKey = stripePublishKey;
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Charge(ChargeViewModel chargeViewModel)
        {
            Debug.WriteLine(chargeViewModel.StripeEmail);
            Debug.WriteLine(chargeViewModel.StripeToken);

            return RedirectToAction("Confirmation");
        }


        public ActionResult Confirmation()
        {
            //return RedirectToAction("Index"); 
            return View();
        }
        public ActionResult full()
        {
            //return RedirectToAction("Index"); 
            return View();
        }


        public ActionResult Custom()
        {
            string stripePublishableKey = ConfigurationManager.AppSettings["stripePublishableKey"];
            var model = new CustomViewModel() { StripePublishableKey = stripePublishableKey, PaymentForHidden = true };
            return View(model);
        }


        
        public ActionResult Charge(string stripeEmail, string stripeToken)
        {
            var customers = new CustomerService();
            var charges = new ChargeService();

            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                SourceToken = stripeToken
            });

            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = 500,
                Description = "Sample Charge",
                Currency = "usd",
                CustomerId = customer.Id
            });

            return RedirectToAction("Index");
        }



        public ActionResult Index3()
        {
            return View();
            return RedirectToAction("Confirmation");
        }

        public ActionResult Error()
        {
            return View();

        }

        public void SendMail(String mail)
        {


            MailMessage mailMessage = new MailMessage("souad.saidi.95@gmail.com", mail);
            mailMessage.Subject = "Participation succeeded";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = string.Format("<html><head></head><body>dear Mr/Mme </b> <br> Congratulation we are waiting for you, to pass an unforgettable time </body></html>");

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.EnableSsl = true;
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;

            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "souad.saidi.95@gmail.com",
                Password = "souadsaidi1995"
            };
            smtpClient.Send(mailMessage);


        }

        public void SendMailAtt(String mail)
        {


            MailMessage mailMessage = new MailMessage("souad.saidi.95@gmail.com", mail);
            mailMessage.Subject = "Waiting Event";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = string.Format("<html><head></head><body><b>dear Mr/Mme </b> <br>  Congratulation,  but you need to pay fees of participation befor 3 days </body></html>");

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.EnableSsl = true;
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;

            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "souad.saidi.95@gmail.com",
                Password = "souadsaidi1995"
            };
            smtpClient.Send(mailMessage);


        }

    }
}

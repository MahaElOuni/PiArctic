﻿using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Blog()
        {
            ViewBag.Message = "Blog page.";

            return View();
        }
        public ActionResult BlogDetail()
        {
            ViewBag.Message = "Blog Detail.";

            return View();
        }

        public ActionResult LogIn()
        {
            ViewBag.Message = "Blog Detail.";

            return View();
        }
        
    }
}
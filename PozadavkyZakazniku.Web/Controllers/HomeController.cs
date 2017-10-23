﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PozadavkyZakazniku.Web.Filters;

namespace PozadavkyZakazniku.Controllers
{
    public class HomeController : Controller
    {

        [GCAutorization(Roles = "user,admin")]
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
    }
}
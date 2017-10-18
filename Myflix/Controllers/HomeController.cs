using myflix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace myflix.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var entities = new myflixDBEntities();
            ViewBag.movies = entities.Movies.ToList();
            return View();
        }

        public ActionResult Watch(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.uid = id;
           

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
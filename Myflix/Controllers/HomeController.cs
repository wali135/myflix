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
            try
            {
                ViewBag.movies = entities.Movies.ToList();
            } 
            catch(Exception ex)
            {
                return View("Entity Error="+ex.Message);
            }
            return View();
        }

        public ActionResult Watch(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.uid = id;
            var entities = new myflixDBEntities();
            var result = entities.Movies.SingleOrDefault(obj => obj.uid == id);
            if (result != null)
            {
                ViewBag.Title = ">"+result.Name;
                result.Views = result.Views + 1;
                entities.SaveChanges();
            }


            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
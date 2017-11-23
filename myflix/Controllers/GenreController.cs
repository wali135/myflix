using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using myflix.Models;

namespace myflix.Controllers
{
    public class GenreController : Controller
    {
        private myflixDBEntities db = new myflixDBEntities();

        
        public ActionResult Comedy()
        {
            var entities = new myflixDBEntities();
            try
            {
                ViewBag.movies = entities.Movies.SqlQuery("Select TOP 8 * from movies where genre1='comedy' ORDER BY views DESC");
            }
            catch (Exception ex)
            {
                return View("Entity Error=" + ex.Message);
            }
            return View();
        }

        public ActionResult Action()
        {
            var entities = new myflixDBEntities();
            try
            {
                ViewBag.movies = entities.Movies.SqlQuery("Select TOP 8 * from movies where genre1='action' ORDER BY views DESC");
            }
            catch (Exception ex)
            {
                return View("Entity Error=" + ex.Message);
            }
            return View();
        }
        public ActionResult Drama()
        {
            var entities = new myflixDBEntities();
            try
            {
                ViewBag.movies = entities.Movies.SqlQuery("Select TOP 8 * from movies where genre1='drama' ORDER BY views DESC");
            }
            catch (Exception ex)
            {
                return View("Entity Error=" + ex.Message);
            }
            return View();
        }


    }
}

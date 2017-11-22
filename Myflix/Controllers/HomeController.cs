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
                ViewBag.movies = entities.Movies.SqlQuery("Select TOP 8 * from movies ORDER BY NEWID()");
                ViewBag.comedy = entities.Movies.SqlQuery("Select TOP 8 * from movies where genre1='comedy' OR genre2='comedy' OR genre3='comedy' ORDER BY views DESC");
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

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add([Bind(Include =
"uid,imid,name,language,year,Genre1, Genre2, Genre3,Resolution,Image,cast1,cast2,cast3,cast4,cast5")] Movy movy)
        {
            myflixDBEntities entities = new myflixDBEntities();
            
                if (ModelState.IsValid)
                {
                    movy.Views = 0;
                    movy.Image = movy.Name + movy.Year + ".jpg";
                try
                {
                    entities.Movies.Add(movy);
                    entities.SaveChanges();
                }
                catch (Exception ex)
                {
                    return View("Entity Error=" + ex.Message);
                }
                return RedirectToAction("Add");
                }
            
           

            return View(movy);

        }

       
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AOLHack.Site.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult PlayNext()
        {
            return Json(new { success = false });
        }

        public ActionResult Index()
        {
            ViewBag.VideoTitle = "Kardashians release most over-the-top Christmas card yet";
            //StateAgent.CurrentLocation.CurrentlyPlayed 
            return View(StateAgent.CurrentLocation.CurrentlyPlayed);
        }

        // GET: /Home/Curator
        public ActionResult Curator()
        {
            return View();
        }
    }
}

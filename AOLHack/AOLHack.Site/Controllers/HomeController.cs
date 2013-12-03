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

        public ActionResult Index()
        {
            ViewBag.VideoTitle = "Kardashians release most over-the-top Christmas card yet";

            return View();
        }

        // GET: /Home/Curator
        public ActionResult Curator()
        {
            return View();
        }
    }
}

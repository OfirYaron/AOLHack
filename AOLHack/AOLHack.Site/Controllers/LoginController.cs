using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AOLHack.Site.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        [HttpGet]
        public ActionResult Index(string location)
        {
            return View(location as object);
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            return View("Welcome");
        }

    }
}

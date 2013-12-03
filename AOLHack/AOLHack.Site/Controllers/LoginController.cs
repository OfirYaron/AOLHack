using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AOLHack.Domain;

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
        public ActionResult Index(FormCollection form)//FormCollection form)
        {
            var context = new AOLHackEntities();
            var loggedinUser = context.Users.Where(u => u.Email == form["email"]);


            StateAgent.CurrentViewer = loggedinUser as Viewer;
            return RedirectToAction("Curate", "View", null);
        }

    }
}

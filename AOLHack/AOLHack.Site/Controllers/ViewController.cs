using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AOLHack.Site.Controllers
{
    public class ViewController : Controller
    {
        //
        // GET: /View/

        public ActionResult Curator()
        {
            return View();
        }

        public ActionResult Watch()
        {
            return View();
        }

        public ActionResult Index()
        {
            StateAgent.Locations.FirstOrDefault(l => l.Viewers.Contains(StateAgent.CurrentViewer));
            return View();
        }

    }
}

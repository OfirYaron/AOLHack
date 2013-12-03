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

        public ActionResult Curate()
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

        public ActionResult Like()
        {
            if (StateAgent.CurrentLocation== null)
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);

            StateAgent.CurrentLocation.CurrentlyPlayed.CurrentRating++;
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Dislike()
        {
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RequestSkip()
        {
            if (StateAgent.CurrentLocation == null)
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);

            StateAgent.CurrentLocation.CurrentlyPlayed.SkipRequests++;
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

    }
}

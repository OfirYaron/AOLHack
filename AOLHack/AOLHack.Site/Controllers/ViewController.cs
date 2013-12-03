using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.IO;

namespace AOLHack.Site.Controllers
{
    public class ViewController : Controller
    {
        //
        // GET: /View/
        public WebRequest OriginalRequest { get; set; }
        public WebResponse Response { get; set; }
        public HttpWebRequest HttpRequest { get { return (HttpWebRequest)OriginalRequest; } }
        public HttpWebResponse HttpResponse { get { return (HttpWebResponse)Response; } }

        public ActionResult Curator()
        {/*
            OriginalRequest = WebRequest.Create("http://api.on.aol.com/v2.0/channel/get/0?json=true&showRenditions=true");
            OriginalRequest.Method = "POST";
            OriginalRequest.ContentType = "JSON";
            OriginalRequest.ContentLength = ("json=true&showRenditions=true").Length;

            using (var requestWriter = new StreamWriter(OriginalRequest.GetRequestStream()))
            {
                requestWriter.Write("");
                requestWriter.Close();
            }

            Response = OriginalRequest.GetResponse();
            */
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

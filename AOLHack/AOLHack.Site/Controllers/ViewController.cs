using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.IO;
using AOLHack.Site.Code;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AOLHack.Site.Controllers
{
    public class ViewController : Controller
    {
        //
        // GET: /View/
        public ActionResult Curator()
        {
            string response = WebHelper.GetWebResponse("http://api.on.aol.com/v2.0/channel/get/0?json=true&showRenditions=true");

            //m["Slots"]["Videos"]

            JObject m = JsonConvert.DeserializeObject<JObject>(response);
            Dictionary<string, string> results = new Dictionary<string, string>();

            foreach (JObject slot in m["Slots"]["Slots"])
            {
                string slotData = JsonConvert.SerializeObject(slot["Type"]);

                if (slotData == "\"Slider\"")
                {
                    results.Add(JsonConvert.SerializeObject(slot["Thumbnail"]["url"]), JsonConvert.SerializeObject(slot["ObjectId"]));
                }
            }

            return View(results);
        }

        public ActionResult Watch()
        {
            Video v = new Video()
            {
                Id=1,
                Thumbnail="https://thumbnails.5min.com/10360697/518034831_c.jpg"
            };
            return View(v);
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

        public ActionResult PickVideo(int videoId)
        {
            StateAgent.CurrentLocation.PickVideo(videoId);
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

    }
}

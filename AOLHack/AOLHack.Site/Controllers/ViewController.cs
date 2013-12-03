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

        public ActionResult Watch(int id)
        {
            
            Video v1 = new Video()
            {
                Id=1,
                Thumbnail = "/Content/images/curator_03.png"
            };
            Video v2= new Video()
            {
                Id=2,
                Thumbnail = "/Content/images/curator_10.png"
            };
            Video v3 = new Video()
            {
                Id=3,
                Thumbnail = "/Content/images/curator_13.png"
            };
            Video v4 = new Video()
            {
                Id=4,
                Thumbnail = "/Content/images/curator_05.png"
            };
            Video v5 = new Video()
            {
                Id=5,
                Thumbnail = "/Content/images/curator_21.png"
            };

            List<Video> list = new List<Video>();
            list.Add(v1);
            list.Add(v2);
            list.Add(v3);
            list.Add(v4);
            list.Add(v5);

            ViewBag.LocationBackground = "/Content/images/mobile_03.png";

            return View(list);
        }

        public ActionResult Index(bool afsp = false)
        {
            if (afsp)
            {
                if (StateAgent.CurrentViewer == null)
                    return RedirectToAction("Index", "Login");
                ActiveLocation location = StateAgent.Locations.FirstOrDefault(l => l.Viewers.Contains(StateAgent.CurrentViewer));
                return Watch(location.Id);
            }

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

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
            StateAgent.CurrentLocation.PlayNext();
            var video = StateAgent.CurrentLocation.CurrentlyPlayed;
            return Json(new { success = true, videoId=video.Id });
        }

        public ActionResult GetSocialMeta()
        {
            int rating = StateAgent.CurrentLocation.CurrentlyPlayed.CurrentRating;
            int skipRequests = StateAgent.CurrentLocation.CurrentlyPlayed.SkipRequests;
            int users = StateAgent.CurrentLocation.Viewers.Count;
            int skipPercent = 100 / users * skipRequests;
            int[] playlist = StateAgent.CurrentLocation.Playlist.Select(p => p.Id).ToArray();
            int[] userIds = new[] { 1, 4, 6, 7 };

            return Json(new { 
                success = true, 
                rating = rating, 
                skipRequests = skipRequests, 
                skip = skipPercent, 
                userIds = userIds, 
                playlist = playlist });

        }

        public ActionResult Index()
        {
            ViewBag.VideoTitle = "Kardashians release most over-the-top Christmas card yet";
            //StateAgent.CurrentLocation.CurrentlyPlayed 
            var current = StateAgent.CurrentLocation.CurrentlyPlayed;
            return View(current);
        }

        // GET: /Home/Curator
        public ActionResult Curator()
        {
            return View();
        }
    }
}

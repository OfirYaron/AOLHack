﻿using System;
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
        public ActionResult Index(int locationId)
        {
            return View(locationId);
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)//FormCollection form)
        {
            var context = new AOLHackEntities();
            var users = context.Users.ToList();
            var loggedinUser = users.FirstOrDefault(u => u.Email == form["email"]);

            var selectedlocation = StateAgent.Locations.FirstOrDefault(l => l.Id == int.Parse(form["locationId"]));

            if ((loggedinUser == null) || (selectedlocation == null))
            {
                // sign up in future
                //return ToString login
                return RedirectToAction("Index", new { locationId = int.Parse(form["locationId"]) });
            }

            StateAgent.CurrentViewer = new Viewer(loggedinUser);
            selectedlocation.JoinIn();

            return RedirectToAction("Curator", "View", new { id = int.Parse(form["locationId"]) });
        }

    }
}

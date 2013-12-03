using AOLHack.Domain;
using System;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AOLHack.Site
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {

        public void FacadeLocationInit()
        {
            var context = new AOLHackEntities();
            var carlsberg = context.Locations.ToList().FirstOrDefault(l => l.Title == "carlsberg");
            ActiveLocation activeLocation = new AOLHack.Site.ActiveLocation();
            activeLocation.Title = carlsberg.Title;
            StateAgent.Locations.Add(activeLocation);
        }

        public void FacadePlaylistInit()
        {
            var carlsberg = StateAgent.Locations[0];
            carlsberg.Playlist.Add(new Video() { Id = 518034831 });
            carlsberg.Playlist.Add(new Video() { Id = 518034832 });
            carlsberg.Playlist.Add(new Video() { Id = 518034830 });
            carlsberg.Playlist.Add(new Video() { Id = 518034831 });
            carlsberg.Playlist.Add(new Video() { Id = 518034832 });
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            RouteTable.Routes.MapRoute(
                "Home",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );

            //staticly create a 'carslberg' room for tests
            FacadeLocationInit();
            FacadePlaylistInit();
        }
    }
}
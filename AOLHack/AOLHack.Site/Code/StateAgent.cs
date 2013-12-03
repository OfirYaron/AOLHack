using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AOLHack.Site
{
    public static class StateAgent
    {   
        static StateAgent()
        {
            Locations = new List<ActiveLocation>();
        }
        public static IList<ActiveLocation> Locations { get; set; }

        public static Viewer CurrentViewer 
        {
            get
            {
                if (HttpContext.Current.Session["User"] != null)
                    return HttpContext.Current.Session["User"] as Viewer;
                else
                    return null;
            }
            set
            {
                HttpContext.Current.Session["User"] = value;
            }
        }

        public static ActiveLocation CurrentLocation
        {
            get
            {
                if (CurrentViewer != null)
                    return StateAgent.Locations.FirstOrDefault(l => l.Viewers.Contains(StateAgent.CurrentViewer));
                else
                    return null;
            }
        }
    }
}
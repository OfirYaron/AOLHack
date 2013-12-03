using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AOLHack.Site
{
    public enum ViewerType
    {
        Curator,
        Viewer
    }

    public class Viewer : AOLHack.Domain.User
    {
        public ViewerType Type { get; set; }

        public Viewer(AOLHack.Domain.User user)
        {
            this.Id = user.Id;
            this.Name = user.Name;
            this.Email = user.Email;
            this.Type = ViewerType.Viewer;
        }
    }
}
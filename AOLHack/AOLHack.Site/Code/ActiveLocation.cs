using AOLHack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AOLHack.Site
{

    public class ActiveLocation : Location
    {
        const int CURATORS = 3; 
        
        public IList<Viewer> Viewers { get; set; }
        public IList<Video> Playlist { get; set; }
        public Video CurrentlyPlayed { get; set; }

        public void JoinIn()
        {
            if (!Viewers.Contains(StateAgent.CurrentViewer))
            {
                if ((Viewers.Count(v => v.Type == ViewerType.Curator) < CURATORS) && (Playlist.Count < CURATORS * 2))
                    StateAgent.CurrentViewer.Type = ViewerType.Curator;

                Viewers.Add(StateAgent.CurrentViewer);
            }
        }

        public void Leave()
        {
            if (Viewers.Contains(StateAgent.CurrentViewer))
                Viewers.Remove(StateAgent.CurrentViewer);
        }

        public void PickVideo(int videoId)
        {
            //API CALL
            if (Viewers.Contains(StateAgent.CurrentViewer) && StateAgent.CurrentViewer.Type == ViewerType.Curator)
                Playlist.Add(new Video()
                {
                    Id = videoId
                });
        }
    }
}
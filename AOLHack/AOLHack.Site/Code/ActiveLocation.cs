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
        private Video _current;

        public ActiveLocation()
        {
            Viewers = new List<Viewer>();
            Playlist = new List<Video>();
        }

        public void PlayNext()
        {
            _current = Playlist.First();
            Playlist.Remove(_current);
        }

        public IList<Viewer> Viewers { get; set; }
        public IList<Video> Playlist { get; set; }
        public Video CurrentlyPlayed 
        {
            get
            {
                if ((_current == null) && (Playlist.Count > 0))
                {
                    PlayNext();

                    return _current;
                }
                else if (_current != null)
                {
                    return _current;
                }
                return null;
            }
        }

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
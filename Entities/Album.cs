using System;
using System.Collections.Generic;

namespace MusicStoreWebApp.Entities
{
    public partial class Album
    {
        public Album()
        {
            Track = new HashSet<Track>();
        }

        public long AlbumId { get; set; }
        public long ArtistId { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Track> Track { get; set; }
        public virtual Artist Artist { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStoreWebApp.ViewModels.MusicStore
{
    public class MusicTrack
    {       
        public long TrackId { get; set; }
        public string TrackName { get; set; }
        
        public string Artist { get; set; }
        
        public string Album { get; set; }
        
        public bool InCart { get; set; }        
    }
}

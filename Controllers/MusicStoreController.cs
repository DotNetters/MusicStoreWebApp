using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using MusicStoreWebApp.Entities;
using MusicStoreWebApp.ViewModels.MusicStore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicStoreWebApp.Controllers
{
    public class MusicStoreController : Controller
    {
        public MusicStoreController(ChinookDbContext dbContext)
        {
            DbContext = dbContext;
        }
        
        protected ChinookDbContext DbContext { get; private set; }
        
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.Tracks = DbContext.Track.Select(t => new MusicTrack 
            {
                Artist = t.Album.Artist.Name,  
                Album = t.Album.Title,
                TrackId = t.TrackId, 
                TrackName = t.Name
            });             
            return View();
        }
    }
}

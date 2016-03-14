using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using MusicStoreWebApp.Entities;
using MusicStoreWebApp.Services;
using MusicStoreWebApp.ViewModels.MusicStore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicStoreWebApp.Controllers
{
    public class MusicStoreController : Controller
    {
        public MusicStoreController(ChinookDbContext dbContext, IShoppingCartService shoppingCartService)
        {
            DbContext = dbContext;
            ShoppingCartService = shoppingCartService;            
        }      
        
        protected ChinookDbContext DbContext { get; private set; }
        
        protected IShoppingCartService ShoppingCartService { get; private set; }
        string _shopingCartId;
        string ShopingCartId
        {
           get 
           {
                if (_shopingCartId == null)
                {
                    var cookie = Request.Cookies["ShopingCartId"];
                    if (cookie.Count > 0)
                    {
                        _shopingCartId = cookie.FirstOrDefault();
                    }
                    else 
                    {
                        _shopingCartId = ShoppingCartService.NewCart();                        
                        Response.Cookies.Append("ShopingCartId", _shopingCartId);
                    }
                }
                return _shopingCartId;
           }
        }
        
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.Tracks = DbContext.Track.Select(t => new MusicTrack 
            {
                Artist = t.Album.Artist.Name,  
                Album = t.Album.Title,
                TrackId = t.TrackId, 
                TrackName = t.Name,
                InCart = ShoppingCartService.HasItem(ShopingCartId, t.TrackId)
            });             
            return View();
        }
        
        public IActionResult AddToCart(long id)
        {           
            ShoppingCartService.AddItem(ShopingCartId, id);
            
            return RedirectToAction("Index");
        }
        
        public IActionResult RemoveFromCart(long id)
        {
            ShoppingCartService.RemoveItem(ShopingCartId, id);
            
            return RedirectToAction("Index");
        }
        
    }
}

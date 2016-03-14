using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStoreWebApp.Services
{
    public interface IShoppingCartService
    {
        string NewCart();
        
        IQueryable<long> GetItems(string cartId);
        
        bool HasItem(string cartId, long itemId);

        void AddItem(string cartId, long itemId);

        void RemoveItem(string cartId, long itemId);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;

namespace MusicStoreWebApp.Services
{
    public class MemoryStoredShoppingCartService: IShoppingCartService
    {
        //TODO: Usar ConcurentDiccionary 
        Dictionary<string, IList<long>> storage = new Dictionary<string, IList<long>>();       
              
        public string NewCart()
        {
            string cartId = Guid.NewGuid().ToString("N");
            storage.Add(cartId, new List<long>());
            return cartId;
        }

        public IQueryable<long> GetItems(string cartId)
        {
            IList<long> items;
            if (storage.TryGetValue(cartId, out items))
            {
                return items.AsQueryable();
            }
            else 
            {
                throw new InvalidOperationException($"No se ha encontrado el carrito con id={cartId}");
            }
        }

        public bool HasItem(string cartId, long itemId)
        {
            IList<long> items;
            if (storage.TryGetValue(cartId, out items))
            {
                return items.Contains(itemId);
            }
            else 
            {
                throw new InvalidOperationException($"No se ha encontrado el carrito con id={cartId}");
            }
        }

        public void AddItem(string cartId, long itemId)
        {
            IList<long> items;
            if (storage.TryGetValue(cartId, out items))
            {
                items.Add(itemId);
            }
            else 
            {
                throw new InvalidOperationException($"No se ha encontrado el carrito con id={cartId}");
            }
        }

        public void RemoveItem(string cartId, long itemId)
        {
            IList<long> items;
            if (storage.TryGetValue(cartId, out items))
            {
                items.Remove(itemId);
            }
            else 
            {
                throw new InvalidOperationException($"No se ha encontrado el carrito con id={cartId}");
            }
        }
    }
}

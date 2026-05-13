using Basket.Core.Entities;
using Basket.Core.Repositories;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Infrastructure.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _cache;

        public BasketRepository(IDistributedCache cache)
        {
             _cache = cache;
        }


        public async Task<ShoppingCart> GetBasket(string userName)
        {
            var basket = await _cache.GetStringAsync(userName);
            if (basket == null)
                return null;

            return JsonConvert.DeserializeObject<ShoppingCart>(basket);

        }

        public async Task DeleteBasket(string userName)
        {
            var basket = await GetBasket(userName);
            if (basket != null)
                await _cache.RemoveAsync(userName);

        }


        public async Task<ShoppingCart> UpdateBasket(ShoppingCart cart)
        {
           await _cache.SetStringAsync(cart.UserName, JsonConvert.SerializeObject(cart));
            return cart;
        }
    }
}

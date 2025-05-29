using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantsApp.Domain.Models;

namespace RestaurantsApp.Domain.ReposotryAbstractions
{
    public interface IRestaurantReposotry
    {
        public Task<IEnumerable<Restaurant>> GetRestaurantsAsync();
        public Task<Restaurant> GetRestaurantByIdAsync(Guid Id);
        public Task<Guid> AddRestaurantAsync(Restaurant restaurant);
        public Task<bool> UpdateRestaurantAsync(Guid Id, Restaurant NewRestaurantData);
        public Task<bool> DeleteRestaurantAsync(Guid Id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantsApp.Domain.Models;

namespace RestaurantsApp.Domain.ReposotryAbstractions
{
    public interface IDishReposotry
    {
        public Task<IEnumerable<Dish>> GetDishesAsync();
        public Task<Dish> GetDishByIdAsync(Guid Id);
        public Task<Guid> AddDishAsync(Dish dish);
        public Task UpdateDishAsync(Guid Id, Dish NewDishData);
        public Task DeleteDishAsync(Guid Id);
    }
}

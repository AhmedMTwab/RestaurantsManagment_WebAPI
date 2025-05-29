using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantsApp.Domain.Models;
using RestaurantsApp.Domain.ReposotryAbstractions;
using RestaurantsApp.Infrastructure.Context;

namespace RestaurantsApp.Infrastructure.Repositories
{
    internal class RestaurantRepository(RestaurantAppDbContext context) : IRestaurantReposotry
    {
        public async Task<Guid> AddRestaurantAsync(Restaurant restaurant)
        {
            context.restaurants.Add(restaurant);
            await context.SaveChangesAsync();
            return restaurant.Id;
        }

        public async Task<bool> DeleteRestaurantAsync(Guid Id)
        {
            var restaurant=await GetRestaurantByIdAsync(Id);
            if (restaurant is null)
            {
                return false;
            }
            context.restaurants.Remove(restaurant);
            await context.SaveChangesAsync();
            return true;

        }

        public async Task<Restaurant> GetRestaurantByIdAsync(Guid Id)
        {
            var restaurant =await  context.restaurants.Include(r=>r.Dishes).FirstOrDefaultAsync(r => r.Id == Id);
            return restaurant;
        }

        public async Task<IEnumerable<Restaurant>> GetRestaurantsAsync()
        {
            var restaurants =await context.restaurants.Include(r=>r.Dishes).ToListAsync();
            return restaurants;
        }

        public async Task<bool> UpdateRestaurantAsync(Guid Id, Restaurant NewRestaurantData)
        {
            var restaurant = await GetRestaurantByIdAsync(Id);
            if(restaurant is null)
            {
                return false;
            }
            restaurant.Name = NewRestaurantData.Name;
            restaurant.Address = NewRestaurantData.Address;
            restaurant.ContactNumber= NewRestaurantData.ContactNumber;
            restaurant.Description = NewRestaurantData.Description;
            restaurant.ContactEmail = NewRestaurantData.ContactEmail;
            restaurant.HasDelivery = NewRestaurantData.HasDelivery;
            restaurant.Type = NewRestaurantData.Type;
            if (NewRestaurantData.Address != null)
            {
                restaurant.Address.City = NewRestaurantData.Address.City;
                restaurant.Address.Country = NewRestaurantData.Address.Country;
                restaurant.Address.PostalCode = NewRestaurantData.Address.PostalCode;
                restaurant.Address.Street = NewRestaurantData.Address.Street;
            }
            context.Update(restaurant);
            await context.SaveChangesAsync();
            return true;
        }
    }
}

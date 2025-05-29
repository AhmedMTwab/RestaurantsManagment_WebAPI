using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using RestaurantsApp.Domain.Models;
namespace RestaurantsApp.Infrastructure.Context
{
    internal class RestaurantAppDbContext:DbContext
    {
        public RestaurantAppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Restaurant> restaurants { get; set; }
        public DbSet<Dish> dishes { get; set; }
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>().OwnsOne<Address>(d=>d.Address);
            modelBuilder.Entity<Restaurant>().HasMany<Dish>(d => d.Dishes).WithOne(r=>r.restaurant);

            base.OnModelCreating(modelBuilder);
        }
    }
}

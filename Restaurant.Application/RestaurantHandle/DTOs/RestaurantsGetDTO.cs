using RestaurantsApp.Application.DishHandle.DTOs;
using RestaurantsApp.Domain.Models;

namespace RestaurantsApp.Application.RestaurantHandle.DTOs
{
    public class RestaurantsGetDTO
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Type { get; set; } = default!;
        public bool HasDelivery { get; set; }

        public string? ContactEmail { get; set; }
        public string? ContactNumber { get; set; }

        public string? Street { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public  IEnumerable<DishesGetDTO>? Dishes { get; set; }
    }
}
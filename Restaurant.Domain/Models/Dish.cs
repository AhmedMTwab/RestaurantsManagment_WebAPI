using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsApp.Domain.Models
{
    public class Dish
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } =default!;
        public Decimal Price { get; set; }
        public Restaurant restaurant { get; set; }=default!;
    }
}

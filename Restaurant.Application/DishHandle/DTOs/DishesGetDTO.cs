namespace RestaurantsApp.Application.DishHandle.DTOs
{
    public class DishesGetDTO
    {
       
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public Decimal Price { get; set; }
        public string? Restaurat { get; set; }
    }
}
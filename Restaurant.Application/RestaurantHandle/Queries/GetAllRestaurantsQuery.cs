using MediatR;
using RestaurantsApp.Application.RestaurantHandle.DTOs;

namespace RestaurantsApp.Application.RestaurantHandle.Queries
{
    public class GetAllRestaurantsQuery:IRequest<IEnumerable<RestaurantsGetDTO>>
    {
    }
}
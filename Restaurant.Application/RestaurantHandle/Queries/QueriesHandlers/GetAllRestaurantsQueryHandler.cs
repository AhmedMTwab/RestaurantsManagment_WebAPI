using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RestaurantsApp.Application.RestaurantHandle.DTOs;
using RestaurantsApp.Domain.Models;
using RestaurantsApp.Domain.ReposotryAbstractions;

namespace RestaurantsApp.Application.RestaurantHandle.Queries.QueriesHandlers
{
    public class GetAllRestaurantsQueryHandler(ILogger<GetAllRestaurantsQueryHandler> logger, IRestaurantReposotry restaurantReposotry,IMapper mapper) : IRequestHandler<GetAllRestaurantsQuery, IEnumerable<RestaurantsGetDTO>>
    {

        public async Task<IEnumerable<RestaurantsGetDTO>> Handle(GetAllRestaurantsQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting All Restaurats");
            var Restaurants = await restaurantReposotry.GetRestaurantsAsync();
            var RestaurantDTO = mapper.Map<IEnumerable<RestaurantsGetDTO>>(Restaurants);
            return RestaurantDTO;
        }
    }
}

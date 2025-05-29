using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RestaurantsApp.Application.RestaurantHandle.DTOs;
using RestaurantsApp.Domain.ReposotryAbstractions;

namespace RestaurantsApp.Application.RestaurantHandle.Queries.QueriesHandlers
{
    internal class GetRestaurantByIdQueryHandler(ILogger<GetRestaurantByIdQueryHandler> logger,IMapper mapper,IRestaurantReposotry restaurantReposotry) : IRequestHandler<GetRestaurantByIdQuery, RestaurantsGetDTO>
    {
        public async Task<RestaurantsGetDTO> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting Restaurant by its id");
            var restaurant =await restaurantReposotry.GetRestaurantByIdAsync(request.Id);
            var restaurantDTO =mapper.Map<RestaurantsGetDTO>(restaurant);
            return restaurantDTO;
        }
    }
}

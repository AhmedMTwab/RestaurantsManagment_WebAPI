using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RestaurantsApp.Domain.Models;
using RestaurantsApp.Domain.ReposotryAbstractions;

namespace RestaurantsApp.Application.RestaurantHandle.Commands.CommandHandlers
{
    internal class UpdateRestaurantCommandHandler(ILogger<UpdateRestaurantCommandHandler> logger,IMapper mapper,IRestaurantReposotry restaurantReposotry) : IRequestHandler<UpdateRestaurantCommand,bool>
    {
        public async Task<bool> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
        {
            var restaurant = mapper.Map<Restaurant>(request);
            var result=await restaurantReposotry.UpdateRestaurantAsync(request.Id, restaurant);
            return result;
        }
    }
}

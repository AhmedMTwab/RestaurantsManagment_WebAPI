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
    internal class AddRestaurantCommandHandler(IRestaurantReposotry restaurantReposotry,IMapper mapper,ILogger<AddRestaurantCommandHandler> logger) : IRequestHandler<AddRestaurantCommand, Guid>
    {
        public Task<Guid> Handle(AddRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Adding new Restaurant");
            var newRestaurant = mapper.Map<Restaurant>(request);
            var newRestaurantId = restaurantReposotry.AddRestaurantAsync(newRestaurant);
            return newRestaurantId;
        }
    }
}

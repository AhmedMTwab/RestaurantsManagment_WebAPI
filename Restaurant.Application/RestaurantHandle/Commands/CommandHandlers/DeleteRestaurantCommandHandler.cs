using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using RestaurantsApp.Domain.ReposotryAbstractions;

namespace RestaurantsApp.Application.RestaurantHandle.Commands.CommandHandlers
{
    internal class DeleteRestaurantCommandHandler(ILogger<DeleteRestaurantCommandHandler> logger,IRestaurantReposotry restaurantReposotry) : IRequestHandler<DeleteRestaurantCommand,bool>
    {
        public async Task<bool> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            var Result=await restaurantReposotry.DeleteRestaurantAsync(request.Id);
            
            return Result;
        }
    }
}

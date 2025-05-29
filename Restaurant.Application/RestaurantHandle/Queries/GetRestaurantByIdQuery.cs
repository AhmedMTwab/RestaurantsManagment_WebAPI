using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RestaurantsApp.Application.RestaurantHandle.DTOs;

namespace RestaurantsApp.Application.RestaurantHandle.Queries
{
    public class GetRestaurantByIdQuery:IRequest<RestaurantsGetDTO>
    {
        public GetRestaurantByIdQuery(Guid id)
        {
            Id= id;
        }
        public Guid Id { get; set; }
    }
}

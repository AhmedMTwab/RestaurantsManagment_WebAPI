using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace RestaurantsApp.Application.RestaurantHandle.Commands
{
    public class DeleteRestaurantCommand:IRequest<bool>

    {
        public DeleteRestaurantCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}

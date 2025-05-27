using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using RestaurantsApp.Infrastructure.Context;

namespace RestaurantsApp.Infrastructure.InfrastructureContainers;

public static class InfrastructureContainer
{
    public static void AddInfrastructure(this IServiceCollection serviceCollection,IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("RestaurantsDb");
        serviceCollection.AddDbContext<RestaurantAppDbContext>(options =>
        options.UseSqlServer()
        );
    }
}

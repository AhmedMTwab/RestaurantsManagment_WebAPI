using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using RestaurantsApp.Domain.ReposotryAbstractions;
using RestaurantsApp.Infrastructure.Context;
using RestaurantsApp.Infrastructure.Repositories;

namespace RestaurantsApp.Infrastructure.InfrastructureContainers;

public static class InfrastructureDIContainer
{
    public static void AddInfrastructureDependancies(this IServiceCollection serviceCollection,IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("RestaurantsDb");
        serviceCollection.AddDbContext<RestaurantAppDbContext>(options =>
        options.UseSqlServer(connectionString)
        );
        serviceCollection.AddTransient<IRestaurantReposotry, RestaurantRepository>();
        
    }
}

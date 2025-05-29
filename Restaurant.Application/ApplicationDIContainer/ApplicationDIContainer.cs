using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RestaurantsApp.Application.ApplicationDIContainer
{
    public static class ApplicationDIContainer
    {
        public static void AddApplicationDependancies(this IServiceCollection serviceCollection,IConfiguration configuration)
        {
            serviceCollection.AddMediatR(cfc => cfc.RegisterServicesFromAssembly(typeof(ApplicationDIContainer).Assembly));
            serviceCollection.AddValidatorsFromAssembly(typeof(ApplicationDIContainer).Assembly,includeInternalTypes:true);
            serviceCollection.AddAutoMapper(typeof(ApplicationDIContainer).Assembly);

        }
    }
}

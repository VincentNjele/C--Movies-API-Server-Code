using Microsoft.Extensions.DependencyInjection;
using ServersideRepository.DAL.Repositories;
using ServersideServices.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServersideRepository.DAL.AddRepositories
{
   public static class AddRepositories
    {
        public static IServiceCollection AddAllRepositories(this IServiceCollection services)
        {

            services.AddSingleton<IService, ServiceRepository>();


            return services;
        }
    }
}

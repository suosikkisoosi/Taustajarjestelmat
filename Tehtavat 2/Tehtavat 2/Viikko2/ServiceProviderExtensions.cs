using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Viikko2.Models;
using Viikko2.Processors;

namespace Viikko2
{
    public static class IServiceProviderExtensions {

        public static void AddPlayerProcessor (this IServiceCollection services) {
            services.AddSingleton<PlayerProcessor> ();
        }

        public static void AddPlayerDatabase (this IServiceCollection services) {
            services.AddSingleton<IRepository<Player>, InMemoryRepository> ();
        }

    }
}

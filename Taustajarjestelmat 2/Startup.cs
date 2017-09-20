using System;
using System.Collections.Generic;
using System.Linq;
using Taustajarjestelmat_2.Processors;
using Taustajarjestelmat_2.Repositories;
using Taustajarjestelmat_2.Controllers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Taustajarjestelmat_2.Controllers;
using Taustajarjestelmat_2;

namespace Taustajarjestelmat_2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<PlayersProcessor>();
            services.AddSingleton<IPlayersRepository, PlayersInMemoryRepository>();
            services.AddSingleton<PlayersController>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseMvc();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consul;
using Gateway.WebApi.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace Gateway.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
{
    services.AddOcelot();
            //services.AddSingleton<Microsoft.Extensions.Hosting.IHostedService, ConsulHostedService>();
            //services.Configure<ConsulConfig>(Configuration.GetSection("ConsulConfig"));

            //services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(consulConfig =>
            //{
            //    var address = Configuration["ConsulConfig:Address"];
            //    consulConfig.Address = new Uri(address);
            //}));

           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
    app.UseRouting();
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
    await app.UseOcelot();
}
    }
}

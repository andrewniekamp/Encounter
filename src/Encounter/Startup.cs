using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Routing;
using System;
using Encounter.Services;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Encounter.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Encounter
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddEntityFramework()
                .AddDbContext<EncounterDbContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));

            services.AddIdentity<ApplicationUser, IdentityRole>(req =>
                {
                    req.Password.RequiredLength = 5;
                    req.Password.RequireNonAlphanumeric = false;
                    req.Password.RequireDigit = false;
                    req.Password.RequireLowercase = false;
                    req.Password.RequireUppercase = false;
                })
                .AddEntityFrameworkStores<EncounterDbContext>()
                .AddDefaultTokenProviders();

            services.AddSingleton(provider => Configuration);
            services.AddSingleton<IGreeter, Greeter>();
            services.AddScoped<IApplicationUserData, SqlApplicationUserData>();
            services.AddScoped<IPlayerData, SqlPlayerData>();
            services.AddScoped<IGameData, SqlGameData>();
            services.AddScoped<ICharacterData, SqlCharacterData>();
            services.AddScoped<IAbilityData, SqlAbilityData>();
            services.AddScoped<IEventData, SqlEventData>();
            services.AddScoped<IFoeData, SqlFoeData>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app, 
            IHostingEnvironment env, 
            ILoggerFactory loggerFactory,
            IGreeter greeter)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseFileServer();

            app.UseIdentity();

            app.UseMvc(ConfigureRoutes);

            app.Run(async (context) =>
            {
                var greeting = greeter.GetGreeting();
                await context.Response.WriteAsync(greeting);
            });
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("Default", "{controller=Account}/{action=Index}/{id?}");
        }
    }
}

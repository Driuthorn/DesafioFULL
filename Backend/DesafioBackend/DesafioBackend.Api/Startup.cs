using DesafioBackend.Api.Infrastructure.IoC;
using DesafioBackend.Data.Database.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace DesafioBackend.Api
{
    public class Startup
    {
        public Container _dependencyInjectionContainer { get; } = new Container();
        public Bootstrapper _bootstrapper { get; } = new Bootstrapper();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DesafioBackend", Version = "v1" });
            });

            _dependencyInjectionContainer.Options.AllowOverridingRegistrations = true;
            _dependencyInjectionContainer.Options.DefaultLifestyle = new AsyncScopedLifestyle();

            services.AddSimpleInjector(_dependencyInjectionContainer, options =>
            {
                options.AddAspNetCore()
                    .AddControllerActivation();

                options.AddLogging();
            });

            services.AddScoped<DesafioBackendContext>();
            services.AddSingleton(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            _bootstrapper.Inject(_dependencyInjectionContainer);
            app.UseSimpleInjector(_dependencyInjectionContainer);
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Desafio Backend");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute("default", "{controller}/{action}");
            });

            _dependencyInjectionContainer.Verify();
        }
    }
}

using Andy.X.SchemaHub.App.Extensions.DependencyInjection;
using Andy.X.SchemaHub.App.Handlers;
using Andy.X.SchemaHub.App.Middleware;
using Andy.X.SchemaHub.Core.Services.App;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Text.Json.Serialization;

namespace Andy.X.SchemaHub.App
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

            services.AddControllers();
            //.AddJsonOptions(opts =>
            //{
            //    opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            //});

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Andy X | SchemaHub",
                    Version = "v3",
                    Description = "Andy X is an open-source distributed streaming platform designed to deliver the best performance possible for high-performance data pipelines, streaming analytics, streaming between microservices and data integration.",
                    License = new OpenApiLicense() { Name = "Licensed under the Apache License 2.0", Url = new Uri("https://bit.ly/3DqVQbx") }

                });
            });


            services.AddAuthentication("Andy.X_Authorization")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("Andy.X_Authorization", null);


            services.AddConfigurations(Configuration);
            services.AddSerilogLoggingConfiguration(Configuration);
            services.AddSingleton<ApplicationService>();



            services.AddFactories();
            services.AddRepositories();
            services.AddServices();

            ApplicationService.TryCreateDataDirectory();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Andy X | SchemaHub v1"));
            }

            app.UseApplicationService(serviceProvider);

            app.UseMiddleware<LoggingMiddleware>();

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

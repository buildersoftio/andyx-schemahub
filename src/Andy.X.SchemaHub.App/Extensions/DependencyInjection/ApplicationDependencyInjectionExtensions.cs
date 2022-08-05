using Andy.X.SchemaHub.Core.Services.App;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Andy.X.SchemaHub.App.Extensions.DependencyInjection
{
    public static class ApplicationDependencyInjectionExtensions
    {
        public static void UseApplicationService(this IApplicationBuilder builder, IServiceProvider serviceProvider)
        {
            var appService = serviceProvider.GetRequiredService<ApplicationService>();
        }
    }
}

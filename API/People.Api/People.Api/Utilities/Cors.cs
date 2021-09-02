using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.Api.Utilities
{
    //In real world deployments, this would be locked down to specific domains.
    public static class Cors
    {
        public static void ConfigureCors(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddCors(options =>
            {
                
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        public static void UseOpenCors(this IApplicationBuilder app)
        {
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true));
        }
    }
}

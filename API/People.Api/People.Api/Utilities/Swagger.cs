using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.Api.Utilities
{
    /// <summary>
    /// Static Swagger configuration utilities.
    /// </summary>
    public static class Swagger
    {
        public static void ConfigureSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "People.Api V1");
            });
        }
    }
}

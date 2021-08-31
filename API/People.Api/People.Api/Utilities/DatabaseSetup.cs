using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using People.Api.Repositories.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.Api.Utilities
{
    public static class DatabaseSetup
    {
        public static void SetupDatabase(this IApplicationBuilder app)
        {
            using (IServiceScope serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                PersonContext context = serviceScope.ServiceProvider.GetRequiredService<PersonContext>();
                context.Database.EnsureCreated();
            }
        }
    }
}

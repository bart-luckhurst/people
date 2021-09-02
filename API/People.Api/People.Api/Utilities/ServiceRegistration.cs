using Microsoft.Extensions.DependencyInjection;
using People.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using People.Api.Repositories;
using People.Api.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;

namespace People.Api.Utilities
{
    /// <summary>
    /// Extension methods for registering services in Startup.cs.
    /// </summary>
    public static class ServiceRegistration
    {
        public static void AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IPersonService, PersonService>();
        }

        public static void AddRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IPersonRepository, PersonRepository>();
        }

        public static void AddContexts(this IServiceCollection serviceCollection,
            string connectionString)
        {
            serviceCollection.AddDbContext<PersonContext>(options =>
               options.UseSqlServer(connectionString));
        }
    }
}

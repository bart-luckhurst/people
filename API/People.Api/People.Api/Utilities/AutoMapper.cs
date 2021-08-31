using AutoMapper;
using People.Api.Entities;
using People.Api.Models;
using People.Api.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.Api.Utilities
{
    public static class AutoMapper
    {
        public static MapperConfiguration ConfigureAutoMapper()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(configurationExpression =>
            {
                configurationExpression.AddProfile<PersonProfile>();
            });
            return mapperConfiguration;
        }
    }
}

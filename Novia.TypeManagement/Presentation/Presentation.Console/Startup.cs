using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Novia.TypeManagement.Domain.Abstractions;
using Novia.TypeManagement.Infrastructure.Data.Ef;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Novia.TypeManagement.Presentation.Console
{
    using Type = Novia.TypeManagement.Domain.Entities.Type;

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            services
                .AddTransient<IType, Type>((context) =>
                {
                    Type entity = Type.CreateType("Empty", -1, -1, -1);
                    return entity;
                });
        }
    }
}

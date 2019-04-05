using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Novia.TypeManagement.Configuration;
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
            .AddJsonFile("appsettings.json").Build();
            ServiceContainerConfigurator.ConfigureServices(
            configuration.GetConnectionString("DefaultConnection"), services);
        }
    }
}
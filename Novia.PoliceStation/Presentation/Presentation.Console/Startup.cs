using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Novia.PoliceStationManagement.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace Novia.PoliceStationManagement.Presentation.Console
{
    using PoliceStation = Novia.PoliceStationManagement.Domain.Entities.PoliceStation;

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
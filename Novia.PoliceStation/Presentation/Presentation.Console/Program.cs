using Microsoft.Extensions.DependencyInjection;
using Novia.PoliceStationManagement.Domain.Abstractions;
using Novia.PoliceStationManagement.Domain.Entities;
using System;

namespace Novia.PoliceStationManagement.Presentation.Console
{
    using Console = System.Console;
    using PoliceStation = Novia.PoliceStationManagement.Domain.Entities.PoliceStation;
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // Dependency injection
            var serviceCollection = new ServiceCollection();

            var bootStrapper = new Startup();
            bootStrapper.ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            IPoliceStation PoliceStation = serviceProvider.GetService<IPoliceStation>();

            Console.ReadKey();
        }
    }
}

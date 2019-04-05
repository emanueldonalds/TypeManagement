using Microsoft.Extensions.DependencyInjection;
using Novia.EngineManagement.Domain.Abstractions;
using Novia.EngineManagement.Domain.Entities;
using System;

namespace Novia.EngineManagement.Presentation.Console
{
    using Console = System.Console;
    using Engine = Novia.EngineManagement.Domain.Entities.Engine;
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

            IEngine Engine = serviceProvider.GetService<IEngine>();

            Console.ReadKey();
        }
    }
}

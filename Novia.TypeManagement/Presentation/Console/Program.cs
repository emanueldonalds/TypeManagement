using Microsoft.Extensions.DependencyInjection;
using Novia.TypeManagement.Domain.Abstractions;
using Novia.TypeManagement.Domain.Entities;
using System;

namespace Novia.TypeManagement.Presentation.Console
{
    using Console = System.Console;
    using Type = Novia.TypeManagement.Domain.Entities.Type;
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

            IType type = serviceProvider.GetService<IType>();

            Console.ReadKey();
        }
    }
}

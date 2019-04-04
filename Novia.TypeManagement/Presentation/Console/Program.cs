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

            IEntity theEntity = new Type();

            Entity otherEntity = new Type();

            Console.Write("The transient value of the entity: ");

            Console.WriteLine(otherEntity.IsTransient().ToString());

            Console.ReadKey();
        }
    }
}

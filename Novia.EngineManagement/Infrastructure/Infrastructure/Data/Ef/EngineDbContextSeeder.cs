using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Novia.EngineManagement.Domain.Abstractions;
using Novia.EngineManagement.Domain.Entities;

namespace Novia.EngineManagement.Infrastructure.Data.Ef
{
    using Engine = Domain.Entities.Engine;
    public static class EngineDbContextSeeder
    {

        public static int SeedAsync(EngineDbContext context)
        {
            // Use the Migrate method to automatically create the database and migrat if needed
            context.Database.EnsureCreated();
            if (context.Engines.Count() == 0)
            {
                // we could also check for some specific instances and behave accordingly to the result.
                Engine firstEngine = new Engine
                {
                    Name = "Honda CR60",
                    Power = 210,
                    Volume = 1800,
                    Price = 8544,
                };
                Engine SecondEngine = new Engine
                {
                    Name = "Nissan XR22",
                    Power = 340,
                    Volume = 2200,
                    Price = 11999,
                };
                Engine thirdEngine = new Engine
                {
                    Name = "Lamborghini ABCDEFGH",
                    Power = 550,
                    Volume = 3500,
                    Price = 34000,
                };

                context.Engines.Add(firstEngine);
                context.Engines.Add(SecondEngine);
                context.Engines.Add(thirdEngine);

                return context.SaveChanges();
            }
            return 0;
        }
    }
}
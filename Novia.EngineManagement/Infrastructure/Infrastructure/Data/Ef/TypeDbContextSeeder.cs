using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Novia.TypeManagement.Domain.Abstractions;
using Novia.TypeManagement.Domain.Entities;

namespace Novia.TypeManagement.Infrastructure.Data.Ef
{
    using Type = Domain.Entities.Type;
    public static class TypeDbContextSeeder
    {

        public static int SeedAsync(TypeDbContext context)
        {
            // Use the Migrate method to automatically create the database and migrat if needed
            context.Database.EnsureCreated();
            if (context.Types.Count() == 0)
            {
                // we could also check for some specific instances and behave accordingly to the result.
                Type firstType = new Type
                {
                    Name = "Honda CR60",
                    Power = 210,
                    Volume = 1800,
                    Price = 8544,
                };
                Type SecondType = new Type
                {
                    Name = "Nissan XR22",
                    Power = 340,
                    Volume = 2200,
                    Price = 11999,
                };
                Type thirdType = new Type
                {
                    Name = "Lamborghini ABCDEFGH",
                    Power = 550,
                    Volume = 3500,
                    Price = 34000,
                };

                context.Types.Add(firstType);
                context.Types.Add(SecondType);
                context.Types.Add(thirdType);

                return context.SaveChanges();
            }
            return 0;
        }
    }
}
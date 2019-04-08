using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Novia.PoliceStationManagement.Domain.Abstractions;
using Novia.PoliceStationManagement.Domain.Entities;

namespace Novia.PoliceStationManagement.Infrastructure.Data.Ef
{
    using PoliceStation = Domain.Entities.PoliceStation;
    public static class PoliceStationManagementDbContextSeeder
    {

        public static int SeedAsync(PoliceStationManagementDbContext context)
        {
            // Use the Migrate method to automatically create the database and migrat if needed
            context.Database.EnsureCreated();
            if (context.PoliceStations.Count() == 0)
            {
                // we could also check for some specific instances and behave accordingly to the result.
                PoliceStation firstPoliceStation = new PoliceStation
                {
                    Name = "Honda CR60",
                    Power = 210,
                    Volume = 1800,
                    Price = 8544,
                };
                PoliceStation SecondPoliceStation = new PoliceStation
                {
                    Name = "Nissan XR22",
                    Power = 340,
                    Volume = 2200,
                    Price = 11999,
                };
                PoliceStation thirdPoliceStation = new PoliceStation
                {
                    Name = "Lamborghini ABCDEFGH",
                    Power = 550,
                    Volume = 3500,
                    Price = 34000,
                };

                context.PoliceStations.Add(firstPoliceStation);
                context.PoliceStations.Add(SecondPoliceStation);
                context.PoliceStations.Add(thirdPoliceStation);

                return context.SaveChanges();
            }
            return 0;
        }
    }
}
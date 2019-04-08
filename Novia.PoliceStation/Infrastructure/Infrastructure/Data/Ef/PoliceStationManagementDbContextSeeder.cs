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
                    Name = "Vasas Polis",
                    Workers = 34,
                    Address = "Wolffskavägen 33",
                    Chief = "Sauli Niinistö",
                };
                PoliceStation SecondPoliceStation = new PoliceStation
                {
                    Name = "Polisen i Åbo",
                    Workers = 56,
                    Address = "Åbovägen 5",
                    Chief = "Lennu",
                };
                PoliceStation thirdPoliceStation = new PoliceStation
                {
                    Name = "Helsingfors Polis",
                    Workers = 78,
                    Address = "Helsingforsgatan 422",
                    Chief = "Carl Gustav",
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
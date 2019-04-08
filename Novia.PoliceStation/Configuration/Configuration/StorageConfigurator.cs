using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Novia.PoliceStationManagement.Infrastructure.Data.Ef;
namespace Novia.PoliceStationManagement.Configuration
{
    public static class StorageConfigurator
    {
        static StorageConfigurator()
        {
            // This will only run once
        }
        static public void SeedDatabase(IServiceProvider services)
        {
            try
            {
                var context = services.GetRequiredService<PoliceStationManagementDbContext>();
                PoliceStationManagementDbContextSeeder.SeedAsync(context);
            }
            catch (Exception ex)
            {
                // here so that we can step debug and could add some semantic meaning to the exceptionand retrow it
            throw;
            }
        }
    }
}
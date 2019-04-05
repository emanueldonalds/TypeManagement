using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Novia.EngineManagement.Infrastructure.Data.Ef;
namespace Novia.EngineManagement.Configuration
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
                var context = services.GetRequiredService<EngineDbContext>();
                EngineDbContextSeeder.SeedAsync(context);
            }
            catch (Exception ex)
            {
                // here so that we can step debug and could add some semantic meaning to the exceptionand retrow it
            throw;
            }
        }
    }
}
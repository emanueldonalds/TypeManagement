using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Novia.TypeManagement.Infrastructure.Data.Ef;
namespace Novia.TypeManagement.Configuration
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
                var context = services.GetRequiredService<TypeDbContext>();
                TypeDbContextSeeder.SeedAsync(context);
            }
            catch (Exception ex)
            {
                // here so that we can step debug and could add some semantic meaning to the exceptionand retrow it
            throw;
            }
        }
    }
}
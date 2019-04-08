using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Novia.PoliceStationManagement.Infrastructure.Data.Ef
{
    public class DesignTimePoliceStationDbContextFactory :
    IDesignTimeDbContextFactory<PoliceStationManagementDbContext>
    {
        public PoliceStationManagementDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<PoliceStationManagementDbContext>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseSqlServer(connectionString);

            return new PoliceStationManagementDbContext(builder.Options);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Novia.PoliceStationManagement.Application;
using Novia.PoliceStationManagement.Application.Abstractions;
using Novia.PoliceStationManagement.Domain.Abstractions;
using Novia.PoliceStationManagement.Infrastructure.Data.Ef;
using Novia.PoliceStationManagement.Infrastructure.Data.Ef.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novia.PoliceStationManagement.Configuration
{
    using PoliceStation = Domain.Entities.PoliceStation;
    using PoliceStationManagement = Application.Services.PoliceStationManagement;

    static public class ServiceContainerConfigurator
    {
        static ServiceContainerConfigurator()
        {
        }

        static public void ConfigureServices(string connectionString, IServiceCollection services)
        {
            services.AddDbContext<PoliceStationManagementDbContext>(options =>
            options.UseSqlServer(connectionString))
            .AddTransient<EfPoliceStationManagementDbContext, PoliceStationManagementDbContext>()
            .AddTransient<IPoliceStationRepository, PoliceStationManagementRepository>()
            .AddTransient<IPoliceStationManagement, PoliceStationManagement>()
            .AddTransient<IPoliceStation, PoliceStation>((context) =>
            {
                PoliceStation entity = PoliceStation.CreatePoliceStation("Empty", -1, -1, -1);
                return entity;
            });
        }
    }
}

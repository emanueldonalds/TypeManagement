using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Novia.EngineManagement.Application;
using Novia.EngineManagement.Application.Abstractions;
using Novia.EngineManagement.Domain.Abstractions;
using Novia.EngineManagement.Infrastructure.Data.Ef;
using Novia.EngineManagement.Infrastructure.Data.Ef.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novia.EngineManagement.Configuration
{
    using Engine = Domain.Entities.Engine;
    using EngineManagement = Application.Services.EngineManagement;

    static public class ServiceContainerConfigurator
    {
        static ServiceContainerConfigurator()
        {
        }

        static public void ConfigureServices(string connectionString, IServiceCollection services)
        {
            services.AddDbContext<EngineDbContext>(options =>
            options.UseSqlServer(connectionString))
            .AddTransient<EfEngineDbContext, EngineDbContext>()
            .AddTransient<IEngineRepository, EngineRepository>()
            .AddTransient<IEngineManagement, EngineManagement>()
            .AddTransient<IEngine, Engine>((context) =>
            {
                Engine entity = Engine.CreateEngine("Empty", -1, -1, -1);
                return entity;
            });
        }
    }
}

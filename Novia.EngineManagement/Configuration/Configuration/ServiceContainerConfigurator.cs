using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Novia.TypeManagement.Application;
using Novia.TypeManagement.Application.Abstractions;
using Novia.TypeManagement.Domain.Abstractions;
using Novia.TypeManagement.Infrastructure.Data.Ef;
using Novia.TypeManagement.Infrastructure.Data.Ef.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novia.TypeManagement.Configuration
{
    using Type = Domain.Entities.Type;
    using TypeManagement = Application.Services.TypeManagement;

    static public class ServiceContainerConfigurator
    {
        static ServiceContainerConfigurator()
        {
        }

        static public void ConfigureServices(string connectionString, IServiceCollection services)
        {
            services.AddDbContext<TypeDbContext>(options =>
            options.UseSqlServer(connectionString))
            .AddTransient<EfTypeDbContext, TypeDbContext>()
            .AddTransient<ITypeRepository, TypeRepository>()
            .AddTransient<ITypeManagement, TypeManagement>()
            .AddTransient<IType, Type>((context) =>
            {
                Type entity = Type.CreateType("Empty", -1, -1, -1);
                return entity;
            });
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using Novia.TypeManagement.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novia.TypeManagement.Presentation.Console
{
    using Type = Novia.TypeManagement.Domain.Entities.Type;

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddTransient<IType, Type>((context) =>
                {
                    Type entity = Type.CreateType("Empty", -1, -1, -1);
                    return entity;
                });
        }
    }
}

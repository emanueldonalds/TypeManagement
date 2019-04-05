using Microsoft.EntityFrameworkCore;
using Novia.EngineManagement.Domain.Abstractions;
using Novia.EngineManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novia.EngineManagement.Infrastructure.Data.Ef
{
    using Engine = Novia.EngineManagement.Domain.Entities.Engine;
    public abstract class EfEngineDbContext : EfDbContext
    {
        public EfEngineDbContext(DbContextOptions options) : base(options)
        {
        }
        protected EfEngineDbContext()
        {
        }
        public abstract DbSet<Engine> Engines { get; set; }
    }
}
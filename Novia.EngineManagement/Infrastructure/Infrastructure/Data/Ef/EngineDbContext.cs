using Microsoft.EntityFrameworkCore;
using Novia.EngineManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novia.EngineManagement.Infrastructure.Data.Ef
{
    using Engine = Novia.EngineManagement.Domain.Entities.Engine;
    public class EngineDbContext : EfEngineDbContext
    {
        public EngineDbContext(DbContextOptions<EngineDbContext> options)
            : base(options)
        {

        }
        public override DbSet<Engine> Engines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Engine>();
        }

        public override int SaveChanges()
        {
            int result = base.SaveChanges();
            // dispatch events only if save was successful
            // Here we will have a event dispatcher later on
            return result;
        }
    }
}

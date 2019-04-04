using Microsoft.EntityFrameworkCore;
using Novia.TypeManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novia.TypeManagement.Infrastructure.Data.Ef
{
    using Type = Novia.TypeManagement.Domain.Entities.Type;
    public class TypeDbContext : EfTypeDbContext
    {
        public TypeDbContext(DbContextOptions<TypeDbContext> options)
            : base(options)
        {

        }
        public override DbSet<Type> Types { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Type>();
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

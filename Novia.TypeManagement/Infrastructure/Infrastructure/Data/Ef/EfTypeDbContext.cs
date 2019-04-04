using Microsoft.EntityFrameworkCore;
using Novia.TypeManagement.Domain.Abstractions;
using Novia.TypeManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novia.TypeManagement.Infrastructure.Data.Ef
{
    using Type = Novia.TypeManagement.Domain.Entities.Type;
    public abstract class EfTypeDbContext : EfDbContext
    {
        public EfTypeDbContext(DbContextOptions options) : base(options)
        {
        }
        protected EfTypeDbContext()
        {
        }
        public abstract DbSet<Type> Types { get; set; }
    }
}
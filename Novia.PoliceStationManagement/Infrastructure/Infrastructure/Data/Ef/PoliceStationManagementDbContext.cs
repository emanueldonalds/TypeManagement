using Microsoft.EntityFrameworkCore;
using Novia.PoliceStationManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novia.PoliceStationManagement.Infrastructure.Data.Ef
{
    using PoliceStation = Novia.PoliceStationManagement.Domain.Entities.PoliceStation;
    public class PoliceStationManagementDbContext : EfPoliceStationManagementDbContext
    {
        public PoliceStationManagementDbContext(DbContextOptions<PoliceStationManagementDbContext> options)
            : base(options)
        {

        }
        public override DbSet<PoliceStation> PoliceStations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PoliceStation>();
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

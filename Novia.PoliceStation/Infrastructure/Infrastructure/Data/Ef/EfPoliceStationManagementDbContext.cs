using Microsoft.EntityFrameworkCore;
using Novia.PoliceStationManagement.Domain.Abstractions;
using Novia.PoliceStationManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novia.PoliceStationManagement.Infrastructure.Data.Ef
{
    using PoliceStation = Novia.PoliceStationManagement.Domain.Entities.PoliceStation;
    public abstract class EfPoliceStationManagementDbContext : EfDbContext
    {
        public EfPoliceStationManagementDbContext(DbContextOptions options) : base(options)
        {
        }
        protected EfPoliceStationManagementDbContext()
        {
        }
        public abstract DbSet<PoliceStation> PoliceStations { get; set; }
    }
}
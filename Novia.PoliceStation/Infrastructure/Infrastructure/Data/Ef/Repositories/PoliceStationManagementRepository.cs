using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Novia.PoliceStationManagement.Domain.Abstractions;
using Novia.PoliceStationManagement.Domain.Entities;

namespace Novia.PoliceStationManagement.Infrastructure.Data.Ef.Repositories
{
    using PoliceStation = Domain.Entities.PoliceStation;

    public class PoliceStationManagementRepository : EfRepository<PoliceStationManagementDbContext, PoliceStation, IPoliceStation>, IPoliceStationRepository
    {

        public PoliceStationManagementRepository(PoliceStationManagementDbContext dbContext) : base(dbContext)
        {

        }
    }
}

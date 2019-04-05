using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Novia.EngineManagement.Domain.Abstractions;
using Novia.EngineManagement.Domain.Entities;

namespace Novia.EngineManagement.Infrastructure.Data.Ef.Repositories
{
    using Engine = Domain.Entities.Engine;

    public class EngineRepository : EfRepository<EngineDbContext, Engine, IEngine>, IEngineRepository
    {

        public EngineRepository(EngineDbContext dbContext) : base(dbContext)
        {

        }
    }
}

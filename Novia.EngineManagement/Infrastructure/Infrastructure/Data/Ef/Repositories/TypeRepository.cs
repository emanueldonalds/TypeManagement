using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Novia.TypeManagement.Domain.Abstractions;
using Novia.TypeManagement.Domain.Entities;

namespace Novia.TypeManagement.Infrastructure.Data.Ef.Repositories
{
    using Type = Domain.Entities.Type;

    public class TypeRepository : EfRepository<TypeDbContext, Type, IType>, ITypeRepository
    {

        public TypeRepository(TypeDbContext dbContext) : base(dbContext)
        {

        }
    }
}

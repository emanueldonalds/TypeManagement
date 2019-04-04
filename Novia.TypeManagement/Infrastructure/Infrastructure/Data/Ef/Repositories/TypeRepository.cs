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

    public class TypeRepository :
        EfRepository<TypeDbContext, Type>,
        ITypeRepository
    {

        public TypeRepository(TypeDbContext dbContext) : base(dbContext)
        {

        }

        public IType Add(IType entity)
        {
            return base.Add(entity as Type);
        }

        public override Type GetById(int id)
        {
            return mDbContext.Types
                .FirstOrDefault(g => g.Id == id) as Type;
        }
    }
}

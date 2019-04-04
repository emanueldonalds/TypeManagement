using System;
using System.Collections.Generic;
using System.Text;

namespace Novia.TypeManagement.Domain.Abstractions
{
    using Type = Novia.TypeManagement.Domain.Entities.Type;

    public interface ITypeRepository : IRepository<Type>
    {

    }
}
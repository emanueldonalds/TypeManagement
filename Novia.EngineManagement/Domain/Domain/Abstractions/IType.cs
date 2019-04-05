using System;
using System.Collections.Generic;
using System.Text;

namespace Novia.TypeManagement.Domain.Abstractions
{
    public interface IType : IAggregateRoot<int>
    {
        string Name { get; set; }
        int Volume { get; set; }
        int Power { get; set; }
        double Price { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Novia.EngineManagement.Domain.Abstractions
{
    public interface IEngine : IAggregateRoot<int>
    {
        string Name { get; set; }
        int Volume { get; set; }
        int Power { get; set; }
        double Price { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Novia.PoliceStationManagement.Domain.Abstractions
{
    public interface IPoliceStation : IAggregateRoot<int>
    {
        string Name { get; set; }
        int Volume { get; set; }
        int Power { get; set; }
        double Price { get; set; }
    }
}

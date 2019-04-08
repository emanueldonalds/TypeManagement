using System;
using System.Collections.Generic;
using System.Text;

namespace Novia.PoliceStationManagement.Domain.Abstractions
{
    public interface IPoliceStation : IAggregateRoot<int>
    {
        string Name { get; set; }
        string Address { get; set; }
        uint Workers { get; set; }
        string Chief { get; set; }
    }
}

using Novia.PoliceStationManagement.Application.Abstractions.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novia.PoliceStationManagement.Application.Abstractions
{
    public interface IPoliceStationManagement
    {
        PoliceStationDto Add(string name, string Address, uint Workers, string Chief);
        bool Remove(PoliceStationDto thePoliceStation);
        bool Modify(PoliceStationDto thePoliceStation);
        PoliceStationDto FindById(int Id);

        IEnumerable<PoliceStationDto> ListAll();
    }
}

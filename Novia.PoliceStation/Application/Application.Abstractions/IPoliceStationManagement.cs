using Novia.PoliceStationManagement.Application.Abstractions.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novia.PoliceStationManagement.Application.Abstractions
{
    public interface IPoliceStationManagement
    {
        PoliceStationDto Add(string name, string Address, int power, string Chief);
        bool Remove(PoliceStationDto thePoliceStation);
        bool Modify(PoliceStationDto thePoliceStation);
        PoliceStationDto FindById(int Id);

        IEnumerable<PoliceStationDto> ListAll();
    }
}

using Novia.PoliceStationManagement.Application.Abstractions.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novia.PoliceStationManagement.Application.Abstractions
{
    public interface IPoliceStationManagement
    {
        PoliceStationDto Add(string name, int volume, int power, double price);
        bool Remove(PoliceStationDto thePoliceStation);
        bool Modify(PoliceStationDto thePoliceStation);
        PoliceStationDto FindById(int Id);

        IEnumerable<PoliceStationDto> ListAll();
    }
}

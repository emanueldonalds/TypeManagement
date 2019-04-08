using Novia.PoliceStationManagement.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novia.PoliceStationManagement.Domain.Entities
{
    public class PoliceStation : Entity, IPoliceStation
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public uint Workers { get; set; }
        public string Chief { get; set; }

        public PoliceStation()
        {
            Name = "Empty";
            Address = "Empty";
            Workers = 0;
            Chief = "Empty";
        }

        static public PoliceStation CreatePoliceStation(string name, string address, uint workers, string chief)
        {
            PoliceStation theNewPoliceStation = new PoliceStation { Name = name, Address = address, Workers = workers, Chief = chief };
            return theNewPoliceStation;
        }
    }

}

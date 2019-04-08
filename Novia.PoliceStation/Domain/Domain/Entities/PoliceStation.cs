using Novia.PoliceStationManagement.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novia.PoliceStationManagement.Domain.Entities
{
    public class PoliceStation : Entity, IPoliceStation
    {
        public string Name { get; set; }
        public int Volume { get; set; }
        public int Power { get; set; }
        public double Price { get; set; }

        public PoliceStation()
        {
            Name = "Empty";
            Volume = -1;
            Power = -1;
            Price = -1;
        }

        static public PoliceStation CreatePoliceStation(string name, int volume, int power, double price)
        {
            PoliceStation theNewPoliceStation = new PoliceStation { Name = name, Volume = volume, Power = power, Price = price };
            return theNewPoliceStation;
        }
    }

}

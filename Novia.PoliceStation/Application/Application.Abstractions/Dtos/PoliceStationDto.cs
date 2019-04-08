using System;
using System.Collections.Generic;
using System.Text;

namespace Novia.PoliceStationManagement.Application.Abstractions.Dtos
{
    public class PoliceStationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Volume { get; set; }
        public int Power { get; set; }
        public double Price { get; set; }
    }
}

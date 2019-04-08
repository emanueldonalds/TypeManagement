using System;
using System.Collections.Generic;
using System.Text;

namespace Novia.PoliceStationManagement.Application.Abstractions.Dtos
{
    public class PoliceStationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Workers { get; set; }
        public string Chief { get; set; }
    }
}

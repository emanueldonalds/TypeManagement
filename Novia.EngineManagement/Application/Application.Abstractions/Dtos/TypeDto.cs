using System;
using System.Collections.Generic;
using System.Text;

namespace Novia.TypeManagement.Application.Abstractions.Dtos
{
    public class TypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Volume { get; set; }
        public int Power { get; set; }
        public double Price { get; set; }
    }
}

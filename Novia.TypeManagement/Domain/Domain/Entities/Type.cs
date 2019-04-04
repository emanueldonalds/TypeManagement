using System;
using System.Collections.Generic;
using System.Text;

namespace Novia.TypeManagement.Domain.Entities
{
    public class Type : Entity
    {
        public string Name { get; set; }
        public int Volume { get; set; }
        public int Power { get; set; }
        public double Price { get; set; }
    }
}

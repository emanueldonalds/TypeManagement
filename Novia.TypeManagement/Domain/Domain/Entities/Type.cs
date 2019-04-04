using Novia.TypeManagement.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novia.TypeManagement.Domain.Entities
{
    public class Type : Entity, IType
    {
        public string Name { get; set; }
        public int Volume { get; set; }
        public int Power { get; set; }
        public double Price { get; set; }

        public Type()
        {
            Name = "Empty";
            Volume = -1;
            Power = -1;
            Price = -1;
        }

        static public Type CreateType(string name, int volume, int power, double price)
        {
            Type theNewType = new Type { Name = name, Volume = volume, Power = power, Price = price };
            return theNewType;
        }
    }

}

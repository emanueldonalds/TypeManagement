using Novia.EngineManagement.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novia.EngineManagement.Domain.Entities
{
    public class Engine : Entity, IEngine
    {
        public string Name { get; set; }
        public int Volume { get; set; }
        public int Power { get; set; }
        public double Price { get; set; }

        public Engine()
        {
            Name = "Empty";
            Volume = -1;
            Power = -1;
            Price = -1;
        }

        static public Engine CreateEngine(string name, int volume, int power, double price)
        {
            Engine theNewEngine = new Engine { Name = name, Volume = volume, Power = power, Price = price };
            return theNewEngine;
        }
    }

}

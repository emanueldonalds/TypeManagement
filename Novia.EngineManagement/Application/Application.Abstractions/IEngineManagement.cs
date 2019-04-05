using Novia.EngineManagement.Application.Abstractions.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novia.EngineManagement.Application.Abstractions
{
    public interface IEngineManagement
    {
        EngineDto Add(string name, int volume, int power, double price);
        bool Remove(EngineDto theEngine);
        bool Modify(EngineDto theEngine);
        EngineDto FindById(int Id);

        IEnumerable<EngineDto> ListAll();
    }
}

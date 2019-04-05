using Novia.TypeManagement.Application.Abstractions.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novia.TypeManagement.Application.Abstractions
{
    public interface ITypeManagement
    {
        TypeDto Add(string name, int volume, int power, double price);
        bool Remove(TypeDto theType);
        bool Modify(TypeDto theType);
        TypeDto FindById(int Id);

        IEnumerable<TypeDto> ListAll();
    }
}

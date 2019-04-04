using Novia.TypeManagement.Application.Abstractions;
using Novia.TypeManagement.Application.Abstractions.Dtos;
using Novia.TypeManagement.Domain.Abstractions;
using Novia.TypeManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Novia.TypeManagement.Application.Services
{
    using Type = Domain.Entities.Type;
    public class TypeManagement : ITypeManagement
    {
        private ITypeRepository mTypeRepository;

        public TypeManagement(ITypeRepository typeRepository)
        {
            mTypeRepository = typeRepository;
        }

        public TypeDto Add(string name, int volume, int power, double price)
        {
            IType newType = Type.CreateType(name, volume, power, price);
            mTypeRepository.Add(newType);

            TypeDto newTypeDto = new TypeDto
            {
                Name = newType.Name,
                Id = newType.Id,
                Power = newType.Power,
                Price = newType.Price,
                Volume = newType.Volume
            };

            return newTypeDto;
        }

        public IEnumerable<TypeDto> ListAll()
        {
            var theTypes = mTypeRepository.ListAll();

            List<TypeDto> theTypeDtos = theTypes.Select(entry=>
                    new TypeDto
                    {
                        Name = entry.Name,
                        Id = entry.Id,
                        Power = entry.Power,
                        Price = entry.Price,
                        Volume = entry.Volume
                    }).ToList();

            return theTypeDtos;
        }

        public bool Modify(TypeDto theType)
        {
            IType theTypeToModify = mTypeRepository.GetById(theType.Id);

            if (theTypeToModify != null)
            {
                theTypeToModify.Name = theType.Name;
                theTypeToModify.Power = theType.Power;
                theTypeToModify.Volume = theType.Volume;
                theTypeToModify.Price = theType.Price;

                mTypeRepository.Update(theTypeToModify);
                return true;
            }

            return false;
        }

        public bool Remove(TypeDto theType)
        {
            IType theTypeToDelete = mTypeRepository.GetById(theType.Id);

            if(theTypeToDelete != null)
            {
                mTypeRepository.Delete(theTypeToDelete);
                return true;
            }

            return false;
        }

        public TypeDto FindById(int Id)
        {
            IType theType = mTypeRepository.GetById(Id);

            if(theType != null)
            {
                TypeDto theTypeDto = new TypeDto
                {
                    Name = theType.Name,
                    Id = theType.Id,
                    Power = theType.Power,
                    Price = theType.Price,
                    Volume = theType.Volume
                };

                return theTypeDto;
            }

            return null;
        }
    }
}

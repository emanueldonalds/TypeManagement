using Novia.EngineManagement.Application.Abstractions;
using Novia.EngineManagement.Application.Abstractions.Dtos;
using Novia.EngineManagement.Domain.Abstractions;
using Novia.EngineManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Novia.EngineManagement.Application.Services
{
    using Engine = Domain.Entities.Engine;
    public class EngineManagement : IEngineManagement
    {
        private IEngineRepository mEngineRepository;

        public EngineManagement(IEngineRepository EngineRepository)
        {
            mEngineRepository = EngineRepository;
        }

        public EngineDto Add(string name, int volume, int power, double price)
        {
            IEngine newEngine = Engine.CreateEngine(name, volume, power, price);
            mEngineRepository.Add(newEngine);

            EngineDto newEngineDto = new EngineDto
            {
                Name = newEngine.Name,
                Id = newEngine.Id,
                Power = newEngine.Power,
                Price = newEngine.Price,
                Volume = newEngine.Volume
            };

            return newEngineDto;
        }

        public IEnumerable<EngineDto> ListAll()
        {
            var theEngines = mEngineRepository.ListAll();

            List<EngineDto> theEngineDtos = theEngines.Select(entry=>
                    new EngineDto
                    {
                        Name = entry.Name,
                        Id = entry.Id,
                        Power = entry.Power,
                        Price = entry.Price,
                        Volume = entry.Volume
                    }).ToList();

            return theEngineDtos;
        }

        public bool Modify(EngineDto theEngine)
        {
            IEngine theEngineToModify = mEngineRepository.GetById(theEngine.Id);

            if (theEngineToModify != null)
            {
                theEngineToModify.Name = theEngine.Name;
                theEngineToModify.Power = theEngine.Power;
                theEngineToModify.Volume = theEngine.Volume;
                theEngineToModify.Price = theEngine.Price;

                mEngineRepository.Update(theEngineToModify);
                return true;
            }

            return false;
        }

        public bool Remove(EngineDto theEngine)
        {
            IEngine theEngineToDelete = mEngineRepository.GetById(theEngine.Id);

            if(theEngineToDelete != null)
            {
                mEngineRepository.Delete(theEngineToDelete);
                return true;
            }

            return false;
        }

        public EngineDto FindById(int Id)
        {
            IEngine theEngine = mEngineRepository.GetById(Id);

            if(theEngine != null)
            {
                EngineDto theEngineDto = new EngineDto
                {
                    Name = theEngine.Name,
                    Id = theEngine.Id,
                    Power = theEngine.Power,
                    Price = theEngine.Price,
                    Volume = theEngine.Volume
                };

                return theEngineDto;
            }

            return null;
        }
    }
}

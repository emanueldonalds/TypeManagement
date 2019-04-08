using Novia.PoliceStationManagement.Application.Abstractions;
using Novia.PoliceStationManagement.Application.Abstractions.Dtos;
using Novia.PoliceStationManagement.Domain.Abstractions;
using Novia.PoliceStationManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Novia.PoliceStationManagement.Application.Services
{
    using PoliceStation = Domain.Entities.PoliceStation;
    public class PoliceStationManagement : IPoliceStationManagement
    {
        private IPoliceStationRepository mPoliceStationRepository;

        public PoliceStationManagement(IPoliceStationRepository PoliceStationRepository)
        {
            mPoliceStationRepository = PoliceStationRepository;
        }

        public PoliceStationDto Add(string name, int volume, int power, double price)
        {
            IPoliceStation newPoliceStation = PoliceStation.CreatePoliceStation(name, volume, power, price);
            mPoliceStationRepository.Add(newPoliceStation);

            PoliceStationDto newPoliceStationDto = new PoliceStationDto
            {
                Name = newPoliceStation.Name,
                Id = newPoliceStation.Id,
                Power = newPoliceStation.Power,
                Price = newPoliceStation.Price,
                Volume = newPoliceStation.Volume
            };

            return newPoliceStationDto;
        }

        public IEnumerable<PoliceStationDto> ListAll()
        {
            var thePoliceStations = mPoliceStationRepository.ListAll();

            List<PoliceStationDto> thePoliceStationDtos = thePoliceStations.Select(entry=>
                    new PoliceStationDto
                    {
                        Name = entry.Name,
                        Id = entry.Id,
                        Power = entry.Power,
                        Price = entry.Price,
                        Volume = entry.Volume
                    }).ToList();

            return thePoliceStationDtos;
        }

        public bool Modify(PoliceStationDto thePoliceStation)
        {
            IPoliceStation thePoliceStationToModify = mPoliceStationRepository.GetById(thePoliceStation.Id);

            if (thePoliceStationToModify != null)
            {
                thePoliceStationToModify.Name = thePoliceStation.Name;
                thePoliceStationToModify.Power = thePoliceStation.Power;
                thePoliceStationToModify.Volume = thePoliceStation.Volume;
                thePoliceStationToModify.Price = thePoliceStation.Price;

                mPoliceStationRepository.Update(thePoliceStationToModify);
                return true;
            }

            return false;
        }

        public bool Remove(PoliceStationDto thePoliceStation)
        {
            IPoliceStation thePoliceStationToDelete = mPoliceStationRepository.GetById(thePoliceStation.Id);

            if(thePoliceStationToDelete != null)
            {
                mPoliceStationRepository.Delete(thePoliceStationToDelete);
                return true;
            }

            return false;
        }

        public PoliceStationDto FindById(int Id)
        {
            IPoliceStation thePoliceStation = mPoliceStationRepository.GetById(Id);

            if(thePoliceStation != null)
            {
                PoliceStationDto thePoliceStationDto = new PoliceStationDto
                {
                    Name = thePoliceStation.Name,
                    Id = thePoliceStation.Id,
                    Power = thePoliceStation.Power,
                    Price = thePoliceStation.Price,
                    Volume = thePoliceStation.Volume
                };

                return thePoliceStationDto;
            }

            return null;
        }
    }
}

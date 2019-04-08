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

        public PoliceStationDto Add(string name, string address, uint workers, string chief)
        {
            IPoliceStation newPoliceStation = PoliceStation.CreatePoliceStation(name, address, workers, chief);
            mPoliceStationRepository.Add(newPoliceStation);

            PoliceStationDto newPoliceStationDto = new PoliceStationDto
            {
                Name = newPoliceStation.Name,
                Id = newPoliceStation.Id,
                Workers = newPoliceStation.Workers,
                Chief = newPoliceStation.Chief,
                Address = newPoliceStation.Address
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
                        Workers = entry.Workers,
                        Chief = entry.Chief,
                        Address = entry.Address
                    }).ToList();

            return thePoliceStationDtos;
        }

        public bool Modify(PoliceStationDto thePoliceStation)
        {
            IPoliceStation thePoliceStationToModify = mPoliceStationRepository.GetById(thePoliceStation.Id);

            if (thePoliceStationToModify != null)
            {
                thePoliceStationToModify.Name = thePoliceStation.Name;
                thePoliceStationToModify.Workers = thePoliceStation.Workers;
                thePoliceStationToModify.Address = thePoliceStation.Address;
                thePoliceStationToModify.Chief = thePoliceStation.Chief;

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
                    Workers = thePoliceStation.Workers,
                    Chief = thePoliceStation.Chief,
                    Address = thePoliceStation.Address
                };

                return thePoliceStationDto;
            }

            return null;
        }
    }
}

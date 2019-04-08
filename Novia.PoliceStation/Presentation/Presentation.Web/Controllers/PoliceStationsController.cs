using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Novia.PoliceStationManagement.Application.Abstractions;
using Novia.PoliceStationManagement.Application.Abstractions.Dtos;

namespace Novia.PoliceStationManagement.Presentation.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoliceStationsController : ControllerBase
    {
        private IPoliceStationManagement mPoliceStationManagement;

        public PoliceStationsController(IPoliceStationManagement PoliceStationManagement)
        {
            mPoliceStationManagement = PoliceStationManagement;
        }

        // GET: api/PoliceStations
        [HttpGet]
        public ActionResult<IEnumerable<PoliceStationDto>> Get()
        {
            var thePoliceStations = mPoliceStationManagement.ListAll();
            return thePoliceStations.ToList();
        }

        // GET: api/PoliceStations/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<PoliceStationDto> Get(int id)
        {
            var thePoliceStation = mPoliceStationManagement.FindById(id);
            if(thePoliceStation != null)
            {
                return thePoliceStation;
            }

            return null;
        }

        // POST: api/PoliceStations
        [HttpPost]
        [Authorize]
        public void Post(PoliceStationDto newPoliceStationDto)
        {
            mPoliceStationManagement.Add(
                newPoliceStationDto.Name,
                newPoliceStationDto.Volume,
                newPoliceStationDto.Power,
                newPoliceStationDto.Price
                );
        }

        // PUT: api/PoliceStations/5
        [HttpPut("{id}")]
        [Authorize]
        public void Put(int id, PoliceStationDto newPoliceStationDto)
        {
            newPoliceStationDto.Id = id;
            mPoliceStationManagement.Modify(newPoliceStationDto);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize]
        public void Delete(int id)
        {
            mPoliceStationManagement.Remove(mPoliceStationManagement.FindById(id));
        }
    }
}

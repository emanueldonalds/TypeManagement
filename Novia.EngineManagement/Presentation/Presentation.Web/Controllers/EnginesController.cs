using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Novia.EngineManagement.Application.Abstractions;
using Novia.EngineManagement.Application.Abstractions.Dtos;

namespace Novia.EngineManagement.Presentation.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnginesController : ControllerBase
    {
        private IEngineManagement mEngineManagement;

        public EnginesController(IEngineManagement EngineManagement)
        {
            mEngineManagement = EngineManagement;
        }

        // GET: api/Engines
        [HttpGet]
        public ActionResult<IEnumerable<EngineDto>> Get()
        {
            var theEngines = mEngineManagement.ListAll();
            return theEngines.ToList();
        }

        // GET: api/Engines/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<EngineDto> Get(int id)
        {
            var theEngine = mEngineManagement.FindById(id);
            if(theEngine != null)
            {
                return theEngine;
            }

            return null;
        }

        // POST: api/Engines
        [HttpPost]
        [Authorize]
        public void Post(EngineDto newEngineDto)
        {
            mEngineManagement.Add(
                newEngineDto.Name,
                newEngineDto.Volume,
                newEngineDto.Power,
                newEngineDto.Price
                );
        }

        // PUT: api/Engines/5
        [HttpPut("{id}")]
        [Authorize]
        public void Put(int id, EngineDto newEngineDto)
        {
            newEngineDto.Id = id;
            mEngineManagement.Modify(newEngineDto);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize]
        public void Delete(int id)
        {
            mEngineManagement.Remove(mEngineManagement.FindById(id));
        }
    }
}

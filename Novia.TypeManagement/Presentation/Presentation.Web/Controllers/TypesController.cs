using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Novia.TypeManagement.Application.Abstractions;
using Novia.TypeManagement.Application.Abstractions.Dtos;

namespace Novia.TypeManagement.Presentation.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController : ControllerBase
    {
        private ITypeManagement mTypeManagement;

        public TypesController(ITypeManagement typeManagement)
        {
            mTypeManagement = typeManagement;
        }

        // GET: api/Types
        [HttpGet]
        public ActionResult<IEnumerable<TypeDto>> Get()
        {
            var theTypes = mTypeManagement.ListAll();
            return theTypes.ToList();
        }

        // GET: api/Types/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<TypeDto> Get(int id)
        {
            var theType = mTypeManagement.FindById(id);
            if(theType != null)
            {
                return theType;
            }

            return null;
        }

        // POST: api/Types
        [HttpPost]
        [Authorize]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Types/5
        [HttpPut("{id}")]
        [Authorize]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize]
        public void Delete(int id)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Types
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Types/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

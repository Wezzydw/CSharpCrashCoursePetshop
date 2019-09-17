using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;
using CA_Petshop.Core.ApplicationServices;
using CA_Petshop.Core.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UI.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnersController(IOwnerService ownerService)
        {
            
            _ownerService = ownerService;
        }

        [HttpPost]
        public void Post([FromBody] Owner owner)
        {
            _ownerService.CreateOwner(owner);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get()
        {
            return _ownerService.GetOwners();
        }

        [HttpPut]
        public void Put([FromBody] Owner owner)
        {
            _ownerService.ChangeOwner(owner);
        }

        // DELETE api/pets/anyID
        [HttpDelete]
        public void Delete([FromQuery] int id)
        {
            _ownerService.DeleteOwner(id);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CA_Petshop.Core.ApplicationServices;
using CA_Petshop.Core.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UI.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private IPetService _petService;

        public  PetsController(IPetService petService)
        {
            _petService = petService;
        }
        // GET api/pets
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get()
        {
            return _petService.GetPets();
        }

        // POST api/pets
        [HttpPost]
        public void Post([FromBody] Pet value)
        {
            _petService.CreatePet(value);
        }

        // PUT api/pets/anyID
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Pet pet)
        {
            _petService.UpdatePet(id,pet);
        }

        // DELETE api/pets/anyID
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _petService.DeletePet(id);
        }
    }
}
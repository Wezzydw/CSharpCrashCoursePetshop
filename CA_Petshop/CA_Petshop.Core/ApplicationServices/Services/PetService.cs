using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CA_Petshop.Core.DomainServices;
using CA_Petshop.Core.Entity;

namespace CA_Petshop.Core.ApplicationServices.Services
{
   public class PetService: IPetService
    {

        private IPetRepository _petRepository;

        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public List<Pet> GetPets()
        {
            return _petRepository.ReadPets().ToList();
        }

        public List<Pet> SearchPets()
        {
            throw new NotImplementedException();
        }

        public void CreatePet(Pet pet)
        {
            throw new NotImplementedException();
        }

        public void DeletePet(Pet pet)
        {
            throw new NotImplementedException();
        }

        public void UpdatePet(int id, Pet pet)
        {
            throw new NotImplementedException();
        }

        public List<Pet> SortPetsByPrice()
        {
            throw new NotImplementedException();
        }

        public List<Pet> Get5CheapestPets()
        {
            throw new NotImplementedException();
        }


    }
}

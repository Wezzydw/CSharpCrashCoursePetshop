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

        public List<Pet> SearchPets(Enum petEnum)
        {
            return _petRepository.ReadPets().Where(pet => pet.race.Equals(petEnum)).ToList();
        }

        public void CreatePet(Pet pet)
        {
            _petRepository.CreatePet(pet);
        }

        public void DeletePet(int id)
        {
            _petRepository.DeletePet(id);
        }

        public void UpdatePet(int id, Pet pet)
        {
            _petRepository.UpdatePet(id, pet);
        }

        public List<Pet> SortPetsByPrice()
        {
            List<Pet> toSort = GetPets();
            toSort.Sort((pet1, pet2) => pet1.Price.CompareTo(pet2.Price));
            return toSort;
        }

        public List<Pet> Get5CheapestPets()
        {
            return SortPetsByPrice().GetRange(0, 5);
        }


    }
}

using System;
using System.Collections.Generic;
using System.Text;
using CA_Petshop.Core.Entity;

namespace CA_Petshop.Core.ApplicationServices
{
    public interface IPetService
    {
        List<Pet> GetPets();
        List<Pet> SearchPets(Enum petEnum);
        void CreatePet(Pet pet);
        void DeletePet(Pet pet);
        void UpdatePet(int id, Pet pet);
        List<Pet> SortPetsByPrice();
        List<Pet> Get5CheapestPets();

    }
}

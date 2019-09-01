using System;
using System.Collections.Generic;
using System.Text;
using CA_Petshop.Core.Entity;

namespace CA_Petshop.Core.DomainServices
{
    public interface IPetRepository
    {
        IEnumerable<Pet> ReadPets();

        void CreatePet(Pet pet);

        void DeletePet(int id);

        void UpdatePet(int id, Pet pet);

    }
}

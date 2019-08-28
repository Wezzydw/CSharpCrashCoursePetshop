using System;
using System.Collections.Generic;
using System.Text;
using CA_Petshop.Core.DomainServices;
using CA_Petshop.Core.Entity;

namespace CA_Petshop.Infrastructure.Data.Repositories
{
   public class PetRepository: IPetRepository
    {
        public PetRepository()
        {
            FakeDataBase.InitData();
        }
        public int GetNextId()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pet> ReadPets()
        {
            return FakeDataBase._pp;
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
    }
}

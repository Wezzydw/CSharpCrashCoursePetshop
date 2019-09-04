using System;
using System.Collections.Generic;
using System.Text;
using CA_Petshop.Core.DomainServices;
using CA_Petshop.Core.Entity;

namespace CA_Petshop.Infrastructure.Data.Repositories
{
    class OwnerRepository: IOwnerRepository
    {
        public void CreateOwner(Owner owner)
        {
            FakeDataBase._Owners.Add(owner);
        }

        public List<Owner> ReadOwners()
        {
            return FakeDataBase._Owners;
        }

        public void UpdateOwner(Owner owner)
        {
            FakeDataBase._Owners.Find(own => own.Id == owner.Id).Name = owner.Name;
        }

        public void DeleteOwner(int id)
        {
            Owner toDelete = FakeDataBase._Owners.Find(own => own.Id == id);
            FakeDataBase._Owners.Remove(toDelete);
        }
    }
}

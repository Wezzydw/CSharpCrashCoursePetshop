using System;
using System.Collections.Generic;
using System.Text;
using CA_Petshop.Core.Entity;

namespace CA_Petshop.Core.DomainServices
{
   public interface IOwnerRepository
    {
        void CreateOwner(Owner owner);
        List<Owner> ReadOwners();
        void UpdateOwner(Owner owner);
        void DeleteOwner(int id);

    }
}

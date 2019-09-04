using System;
using System.Collections.Generic;
using System.Text;
using CA_Petshop.Core.Entity;

namespace CA_Petshop.Core.ApplicationServices
{
   public interface IOwnerService
   {
       void CreateOwner(Owner owner);
       List<Owner> GetOwners();
       void ChangeOwner(Owner owner);
       void DeleteOwner(int id);
   }
}

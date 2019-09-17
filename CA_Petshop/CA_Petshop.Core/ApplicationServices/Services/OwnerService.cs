using System;
using System.Collections.Generic;
using System.Text;
using CA_Petshop.Core.DomainServices;
using CA_Petshop.Core.Entity;

namespace CA_Petshop.Core.ApplicationServices.Services
{
    public class OwnerService: IOwnerService
    {
        private IOwnerRepository _ownerRepository;
        public OwnerService(IOwnerRepository ownerRepository)
        {
            this._ownerRepository = ownerRepository;
        }
        public void CreateOwner(Owner owner)
        {
            _ownerRepository.CreateOwner(owner);
        }

        public List<Owner> GetOwners()
        {
            return _ownerRepository.ReadOwners();
        }

        public void ChangeOwner(Owner owner)
        {
            _ownerRepository.UpdateOwner(owner);
        }

        public void DeleteOwner(int id)
        {
            _ownerRepository.DeleteOwner(id);
        }
    }
}

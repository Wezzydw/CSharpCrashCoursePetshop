using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CA_Petshop.Core.DomainServices;
using CA_Petshop.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace CA_Petshop.Infrastructure.Data.SQL.Repositories
{
    public class OwnerSQLRepository : IOwnerRepository
    {
        private PetshopContext _context;
        public OwnerSQLRepository(PetshopContext context)
        {
            _context = context;
        }

        public void CreateOwner(Owner owner)
        {
            _context.Attach(owner).State = EntityState.Added;
        }

        public List<Owner> ReadOwners()
        {
            return _context.owners.ToList();
        }

        public void UpdateOwner(Owner owner)
        {
            throw new NotImplementedException();
        }

        public void DeleteOwner(int id)
        {
            Owner delteOwner = _context.Remove(new Owner() {Id = id}).Entity;
            _context.SaveChanges();
        }
    }
}

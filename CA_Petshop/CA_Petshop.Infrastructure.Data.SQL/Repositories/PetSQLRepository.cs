using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CA_Petshop.Core.DomainServices;
using CA_Petshop.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace CA_Petshop.Infrastructure.Data.SQL.Repositories
{
    public class PetSQLRepository: IPetRepository
    {
        private PetshopContext _context;
        public PetSQLRepository(PetshopContext context)
        {
            _context = context;
        }
        public IEnumerable<Pet> ReadPets()
        {
            return _context.pets;
        }

        public void CreatePet(Pet pet)
        {
            //_context.pets.Add(pet);
            //_context.SaveChanges();

            _context.Attach(pet).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void DeletePet(int id)
        {
            Pet pet = _context.pets.ToList().Find(pp => pp.ID == id);
            _context.pets.Remove(pet);
            _context.SaveChanges();

            //Pet deletePet = _context.Remove(new Pet() {ID = id}).Entity;
            //_context.SaveChanges();

        }

        public void UpdatePet(int id, Pet pet)
        {
            Pet pet2 = _context.pets.ToList().Find(pp => pp.ID == id);
            pet.ID = id;
            pet2.Name = pet.Name;
            //_context.Update(pet2).State = EntityState.Modified;
            _context.SaveChanges();
            
        }
    }
}

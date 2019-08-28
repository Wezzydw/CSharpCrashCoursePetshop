using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CA_Petshop.Core;
using CA_Petshop.Core.Entity;

namespace CA_Petshop.Infrastructure.Data
{
   public class FakeDataBase
    {
        public static List<Pet> _pets = new List<Pet>();
        public static int _idCounter = 0;
        public static IEnumerable<Pet> _pp;

        public static void InitData()
        {
            _pets.ToList().Add(new Pet()
            {
                Birthdate = DateTime.Today, ID = _idCounter++, Name = "Sweetý", Color = "White", Price = 8000, race = Pet.Race.Fox
            });

            _pp = _pets;
        }
















    /**
        public List<Pet> GetPets()
        {

            return _pets;
        }

        public int GetId()
        {
            return _idCounter++;
        }

        public void CreatePet(Pet pet)
        {
            _pets.Add(pet);
        }

        public void DeletePet(Pet pet)
        {
            _pets.Remove(pet);
        }

        public void UpdatePet(int id, Pet pet)
        {
            Pet old = null;
            foreach (Pet vari in _pets)
            {
                if (vari.ID.Equals(id))
                {
                    old = vari;
                    break;
                }
            }

            old = pet;
        }**/
    }
}

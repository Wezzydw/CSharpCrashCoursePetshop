using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CA_Petshop.Core;
using CA_Petshop.Core.Entity;

namespace CA_Petshop.Infrastructure.Data
{
   public static class FakeDataBase
    {
        public static List<Pet> _pets = new List<Pet>();
        public static int _idCounter = 1;
        public static IEnumerable<Pet> _pp = _pets;

        public static void InitData()
        {

            _pets.Add(new Pet()
            {
                Birthdate = DateTime.Parse("28-03-2019"),
                ID = _idCounter++,
                Name = "Sweetý",
                Color = "White",
                Price = 8000,
                race = Pet.Race.Fox
                , PreviousOwner = "None",
                
            });
            _pets.Add(new Pet()
            {
                Birthdate = DateTime.Parse("02-07-1996"),
                ID = _idCounter++,
                Name = "Frank",
                Color = "Black",
                Price = 80000,
                race = Pet.Race.Dog, PreviousOwner = "MiB", SoldDate = DateTime.Parse("02-07-1997"),
            });
            _pets.Add(new Pet()
            {
                Birthdate = DateTime.Parse("04-09-2008"),
                ID = _idCounter++,
                Name = "Spot",
                Color = "White & Black",
                Price = 700,
                race = Pet.Race.Dog
            });
            _pets.Add(new Pet()
            {
                Birthdate = DateTime.Parse("01-01-2019"),
                ID = _idCounter++,
                Name = "Fireworks",
                Color = "Brown",
                Price = 7680,
                race = Pet.Race.Cat
            });
            _pets.Add(new Pet()
            {
                Birthdate = DateTime.Parse("28-03-2010"),
                ID = _idCounter++,
                Name = "Shoop",
                Color = "White",
                Price = 550,
                race = Pet.Race.Goat
            });
            _pets.Add(new Pet()
            {
                Birthdate = DateTime.Parse("28-03-2012"),
                ID = _idCounter++,
                Name = "SnowWhite",
                Color = "Snow-White",
                Price = 80,
                race = Pet.Race.Rabbit
            });
           


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

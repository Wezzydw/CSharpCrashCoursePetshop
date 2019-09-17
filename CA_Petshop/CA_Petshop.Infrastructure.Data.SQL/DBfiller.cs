using System;
using System.Collections.Generic;
using System.Text;
using CA_Petshop.Core.Entity;

namespace CA_Petshop.Infrastructure.Data.SQL
{
    public class DBfiller
    {

        public static void Seed(PetshopContext context)
        {
            context.Add(new Pet()
            {
                Birthdate = DateTime.Parse("28-03-2019"),
                
                Name = "Sweetý",
                Color = "White",
                Price = 8000,
                race = Pet.Race.Fox
                ,
                PreviousOwner = new Owner()
                {
                    
                    Name = "Tanketorsk"
                }

            });
            context.Add(new Pet()
            {
                Birthdate = DateTime.Parse("02-07-1996"),
                
                Name = "Frank",
                Color = "Black",
                Price = 80000,
                race = Pet.Race.Dog,
                PreviousOwner = new Owner()
                {
                    
                    Name = "Marcipan"
                },
                SoldDate = DateTime.Parse("02-07-1997"),
            });
            context.Add(new Pet()
            {
                Birthdate = DateTime.Parse("04-09-2008"),
               
                Name = "Spot",
                Color = "White & Black",
                Price = 700,
                race = Pet.Race.Dog
            });
            context.Add(new Pet()
            {
                Birthdate = DateTime.Parse("01-01-2019"),
               
                Name = "Fireworks",
                Color = "Brown",
                Price = 7680,
                race = Pet.Race.Cat
            });
            context.Add(new Pet()
            {
                Birthdate = DateTime.Parse("28-03-2010"),
              
                Name = "Shoop",
                Color = "White",
                Price = 550,
                race = Pet.Race.Goat
            });
            context.Add(new Pet()
            {
                Birthdate = DateTime.Parse("28-03-2012"),
               

                Name = "SnowWhite",
                Color = "Snow-White",
                Price = 80,
                race = Pet.Race.Rabbit
            });

            context.SaveChanges();
        }
    }
}

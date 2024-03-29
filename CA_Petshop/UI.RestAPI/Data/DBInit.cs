﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CA_Petshop.Core.Entity;
using CA_Petshop.Infrastructure.Data.SQL;
using Microsoft.EntityFrameworkCore;

namespace UI.RestAPI.Data
{
    public class DBInit : IDBInit
    {
        public void Init(PetshopContext psc)
        {
            psc.Database.EnsureCreated();


            if (psc.pets.Any())
            {
                psc.Database.ExecuteSqlCommand("DROP TABLE PETS");
                psc.Database.EnsureCreated();
            }
            psc.Add(new Pet()
            {
                Birthdate = DateTime.Parse("28-03-2019"),

                Name = "Sweetý",
                Color = "White",
                Price = 8000,
                race = Pet.Race.Fox,
                PreviousOwner = new Owner()
                {

                    Name = "Tanketorsk"
                }

            });
            psc.Add(new Pet()
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
            psc.Add(new Pet()
            {
                Birthdate = DateTime.Parse("04-09-2008"),

                Name = "Spot",
                Color = "White & Black",
                Price = 700,
                race = Pet.Race.Dog
            });
            psc.Add(new Pet()
            {
                Birthdate = DateTime.Parse("01-01-2019"),

                Name = "Fireworks",
                Color = "Brown",
                Price = 7680,
                race = Pet.Race.Cat
            });
            psc.Add(new Pet()
            {
                Birthdate = DateTime.Parse("28-03-2010"),

                Name = "Shoop",
                Color = "White",
                Price = 550,
                race = Pet.Race.Goat
            });
            psc.Add(new Pet()
            {
                Birthdate = DateTime.Parse("28-03-2012"),


                Name = "SnowWhite",
                Color = "Snow-White",
                Price = 80,
                race = Pet.Race.Rabbit
            });

            psc.Add(new Owner()
            {
                Name = "Tester"
            });

            psc.Add(new Owner()
            {
                Name = "Lars"
            });

            psc.Add(new Owner()
            {
                Name = "Peter"
            });

            psc.Add(new Owner()
            {
                Name = "Jeppe"
            });

            psc.Add(new Owner()
            {
                Name = "Lårs"
            });

            psc.SaveChanges();

        }
    }
}

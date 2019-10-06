using System;
using System.Collections.Generic;
using System.Text;
using CA_Petshop.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace CA_Petshop.Infrastructure.Data.SQL
{
    public class PetshopContext : DbContext
    {

        public PetshopContext(DbContextOptions opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>()
                .HasOne(o => o.PreviousOwner);
        }

        public DbSet<Pet> pets { get; set; }
        public DbSet<Owner> owners { get; set; }
    }
}

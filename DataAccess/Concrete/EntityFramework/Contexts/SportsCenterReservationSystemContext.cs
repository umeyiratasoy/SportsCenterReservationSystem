using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Core.Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class SportsCenterReservationSystemContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=ATASOY;Database=SportsCenterReservationSystem;Trusted_Connection=true");
        }


        public DbSet<Astroturf> Astroturfs { get; set; }
        public DbSet<FieldType> FieldTypes { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<AstroturfImage> AstroturfImages { get; set; }

        

        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

    }
}

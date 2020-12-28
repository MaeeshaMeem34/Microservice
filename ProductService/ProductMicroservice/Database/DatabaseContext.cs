using Microsoft.EntityFrameworkCore;
using ProductMicroservice.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroservice.Database
{
    public class DatabaseContext: DbContext
    {

        public DbSet<Product> products { get; set;  }
        public DbSet<Category> categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-R5MM19P;initial catalog= ProductDB; Integrated Security=True");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
        .HasIndex(u => u.name)
        .IsUnique();
        }


    }
}

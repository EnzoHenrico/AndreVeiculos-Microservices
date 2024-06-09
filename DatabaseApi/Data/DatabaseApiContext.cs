using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DatabaseApi.Data
{
    public class DatabaseApiContext : DbContext
    {
        public DatabaseApiContext (DbContextOptions<DatabaseApiContext> options)
            : base(options)
        {
        }
        
        // Create Database to manage all Services
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Employee>().ToTable("Employee");
        }

        public DbSet<Models.Car> Car { get; set; }
        public DbSet<Models.CarService> CarService { get; set; }
        public DbSet<Models.Employee> Employee { get; set; }
        public DbSet<Models.Service> Service { get; set; }
        public DbSet<Models.Purchase> Purchase { get; set; }
        public DbSet<Models.Address> Address { get; set; }
        public DbSet<Models.Customer> Customer { get; set; }
        public DbSet<Models.Boleto> Boleto { get; set; }
        public DbSet<Models.Card> Card { get; set; }
        public DbSet<Models.Sale> Sale { get; set; }
        public DbSet<Models.Position> Position { get; set; }
        public DbSet<Models.Payment> Payment { get; set; }
        public DbSet<Models.Pix> Pix { get; set; }
        public DbSet<Models.PixType> PixType { get; set; }
    }
}

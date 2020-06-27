using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using FineEx.DataLayer.Models;

namespace FineEx.DataLayer.Context
{
    public class DbFineEx : System.Data.Entity.DbContext
    {

        public DbFineEx() : base("dbFineEx")
        {
            Database.SetInitializer(strategy: new CreateDatabaseIfNotExists<DbFineEx>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new StudentConfigurations());
            modelBuilder.Entity<User>()
                .ToTable("User");

            modelBuilder.Entity<User>()
                .MapToStoredProcedures();


        }

        public DbSet<Item> Items { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Company> Companies { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<User> Users { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Invoice> Invoices { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Role> Role { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<PaymentMethod> PaymentMethods { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Location> Locations { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Country> Country { get; set; }

    }
}

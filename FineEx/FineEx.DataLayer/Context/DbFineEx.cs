using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration.Conventions;
using FineEx.DataLayer.Migrations;
using FineEx.DataLayer.Models;

namespace FineEx.DataLayer.Context
{
    public class DbFineEx : System.Data.Entity.DbContext
    {
        //PM> Add-Migration InitialCreate
        //update-database
        public DbFineEx() : base("dbFineEx")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DbFineEx, Configuration>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //TODO something like this
            //modelBuilder.Entity<Card>()
            //    .HasRequired(c => c.Stage)
            //    .WithMany()
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Side>()
            //    .HasRequired(s => s.Stage)
            //    .WithMany()
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Company>().HasMany(i => i.Users).WithRequired().WillCascadeOnDelete(false);
            modelBuilder.Entity<Company>().HasMany(i => i.Items).WithRequired().WillCascadeOnDelete(false);
            modelBuilder.Entity<Company>().HasMany(i => i.SentInvoices).WithRequired().WillCascadeOnDelete(false);
            modelBuilder.Entity<Company>().HasMany(i => i.ReceivedInvoices).WithRequired().WillCascadeOnDelete(false);


            modelBuilder.Entity<Invoice>()
                .HasRequired(m => m.Sender)
                .WithMany(t => t.SentInvoices)
                .HasForeignKey(m => m.SenderId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Invoice>()
                .HasRequired(m => m.Receiver)
                .WithMany(t => t.ReceivedInvoices)
                .HasForeignKey(m => m.ReceiverId)
                .WillCascadeOnDelete(false);

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

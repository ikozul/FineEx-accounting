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

            modelBuilder.Entity<User>()
                .HasMany<Company>(s => s.Companies)
                .WithMany(c => c.Users)
                .Map(cs =>
                {
                    cs.MapLeftKey("UserId");
                    cs.MapRightKey("CompanyId");
                    cs.ToTable("UsersCompanies");
                });

            //modelBuilder.Entity<Item>()
            //    .HasMany<Invoice>(s => s.Invoices)
            //    .WithMany(c => c.Items)
            //    .Map(cs =>
            //    {
            //        cs.MapLeftKey("InvoiceId");
            //        cs.MapRightKey("ItemId");
            //        cs.ToTable("InvoiceItems");
            //    });
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<InvoiceItems> InvoiceItems { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Country> Country { get; set; }

    }
}

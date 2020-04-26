namespace FineEx.DataLayer
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbFineEx : DbContext
    {
        public DbFineEx()
            : base("name=DbFineEx")
        {
        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .HasMany(e => e.Invoices)
                .WithOptional(e => e.Company)
                .HasForeignKey(e => e.RecipientCompanyId);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.Invoices1)
                .WithOptional(e => e.Company1)
                .HasForeignKey(e => e.RecipientCompanyId);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.Invoices2)
                .WithOptional(e => e.Company2)
                .HasForeignKey(e => e.SenderCompanyId);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.Invoices3)
                .WithOptional(e => e.Company3)
                .HasForeignKey(e => e.SenderCompanyId);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.Items)
                .WithOptional(e => e.Company)
                .HasForeignKey(e => e.CompanyId);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.Items1)
                .WithOptional(e => e.Company1)
                .HasForeignKey(e => e.CompanyId);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.Items2)
                .WithOptional(e => e.Company2)
                .HasForeignKey(e => e.CompanyId);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.Company)
                .HasForeignKey(e => e.CompanyId);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.Users1)
                .WithOptional(e => e.Company1)
                .HasForeignKey(e => e.CompanyId);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.Users2)
                .WithOptional(e => e.Company2)
                .HasForeignKey(e => e.CompanyId);

            modelBuilder.Entity<Invoice>()
                .HasMany(e => e.Items)
                .WithOptional(e => e.Invoice)
                .HasForeignKey(e => e.InvoiceId);

            modelBuilder.Entity<Invoice>()
                .HasMany(e => e.Items1)
                .WithOptional(e => e.Invoice1)
                .HasForeignKey(e => e.InvoiceId);

            modelBuilder.Entity<Invoice>()
                .HasMany(e => e.Items2)
                .WithOptional(e => e.Invoice2)
                .HasForeignKey(e => e.InvoiceId);

            modelBuilder.Entity<Location>()
                .HasMany(e => e.Companies)
                .WithOptional(e => e.Location)
                .HasForeignKey(e => e.IdLocation);

            modelBuilder.Entity<Location>()
                .HasMany(e => e.Companies1)
                .WithOptional(e => e.Location1)
                .HasForeignKey(e => e.IdLocation);

            modelBuilder.Entity<Location>()
                .HasMany(e => e.Companies2)
                .WithOptional(e => e.Location2)
                .HasForeignKey(e => e.IdLocation);

            modelBuilder.Entity<Location>()
                .HasMany(e => e.Invoices)
                .WithOptional(e => e.Location)
                .HasForeignKey(e => e.IdLocation);

            modelBuilder.Entity<Location>()
                .HasMany(e => e.Invoices1)
                .WithOptional(e => e.Location1)
                .HasForeignKey(e => e.IdLocation);

            modelBuilder.Entity<Location>()
                .HasMany(e => e.Invoices2)
                .WithOptional(e => e.Location2)
                .HasForeignKey(e => e.IdLocation);
        }
    }
}

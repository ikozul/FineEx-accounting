namespace FineEx.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Invoices", "LocationId", "dbo.Locations");
            DropIndex("dbo.Invoices", new[] { "LocationId" });
            AddColumn("dbo.Invoices", "Approved", c => c.Boolean(nullable: false));
            AddColumn("dbo.Invoices", "PdfPath", c => c.String());
            DropColumn("dbo.Invoices", "Incoming");
            DropColumn("dbo.Invoices", "ProtectedCodeOfSupplier");
            DropColumn("dbo.Invoices", "LocationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Invoices", "LocationId", c => c.Int(nullable: false));
            AddColumn("dbo.Invoices", "ProtectedCodeOfSupplier", c => c.String());
            AddColumn("dbo.Invoices", "Incoming", c => c.Boolean(nullable: false));
            DropColumn("dbo.Invoices", "PdfPath");
            DropColumn("dbo.Invoices", "Approved");
            CreateIndex("dbo.Invoices", "LocationId");
            AddForeignKey("dbo.Invoices", "LocationId", "dbo.Locations", "Id", cascadeDelete: true);
        }
    }
}

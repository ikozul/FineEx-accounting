namespace FineEx.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ItemQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ItemName = c.String(),
                        CompanyId = c.Int(nullable: false),
                        Name = c.String(),
                        Company_Id = c.Int(nullable: false),
                        Invoice_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.Company_Id)
                .ForeignKey("dbo.Invoices", t => t.Invoice_Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId)
                .Index(t => t.Company_Id)
                .Index(t => t.Invoice_Id);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BusinessNumber = c.String(maxLength: 64),
                        BusinessUnit = c.String(),
                        Name = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        County = c.String(),
                        GLN = c.String(),
                        IBAN = c.String(),
                        Phone = c.String(),
                        PricePrecision = c.Int(nullable: false),
                        QuantityPrecision = c.Int(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.BusinessNumber)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Incoming = c.Boolean(nullable: false),
                        SenderId = c.Int(nullable: false),
                        ReceiverId = c.Int(nullable: false),
                        PaymentMethodId = c.Int(nullable: false),
                        InvoiceDate = c.DateTime(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        DeliveryDate = c.DateTime(nullable: false),
                        ProtectedCodeOfSupplier = c.String(),
                        UniqueIdentifierOfInvoice = c.String(),
                        VatNumber = c.String(),
                        VatSwiftBankClient = c.String(),
                        LocationId = c.Int(nullable: false),
                        InvoiceNumber = c.String(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .ForeignKey("dbo.PaymentMethods", t => t.PaymentMethodId, cascadeDelete: true)
                .ForeignKey("dbo.Companies", t => t.ReceiverId)
                .ForeignKey("dbo.Companies", t => t.SenderId)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.SenderId)
                .Index(t => t.ReceiverId)
                .Index(t => t.PaymentMethodId)
                .Index(t => t.LocationId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StreetName = c.String(),
                        Longitude = c.String(),
                        Latitude = c.String(),
                        StreetNumber = c.Int(nullable: false),
                        City = c.String(),
                        PostalCode = c.Int(nullable: false),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TwoLettercountryCode = c.String(maxLength: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PaymentMethods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PaymentType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        LanguageId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        Company_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Companies", t => t.Company_Id)
                .Index(t => t.RoleId)
                .Index(t => t.Company_Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Users", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.Invoices", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Companies", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Invoices", "SenderId", "dbo.Companies");
            DropForeignKey("dbo.Invoices", "ReceiverId", "dbo.Companies");
            DropForeignKey("dbo.Invoices", "PaymentMethodId", "dbo.PaymentMethods");
            DropForeignKey("dbo.Invoices", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.Locations", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Items", "Invoice_Id", "dbo.Invoices");
            DropForeignKey("dbo.Items", "Company_Id", "dbo.Companies");
            DropIndex("dbo.Users", new[] { "Company_Id" });
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Locations", new[] { "CountryId" });
            DropIndex("dbo.Invoices", new[] { "User_Id" });
            DropIndex("dbo.Invoices", new[] { "LocationId" });
            DropIndex("dbo.Invoices", new[] { "PaymentMethodId" });
            DropIndex("dbo.Invoices", new[] { "ReceiverId" });
            DropIndex("dbo.Invoices", new[] { "SenderId" });
            DropIndex("dbo.Companies", new[] { "User_Id" });
            DropIndex("dbo.Companies", new[] { "BusinessNumber" });
            DropIndex("dbo.Items", new[] { "Invoice_Id" });
            DropIndex("dbo.Items", new[] { "Company_Id" });
            DropIndex("dbo.Items", new[] { "CompanyId" });
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.PaymentMethods");
            DropTable("dbo.Countries");
            DropTable("dbo.Locations");
            DropTable("dbo.Invoices");
            DropTable("dbo.Companies");
            DropTable("dbo.Items");
        }
    }
}

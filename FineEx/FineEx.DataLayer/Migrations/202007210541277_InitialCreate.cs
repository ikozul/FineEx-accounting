namespace FineEx.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
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
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.BusinessNumber);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WarehouseQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ItemName = c.String(),
                        CompanyId = c.Int(nullable: false),
                        Invoice_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Invoices", t => t.Invoice_Id)
                .Index(t => t.Invoice_Id);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Approved = c.Boolean(nullable: false),
                        PdfPath = c.String(),
                        SenderId = c.Int(nullable: false),
                        ReceiverId = c.Int(nullable: false),
                        PaymentMethodId = c.Int(nullable: false),
                        InvoiceDate = c.DateTime(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        UniqueIdentifierOfInvoice = c.String(),
                        VatNumber = c.String(),
                        VatSwiftBankClient = c.String(),
                        PriceWithoutVat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VatPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InvoiceNumber = c.String(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PaymentMethods", t => t.PaymentMethodId, cascadeDelete: true)
                .ForeignKey("dbo.Companies", t => t.ReceiverId)
                .ForeignKey("dbo.Companies", t => t.SenderId)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.SenderId)
                .Index(t => t.ReceiverId)
                .Index(t => t.PaymentMethodId)
                .Index(t => t.User_Id);
            
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
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.InvoiceItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InvoiceId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        ItemQuantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Invoices", t => t.InvoiceId, cascadeDelete: true)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .Index(t => t.InvoiceId)
                .Index(t => t.ItemId);
            
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
                "dbo.ItemCompanies",
                c => new
                    {
                        Item_Id = c.Int(nullable: false),
                        Company_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Item_Id, t.Company_Id })
                .ForeignKey("dbo.Items", t => t.Item_Id, cascadeDelete: true)
                .ForeignKey("dbo.Companies", t => t.Company_Id, cascadeDelete: true)
                .Index(t => t.Item_Id)
                .Index(t => t.Company_Id);
            
            CreateTable(
                "dbo.UsersCompanies",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.CompanyId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CompanyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Locations", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.InvoiceItems", "ItemId", "dbo.Items");
            DropForeignKey("dbo.InvoiceItems", "InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.Invoices", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.UsersCompanies", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.UsersCompanies", "UserId", "dbo.Users");
            DropForeignKey("dbo.Invoices", "SenderId", "dbo.Companies");
            DropForeignKey("dbo.Invoices", "ReceiverId", "dbo.Companies");
            DropForeignKey("dbo.Invoices", "PaymentMethodId", "dbo.PaymentMethods");
            DropForeignKey("dbo.Items", "Invoice_Id", "dbo.Invoices");
            DropForeignKey("dbo.ItemCompanies", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.ItemCompanies", "Item_Id", "dbo.Items");
            DropIndex("dbo.UsersCompanies", new[] { "CompanyId" });
            DropIndex("dbo.UsersCompanies", new[] { "UserId" });
            DropIndex("dbo.ItemCompanies", new[] { "Company_Id" });
            DropIndex("dbo.ItemCompanies", new[] { "Item_Id" });
            DropIndex("dbo.Locations", new[] { "CountryId" });
            DropIndex("dbo.InvoiceItems", new[] { "ItemId" });
            DropIndex("dbo.InvoiceItems", new[] { "InvoiceId" });
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Invoices", new[] { "User_Id" });
            DropIndex("dbo.Invoices", new[] { "PaymentMethodId" });
            DropIndex("dbo.Invoices", new[] { "ReceiverId" });
            DropIndex("dbo.Invoices", new[] { "SenderId" });
            DropIndex("dbo.Items", new[] { "Invoice_Id" });
            DropIndex("dbo.Companies", new[] { "BusinessNumber" });
            DropTable("dbo.UsersCompanies");
            DropTable("dbo.ItemCompanies");
            DropTable("dbo.Locations");
            DropTable("dbo.InvoiceItems");
            DropTable("dbo.Countries");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.PaymentMethods");
            DropTable("dbo.Invoices");
            DropTable("dbo.Items");
            DropTable("dbo.Companies");
        }
    }
}

Create DATABASE FineEx
GO
USE FineEx
GO

CREATE TABLE [Invoice] (
  [IdInvoice] integer PRIMARY KEY IDENTITY(1, 1),
  [Incoming] bit,
  [SenderCompanyId] integer,
  [RecipientCompanyId] integer,
  [Date] datetime,
  [LocationId] integer,
  [DueDate] datetime,
  [DeliveryDate] datetime,
  [InvoiceNumber] nvarchar(255),
  [EmployeeId] nvarchar(255),
  [PaymentMethod] nvarchar(255),
  [ProtectedCodeOfSupplier] nvarchar(255),
  [UniqueIdentifierOfInvoice] nvarchar(255),
  [VatNumber] nvarchar(255),
  [VatSwiftBankClient] nvarchar(255)
)
GO

CREATE TABLE [Item] (
  [IdItem] integer PRIMARY KEY IDENTITY(1, 1),
  [InvoiceId] integer,
  [Name] nvarchar(255),
  [Price] float,
  [Amount] integer,
  [CompanyId] integer
)
GO

CREATE TABLE [User] (
  [IdUser] integer PRIMARY KEY IDENTITY(1, 1),
  [Name] nvarchar(255),
  [Surname] nvarchar(255),
  [Salary] float,
  [CompanyId] integer,
  [Password] nvarchar(255),
  [IdCardNumber] nvarchar(255),
  [IdNumber] nvarchar(255),
  [IsActive] bit
)
GO

CREATE TABLE [Role] (
  [IdRole] integer PRIMARY KEY,
  [Name] nvarchar(255)
)
GO

CREATE TABLE [EmployeeRole] (
  [UserId] integer,
  [RoleId] integer
)
GO

CREATE TABLE [Company] (
  [IdCompany] integer PRIMARY KEY,
  [Name] nvarchar(255),
  [Address] nvarchar(255),
  [LocationId] integer,
  [Iban] nvarchar(255),
  [Email] nvarchar(255),
  [IsActive] bit,
  [InsertDate] datetime,
  [UpdateDate] datetime,
  [DeleteDate] datetime
)
GO

CREATE TABLE [Location] (
  [IdLocation] integer PRIMARY KEY IDENTITY(1, 1),
  [X] float,
  [Y] float,
  [StreetName] nvarchar(255),
  [StreetNumber] integer,
  [City] nvarchar(255),
  [PostalCode] integer,
  [Country] nvarchar(255)
)
GO

ALTER TABLE [Invoice] ADD FOREIGN KEY ([SenderCompanyId]) REFERENCES [Company] ([IdCompany])
GO

ALTER TABLE [Invoice] ADD FOREIGN KEY ([RecipientCompanyId]) REFERENCES [Company] ([IdCompany])
GO

ALTER TABLE [Invoice] ADD FOREIGN KEY ([EmployeeId]) REFERENCES [User] ([IdUser])
GO

ALTER TABLE [Invoice] ADD FOREIGN KEY ([LocationId]) REFERENCES [Location] ([IdLocation])
GO

ALTER TABLE [Company] ADD FOREIGN KEY ([LocationId]) REFERENCES [Location] ([IdLocation])
GO

ALTER TABLE [Item] ADD FOREIGN KEY ([InvoiceId]) REFERENCES [Invoice] ([IdInvoice])
GO

ALTER TABLE [Item] ADD FOREIGN KEY ([CompanyId]) REFERENCES [Company] ([IdCompany])
GO

ALTER TABLE [User] ADD FOREIGN KEY ([CompanyId]) REFERENCES [Company] ([IdCompany])
GO

ALTER TABLE [EmployeeRole] ADD FOREIGN KEY ([UserId]) REFERENCES [User] ([IdUser])
GO

ALTER TABLE [EmployeeRole] ADD FOREIGN KEY ([RoleId]) REFERENCES [Role] ([IdRole])
GO

INSERT INTO [Role] ([IdRole], [Name]) VALUES
  (100, 'Site admin'),
  (90, 'Tech support'),
  (50, 'Company admin'),
  (40, 'Sales manager'),
  (30, 'Procurement manager'),
  (20, 'Accountant')
GO

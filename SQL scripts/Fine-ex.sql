CREATE TABLE [Invoice] (
  [IdInvoice] integer PRIMARY KEY IDENTITY(1, 1),
  [Incoming] bit,
  [CompanyId] integer,
  [RecepientId] integer,
  [Date] datetime,
  [Location] nvarchar(255),
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

CREATE TABLE [Recepient] (
  [Id] nvarchar(255) PRIMARY KEY,
  [Name] nvarchar(255),
  [Address] nvarchar(255),
  [Location] nvarchar(255)
)
GO

CREATE TABLE [Item] (
  [IdItem] integer PRIMARY KEY IDENTITY(1, 1),
  [InvoiceId] integer,
  [Name] nvarchar(255),
  [Price] double,
  [Amount] integer,
  [CompanyId] integer
)
GO

CREATE TABLE [Employee] (
  [IdEmployee] integer PRIMARY KEY IDENTITY(1, 1),
  [Name] nvarchar(255),
  [Surname] nvarchar(255),
  [Salary] double,
  [CompanyId] integer
)
GO

CREATE TABLE [Role] (
  [IdRole] integer PRIMARY KEY IDENTITY(1, 1),
  [Name] nvarchar(255)
)
GO

CREATE TABLE [EmployeeRole] (
  [EmployeeId] integer,
  [RoleId] integer
)
GO

CREATE TABLE [Company] (
  [Id] integer PRIMARY KEY,
  [Name] nvarchar(255),
  [Address] nvarchar(255),
  [Location] nvarchar(255),
  [Iban] nvarchar(255)
)
GO

ALTER TABLE [Invoice] ADD FOREIGN KEY ([CompanyId]) REFERENCES [Company] ([Id])
GO

ALTER TABLE [Invoice] ADD FOREIGN KEY ([RecepientId]) REFERENCES [Recepient] ([Id])
GO

ALTER TABLE [Invoice] ADD FOREIGN KEY ([EmployeeId]) REFERENCES [Employee] ([IdEmployee])
GO

ALTER TABLE [Item] ADD FOREIGN KEY ([InvoiceId]) REFERENCES [Invoice] ([IdInvoice])
GO

ALTER TABLE [Invoice] ADD FOREIGN KEY ([CompanyId]) REFERENCES [Company] ([Id])
GO

ALTER TABLE [Employee] ADD FOREIGN KEY ([CompanyId]) REFERENCES [Company] ([Id])
GO

ALTER TABLE [EmployeeRole] ADD FOREIGN KEY ([EmployeeId]) REFERENCES [Employee] ([IdEmployee])
GO

ALTER TABLE [EmployeeRole] ADD FOREIGN KEY ([RoleId]) REFERENCES [Role] ([IdRole])
GO

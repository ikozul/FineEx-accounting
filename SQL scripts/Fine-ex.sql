INSERT INTO [Roles] ([Id], [Name]) VALUES
  (100, 'Site admin'),
  (90, 'Tech support'),
  (50, 'Company admin'),
  (40, 'Sales manager'),
  (30, 'Procurement manager'),
  (20, 'Accountant')
GO

select * from Invoices
select * from InvoiceItems
select * from Items
select * from Users
select * from Companies
select * from UsersCompanies
select * from PaymentMethods

insert into PaymentMethods ([PaymentType]) values
('Credit Card'), ('Cash On Delivery'), ('PayPal')

insert into Companies ([BusinessNumber], [BusinessUnit], [Name], [Address], [City], [County], [GLN], [IBAN], [Phone], [PricePrecision], [QuantityPrecision]) values
('99999999927', '', 'Test Company', 'Ilica 212', 'Zagreb', 'Croatia', '', 'HR46546546546465', '123', 2 , 2),
('38429479874', '', 'Another Company', 'Neka Ulica 2', 'Zagreb', 'Croatia', '', 'HR001093229482', '091', 2 , 2)

insert into Users ( [FirstName], [LastName], [Email], [Password], [IsActive], [RoleId]) values (
'Test', 'Test', 'test@test.com', 'eaf900ea8035356e17e0d443e21cf868c0824d3b', 1, 100)

insert into Items ([ItemPrice], [ItemQuantity], [ItemName], [CompanyId]) values
(14.99, 3, 'Test Item', 1),
(9.99, 1, 'Test Item 2', 1),
(49.50, 2, 'Test Item 3', 1),
(3.99, 10, 'Test Item 4', 1),
(24.99, 1, 'Test Item 5', 1)

insert into Invoices ([SenderId], [ReceiverId], [PaymentMethodId], [InvoiceDate], [DueDate], [UniqueIdentifierOfInvoice], [VatNumber], [VatSwiftBankClient], [PriceWithoutVat], [TotalPrice], [VatPercentage], [InvoiceNumber], [User_Id], [Approved], [PdfPath]) values
(1, 2, 1, '20191010', '20200101', '09000323', '283787772723', 'NRSO13498OF', 2000, 2400, 20, 'ABCDEF231-9220', 1, 1, NULL),
(1, 2, 2, '20200404', '20200430', '10320099', '592488913737', 'HUHW239F923', 100, 110, 10, 'GHJK24SJL-2089', 1, 0, NULL),
(1, 2, 3, '20200715', '20200810', '48822200', '849809240498', 'OD4948FWJWB', 12000, 15000, 25, 'OPRS349FB-9220', 1, 1, NULL)

insert into InvoiceItems ([InvoiceId], [ItemId]) values
(1, 1),
(1, 2),
(2, 3),
(2, 4),
(3, 5)

insert into UsersCompanies ([UserId], [CompanyId]) values (1,1)
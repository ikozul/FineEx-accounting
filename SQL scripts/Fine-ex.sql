INSERT INTO [Roles] ([Id], [Name]) VALUES
  (100, 'Site admin'),
  (90, 'Tech support'),
  (50, 'Company admin'),
  (40, 'Sales manager'),
  (30, 'Procurement manager'),
  (20, 'Accountant')
GO

select * from Items
select * from Users
select * from Companies
select * from UsersCompanies

insert into Companies ([BusinessNumber], [BusinessUnit], [Name], [Address], [City], [County], [GLN], [IBAN], [Phone], [PricePrecision], [QuantityPrecision]) values
('99999999927', '', 'Test Company', 'Ilica 212', 'Zagreb', 'Croatia', '', 'HR46546546546465', '123', 2 , 2)

insert into Users ( [FirstName], [LastName], [Email], [Password], [IsActive], [RoleId]) values (
'Test', 'Test', 'test@test.com', 'eaf900ea8035356e17e0d443e21cf868c0824d3b', 1, 100)

insert into UsersCompanies ([UserId], [CompanyId]) values (1,1)
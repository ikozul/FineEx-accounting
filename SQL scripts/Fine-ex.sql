CREATE TABLE [Racun] (
  [idRacun] integer PRIMARY KEY IDENTITY(1, 1),
  [ulazni] bit,
  [TvrtkaOib] integer,
  [primateljOib] integer,
  [datum] datetime,
  [mjesto] nvarchar(255),
  [datumDospijeca] datetime,
  [datumIsporuke] datetime,
  [brojRacuna] nvarchar(255),
  [zaposlenikId] nvarchar(255),
  [nacinPlacanja] nvarchar(255),
  [zki] nvarchar(255),
  [jir] nvarchar(255),
  [pdvId] nvarchar(255),
  [pdvKlijentaSwiftBanke] nvarchar(255)
)
GO

CREATE TABLE [Primatelj] (
  [oib] nvarchar(255) PRIMARY KEY,
  [naziv] nvarchar(255),
  [adresa] nvarchar(255),
  [mjesto] nvarchar(255)
)
GO

CREATE TABLE [Stavka] (
  [idStavka] integer PRIMARY KEY IDENTITY(1, 1),
  [racunId] integer,
  [naziv] nvarchar(255),
  [cijena] double,
  [kolicina] integer,
  [tvrtkaOib] integer
)
GO

CREATE TABLE [Zaposlenik] (
  [idZaposlenik] integer PRIMARY KEY IDENTITY(1, 1),
  [ime] nvarchar(255),
  [prezime] nvarchar(255),
  [placa] double,
  [tvrtkaId] integer
)
GO

CREATE TABLE [Rola] (
  [idRola] integer PRIMARY KEY IDENTITY(1, 1),
  [naziv] nvarchar(255)
)
GO

CREATE TABLE [ZaposlenikRola] (
  [zaposlenikId] integer,
  [rolaId] integer
)
GO

CREATE TABLE [Tvrtka] (
  [oib] integer PRIMARY KEY,
  [naziv] nvarchar(255),
  [adresa] nvarchar(255),
  [mjesto] nvarchar(255),
  [iban] nvarchar(255)
)
GO

ALTER TABLE [Racun] ADD FOREIGN KEY ([TvrtkaOib]) REFERENCES [Tvrtka] ([oib])
GO

ALTER TABLE [Racun] ADD FOREIGN KEY ([primateljOib]) REFERENCES [Primatelj] ([oib])
GO

ALTER TABLE [Racun] ADD FOREIGN KEY ([zaposlenikId]) REFERENCES [Zaposlenik] ([idZaposlenik])
GO

ALTER TABLE [Stavka] ADD FOREIGN KEY ([racunId]) REFERENCES [Racun] ([idRacun])
GO

ALTER TABLE [Stavka] ADD FOREIGN KEY ([tvrtkaOib]) REFERENCES [Tvrtka] ([oib])
GO

ALTER TABLE [Zaposlenik] ADD FOREIGN KEY ([tvrtkaId]) REFERENCES [Tvrtka] ([oib])
GO

ALTER TABLE [ZaposlenikRola] ADD FOREIGN KEY ([zaposlenikId]) REFERENCES [Zaposlenik] ([idZaposlenik])
GO

ALTER TABLE [ZaposlenikRola] ADD FOREIGN KEY ([rolaId]) REFERENCES [Rola] ([idRola])
GO

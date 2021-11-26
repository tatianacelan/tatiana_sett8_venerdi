
create database Rubrica

CREATE TABLE [dbo].[Contatto] (
	[IdContatto] INT    Identity(100,1)       NOT NULL,
	[Cognome] NVARCHAR (50) NOT NULL,
	[Nome] nvarchar(30)         NOT NULL,
	
	PRIMARY KEY CLUSTERED ([IdContatto] ASC)
)


CREATE TABLE [dbo].[Indirizzo] (
	[IdIndirizzo] INT    Identity(800,1)       NOT NULL,
	[Tipologia] NVARCHAR (20) NOT NULL,
	[Via] nvarchar(50)         NOT NULL,
	[Città] nvarchar(30)         NOT NULL,
	[CAP] int not null, 
	[Provincia] nchar(2)         NOT NULL,
	[Nazione] nvarchar(20)         NOT NULL,
	[IdContatto] int  NOT NULL constraint FK_1 foreign key references  Contatto(IdContatto),
    constraint PK_2 PRIMARY KEY  (IdIndirizzo )
	
)

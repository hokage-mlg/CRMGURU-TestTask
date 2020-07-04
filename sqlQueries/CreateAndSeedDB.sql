-- Database creation

CREATE DATABASE [testTaskDB]

GO

-- Tables creation

USE [testTaskDB]

CREATE TABLE [Cities](
Id INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
Name NVARCHAR(25) NOT NULL
);

CREATE TABLE [Regions](
Id INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
Name NVARCHAR(25) NOT NULL
);

CREATE TABLE [Countries](
Id INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
Name NVARCHAR(25) NOT NULL,
CountryCode NVARCHAR(3) NOT NULL,
CapitalId INT NOT NULL FOREIGN KEY REFERENCES Cities(Id),
Area FLOAT NOT NULL,
Population INT NOT NULL,
RegionId INT NOT NULL FOREIGN KEY REFERENCES Regions(Id)
);

GO

-- Filling tables with data

USE [testTaskDB]

INSERT INTO Cities(Name) VALUES ('Moscow'), ('Kiev'), ('Minsk');
INSERT INTO Regions(Name) VALUES ('Eurasia'), ('Europe'), ('Asia');
INSERT INTO Countries(Name, CountryCode, CapitalId, Area, Population, RegionId) VALUES
('Russia', 'RUS', 1, 17100000.0, 144500000, 1),
('Ukraine', 'UKR', 2, 603700.0, 42692393, 2),
('Belarus', 'BLR', 3, 207595.0, 9485000, 2);

GO
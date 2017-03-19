IF EXISTS(SELECT 1 FROM master.dbo.sysdatabases WHERE name = 'SportsStoreDBAM')
BEGIN
  Print '' print  ' *** dropping database SportsStoreDBAM'
  DROP DATABASE SportsStoreDBAM
End
GO
print '' print '*** creating database SportsStoreDBAM'
GO
CREATE DATABASE SportsStoreDBAM
GO

print '' print '*** using database SportsStoreDBAM'
GO
USE [SportsStoreDBAM]
GO


Create table Products
(
	[ProductID] INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(100) NOT NULL,
	[DESCRIPTION] NVARCHAR(500) NOT NULL,
	[CATEGORY] NVARCHAR(50) NOT NULL,
	[PRICE] DECIMAL(16,2) NOT NULL
)

print '*** Inserting Product Test Data ***'
GO
INSERT INTO [dbo].[Products]
	(Name, Description, Category, Price)
	VALUES
	('Kayak', 'A boat for one person', 'Watersports', 275.00),
	('Lifejacket', 'Protective and fashionable', 'Watersports', 48.95),
	('Soccer Ball', 'FIFA-approved size and weight', 'Soccer', 275.00),
	('Corner Flags', 'Give your playing field a professional touch', 'Soccer', 34.95),
	('Stadium', 'Flat-packed 35,000-seat stadium', 'Soccer', 79500.00),
	('Thinking Cap', 'Improve your brain efficieny by 75%', 'Chess', 16.00),
	('Unsteady Chair', 'Secretly give your opponent a disadvantage', 'Chess', 29.95),
	('Human Chess Board', 'A fun game for the family', 'Chess', 75.00),
	('Bing-Bling King', 'Gold-plated, diamond-studded ', 'Chess', 1200.00)
GO
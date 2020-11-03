CREATE DATABASE E_Commerce_MilkTea
GO
USE E_Commerce_MilkTea
GO
CREATE TABLE User_Accounts(
	Username NCHAR(50) NOT NULL,
	Password NCHAR(50) NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Email NCHAR(50) NOT NULL,
	PhoneNumber VARCHAR(20) NOT NULL,
	Address NVARCHAR(100),
	PRIMARY KEY(Username)
)
GO
CREATE TABLE Products(
	ProductId INT PRIMARY KEY NOT NULL,
	Name NVARCHAR(100) NOT NULL,
	Price REAL NOT NULL,
	Imgage_url VARCHAR(50) NOT NULL,
	Desciption TEXT,
)
GO
CREATE TABLE Topping(
	ToppingId INT IDENTITY(1,1),
	Name NVARCHAR(50) NOT NULL,
	Price INT,
	PRIMARY KEY(ToppingID)
)
GO
CREATE TABLE Orders(
	Oder_Time DATETIME NOT NULL,
	Amount INT NOT NULL,
	ProductId INT REFERENCES dbo.Products(ProductId),
	ToppingId INT REFERENCES dbo.Topping(ToppingId),
	Size CHAR,
	Username NCHAR(50) REFERENCES dbo.User_Accounts(Username),
	PRIMARY KEY(Oder_Time, ProductId, Username)
)
GO
CREATE TABLE Carts(
	Username NCHAR(50) REFERENCES dbo.User_Accounts(Username),
	ProductId INT REFERENCES dbo.Products(ProductId),
	Amount INT NOT NULL,
	PRIMARY KEY(Username, productId)
)
GO
CREATE TABLE Acc_Sell_Pro(
	Username NCHAR(50) NOT NULL REFERENCES User_Accounts(Username),
	ProductId INT NOT NULL REFERENCES Products(ProductId),
	Quantity INT DEFAULT 0,
	PRIMARY KEY(Username, ProductId)
)
GO
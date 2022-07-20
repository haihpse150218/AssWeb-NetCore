

CREATE DATABASE eStore
GO
USE eStore
go
CREATE TABLE Member(
	MemberId INT PRIMARY KEY NOT NULL,
	Email VARCHAR(100) NOT NULL,
	CompanyName VARCHAR(40) NOT NULL,
	City VARCHAR(15) NOT NULL,
	Country VARCHAR(15) NOT NULL,
	Password VARCHAR(30) NOT NULL,
)
GO
CREATE TABLE [Order] (
	OrderId INT PRIMARY KEY NOT NULL,
	MemberId INT NOT NULL,
	OrderDate DATETIME NOT NULL,
	RequiredDate DATETIME,
	ShippedDate DATETIME,
	Freight MONEY,
	CONSTRAINT FK_MemberOrder FOREIGN KEY (MemberId) REFERENCES dbo.Member(MemberId),
)
GO
CREATE TABLE Product(
	ProductId INT PRIMARY KEY NOT NULL,
	CategoryId INT NOT NULL,
	ProductName VARCHAR(40) NOT NULL,
	Weight VARCHAR(20) NOT NULL,
	UnitPrice MONEY NOT NULL,
	UnitInStock INT NOT NULL,
)

GO
CREATE TABLE OrderDetail(
	OrderId INT NOT NULL,
	ProductId INT NOT NULL,
	UnitPrice MONEY NOT NULL,
	Quantity INT NOT NULL,
	Discount FLOAT NOT NULL,
	CONSTRAINT FK_OrderOrderDetail FOREIGN KEY (OrderId) REFERENCES dbo.[Order](OrderId),
	CONSTRAINT FK_ProductOrderDetail FOREIGN KEY(ProductId) REFERENCES dbo.Product(ProductId),
	PRIMARY KEY(OrderId,ProductId),
)
GO





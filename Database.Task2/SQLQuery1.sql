
CREATE TABLE Product
(
	Id INT PRIMARY KEY IDENTITY,
	"Name" NVARCHAR(50) NOT NULL
);

CREATE TABLE Category(
	Id INT PRIMARY KEY IDENTITY,
	"Name" NVARCHAR(50) NOT NULL
	);

CREATE TABLE ProductCategory(
	ProductId INT REFERENCES Product (Id),
	CategoryId INT REFERENCES Category (Id),
	PRIMARY KEY (ProductId, CategoryId)
	);

INSERT INTO Product VALUES
	('BMW X5'),
	('Mazda CX-3'),
	('Hyundai H1'),
	('Yutong ZK6127HQ'),
	('Mercedes E200');

INSERT INTO Category VALUES
	('Car'),
	('SUV'),
	('Minivan'),
	('Used');

INSERT INTO ProductCategory VALUES
	(1, 1),
	(1, 2),
	(2, 1),
	(2, 4),
	(3, 1),
	(3, 3);

SELECT p."Name" AS 'Product', c."Name" AS 'Category' 
FROM Product p
LEFT JOIN ProductCategory pc
ON p.Id = pc.ProductId
LEFT JOIN Category c
ON pc.CategoryId = c.Id
CREATE DATABASE backend;
GO

USE backend;

CREATE TABLE GasPrices (
	grade INT primary key,
	price MONEY
);

CREATE TABLE Transactions (
	id INT IDENTITY(1,1) PRIMARY KEY,
	time DATETIME,
	cc VARCHAR(50),
	total MONEY
);

CREATE TABLE TransactionLineItems (
	txid INT,
	line INT,
	descrip VARCHAR(500),
	price MONEY,
	PRIMARY KEY (txid, line),
	FOREIGN KEY (txid) REFERENCES Transactions(id)
);


INSERT INTO GasPrices VALUES (0, 3.11);
INSERT INTO GasPrices VALUES (1, 3.21);
INSERT INTO GasPrices VALUES (2, 3.31);
USE [Northwind]

CREATE TRIGGER tr_OrderQuantity ON [Order Details]
INSTEAD OF INSERT 
AS
BEGIN
DECLARE @Code TINYINT
SELECT @Code = quantity FROM INSERTED
IF (@Code > 50)
PRINT 'Error: Order quantity should not be greater than 50';
ELSE
BEGIN
INSERT INTO [Order Details] (OrderID, ProductID, UnitPrice, Quantity, Discount) 
SELECT OrderID, ProductID, UnitPrice, Quantity, Discount FROM INSERTED
INSERT INTO dbo.OrderInfo_Table SELECT OrderID, Quantity FROM INSERTED
PRINT 'Success: Order Added';
END
END
GO

DROP TRIGGER tr_OrderQuantity

INSERT INTO [Order Details] (OrderID, ProductID, UnitPrice, Quantity, Discount)
VALUES (10248, 11, 14, 40, 0);

DELETE FROM [Order Details] WHERE OrderID = 10248

DELETE FROM OrderInfo_Table WHERE OrderID = 10248
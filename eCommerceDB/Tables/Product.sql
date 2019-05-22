CREATE TABLE [dbo].[Product]
(
    [ProductId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(50) NOT NULL, 
    [Description] VARCHAR(100) NOT NULL DEFAULT '', 
    [Price] DECIMAL(19, 4) NOT NULL CHECK ([Price] >= 0), 
    [Shipping] DECIMAL(19, 4) NOT NULL CHECK ([Shipping] >= 0)
)

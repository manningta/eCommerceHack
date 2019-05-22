CREATE TABLE [dbo].[Product]
(
    [ProductId] INT NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(50) NOT NULL, 
    [Description] VARCHAR(100) NOT NULL DEFAULT '', 
    [Price] DECIMAL(19, 4) NOT NULL, 
    [Shipping] DECIMAL(19, 4) NOT NULL
)

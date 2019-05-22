CREATE TABLE [dbo].[OrderItem]
(
    [OrderItemId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [OrderId] INT NOT NULL FOREIGN KEY References [dbo].[Order](OrderId),
    [ProductId] INT NOT NULL FOREIGN KEY References [dbo].[Product](ProductId), 
    [Quantity] INT NOT NULL DEFAULT 0,
    [TotalCost] DECIMAL(19, 4) NOT NULL CHECK ([TotalCost] >= 0),
    CONSTRAINT OrderItem_Quantity CHECK ([Quantity] >= 0)
)

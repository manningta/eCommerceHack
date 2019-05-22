CREATE TABLE [dbo].[ShoppingCartItem]
(
    [ShoppingCartItemId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [ShoppingCartId] INT NOT NULL FOREIGN KEY References [dbo].[ShoppingCart](ShoppingCartId),
    [ProductId] INT NOT NULL FOREIGN KEY References [dbo].[Product](ProductId),
    [Quantity] INT NOT NULL DEFAULT 0
)

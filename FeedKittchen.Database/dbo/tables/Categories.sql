CREATE TABLE [dbo].[Categories]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(250) NOT NULL, 
    [Ingredient_Id] BIGINT NOT NULL, 
    CONSTRAINT [FK_Categories_Ingredients] FOREIGN KEY ([Ingredient_Id]) REFERENCES [Ingredients]([Id])
)

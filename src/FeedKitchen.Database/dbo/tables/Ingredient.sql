CREATE TABLE [dbo].[Ingredient]
(
	[Id] BIGINT NOT NULL PRIMARY KEY,
    [Name] NVARCHAR(500) NOT NULL, 
    [Url] NVARCHAR(500) NOT NULL, 
    [Recipe_Id] BIGINT NOT NULL,
    CONSTRAINT [FK_Categories_Recipes] FOREIGN KEY ([Recipe_Id]) REFERENCES [Recipes]([Id])
)

CREATE TABLE [dbo].[Ingredient]
(
	[Id] BIGINT IDENTITY(1,1) PRIMARY KEY,
    [Name] NVARCHAR(500) NOT NULL, 
    [Url] NVARCHAR(500) NOT NULL, 
    [RecipeId] BIGINT NOT NULL,
    CONSTRAINT [FK_Categories_Recipes] FOREIGN KEY ([RecipeId]) REFERENCES [Recipes]([Id])
)

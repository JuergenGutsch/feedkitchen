CREATE TABLE [dbo].[Menus]
(
	[Id] BIGINT IDENTITY(1,1) PRIMARY KEY,
    [Title] NVARCHAR(500) NOT NULL, 
    [Description] NVARCHAR(2000) NULL, 
    [LastUpdate] DATETIME2 NOT NULL, 
    [Url] NVARCHAR(500) NOT NULL, 
    [AuthorId] BIGINT NOT NULL, 
    [RecipeId] BIGINT NOT NULL,
    CONSTRAINT [FK_Recipes_Menus] FOREIGN KEY ([RecipeId]) REFERENCES [Recipes]([Id]),
    CONSTRAINT [FK_Authors_Menus] FOREIGN KEY ([AuthorId]) REFERENCES [Authors]([Id])
)

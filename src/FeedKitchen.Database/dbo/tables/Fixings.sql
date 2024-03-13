CREATE TABLE [dbo].[Fixings]
(
	[Id] BIGINT IDENTITY(1,1) PRIMARY KEY,
    [Title] NVARCHAR(500) NOT NULL, 
    [Url] NVARCHAR(500) NOT NULL, 
    [KitchenUri] NVARCHAR(500) NOT NULL, 
    [AuthorId] BIGINT NOT NULL, 
    [PublishingDate] DATETIME2 NOT NULL,
    [Content] NVARCHAR(500) NOT NULL, 
    [Summary] NVARCHAR(500) NOT NULL, 
    [RecipeId] BIGINT NOT NULL,
    CONSTRAINT [FK_Fixings_Recipes] FOREIGN KEY ([RecipeId]) REFERENCES [Recipes]([Id]),
    CONSTRAINT [FK_Fixings_Authors] FOREIGN KEY ([AuthorId]) REFERENCES [Authors]([Id])
)

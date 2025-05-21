CREATE TABLE [dbo].[Fixings]
(
	[Id] BIGINT IDENTITY(1,1) PRIMARY KEY,
    [Title] NVARCHAR(500) NOT NULL, 
    [Url] NVARCHAR(500) NOT NULL, 
    [AuthorName] BIGINT NOT NULL, 
    [AuthorEmail] BIGINT NOT NULL, 
    [PublishingDate] DATETIME2 NOT NULL,
    [Content] NVARCHAR(500) NOT NULL, 
    [Summary] NVARCHAR(500) NOT NULL, 
    [IngredientId] BIGINT NOT NULL,
    CONSTRAINT [FK_Fixings_Ingredients] FOREIGN KEY ([IngredientId]) REFERENCES [Ingredient]([Id]),
)

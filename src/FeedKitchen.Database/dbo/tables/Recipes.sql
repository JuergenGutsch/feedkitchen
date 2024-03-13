CREATE TABLE [dbo].[Recipes]
(
	[Id] BIGINT IDENTITY(1,1) PRIMARY KEY,
    [Title] NVARCHAR(500) NOT NULL, 
    [Description] NVARCHAR(2000) NULL, 
    [LastUpdate] DATETIME2 NOT NULL, 
    [AuthorId] BIGINT NOT NULL, 
    CONSTRAINT [FK_Recipes_Authors] FOREIGN KEY ([AuthorId]) REFERENCES [Authors]([Id])
)

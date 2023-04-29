CREATE TABLE [dbo].[Menus]
(
	[Id] BIGINT NOT NULL PRIMARY KEY,
    [Title] NVARCHAR(500) NOT NULL, 
    [Description] NVARCHAR(2000) NULL, 
    [LastUpdate] DATETIME2 NOT NULL, 
    [Url] NVARCHAR(500) NOT NULL, 
    [Author_Id] BIGINT NOT NULL,
    CONSTRAINT [FK_Recipes_Menus] FOREIGN KEY ([Author_Id]) REFERENCES [Authors]([Id])
)

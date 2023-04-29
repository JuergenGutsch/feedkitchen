CREATE TABLE [dbo].[Ingredients]
(
	[Id] BIGINT NOT NULL PRIMARY KEY,
    [Title] NVARCHAR(500) NOT NULL, 
    [Url] NVARCHAR(500) NOT NULL, 
    [KitchenUri] NVARCHAR(500) NOT NULL, 
    [Author_Id] BIGINT NOT NULL, 
    [PublishingDate] DATETIME2 NOT NULL,
    [Content] NVARCHAR(500) NOT NULL, 
    [Summary] NVARCHAR(500) NOT NULL, 
    CONSTRAINT [FK_Ingredients_Authors] FOREIGN KEY ([Author_Id]) REFERENCES [Authors]([Id]), 
)

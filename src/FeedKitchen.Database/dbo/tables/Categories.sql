CREATE TABLE [dbo].[Categories]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(250) NOT NULL, 
    [Fixing_Id] BIGINT NOT NULL, 
    CONSTRAINT [FK_Categories_Fixings] FOREIGN KEY ([Fixing_Id]) REFERENCES [Fixings]([Id])
)

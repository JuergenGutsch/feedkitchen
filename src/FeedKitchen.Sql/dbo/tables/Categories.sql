CREATE TABLE [dbo].[Categories]
(
	[Id] BIGINT IDENTITY(1,1) PRIMARY KEY,
    [Name] NVARCHAR(250) NOT NULL, 
    [FixingId] BIGINT NOT NULL, 
    CONSTRAINT [FK_Categories_Fixings] FOREIGN KEY ([FixingId]) REFERENCES [Fixings]([Id])
)

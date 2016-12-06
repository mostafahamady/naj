CREATE TABLE [Fee].[Municipality]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT (newid()), 
    [Name] NVARCHAR(50) NOT NULL, 
    [SegementId] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [FK_Municipality_Segement] FOREIGN KEY ([SegementId]) REFERENCES [Fee].[Segement]([Id])
)

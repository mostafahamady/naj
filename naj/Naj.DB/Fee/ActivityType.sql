CREATE TABLE [Fee].[ActivityType]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT (newid()), 
    [Name] NVARCHAR(200) NOT NULL, 
    [IsAccomendation] BIT NOT NULL
)

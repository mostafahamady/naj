CREATE TABLE [Fee].[Activity]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT (newid()), 
    [Name] NVARCHAR(MAX) NOT NULL, 
    [Code] NVARCHAR(10) NOT NULL, 
    [MainActivityId] UNIQUEIDENTIFIER NOT NULL,
	[ActivityTypeId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [FK_Activity_MainActivity] FOREIGN KEY ([MainActivityId]) REFERENCES [Fee].[MainActivity]([Id]),
	CONSTRAINT [FK_Activity_ActivityType] FOREIGN KEY ([ActivityTypeId]) REFERENCES [Fee].[ActivityType]([Id])
)

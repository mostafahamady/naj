CREATE TABLE [Fee].[ItemValue]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT (newid()), 
    [Value] decimal(18, 2) NULL, 
    [ItemId] UNIQUEIDENTIFIER NOT NULL, 
    [ItemOperationId] UNIQUEIDENTIFIER NULL, 
    [SliceId] UNIQUEIDENTIFIER NULL, 
    [BuildingUsageId] UNIQUEIDENTIFIER NULL, 
    [ActivityTypeId] UNIQUEIDENTIFIER NULL, 
    [AccomendationId] UNIQUEIDENTIFIER NULL, 
    [UnitId] UNIQUEIDENTIFIER NULL, 
    [SegementId] UNIQUEIDENTIFIER NULL, 
    [Duration] INT NULL, 
    [DurationId] UNIQUEIDENTIFIER NULL, 
    CONSTRAINT [FK_ItemValue_Item] FOREIGN KEY ([ItemId]) REFERENCES [Fee].[Item]([Id]),
	CONSTRAINT [FK_ItemValue_ItemOperation] FOREIGN KEY ([ItemOperationId]) REFERENCES [Fee].[ItemOperation]([Id]),
	CONSTRAINT [FK_ItemValue_Slice] FOREIGN KEY ([SliceId]) REFERENCES [Fee].[Slice]([Id]),
	CONSTRAINT [FK_ItemValue_BuildingUsage] FOREIGN KEY ([BuildingUsageId]) REFERENCES [Fee].[BuildingUsage]([Id]),
	CONSTRAINT [FK_ItemValue_ActivityType] FOREIGN KEY ([ActivityTypeId]) REFERENCES [Fee].[ActivityType]([Id]),
	CONSTRAINT [FK_ItemValue_Accomendation] FOREIGN KEY ([AccomendationId]) REFERENCES [Fee].[Accomendation]([Id]),
	CONSTRAINT [FK_ItemValue_Unit] FOREIGN KEY ([UnitId]) REFERENCES [Fee].[Unit]([Id]),
	CONSTRAINT [FK_ItemValue_Segement] FOREIGN KEY ([SegementId]) REFERENCES [Fee].[Segement]([Id])
)

﻿CREATE TABLE [Fee].[Slice]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT (newid()), 
    [From] INT NOT NULL, 
    [To] INT NOT NULL, 
    [UnitId] UNIQUEIDENTIFIER NOT NULL,
	[SliceTypeId] UNIQUEIDENTIFIER NULL, 
    CONSTRAINT [FK_Slice_Unit] FOREIGN KEY ([UnitId]) REFERENCES [Fee].[Unit]([Id]),
	CONSTRAINT [FK_Slice_SliceType] FOREIGN KEY ([SliceTypeId]) REFERENCES [Fee].[SliceType]([Id]),
)

﻿CREATE TABLE [Fee].[BuildingUsage]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT (newid()), 
    [Name] NVARCHAR(50) NOT NULL
)

﻿CREATE TABLE [Fee].[Duration]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT (newid()), 
    [Name] NVARCHAR(50) NOT NULL
)

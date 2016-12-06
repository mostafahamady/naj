CREATE TABLE [Fee].[Accomendation]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT (newid()), 
    [ServiceTypeId] UNIQUEIDENTIFIER NOT NULL,
	[ServiceRateId] UNIQUEIDENTIFIER NOT NULL, 
    [ServiceClassId] UNIQUEIDENTIFIER NOT NULL--, 
    CONSTRAINT [FK_Accomendation_ServiceType] FOREIGN KEY ([ServiceTypeId]) REFERENCES [Fee].[ServiceType]([Id]),
	CONSTRAINT [FK_Accomendation_ServiceRate] FOREIGN KEY ([ServiceRateId]) REFERENCES [Fee].[ServiceRate]([Id]),
	CONSTRAINT [FK_Accomendation_ServiceClass] FOREIGN KEY ([ServiceClassId]) REFERENCES [Fee].[ServiceClass]([Id])
)

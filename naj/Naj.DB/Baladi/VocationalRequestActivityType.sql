CREATE TABLE [Baladi].[VocationalRequestActivityType] (
    [Id]                    UNIQUEIDENTIFIER NOT NULL DEFAULT (newid()),
    [VocationalRequestId]   UNIQUEIDENTIFIER NOT NULL,
    [RequestActivityTypeId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_VocationalRequestActivityType] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_RequestActivityType] FOREIGN KEY ([RequestActivityTypeId]) REFERENCES [Baladi].[RequestActivityType] ([Id]),
    CONSTRAINT [FK_VocationalRequest] FOREIGN KEY ([VocationalRequestId]) REFERENCES [Baladi].[VocationalRequest] ([Id])
);


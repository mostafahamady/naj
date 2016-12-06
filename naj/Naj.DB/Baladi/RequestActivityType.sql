CREATE TABLE [Baladi].[RequestActivityType] (
    [Id]                       UNIQUEIdENTIFIER CONSTRAINT [DF_RequestActivityType_Id] DEFAULT (newId()) NOT NULL,
    [ActivityTypeId]           INT              NOT NULL,
    [SubActivityTypeId]        INT              NOT NULL,
    [DetailedActivityTypeId]   INT              NULL,
    [ActivityTypeCode]         NVARCHAR (50)    NOT NULL,
    [SubActivityTypeCode]      NVARCHAR (50)    NOT NULL,
    [DetailedActivityTypeCode] NVARCHAR (50)    NULL,
    CONSTRAINT [PK_RequestActivityType] PRIMARY KEY CLUSTERED ([Id] ASC)
);


CREATE TABLE [System].[Menu] (
    [Id]       UNIQUEIDENTIFIER CONSTRAINT [DF_Menu_Id] DEFAULT (newid()) NOT NULL,
    [Name]     NVARCHAR (50)    NOT NULL,
    [Title]    NVARCHAR (200)   NOT NULL,
    [Sort]     INT              NOT NULL,
    [Icon]     NVARCHAR (MAX)   NULL,
    [ModuleId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Module] FOREIGN KEY ([ModuleId]) REFERENCES [System].[Module] ([Id])
);


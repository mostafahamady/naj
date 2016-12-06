CREATE TABLE [Baladi].[RequestSubmitterInfo] (
    [Id]                    UNIQUEIDENTIFIER CONSTRAINT [DF_RequestSubmitterInfo_Id] DEFAULT (newid()) NOT NULL,
    [FullName]              NVARCHAR (500)   NULL,
    [IdentityNumber]        NVARCHAR (50)    NULL,
    [Mobile]                NVARCHAR (50)    NULL,
    [Email]                 NVARCHAR (50)    NULL,
    [BirthDate]             DATETIME         NULL,
    [IdentityTypeId]        INT              NULL,
    [IdentityIssuanceDate]  DATETIME         NULL,
    [IdentityExpiredDate]   DATETIME         NULL,
    [GenderId]              INT              NULL,
    [NationalityId]         INT              NULL,
    [IdentityIssuancePalce] NVARCHAR (50)    NULL,
    [FirstName]             NVARCHAR (50)    NULL,
    [SecondName]            NVARCHAR (50)    NULL,
    [ThirdName]             NVARCHAR (50)    NULL,
    [FamilyName]            NVARCHAR (50)    NULL,
    [InvestorId]            BIGINT           NOT NULL,
    CONSTRAINT [PK_RequestSubmitterInfo] PRIMARY KEY CLUSTERED ([Id] ASC)
);


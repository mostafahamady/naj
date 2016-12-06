﻿CREATE TABLE [Baladi].[VocationalRequest] (
    [Id]                        UNIQUEIDENTIFIER CONSTRAINT [DF_VocationalRequest_Id] DEFAULT (newid()) NOT NULL,
    [RequestNumber]             NVARCHAR (50)    NOT NULL,
    [CreatedOn]                 DATETIME         NOT NULL,
    [EngineeringOfficeId]       INT              NULL,
    [EngineeringOfficeCode]     NVARCHAR (50)    NULL,
    [StatusId]                  INT              NOT NULL,
    [MunicipalityId]            UNIQUEIDENTIFIER NOT NULL,
    [SubMunicipalityId]         UNIQUEIDENTIFIER NOT NULL,
    [AuthorizationNumber]       NVARCHAR (50)    NULL,
    [AuthorizationDate]         DATETIME         NULL,
    [FirstName]                 NVARCHAR (50)    NULL,
    [SecondName]                NVARCHAR (50)    NULL,
    [ThirdName]                 NVARCHAR (50)    NULL,
    [LastName]                  NVARCHAR (50)    NULL,
    [IdentityTypeId]            INT              NULL,
    [IdentityNo]                NVARCHAR (50)    NULL,
    [IdentitySource]            NVARCHAR (50)    NULL,
    [IdentityIssueDate]         DATETIME         NULL,
    [IdentityEndDate]           DATETIME         NULL,
    [CompanyName]               NVARCHAR (50)    NULL,
    [CommercialRecordNumber]    NVARCHAR (50)    NULL,
    [CRIssueDate]               DATETIME         NULL,
    [CRExpirationDate]          DATETIME         NULL,
    [CRSource]                  NVARCHAR (50)    NULL,
    [ShopName]                  NVARCHAR (50)    NULL,
    [ActivityId]                INT              NULL,
    [ShopArea]                  FLOAT (53)       NOT NULL,
    [HolesCount]                INT              NOT NULL,
    [ShopAddress]               NVARCHAR (50)    NOT NULL,
    [BoardArea]                 FLOAT (53)       NOT NULL,
    [BoardTypeId]               INT              NOT NULL,
    [BuildingLicensingNumber]   NVARCHAR (50)    NOT NULL,
    [BuildingLicensingDate]     DATETIME         NOT NULL,
    [PlotNo]                    NVARCHAR (50)    NULL,
    [Latitude]                  NVARCHAR (50)    NULL,
    [Longitude]                 NVARCHAR (50)    NULL,
    [LocationDescription]       NVARCHAR (50)    NULL,
    [LocationStreet]            NVARCHAR (50)    NULL,
    [LocationDistrict]          NVARCHAR (50)    NULL,
    [LocationSubDistrict]       NVARCHAR (50)    NULL,
    [LocationMunicipal]         NVARCHAR (50)    NULL,
    [LocationSubMunicipalityId] UNIQUEIDENTIFIER NULL,
    [LocationMainDistrictId]    INT              NULL,
    [LocationSubDistrictId]     INT              NULL,
    [LocationStreetId]          INT              NULL,
    [LocationMainDistrictCode]  NVARCHAR (50)    NULL,
    [LocationSubDistrictCode]   NVARCHAR (50)    NULL,
    [LocationStreetCode]        NVARCHAR (50)    NULL,
    [RequestSubmitterTypeId]    INT              NULL,
    [UserTypeId]                INT              NULL,
    [Attachments]               VARBINARY (MAX)  NULL,
    [RequestSubmitterInfoId]    UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_VocationalRequest] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_RequestSubmitterInfo] FOREIGN KEY ([RequestSubmitterInfoId]) REFERENCES [Baladi].[RequestSubmitterInfo] ([Id])
);


﻿CREATE TABLE [dbo].[Empresa] (
    [idEmpresa] INT          NOT NULL IDENTITY,
    [idUsuario] INT          NULL,
    [Nombre]    VARCHAR (50) NULL,
    [RUC]       VARCHAR (11) NULL,
    [direccion] VARCHAR (40) NULL,
    [telefono]  VARCHAR (30) NULL,
    PRIMARY KEY CLUSTERED ([idEmpresa] ASC),
    FOREIGN KEY ([idUsuario]) REFERENCES [dbo].[Usuario] ([idUsuario])
);


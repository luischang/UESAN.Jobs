CREATE TABLE [dbo].[Postulante] (
    [IdPostulante] INT          NOT NULL IDENTITY,
    [idUsuario]    INT          NULL,
    [Nombre]       VARCHAR (50) NULL,
    [DNI]          VARCHAR (10) NULL,
    [direccion]    VARCHAR (40) NULL,
    [telefono]     VARCHAR (30) NULL,
    [CV]           VARCHAR(50)        NULL,
    [certificados] VARCHAR(50)        NULL,
    PRIMARY KEY CLUSTERED ([IdPostulante] ASC),
    FOREIGN KEY ([idUsuario]) REFERENCES [dbo].[Usuario] ([idUsuario])
);


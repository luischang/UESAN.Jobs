CREATE TABLE [dbo].[Oferta] (
    [idOferta]       INT          NOT NULL IDENTITY,
    [idEmpresa]      INT          NULL,
    [puesto]         VARCHAR (50) NULL,
    [descripcion]    VARCHAR (30) NULL,
    [requisitos]     VARCHAR (40) NULL,
    [certificados]   VARCHAR(50)        NULL,
    [funciones]      VARCHAR (50) NULL,
    [ubicacion]      VARCHAR (50) NULL,
    [modalidad]      VARCHAR (50) NULL,
    [estado]         BIT NULL,
    [Fecha_Creacion] DATETIME     NULL,
    [numeroPostulantes] INT NULL, 
    PRIMARY KEY CLUSTERED ([idOferta] ASC),
    FOREIGN KEY ([idEmpresa]) REFERENCES [dbo].[Empresa] ([idEmpresa])
);


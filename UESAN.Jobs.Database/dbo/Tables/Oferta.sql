CREATE TABLE [dbo].[Oferta] (
    [idOferta]       INT          NOT NULL,
    [idEmpresa]      INT          NULL,
    [puesto]         VARCHAR (50) NULL,
    [descripcion]    VARCHAR (30) NULL,
    [requisitos]     VARCHAR (40) NULL,
    [certificados]   IMAGE        NULL,
    [funciones]      VARCHAR (50) NULL,
    [ubicacion]      VARCHAR (50) NULL,
    [modalidad]      VARCHAR (50) NULL,
    [estado]         VARCHAR (50) NULL,
    [Fecha_Creacion] DATETIME     NULL,
    PRIMARY KEY CLUSTERED ([idOferta] ASC),
    FOREIGN KEY ([idEmpresa]) REFERENCES [dbo].[Empresa] ([idEmpresa])
);


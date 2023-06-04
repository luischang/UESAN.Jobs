CREATE TABLE [dbo].[Usuario] (
    [idUsuario] INT          NOT NULL IDENTITY,
    [tipo]      VARCHAR (50) NULL,
    [estado]    BIT          NULL,
    [correo]    VARCHAR (50) NULL,
    [password]  VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([idUsuario] ASC)
);


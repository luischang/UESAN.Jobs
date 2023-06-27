CREATE TABLE [dbo].[Archivos]
(
	[IdArchivo] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IdPostulante] INT NULL, 
    [NombreArchivo] NCHAR(100) NULL, 
    [tipo] NCHAR(100) NULL, 
    [estado] BIT NULL
    FOREIGN KEY ([IdPostulante]) REFERENCES [dbo].[Postulante] ([IdPostulante])
)

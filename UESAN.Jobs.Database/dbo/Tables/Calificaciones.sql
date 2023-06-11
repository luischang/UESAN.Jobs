CREATE TABLE [dbo].[Calificaciones]
(
	[idEmpresa] INT NOT NULL, 
    [IdPostulante] INT NOT NULL, 
    [Calificacion] INT NULL, 
    [Estado] BIT NULL, 
    FOREIGN KEY ([idEmpresa]) REFERENCES [dbo].[Empresa] ([idEmpresa]),
    FOREIGN KEY ([IdPostulante]) REFERENCES [dbo].[Postulante] ([IdPostulante])
)

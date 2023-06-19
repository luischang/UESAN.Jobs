CREATE TABLE [dbo].[CompetenciasPostulante]
(
    [IdCompetenciaPostulante] INT NOT NULL PRIMARY KEY IDENTITY, 
	[IdCompetencia] INT NOT NULL, 
    [IdPostulante] INT NOT NULL, 
    [Estado] BIT NULL, 
    FOREIGN KEY ([IdCompetencia]) REFERENCES [dbo].[Competencias] ([IdCompetencia]),
    FOREIGN KEY ([IdPostulante]) REFERENCES [dbo].[Postulante] ([IdPostulante]), 
)

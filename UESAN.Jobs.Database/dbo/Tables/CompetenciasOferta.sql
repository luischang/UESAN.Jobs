CREATE TABLE [dbo].[CompetenciasOferta]
(
    [IdCompetenciaOferta] INT NOT NULL PRIMARY KEY IDENTITY, 
	[IdCompetencia] INT NOT NULL, 
    [IdOferta] INT NOT NULL, 
    [Estado] BIT NULL, 
    FOREIGN KEY ([IdCompetencia]) REFERENCES [dbo].[Competencias] ([IdCompetencia]),
    FOREIGN KEY ([IdOferta]) REFERENCES [dbo].[Oferta] ([IdOferta]), 
) 

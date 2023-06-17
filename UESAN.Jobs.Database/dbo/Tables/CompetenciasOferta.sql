CREATE TABLE [dbo].[CompetenciasOferta]
(
	[IdCompetencia] INT NOT NULL, 
    [IdOferta] INT NOT NULL, 
    [Estado] BIT NULL, 
    FOREIGN KEY ([IdCompetencia]) REFERENCES [dbo].[Competencias] ([IdCompetencia]),
    FOREIGN KEY ([IdOferta]) REFERENCES [dbo].[Oferta] ([IdOferta]), 
    CONSTRAINT [PK_CompetenciasOferta] PRIMARY KEY ([IdOferta])
) 

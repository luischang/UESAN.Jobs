CREATE TABLE [dbo].[OfertaPostular] (
    [idOfertaPostular] INT      NOT NULL IDENTITY,
    [idOferta]         INT      NULL,
    [idPostulante]     INT      NULL,
    [fecha]            DATETIME NULL,
    [estado]           BIT      NULL,
    PRIMARY KEY CLUSTERED ([idOfertaPostular] ASC),
    CONSTRAINT [idOferta] FOREIGN KEY ([idOferta]) REFERENCES [dbo].[Oferta] ([idOferta]),
    CONSTRAINT [idPostulante] FOREIGN KEY ([idPostulante]) REFERENCES [dbo].[Postulante] ([IdPostulante])
);


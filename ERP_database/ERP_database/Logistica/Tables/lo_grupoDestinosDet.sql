CREATE TABLE [Logistica].[lo_grupoDestinosDet] (
    [IdGrupoDDet]       INT IDENTITY (1, 1) NOT NULL,
    [IdGrupoD]          INT NOT NULL,
    [IdCatalogoDestino] INT NOT NULL,
    CONSTRAINT [PK_lo_grupoDestinosDet] PRIMARY KEY CLUSTERED ([IdGrupoDDet] ASC),
    CONSTRAINT [FK_lo_grupoDestinosDet_lo_catalogo] FOREIGN KEY ([IdCatalogoDestino]) REFERENCES [Logistica].[lo_catalogo] ([IdCatalogo]),
    CONSTRAINT [FK_lo_grupoDestinosDet_lo_grupoDestinos] FOREIGN KEY ([IdGrupoD]) REFERENCES [Logistica].[lo_grupoDestinos] ([IdGrupoD])
);


CREATE TABLE [Logistica].[lo_movimientoCostoHistorico] (
    [IdHistorico]      INT              IDENTITY (1, 1) NOT NULL,
    [IdCatalogoBodega] INT              NOT NULL,
    [IdRecurso]        INT              NOT NULL,
    [Fecha]            DATE             NOT NULL,
    [CantidadTotal]    NUMERIC (18, 10) NOT NULL,
    [CostoTotal]       NUMERIC (18, 10) NOT NULL,
    [CostoPromedio]    NUMERIC (18, 10) NOT NULL,
    [IdMovimiento]     NUMERIC (18)     NOT NULL,
    CONSTRAINT [PK_lo_movimientoCostoHistorico] PRIMARY KEY CLUSTERED ([IdHistorico] ASC),
    CONSTRAINT [FK_lo_movimientoCostoHistorico_lo_catalogo] FOREIGN KEY ([IdCatalogoBodega]) REFERENCES [Logistica].[lo_catalogo] ([IdCatalogo]),
    CONSTRAINT [FK_lo_movimientoCostoHistorico_lo_movimiento] FOREIGN KEY ([IdMovimiento]) REFERENCES [Logistica].[lo_movimiento] ([IdMovimiento]),
    CONSTRAINT [FK_lo_movimientoCostoHistorico_lo_recurso] FOREIGN KEY ([IdRecurso]) REFERENCES [Logistica].[lo_recurso] ([IdRecurso])
);


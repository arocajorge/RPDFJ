CREATE TABLE [Logistica].[lo_movimientoDet] (
    [IdMovimientoDet]  NUMERIC (18)     IDENTITY (1, 1) NOT NULL,
    [IdMovimiento]     NUMERIC (18)     NOT NULL,
    [IdRecurso]        INT              NOT NULL,
    [Cantidad]         NUMERIC (18, 10) NOT NULL,
    [Costo]            NUMERIC (18, 10) NOT NULL,
    [Total]            NUMERIC (18, 10) NOT NULL,
    [CodigoBarra]      VARCHAR (500)    NULL,
    [CodigoBarraDesde] VARCHAR (500)    NULL,
    [CodigoBarraHasta] VARCHAR (500)    NULL,
    CONSTRAINT [PK_lo_movimientoDet] PRIMARY KEY CLUSTERED ([IdMovimientoDet] ASC),
    CONSTRAINT [FK_lo_movimientoDet_lo_movimiento] FOREIGN KEY ([IdMovimiento]) REFERENCES [Logistica].[lo_movimiento] ([IdMovimiento]),
    CONSTRAINT [FK_lo_movimientoDet_lo_recurso] FOREIGN KEY ([IdRecurso]) REFERENCES [Logistica].[lo_recurso] ([IdRecurso])
);




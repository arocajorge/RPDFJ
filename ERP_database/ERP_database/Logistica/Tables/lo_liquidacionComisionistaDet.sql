CREATE TABLE [Logistica].[lo_liquidacionComisionistaDet] (
    [IdLiquidacionDet] INT          IDENTITY (1, 1) NOT NULL,
    [IdLiquidacion]    INT          NOT NULL,
    [IdSucursal]       INT          NOT NULL,
    [IdBodega]         INT          NOT NULL,
    [IdCbteVta]        NUMERIC (18) NOT NULL,
    [Valor]            MONEY        NOT NULL,
    CONSTRAINT [PK_lo_liquidacionComisionistaDet] PRIMARY KEY CLUSTERED ([IdLiquidacionDet] ASC),
    CONSTRAINT [FK_lo_liquidacionComisionistaDet_lo_liquidacionComisionista] FOREIGN KEY ([IdLiquidacion]) REFERENCES [Logistica].[lo_liquidacionComisionista] ([IdLiquidacion])
);


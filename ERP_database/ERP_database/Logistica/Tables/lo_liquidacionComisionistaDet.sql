CREATE TABLE [Logistica].[lo_liquidacionComisionistaDet] (
    [IdLiquidacionDet] INT             IDENTITY (1, 1) NOT NULL,
    [IdLiquidacion]    INT             NOT NULL,
    [IdGuia]           INT             NOT NULL,
    [Valor]            NUMERIC (18, 2) NOT NULL,
    CONSTRAINT [PK_lo_liquidacionComisionistaDet] PRIMARY KEY CLUSTERED ([IdLiquidacionDet] ASC),
    CONSTRAINT [FK_lo_liquidacionComisionistaDet_lo_Guia] FOREIGN KEY ([IdGuia]) REFERENCES [Logistica].[lo_Guia] ([IdGuia]),
    CONSTRAINT [FK_lo_liquidacionComisionistaDet_lo_liquidacionComisionista] FOREIGN KEY ([IdLiquidacion]) REFERENCES [Logistica].[lo_liquidacionComisionista] ([IdLiquidacion])
);






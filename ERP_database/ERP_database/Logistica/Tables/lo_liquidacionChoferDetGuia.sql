CREATE TABLE [Logistica].[lo_liquidacionChoferDetGuia] (
    [IdLiquidacionDet] INT IDENTITY (1, 1) NOT NULL,
    [IdLiquidacion]    INT NOT NULL,
    [IdGuia]           INT NOT NULL,
    CONSTRAINT [PK_lo_liquidacionChoferDetGuia] PRIMARY KEY CLUSTERED ([IdLiquidacionDet] ASC),
    CONSTRAINT [FK_lo_liquidacionChoferDetGuia_lo_Guia] FOREIGN KEY ([IdGuia]) REFERENCES [Logistica].[lo_Guia] ([IdGuia]),
    CONSTRAINT [FK_lo_liquidacionChoferDetGuia_lo_liquidacionChofer] FOREIGN KEY ([IdLiquidacion]) REFERENCES [Logistica].[lo_liquidacionChofer] ([IdLiquidacion])
);


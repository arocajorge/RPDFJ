CREATE TABLE [Logistica].[lo_liquidacionChoferDet] (
    [IdLiquidacionDet]   INT   NOT NULL,
    [IdLiquidacion]      INT   NOT NULL,
    [IdChofer]           INT   NOT NULL,
    [IdVehiculo]         INT   NOT NULL,
    [Viajes]             INT   NOT NULL,
    [Facturado]          MONEY NOT NULL,
    [Comision]           MONEY NOT NULL,
    [Anticipo]           MONEY NOT NULL,
    [Viatico]            MONEY NOT NULL,
    [ViaticoJustificado] MONEY NOT NULL,
    [OtrosDsctos]        MONEY NOT NULL,
    [TotalAPagar]        MONEY NOT NULL,
    CONSTRAINT [PK_lo_liquidacionChoferDet] PRIMARY KEY CLUSTERED ([IdLiquidacionDet] ASC),
    CONSTRAINT [FK_lo_liquidacionChoferDet_lo_chofer] FOREIGN KEY ([IdChofer]) REFERENCES [Logistica].[lo_chofer] ([IdChofer]),
    CONSTRAINT [FK_lo_liquidacionChoferDet_lo_liquidacionChofer] FOREIGN KEY ([IdLiquidacion]) REFERENCES [Logistica].[lo_liquidacionChofer] ([IdLiquidacion]),
    CONSTRAINT [FK_lo_liquidacionChoferDet_lo_vehiculo] FOREIGN KEY ([IdVehiculo]) REFERENCES [Logistica].[lo_vehiculo] ([IdVehiculo])
);


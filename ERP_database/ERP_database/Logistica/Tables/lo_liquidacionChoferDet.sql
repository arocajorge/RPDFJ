CREATE TABLE [Logistica].[lo_liquidacionChoferDet] (
    [IdLiquidacionDet]   INT             IDENTITY (1, 1) NOT NULL,
    [IdLiquidacion]      INT             NOT NULL,
    [IdChofer]           INT             NOT NULL,
    [IdVehiculo]         INT             NOT NULL,
    [Viajes]             INT             NOT NULL,
    [Facturado]          NUMERIC (18, 2) NOT NULL,
    [Comision]           NUMERIC (18, 2) NOT NULL,
    [Anticipo]           NUMERIC (18, 2) NOT NULL,
    [Viatico]            NUMERIC (18, 2) NOT NULL,
    [ViaticoJustificado] NUMERIC (18, 2) NOT NULL,
    [OtrosDsctos]        NUMERIC (18, 2) NOT NULL,
    [TotalAPagar]        NUMERIC (18, 2) NOT NULL,
    CONSTRAINT [PK_lo_liquidacionChoferDet] PRIMARY KEY CLUSTERED ([IdLiquidacionDet] ASC),
    CONSTRAINT [FK_lo_liquidacionChoferDet_lo_chofer] FOREIGN KEY ([IdChofer]) REFERENCES [Logistica].[lo_chofer] ([IdChofer]),
    CONSTRAINT [FK_lo_liquidacionChoferDet_lo_liquidacionChofer] FOREIGN KEY ([IdLiquidacion]) REFERENCES [Logistica].[lo_liquidacionChofer] ([IdLiquidacion]),
    CONSTRAINT [FK_lo_liquidacionChoferDet_lo_vehiculo] FOREIGN KEY ([IdVehiculo]) REFERENCES [Logistica].[lo_vehiculo] ([IdVehiculo])
);






CREATE TABLE [Logistica].[lo_grupoVehiculoTerceroDet] (
    [IdGrupoVDet] INT IDENTITY (1, 1) NOT NULL,
    [IdGrupoV]    INT NOT NULL,
    [IdVehiculo]  INT NOT NULL,
    CONSTRAINT [PK_lo_grupoVehiculoTerceroDet] PRIMARY KEY CLUSTERED ([IdGrupoVDet] ASC),
    CONSTRAINT [FK_lo_grupoVehiculoTerceroDet_lo_grupoVechiculoTercero] FOREIGN KEY ([IdGrupoV]) REFERENCES [Logistica].[lo_grupoVechiculoTercero] ([IdGrupoV]),
    CONSTRAINT [FK_lo_grupoVehiculoTerceroDet_lo_vehiculo] FOREIGN KEY ([IdVehiculo]) REFERENCES [Logistica].[lo_vehiculo] ([IdVehiculo])
);


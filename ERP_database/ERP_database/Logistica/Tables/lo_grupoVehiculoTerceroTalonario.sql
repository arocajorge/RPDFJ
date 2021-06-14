CREATE TABLE [Logistica].[lo_grupoVehiculoTerceroTalonario] (
    [IdGrupoVTal]    INT             IDENTITY (1, 1) NOT NULL,
    [IdGrupoV]       INT             NOT NULL,
    [IdGrupoDDet]    INT             NOT NULL,
    [CapacidadBines] INT             NOT NULL,
    [Valor]          NUMERIC (18, 2) NOT NULL,
    CONSTRAINT [PK_lo_grupoVehiculoTerceroTalonario] PRIMARY KEY CLUSTERED ([IdGrupoVTal] ASC),
    CONSTRAINT [FK_lo_grupoVehiculoTerceroTalonario_lo_grupoDestinosDet] FOREIGN KEY ([IdGrupoDDet]) REFERENCES [Logistica].[lo_grupoDestinosDet] ([IdGrupoDDet]),
    CONSTRAINT [FK_lo_grupoVehiculoTerceroTalonario_lo_grupoVechiculoTercero] FOREIGN KEY ([IdGrupoV]) REFERENCES [Logistica].[lo_grupoVechiculoTercero] ([IdGrupoV])
);


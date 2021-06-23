CREATE TABLE [Logistica].[lo_Guia] (
    [IdGuia]                 INT             IDENTITY (1, 1) NOT NULL,
    [IdEmpacadora]           INT             NOT NULL,
    [IdVehiculo]             INT             NOT NULL,
    [IdChofer]               INT             NOT NULL,
    [IdPlanificacion]        INT             NULL,
    [Fecha]                  DATE            NOT NULL,
    [Hora]                   DATETIME        NOT NULL,
    [IdCatalogoOrigen]       INT             NOT NULL,
    [IdCatalogoDestino]      INT             NOT NULL,
    [CodDocumentoTipo]       VARCHAR (20)    NOT NULL,
    [Establecimiento]        VARCHAR (3)     NULL,
    [PuntoEmision]           VARCHAR (3)     NULL,
    [NumDocumento]           VARCHAR (20)    NULL,
    [FechaAutorizacion]      DATETIME        NULL,
    [NumeroAutorizacion]     VARCHAR (500)   NULL,
    [IdCatalogoTipoGuia]     INT             NOT NULL,
    [Observacion]            VARCHAR (MAX)   NULL,
    [CapacidadLibrasTotal]   NUMERIC (18, 2) NOT NULL,
    [CapacidadLibrasProg]    NUMERIC (18, 2) NOT NULL,
    [CapacidadBines]         INT             NOT NULL,
    [ValorFlete]             NUMERIC (18, 2) NOT NULL,
    [ValorPorLibra]          NUMERIC (18, 2) NOT NULL,
    [ValorAFacturar]         NUMERIC (18, 2) NOT NULL,
    [IdEmpresa_Ogiro]        INT             NULL,
    [IdCbteCble_Ogiro]       NUMERIC (18)    NULL,
    [IdTipoCbte_Ogiro]       INT             NULL,
    [Piscina]                VARCHAR (50)    NULL,
    [IdCatalogoOrigenFinal]  INT             NOT NULL,
    [IdCatalogoDestinoFinal] INT             NOT NULL,
    [Estado]                 BIT             NOT NULL,
    [IdUsuario]              VARCHAR (50)    NOT NULL,
    [FechaTransaccion]       DATETIME        NOT NULL,
    [IdUsuarioModificacion]  VARCHAR (50)    NULL,
    [FechaModificacion]      DATETIME        NULL,
    [IdUsuarioAnulacion]     VARCHAR (50)    NULL,
    [FechaAnulacion]         DATETIME        NULL,
    [MotivoAnulacion]        VARCHAR (MAX)   NULL,
    CONSTRAINT [PK_lo_Guia] PRIMARY KEY CLUSTERED ([IdGuia] ASC),
    CONSTRAINT [FK_lo_Guia_cp_orden_giro] FOREIGN KEY ([IdEmpresa_Ogiro], [IdCbteCble_Ogiro], [IdTipoCbte_Ogiro]) REFERENCES [dbo].[cp_orden_giro] ([IdEmpresa], [IdCbteCble_Ogiro], [IdTipoCbte_Ogiro]),
    CONSTRAINT [FK_lo_Guia_lo_catalogo] FOREIGN KEY ([IdCatalogoTipoGuia]) REFERENCES [Logistica].[lo_catalogo] ([IdCatalogo]),
    CONSTRAINT [FK_lo_Guia_lo_chofer] FOREIGN KEY ([IdChofer]) REFERENCES [Logistica].[lo_chofer] ([IdChofer]),
    CONSTRAINT [FK_lo_Guia_lo_Empacadora] FOREIGN KEY ([IdEmpacadora]) REFERENCES [Logistica].[lo_Empacadora] ([IdEmpacadora]),
    CONSTRAINT [FK_lo_Guia_lo_PlanificacionPesca1] FOREIGN KEY ([IdPlanificacion]) REFERENCES [Logistica].[lo_PlanificacionPesca] ([IdPlanificacion]),
    CONSTRAINT [FK_lo_Guia_lo_vehiculo] FOREIGN KEY ([IdVehiculo]) REFERENCES [Logistica].[lo_vehiculo] ([IdVehiculo])
);












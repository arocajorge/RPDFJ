﻿CREATE TABLE [Logistica].[lo_GuiaEmpacadora] (
    [IdGuiaEmpacadora]      INT             IDENTITY (1, 1) NOT NULL,
    [IdPlanificacion]       INT             NULL,
    [IdEmpacadora]          INT             NOT NULL,
    [IdVehiculo]            INT             NOT NULL,
    [IdChofer]              INT             NOT NULL,
    [IdCatalogoOrigen]      INT             NOT NULL,
    [IdCatalogoDestino]     INT             NOT NULL,
    [IdCatalogoTipoGuia]    INT             NOT NULL,
    [Establecimiento]       VARCHAR (3)     NOT NULL,
    [PuntoEmision]          VARCHAR (3)     NOT NULL,
    [NumDocumento]          VARCHAR (20)    NOT NULL,
    [Fecha]                 DATE            NOT NULL,
    [Piscina]               VARCHAR (50)    NULL,
    [CapacidadLibrasTotal]  NUMERIC (18, 2) NOT NULL,
    [CapacidadLibrasProg]   NUMERIC (18, 2) NOT NULL,
    [CapacidadBines]        INT             NOT NULL,
    [ValorFlete]            NUMERIC (18, 2) NOT NULL,
    [ValorPorLibra]         NUMERIC (18, 2) NOT NULL,
    [ValorAFacturar]        NUMERIC (18, 2) NOT NULL,
    [Observacion]           VARCHAR (MAX)   NULL,
    [IdGuiaPropia]          INT             NULL,
    [LibrasPescaReal]       NUMERIC (18, 2) NOT NULL,
    [Estado]                BIT             NOT NULL,
    [IdUsuario]             VARCHAR (50)    NOT NULL,
    [FechaTransaccion]      DATETIME        NOT NULL,
    [IdUsuarioModificacion] VARCHAR (50)    NULL,
    [FechaModificacion]     DATETIME        NULL,
    [IdUsuarioAnulacion]    VARCHAR (50)    NULL,
    [FechaAnulacion]        DATETIME        NULL,
    [MotivoAnulacion]       VARCHAR (MAX)   NULL,
    CONSTRAINT [PK_lo_GuiaEmpacadora] PRIMARY KEY CLUSTERED ([IdGuiaEmpacadora] ASC),
    CONSTRAINT [FK_lo_GuiaEmpacadora_lo_catalogo] FOREIGN KEY ([IdCatalogoOrigen]) REFERENCES [Logistica].[lo_catalogo] ([IdCatalogo]),
    CONSTRAINT [FK_lo_GuiaEmpacadora_lo_catalogo1] FOREIGN KEY ([IdCatalogoDestino]) REFERENCES [Logistica].[lo_catalogo] ([IdCatalogo]),
    CONSTRAINT [FK_lo_GuiaEmpacadora_lo_catalogo2] FOREIGN KEY ([IdCatalogoTipoGuia]) REFERENCES [Logistica].[lo_catalogo] ([IdCatalogo]),
    CONSTRAINT [FK_lo_GuiaEmpacadora_lo_chofer] FOREIGN KEY ([IdChofer]) REFERENCES [Logistica].[lo_chofer] ([IdChofer]),
    CONSTRAINT [FK_lo_GuiaEmpacadora_lo_Empacadora] FOREIGN KEY ([IdEmpacadora]) REFERENCES [Logistica].[lo_Empacadora] ([IdEmpacadora]),
    CONSTRAINT [FK_lo_GuiaEmpacadora_lo_PlanificacionPesca] FOREIGN KEY ([IdPlanificacion]) REFERENCES [Logistica].[lo_PlanificacionPesca] ([IdPlanificacion]),
    CONSTRAINT [FK_lo_GuiaEmpacadora_lo_vehiculo] FOREIGN KEY ([IdVehiculo]) REFERENCES [Logistica].[lo_vehiculo] ([IdVehiculo])
);











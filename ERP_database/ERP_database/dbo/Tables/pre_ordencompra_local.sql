﻿CREATE TABLE [dbo].[pre_ordencompra_local] (
    [IdEmpresa]           INT            NOT NULL,
    [IdSucursal]          INT            NOT NULL,
    [IdOrdenCompra]       NUMERIC (18)   NOT NULL,
    [IdProveedor]         NUMERIC (18)   NULL,
    [oc_NumDocumento]     VARCHAR (50)   NULL,
    [oc_fecha]            DATETIME       NOT NULL,
    [oc_observacion]      VARCHAR (1000) NOT NULL,
    [Estado]              CHAR (1)       NOT NULL,
    [CondicionPago]       VARCHAR (150)  NULL,
    [FormaEnvio]          VARCHAR (150)  NULL,
    [IdEstadoAprobacion]  VARCHAR (15)   NOT NULL,
    [co_fecha_aprobacion] DATETIME       NULL,
    [IdUsuario_Aprueba]   VARCHAR (20)   NULL,
    [IdUsuario_Reprue]    VARCHAR (20)   NULL,
    [co_fechaReproba]     DATETIME       NULL,
    [Fecha_Transac]       DATETIME       NULL,
    [Fecha_UltMod]        DATETIME       NULL,
    [IdUsuarioUltMod]     CHAR (20)      NULL,
    [FechaHoraAnul]       DATETIME       NULL,
    [IdUsuarioUltAnu]     CHAR (20)      NULL,
    [EstadoRecepcion]     VARCHAR (15)   NOT NULL,
    [MotivoAnulacion]     VARCHAR (500)  NULL,
    [IdTerminoPago]       VARCHAR (15)   NULL,
    [IdUsuario]           VARCHAR (20)   NULL,
    CONSTRAINT [PK_pre_ordencompra_local] PRIMARY KEY CLUSTERED ([IdEmpresa] ASC, [IdSucursal] ASC, [IdOrdenCompra] ASC)
);

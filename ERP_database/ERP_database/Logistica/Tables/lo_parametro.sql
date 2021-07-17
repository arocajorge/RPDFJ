CREATE TABLE [Logistica].[lo_parametro] (
    [IdParametro]                 INT             IDENTITY (1, 1) NOT NULL,
    [ComisionVehiculoPropio]      NUMERIC (18, 2) NOT NULL,
    [ComisionVehiculoTercero]     NUMERIC (18, 2) NOT NULL,
    [Establecimiento]             VARCHAR (3)     NOT NULL,
    [PuntoEmision]                VARCHAR (3)     NOT NULL,
    [IdRubroAnticipo]             INT             NOT NULL,
    [IdRubroViatico]              INT             NOT NULL,
    [IdMovimientoTipoIngFactProv] INT             NOT NULL,
    [IdMovimientoTipoEgrGuia]     INT             NOT NULL,
    [IdUsuario]                   VARCHAR (50)    NOT NULL,
    [FechaTransaccion]            DATETIME        NOT NULL,
    [IdUsuarioModificacion]       VARCHAR (50)    NULL,
    [FechaModificacion]           DATETIME        NULL,
    [IdUsuarioAnulacion]          VARCHAR (50)    NULL,
    [FechaAnulacion]              DATETIME        NULL,
    [MotivoAnulacion]             VARCHAR (MAX)   NULL,
    CONSTRAINT [PK_lo_parametro] PRIMARY KEY CLUSTERED ([IdParametro] ASC)
);










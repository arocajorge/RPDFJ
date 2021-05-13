CREATE TABLE [Logistica].[lo_parametro] (
    [IdParametro]             INT           IDENTITY (1, 1) NOT NULL,
    [ComisionVehiculoPropio]  MONEY         NOT NULL,
    [ComisionVehiculoTercero] MONEY         NOT NULL,
    [IdUsuario]               VARCHAR (50)  NOT NULL,
    [FechaTransaccion]        DATETIME      NOT NULL,
    [IdUsuarioModificacion]   VARCHAR (50)  NULL,
    [FechaModificacion]       DATETIME      NULL,
    [IdUsuarioAnulacion]      VARCHAR (50)  NULL,
    [FechaAnulacion]          DATETIME      NULL,
    [MotivoAnulacion]         VARCHAR (MAX) NULL,
    CONSTRAINT [PK_lo_parametro] PRIMARY KEY CLUSTERED ([IdParametro] ASC)
);


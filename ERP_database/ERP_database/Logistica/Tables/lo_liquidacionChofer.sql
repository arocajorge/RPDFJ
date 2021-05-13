CREATE TABLE [Logistica].[lo_liquidacionChofer] (
    [IdLiquidacion]         INT           IDENTITY (1, 1) NOT NULL,
    [FechaDesde]            DATE          NOT NULL,
    [FechaHasta]            DATE          NOT NULL,
    [Observacion]           VARCHAR (MAX) NOT NULL,
    [Estado]                BIT           NOT NULL,
    [IdArchivo]             INT           NULL,
    [IdUsuario]             VARCHAR (50)  NOT NULL,
    [FechaTransaccion]      DATETIME      NOT NULL,
    [IdUsuarioModificacion] VARCHAR (50)  NULL,
    [FechaModificacion]     DATETIME      NULL,
    [IdUsuarioAnulacion]    VARCHAR (50)  NULL,
    [FechaAnulacion]        DATETIME      NULL,
    [MotivoAnulacion]       VARCHAR (MAX) NULL,
    CONSTRAINT [PK_lo_liquidacionChofer] PRIMARY KEY CLUSTERED ([IdLiquidacion] ASC)
);


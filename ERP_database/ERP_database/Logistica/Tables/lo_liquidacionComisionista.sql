CREATE TABLE [Logistica].[lo_liquidacionComisionista] (
    [IdLiquidacion]         INT           IDENTITY (1, 1) NOT NULL,
    [IdChofer]              INT           NOT NULL,
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
    CONSTRAINT [PK_lo_liquidacionComisionista] PRIMARY KEY CLUSTERED ([IdLiquidacion] ASC),
    CONSTRAINT [FK_lo_liquidacionComisionista_lo_chofer] FOREIGN KEY ([IdChofer]) REFERENCES [Logistica].[lo_chofer] ([IdChofer])
);


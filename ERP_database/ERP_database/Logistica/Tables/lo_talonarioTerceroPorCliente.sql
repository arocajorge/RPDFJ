CREATE TABLE [Logistica].[lo_talonarioTerceroPorCliente] (
    [IdTalonario]           INT           IDENTITY (1, 1) NOT NULL,
    [IdEmpresa]             INT           NOT NULL,
    [IdCliente]             NUMERIC (18)  NOT NULL,
    [IdCatalogoOrigen]      INT           NOT NULL,
    [IdCatalogoDestino]     INT           NOT NULL,
    [IdUsuario]             VARCHAR (50)  NOT NULL,
    [FechaTransaccion]      DATETIME      NOT NULL,
    [IdUsuarioModificacion] VARCHAR (50)  NULL,
    [FechaModificacion]     DATETIME      NULL,
    [IdUsuarioAnulacion]    VARCHAR (50)  NULL,
    [FechaAnulacion]        DATETIME      NULL,
    [MotivoAnulacion]       VARCHAR (MAX) NULL,
    CONSTRAINT [PK_lo_talonarioTerceroPorCliente] PRIMARY KEY CLUSTERED ([IdTalonario] ASC),
    CONSTRAINT [FK_lo_talonarioTerceroPorCliente_fa_cliente] FOREIGN KEY ([IdEmpresa], [IdCliente]) REFERENCES [dbo].[fa_cliente] ([IdEmpresa], [IdCliente])
);


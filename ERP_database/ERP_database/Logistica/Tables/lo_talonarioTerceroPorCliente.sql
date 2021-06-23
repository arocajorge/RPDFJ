CREATE TABLE [Logistica].[lo_talonarioTerceroPorCliente] (
    [IdTalonario]           INT           IDENTITY (1, 1) NOT NULL,
    [IdEmpacadora]          INT           NOT NULL,
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
    CONSTRAINT [FK_lo_talonarioTerceroPorCliente_lo_Empacadora] FOREIGN KEY ([IdEmpacadora]) REFERENCES [Logistica].[lo_Empacadora] ([IdEmpacadora])
);




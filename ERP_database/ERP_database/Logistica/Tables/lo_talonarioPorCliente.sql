CREATE TABLE [Logistica].[lo_talonarioPorCliente] (
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
    CONSTRAINT [PK_lo_talonarioPorCliente] PRIMARY KEY CLUSTERED ([IdTalonario] ASC),
    CONSTRAINT [FK_lo_talonarioPorCliente_lo_catalogo] FOREIGN KEY ([IdCatalogoDestino]) REFERENCES [Logistica].[lo_catalogo] ([IdCatalogo]),
    CONSTRAINT [FK_lo_talonarioPorCliente_lo_catalogo1] FOREIGN KEY ([IdCatalogoOrigen]) REFERENCES [Logistica].[lo_catalogo] ([IdCatalogo]),
    CONSTRAINT [FK_lo_talonarioPorCliente_lo_Empacadora] FOREIGN KEY ([IdEmpacadora]) REFERENCES [Logistica].[lo_Empacadora] ([IdEmpacadora])
);




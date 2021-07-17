CREATE TABLE [Logistica].[lo_movimientoTipo] (
    [IdMovimientoTipo]       INT           IDENTITY (1, 1) NOT NULL,
    [Signo]                  VARCHAR (1)   NOT NULL,
    [UsoExclusivoSistema]    BIT           NOT NULL,
    [IdCatalogoEstadoAproba] INT           NOT NULL,
    [Descripcion]            VARCHAR (500) NOT NULL,
    [Estado]                 BIT           NOT NULL,
    [IdUsuario]              VARCHAR (50)  NOT NULL,
    [FechaTransaccion]       DATETIME      NOT NULL,
    [IdUsuarioModificacion]  VARCHAR (50)  NULL,
    [FechaModificacion]      DATETIME      NULL,
    [IdUsuarioAnulacion]     VARCHAR (50)  NULL,
    [FechaAnulacion]         DATETIME      NULL,
    [MotivoAnulacion]        VARCHAR (MAX) NULL,
    CONSTRAINT [PK_lo_movimientoTipo] PRIMARY KEY CLUSTERED ([IdMovimientoTipo] ASC),
    CONSTRAINT [FK_lo_movimientoTipo_lo_catalogo] FOREIGN KEY ([IdCatalogoEstadoAproba]) REFERENCES [Logistica].[lo_catalogo] ([IdCatalogo])
);


CREATE TABLE [Logistica].[lo_rubro] (
    [IdRubro]               INT           IDENTITY (1, 1) NOT NULL,
    [Descripcion]           VARCHAR (500) NOT NULL,
    [DescripcionCorta]      VARCHAR (500) NOT NULL,
    [Signo]                 VARCHAR (1)   NOT NULL,
    [SeJustifica]           BIT           NOT NULL,
    [GeneraArchivo]         BIT           NOT NULL,
    [Orden]                 INT           NOT NULL,
    [Estado]                BIT           NOT NULL,
    [IdCtaCble]             VARCHAR (20)  NULL,
    [IdUsuario]             VARCHAR (50)  NOT NULL,
    [FechaTransaccion]      DATETIME      NOT NULL,
    [IdUsuarioModificacion] VARCHAR (50)  NULL,
    [FechaModificacion]     DATETIME      NULL,
    [IdUsuarioAnulacion]    VARCHAR (50)  NULL,
    [FechaAnulacion]        DATETIME      NULL,
    [MotivoAnulacion]       VARCHAR (MAX) NULL,
    CONSTRAINT [PK_lo_rubro] PRIMARY KEY CLUSTERED ([IdRubro] ASC)
);


CREATE TABLE [Logistica].[lo_ArchivoPago] (
    [IdArchivo]             INT           IDENTITY (1, 1) NOT NULL,
    [IdRubro]               INT           NOT NULL,
    [IdBanco]               INT           NOT NULL,
    [IdProceso_bancario]    VARCHAR (25)  NOT NULL,
    [Observacion]           VARCHAR (MAX) NOT NULL,
    [Desde]                 DATE          NOT NULL,
    [Hasta]                 DATE          NOT NULL,
    [FechaConta]            DATE          NOT NULL,
    [Estado]                BIT           NOT NULL,
    [IdUsuario]             VARCHAR (50)  NOT NULL,
    [FechaTransaccion]      DATETIME      NOT NULL,
    [IdUsuarioModificacion] VARCHAR (50)  NULL,
    [FechaModificacion]     DATETIME      NULL,
    [IdUsuarioAnulacion]    VARCHAR (50)  NULL,
    [FechaAnulacion]        DATETIME      NULL,
    [MotivoAnulacion]       VARCHAR (MAX) NULL,
    [IdTipoCbte]            INT           NULL,
    [IdCbteCble]            NUMERIC (18)  NULL,
    CONSTRAINT [PK_lo_ArchivoPago] PRIMARY KEY CLUSTERED ([IdArchivo] ASC),
    CONSTRAINT [FK_lo_ArchivoPago_lo_rubro] FOREIGN KEY ([IdRubro]) REFERENCES [Logistica].[lo_rubro] ([IdRubro])
);


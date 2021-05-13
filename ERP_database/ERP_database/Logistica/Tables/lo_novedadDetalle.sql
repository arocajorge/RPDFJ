CREATE TABLE [Logistica].[lo_novedadDetalle] (
    [IdNovedadDetalle] INT           IDENTITY (1, 1) NOT NULL,
    [IdNovedad]        INT           NOT NULL,
    [FechaJustificado] DATE          NOT NULL,
    [Valor]            MONEY         NOT NULL,
    [Observacion]      VARCHAR (MAX) NULL,
    CONSTRAINT [PK_lo_novedadDetalle] PRIMARY KEY CLUSTERED ([IdNovedadDetalle] ASC),
    CONSTRAINT [FK_lo_novedadDetalle_lo_novedad] FOREIGN KEY ([IdNovedad]) REFERENCES [Logistica].[lo_novedad] ([IdNovedad])
);


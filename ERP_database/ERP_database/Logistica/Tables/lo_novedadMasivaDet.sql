CREATE TABLE [Logistica].[lo_novedadMasivaDet] (
    [IdNovedadMasivaDet] INT             IDENTITY (1, 1) NOT NULL,
    [IdNovedadMasiva]    INT             NOT NULL,
    [IdChofer]           INT             NOT NULL,
    [IdRubro]            INT             NOT NULL,
    [Valor]              NUMERIC (18, 2) NOT NULL,
    [IdNovedad]          INT             NULL,
    CONSTRAINT [PK_lo_novedadMasivaDet] PRIMARY KEY CLUSTERED ([IdNovedadMasivaDet] ASC),
    CONSTRAINT [FK_lo_novedadMasivaDet_lo_chofer] FOREIGN KEY ([IdChofer]) REFERENCES [Logistica].[lo_chofer] ([IdChofer]),
    CONSTRAINT [FK_lo_novedadMasivaDet_lo_novedad] FOREIGN KEY ([IdNovedad]) REFERENCES [Logistica].[lo_novedad] ([IdNovedad]),
    CONSTRAINT [FK_lo_novedadMasivaDet_lo_novedadMasiva] FOREIGN KEY ([IdNovedadMasiva]) REFERENCES [Logistica].[lo_novedadMasiva] ([IdNovedadMasiva]),
    CONSTRAINT [FK_lo_novedadMasivaDet_lo_rubro] FOREIGN KEY ([IdRubro]) REFERENCES [Logistica].[lo_rubro] ([IdRubro])
);


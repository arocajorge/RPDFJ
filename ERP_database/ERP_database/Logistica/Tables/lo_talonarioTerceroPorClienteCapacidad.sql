CREATE TABLE [Logistica].[lo_talonarioTerceroPorClienteCapacidad] (
    [IdCapacidad]    INT             IDENTITY (1, 1) NOT NULL,
    [IdTalonario]    INT             NOT NULL,
    [CapacidadBines] INT             NOT NULL,
    [Valor]          NUMERIC (18, 2) NOT NULL,
    CONSTRAINT [PK_lo_talonarioTerceroPorClienteCapacidad] PRIMARY KEY CLUSTERED ([IdCapacidad] ASC),
    CONSTRAINT [FK_lo_talonarioTerceroPorClienteCapacidad_lo_talonarioTerceroPorCliente] FOREIGN KEY ([IdTalonario]) REFERENCES [Logistica].[lo_talonarioTerceroPorCliente] ([IdTalonario])
);


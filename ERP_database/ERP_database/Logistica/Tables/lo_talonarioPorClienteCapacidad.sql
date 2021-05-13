CREATE TABLE [Logistica].[lo_talonarioPorClienteCapacidad] (
    [IdCapacidad]    INT   IDENTITY (1, 1) NOT NULL,
    [IdTalonario]    INT   NOT NULL,
    [CapacidadBines] INT   NOT NULL,
    [Valor]          MONEY NOT NULL,
    CONSTRAINT [PK_lo_talonarioPorClienteCapacidad] PRIMARY KEY CLUSTERED ([IdCapacidad] ASC),
    CONSTRAINT [FK_lo_talonarioPorClienteCapacidad_lo_talonarioPorCliente] FOREIGN KEY ([IdTalonario]) REFERENCES [Logistica].[lo_talonarioPorCliente] ([IdTalonario])
);


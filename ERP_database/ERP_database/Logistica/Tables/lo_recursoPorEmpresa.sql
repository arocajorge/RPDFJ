CREATE TABLE [Logistica].[lo_recursoPorEmpresa] (
    [IdRecurso]  INT          NOT NULL,
    [IdEmpresa]  INT          NOT NULL,
    [IdProducto] NUMERIC (18) NOT NULL,
    CONSTRAINT [PK_lo_recursoPorEmpresa] PRIMARY KEY CLUSTERED ([IdRecurso] ASC, [IdEmpresa] ASC, [IdProducto] ASC)
);


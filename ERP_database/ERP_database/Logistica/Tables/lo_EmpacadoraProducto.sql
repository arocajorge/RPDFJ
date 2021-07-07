CREATE TABLE [Logistica].[lo_EmpacadoraProducto] (
    [IdEmpacadoraD]      INT          IDENTITY (1, 1) NOT NULL,
    [IdEmpacadora]       INT          NOT NULL,
    [IdCatalogoTipoGuia] INT          NOT NULL,
    [IdEmpresa]          INT          NOT NULL,
    [IdProducto]         NUMERIC (18) NOT NULL,
    CONSTRAINT [PK_lo_EmpacadoraProducto] PRIMARY KEY CLUSTERED ([IdEmpacadoraD] ASC),
    CONSTRAINT [FK_lo_EmpacadoraProducto_in_Producto] FOREIGN KEY ([IdEmpresa], [IdProducto]) REFERENCES [dbo].[in_Producto] ([IdEmpresa], [IdProducto]),
    CONSTRAINT [FK_lo_EmpacadoraProducto_lo_catalogo] FOREIGN KEY ([IdCatalogoTipoGuia]) REFERENCES [Logistica].[lo_catalogo] ([IdCatalogo]),
    CONSTRAINT [FK_lo_EmpacadoraProducto_lo_Empacadora] FOREIGN KEY ([IdEmpacadora]) REFERENCES [Logistica].[lo_Empacadora] ([IdEmpacadora])
);


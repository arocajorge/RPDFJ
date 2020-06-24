CREATE TABLE [dbo].[cp_proveedor_producto] (
    [IdEmpresa]    INT          NOT NULL,
    [IdProveedor]  NUMERIC (18) NOT NULL,
    [Secuencia]    INT          NOT NULL,
    [CodProducto]  VARCHAR (50) NOT NULL,
    [BienServicio] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_cp_proveedor_producto] PRIMARY KEY CLUSTERED ([IdEmpresa] ASC, [IdProveedor] ASC, [Secuencia] ASC),
    CONSTRAINT [FK_cp_proveedor_producto_cp_proveedor] FOREIGN KEY ([IdEmpresa], [IdProveedor]) REFERENCES [dbo].[cp_proveedor] ([IdEmpresa], [IdProveedor])
);


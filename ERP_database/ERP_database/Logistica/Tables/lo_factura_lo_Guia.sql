CREATE TABLE [Logistica].[lo_factura_lo_Guia] (
    [IdEmpresa]  INT          NOT NULL,
    [IdSucursal] INT          NOT NULL,
    [IdBodega]   INT          NOT NULL,
    [IdCbteVta]  NUMERIC (18) NOT NULL,
    [IdGuia]     INT          NOT NULL,
    CONSTRAINT [PK_lo_factura_lo_Guia] PRIMARY KEY CLUSTERED ([IdEmpresa] ASC, [IdSucursal] ASC, [IdBodega] ASC, [IdCbteVta] ASC, [IdGuia] ASC),
    CONSTRAINT [FK_lo_factura_lo_Guia_fa_factura] FOREIGN KEY ([IdEmpresa], [IdSucursal], [IdBodega], [IdCbteVta]) REFERENCES [dbo].[fa_factura] ([IdEmpresa], [IdSucursal], [IdBodega], [IdCbteVta]),
    CONSTRAINT [FK_lo_factura_lo_Guia_lo_Guia] FOREIGN KEY ([IdGuia]) REFERENCES [Logistica].[lo_Guia] ([IdGuia])
);


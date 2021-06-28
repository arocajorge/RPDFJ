CREATE TABLE [Logistica].[lo_factura_lo_Guia] (
    [IdRelacion]       INT          IDENTITY (1, 1) NOT NULL,
    [IdEmpresa]        INT          NOT NULL,
    [IdSucursal]       INT          NOT NULL,
    [IdBodega]         INT          NOT NULL,
    [IdCbteVta]        NUMERIC (18) NOT NULL,
    [IdGuiaEmpacadora] INT          NOT NULL,
    CONSTRAINT [PK_lo_factura_lo_Guia_1] PRIMARY KEY CLUSTERED ([IdRelacion] ASC),
    CONSTRAINT [FK_lo_factura_lo_Guia_fa_factura] FOREIGN KEY ([IdEmpresa], [IdSucursal], [IdBodega], [IdCbteVta]) REFERENCES [dbo].[fa_factura] ([IdEmpresa], [IdSucursal], [IdBodega], [IdCbteVta]),
    CONSTRAINT [FK_lo_factura_lo_Guia_lo_GuiaEmpacadora] FOREIGN KEY ([IdGuiaEmpacadora]) REFERENCES [Logistica].[lo_GuiaEmpacadora] ([IdGuiaEmpacadora])
);




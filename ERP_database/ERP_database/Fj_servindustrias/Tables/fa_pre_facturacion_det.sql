﻿CREATE TABLE [Fj_servindustrias].[fa_pre_facturacion_det] (
    [IdEmpresa]                      INT          NOT NULL,
    [IdPreFacturacion]               NUMERIC (18) NOT NULL,
    [Secuencia]                      INT          NOT NULL,
    [IdGrupo]                        NUMERIC (18) NOT NULL,
    [IdCentroCosto]                  VARCHAR (20) NOT NULL,
    [IdCentroCosto_sub_centro_costo] VARCHAR (20) NOT NULL,
    [IdProducto]                     NUMERIC (18) NOT NULL,
    [subtotal]                       FLOAT (53)   NOT NULL,
    [valor_ganancia]                 FLOAT (53)   NOT NULL,
    [IdCod_Impuesto]                 VARCHAR (25) NOT NULL,
    [por_iva]                        FLOAT (53)   NOT NULL,
    [valor_iva]                      FLOAT (53)   NOT NULL,
    [total]                          FLOAT (53)   NOT NULL,
    [IdEmpresa_vta]                  INT          NULL,
    [IdSucursal]                     INT          NULL,
    [IdBodega]                       INT          NULL,
    [IdCbteVta]                      NUMERIC (18) NULL,
    [IdProceso_prefacturacion]       INT          NOT NULL,
    CONSTRAINT [PK_fa_pre_facturacion_det] PRIMARY KEY CLUSTERED ([IdEmpresa] ASC, [IdPreFacturacion] ASC, [Secuencia] ASC),
    CONSTRAINT [FK_fa_pre_facturacion_det_ct_centro_costo_sub_centro_costo] FOREIGN KEY ([IdEmpresa], [IdCentroCosto], [IdCentroCosto_sub_centro_costo]) REFERENCES [dbo].[ct_centro_costo_sub_centro_costo] ([IdEmpresa], [IdCentroCosto], [IdCentroCosto_sub_centro_costo]),
    CONSTRAINT [FK_fa_pre_facturacion_det_fa_factura] FOREIGN KEY ([IdEmpresa_vta], [IdSucursal], [IdBodega], [IdCbteVta]) REFERENCES [dbo].[fa_factura] ([IdEmpresa], [IdSucursal], [IdBodega], [IdCbteVta]),
    CONSTRAINT [FK_fa_pre_facturacion_det_fa_pre_facturacion] FOREIGN KEY ([IdEmpresa], [IdPreFacturacion]) REFERENCES [Fj_servindustrias].[fa_pre_facturacion] ([IdEmpresa], [IdPreFacturacion]),
    CONSTRAINT [FK_fa_pre_facturacion_det_in_Producto] FOREIGN KEY ([IdEmpresa], [IdProducto]) REFERENCES [dbo].[in_Producto] ([IdEmpresa], [IdProducto]),
    CONSTRAINT [FK_fa_pre_facturacion_det_tb_sis_Impuesto] FOREIGN KEY ([IdCod_Impuesto]) REFERENCES [dbo].[tb_sis_Impuesto] ([IdCod_Impuesto])
);




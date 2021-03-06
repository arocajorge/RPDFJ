﻿CREATE TABLE [dbo].[in_producto_x_tb_bodega] (
    [IdEmpresa]                           INT          NOT NULL,
    [IdSucursal]                          INT          NOT NULL,
    [IdBodega]                            INT          NOT NULL,
    [IdProducto]                          NUMERIC (18) NOT NULL,
    [pr_precio_publico]                   FLOAT (53)   NOT NULL,
    [pr_precio_mayor]                     FLOAT (53)   NOT NULL,
    [pr_precio_puerta]                    FLOAT (53)   NOT NULL,
    [pr_precio_minimo]                    FLOAT (53)   NOT NULL,
    [pr_Por_descuento]                    FLOAT (53)   NOT NULL,
    [pr_stock_maximo]                     FLOAT (53)   NOT NULL,
    [pr_stock_minimo]                     FLOAT (53)   NOT NULL,
    [pr_costo_fob]                        FLOAT (53)   NOT NULL,
    [pr_costo_CIF]                        FLOAT (53)   NOT NULL,
    [pr_costo_promedio]                   FLOAT (53)   NOT NULL,
    [IdCtaCble_Inven]                     VARCHAR (20) NULL,
    [IdCtaCble_CosBaseIva]                VARCHAR (20) NULL,
    [IdCtaCble_CosBase0]                  VARCHAR (20) NULL,
    [IdCtaCble_VenIva]                    VARCHAR (20) NULL,
    [IdCtaCble_Ven0]                      VARCHAR (20) NULL,
    [IdCtaCble_DesIva]                    VARCHAR (20) NULL,
    [IdCtaCble_Des0]                      VARCHAR (20) NULL,
    [IdCtaCble_DevIva]                    VARCHAR (20) NULL,
    [IdCtaCble_Dev0]                      VARCHAR (20) NULL,
    [Estado]                              CHAR (1)     NOT NULL,
    [IdCtaCble_Costo]                     VARCHAR (20) NULL,
    [IdCentro_Costo_Inventario]           VARCHAR (20) NULL,
    [IdCentro_Costo_Costo]                VARCHAR (20) NULL,
    [IdCtaCble_Gasto_x_cxp]               VARCHAR (20) NULL,
    [IdCentroCosto_x_Gasto_x_cxp]         VARCHAR (20) NULL,
    [IdCentroCosto_sub_centro_costo_inv]  VARCHAR (20) NULL,
    [IdCentroCosto_sub_centro_costo_cost] VARCHAR (20) NULL,
    [IdCentroCosto_sub_centro_costo_cxp]  VARCHAR (20) NULL,
    [IdCtaCble_Vta]                       VARCHAR (20) NULL,
    CONSTRAINT [PK_in_producto_x_tb_puntoVenta] PRIMARY KEY CLUSTERED ([IdEmpresa] ASC, [IdSucursal] ASC, [IdBodega] ASC, [IdProducto] ASC),
    CONSTRAINT [FK_in_producto_x_tb_bodega_ct_plancta] FOREIGN KEY ([IdEmpresa], [IdCtaCble_Inven]) REFERENCES [dbo].[ct_plancta] ([IdEmpresa], [IdCtaCble]),
    CONSTRAINT [FK_in_producto_x_tb_bodega_ct_plancta1] FOREIGN KEY ([IdEmpresa], [IdCtaCble_CosBaseIva]) REFERENCES [dbo].[ct_plancta] ([IdEmpresa], [IdCtaCble]),
    CONSTRAINT [FK_in_producto_x_tb_bodega_ct_plancta10] FOREIGN KEY ([IdEmpresa], [IdCtaCble_Gasto_x_cxp]) REFERENCES [dbo].[ct_plancta] ([IdEmpresa], [IdCtaCble]),
    CONSTRAINT [FK_in_producto_x_tb_bodega_ct_plancta11] FOREIGN KEY ([IdEmpresa], [IdCtaCble_Vta]) REFERENCES [dbo].[ct_plancta] ([IdEmpresa], [IdCtaCble]),
    CONSTRAINT [FK_in_producto_x_tb_bodega_ct_plancta2] FOREIGN KEY ([IdEmpresa], [IdCtaCble_CosBase0]) REFERENCES [dbo].[ct_plancta] ([IdEmpresa], [IdCtaCble]),
    CONSTRAINT [FK_in_producto_x_tb_bodega_ct_plancta3] FOREIGN KEY ([IdEmpresa], [IdCtaCble_VenIva]) REFERENCES [dbo].[ct_plancta] ([IdEmpresa], [IdCtaCble]),
    CONSTRAINT [FK_in_producto_x_tb_bodega_ct_plancta4] FOREIGN KEY ([IdEmpresa], [IdCtaCble_Ven0]) REFERENCES [dbo].[ct_plancta] ([IdEmpresa], [IdCtaCble]),
    CONSTRAINT [FK_in_producto_x_tb_bodega_ct_plancta5] FOREIGN KEY ([IdEmpresa], [IdCtaCble_DevIva]) REFERENCES [dbo].[ct_plancta] ([IdEmpresa], [IdCtaCble]),
    CONSTRAINT [FK_in_producto_x_tb_bodega_ct_plancta6] FOREIGN KEY ([IdEmpresa], [IdCtaCble_Des0]) REFERENCES [dbo].[ct_plancta] ([IdEmpresa], [IdCtaCble]),
    CONSTRAINT [FK_in_producto_x_tb_bodega_ct_plancta7] FOREIGN KEY ([IdEmpresa], [IdCtaCble_DevIva]) REFERENCES [dbo].[ct_plancta] ([IdEmpresa], [IdCtaCble]),
    CONSTRAINT [FK_in_producto_x_tb_bodega_ct_plancta8] FOREIGN KEY ([IdEmpresa], [IdCtaCble_Dev0]) REFERENCES [dbo].[ct_plancta] ([IdEmpresa], [IdCtaCble]),
    CONSTRAINT [FK_in_producto_x_tb_bodega_ct_plancta9] FOREIGN KEY ([IdEmpresa], [IdCtaCble_Costo]) REFERENCES [dbo].[ct_plancta] ([IdEmpresa], [IdCtaCble]),
    CONSTRAINT [FK_in_producto_x_tb_bodega_in_Producto] FOREIGN KEY ([IdEmpresa], [IdProducto]) REFERENCES [dbo].[in_Producto] ([IdEmpresa], [IdProducto]),
    CONSTRAINT [FK_in_producto_x_tb_bodega_tb_bodega] FOREIGN KEY ([IdEmpresa], [IdSucursal], [IdBodega]) REFERENCES [dbo].[tb_bodega] ([IdEmpresa], [IdSucursal], [IdBodega])
);


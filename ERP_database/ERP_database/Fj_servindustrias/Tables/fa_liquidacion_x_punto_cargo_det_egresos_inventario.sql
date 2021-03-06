﻿CREATE TABLE [Fj_servindustrias].[fa_liquidacion_x_punto_cargo_det_egresos_inventario] (
    [IdEmpresa]             INT          NOT NULL,
    [IdSucursal]            INT          NOT NULL,
    [IdCentroCosto]         VARCHAR (20) NOT NULL,
    [IdLiquidacion]         NUMERIC (18) NOT NULL,
    [eg_secuencia]          INT          NOT NULL,
    [eg_cantidad]           FLOAT (53)   NOT NULL,
    [eg_precio_uni]         FLOAT (53)   NOT NULL,
    [eg_por_ganancia]       FLOAT (53)   NOT NULL,
    [eg_valor_ganancia]     FLOAT (53)   NOT NULL,
    [eg_precio_total]       FLOAT (53)   NOT NULL,
    [inv_IdEmpresa]         INT          NULL,
    [inv_IdSucursal]        INT          NULL,
    [inv_IdMovi_inven_tipo] INT          NULL,
    [inv_IdNumMovi]         NUMERIC (18) NULL,
    [inv_Secuencia]         INT          NULL,
    [IdUnidadMedida]        VARCHAR (25) NOT NULL,
    [IdProducto]            NUMERIC (18) NOT NULL,
    [pr_precio_publico]     FLOAT (53)   NOT NULL,
    CONSTRAINT [PK_fa_liquidacion_x_punto_cargo_det_egresos_inventario] PRIMARY KEY CLUSTERED ([IdEmpresa] ASC, [IdSucursal] ASC, [IdCentroCosto] ASC, [IdLiquidacion] ASC, [eg_secuencia] ASC),
    CONSTRAINT [FK_fa_liquidacion_x_punto_cargo_det_egresos_inventario_fa_liquidacion_x_punto_cargo] FOREIGN KEY ([IdEmpresa], [IdSucursal], [IdCentroCosto], [IdLiquidacion]) REFERENCES [Fj_servindustrias].[fa_liquidacion_x_punto_cargo] ([IdEmpresa], [IdSucursal], [IdCentroCosto], [IdLiquidacion]),
    CONSTRAINT [FK_fa_liquidacion_x_punto_cargo_det_egresos_inventario_in_Producto] FOREIGN KEY ([IdEmpresa], [IdProducto]) REFERENCES [dbo].[in_Producto] ([IdEmpresa], [IdProducto]),
    CONSTRAINT [FK_fa_liquidacion_x_punto_cargo_det_egresos_inventario_in_UnidadMedida] FOREIGN KEY ([IdUnidadMedida]) REFERENCES [dbo].[in_UnidadMedida] ([IdUnidadMedida])
);










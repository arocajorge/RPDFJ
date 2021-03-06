﻿CREATE TABLE [dbo].[cxc_conciliacion_det] (
    [IdEmpresa]          INT          NOT NULL,
    [IdSucursal]         INT          NOT NULL,
    [IdConciliacion]     NUMERIC (18) NOT NULL,
    [Secuencia]          INT          NOT NULL,
    [IdTipoConciliacion] VARCHAR (20) NOT NULL,
    [IdEmpresa_cbr]      INT          NULL,
    [IdSucursal_cbr]     INT          NULL,
    [IdCobro]            NUMERIC (18) NULL,
    [IdEmpresa_nt]       INT          NULL,
    [IdSucursal_nt]      INT          NULL,
    [IdBodega_nt]        INT          NULL,
    [IdNota_nt]          NUMERIC (18) NULL,
    [IdEmpresa_fa]       INT          NULL,
    [IdSucursal_fa]      INT          NULL,
    [IdBodega_fa]        INT          NULL,
    [TipoDoc_vta]        VARCHAR (20) NULL,
    [IdCbteVta_fa]       NUMERIC (18) NULL,
    [Saldo_por_aplicar]  FLOAT (53)   NOT NULL,
    [Valor_Aplicado]     FLOAT (53)   NOT NULL,
    CONSTRAINT [PK_cxc_conciliacion_det] PRIMARY KEY CLUSTERED ([IdEmpresa] ASC, [IdSucursal] ASC, [IdConciliacion] ASC, [Secuencia] ASC),
    CONSTRAINT [FK_cxc_conciliacion_det_cxc_cobro] FOREIGN KEY ([IdEmpresa_cbr], [IdSucursal_cbr], [IdCobro]) REFERENCES [dbo].[cxc_cobro] ([IdEmpresa], [IdSucursal], [IdCobro]),
    CONSTRAINT [FK_cxc_conciliacion_det_cxc_conciliacion] FOREIGN KEY ([IdEmpresa], [IdSucursal], [IdConciliacion]) REFERENCES [dbo].[cxc_conciliacion] ([IdEmpresa], [IdSucursal], [IdConciliacion]),
    CONSTRAINT [FK_cxc_conciliacion_det_cxc_conciliacion_tipo] FOREIGN KEY ([IdTipoConciliacion]) REFERENCES [dbo].[cxc_conciliacion_tipo] ([IdTipoConciliacion]),
    CONSTRAINT [FK_cxc_conciliacion_det_fa_factura] FOREIGN KEY ([IdEmpresa_fa], [IdSucursal_fa], [IdBodega_fa], [IdCbteVta_fa]) REFERENCES [dbo].[fa_factura] ([IdEmpresa], [IdSucursal], [IdBodega], [IdCbteVta]),
    CONSTRAINT [FK_cxc_conciliacion_det_fa_notaCreDeb] FOREIGN KEY ([IdEmpresa_nt], [IdSucursal_nt], [IdBodega_nt], [IdNota_nt]) REFERENCES [dbo].[fa_notaCreDeb] ([IdEmpresa], [IdSucursal], [IdBodega], [IdNota])
);


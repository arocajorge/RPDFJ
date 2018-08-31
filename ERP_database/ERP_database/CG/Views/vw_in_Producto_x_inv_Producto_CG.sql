CREATE VIEW CG.vw_in_Producto_x_inv_Producto_CG
AS
SELECT        dbo.in_Producto.IdEmpresa, dbo.in_Producto.IdProducto, dbo.in_Producto.pr_codigo, dbo.in_Producto.IdCategoria, dbo.in_Producto.IdLinea, 
                         dbo.in_Producto.IdGrupo, dbo.in_Producto.IdUnidadMedida, dbo.in_Producto.pr_codigo_barra, dbo.in_Producto.IdMotivo_Vta, 
                         CG.in_Producto_CG.sw_solicita_autorizacion, CG.in_Producto_CG.codigo_alterno, CG.in_Producto_CG.sw_venta_directa, CG.in_Producto_CG.codigo_cnmb, 
                         CG.in_Producto_CG.sw_control_fecha_vencimiento, CG.in_Producto_CG.sw_generico, CG.in_Producto_CG.sw_pos, 
                         CG.in_Producto_CG.med_cod_forma_farmacologica, CG.in_Producto_CG.med_cod_anatofarmacologico, CG.in_Producto_CG.contenido_unidad_venta, 
                         CG.in_Producto_CG.med_cod_principio_activo, CG.in_Producto_CG.med_sw_farmacovigilancia, CG.in_Producto_CG.med_descripcion_alerta, 
                         CG.in_Producto_CG.med_sw_alimento_parenteral, CG.in_Producto_CG.med_sw_alimento_enteral, CG.in_Producto_CG.med_sw_manejo_luz, 
                         dbo.in_Producto.pr_descripcion, dbo.in_Producto.IdUnidadMedida_Consumo, CG.in_Producto_CG.Estado AS estado_medicina, 
                         dbo.in_Producto.Estado AS estado_producto, dbo.in_Producto.IdProductoTipo
FROM            dbo.in_Producto INNER JOIN
                         CG.in_Producto_CG ON dbo.in_Producto.IdEmpresa = CG.in_Producto_CG.IdEmpresa AND dbo.in_Producto.IdProducto = CG.in_Producto_CG.IdProducto
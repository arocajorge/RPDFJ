--EXEC spsys_inv_cambiar_fecha_movimientos 1,2,1,86,'2018/02/23',1
CREATE PROCEDURE spsys_inv_cambiar_fecha_movimientos
(
@IdEmpresa int,
@IdSucursal int,
@IdMovi_inven_tipo int,
@IdNumMovi numeric,
@nueva_Fecha datetime,
@ejecutar bit
)
AS
BEGIN

if(@ejecutar = 1)
begin
		update in_Ing_Egr_Inven 
		set cm_fecha = @nueva_Fecha
		where IdEmpresa = @IdEmpresa and IdSucursal = @IdSucursal and IdMovi_inven_tipo = @IdMovi_inven_tipo and IdNumMovi = @IdNumMovi

		update in_movi_inve
		set cm_fecha = @nueva_Fecha
		FROM (
				SELECT        d.IdEmpresa_inv, d.IdSucursal_inv, d.IdBodega_inv, d.IdMovi_inven_tipo_inv, d.IdNumMovi_inv, in_movi_inve.cm_fecha, in_movi_inve.cm_observacion
				FROM            in_Ing_Egr_Inven_det AS d INNER JOIN
				in_movi_inve_detalle AS m ON m.IdEmpresa = d.IdEmpresa_inv AND m.IdSucursal = d.IdSucursal_inv AND m.IdBodega = d.IdBodega_inv AND m.IdMovi_inven_tipo = d.IdMovi_inven_tipo_inv AND 
				m.IdNumMovi = d.IdNumMovi_inv AND m.Secuencia = d.secuencia_inv INNER JOIN
				in_movi_inve ON m.IdEmpresa = in_movi_inve.IdEmpresa AND m.IdSucursal = in_movi_inve.IdSucursal AND m.IdBodega = in_movi_inve.IdBodega AND m.IdMovi_inven_tipo = in_movi_inve.IdMovi_inven_tipo AND 
				m.IdNumMovi = in_movi_inve.IdNumMovi
				where d.IdEmpresa = @IdEmpresa 
				and d.IdSucursal = @IdSucursal 
				and d.IdMovi_inven_tipo = @IdMovi_inven_tipo 
				and d.IdNumMovi = @IdNumMovi
				GROUP BY d.IdEmpresa_inv, d.IdSucursal_inv, d.IdBodega_inv, d.IdMovi_inven_tipo_inv, d.IdNumMovi_inv, in_movi_inve.cm_fecha, in_movi_inve.cm_observacion
		) d WHERE
		d.IdEmpresa_inv = in_movi_inve.IdEmpresa 
		and d.IdSucursal_inv = in_movi_inve.IdSucursal 
		and d.IdBodega_inv = in_movi_inve.IdBodega 
		and d.IdMovi_inven_tipo_inv = in_movi_inve.IdMovi_inven_tipo 
		and d.IdNumMovi_inv = in_movi_inve.IdNumMovi
end

select IdEmpresa, IdSucursal, IdMovi_inven_tipo, IdNumMovi, cm_fecha, cm_observacion
from in_Ing_Egr_Inven
where IdEmpresa = @IdEmpresa and IdSucursal = @IdSucursal and IdMovi_inven_tipo = @IdMovi_inven_tipo and IdNumMovi = @IdNumMovi

SELECT        d.IdEmpresa_inv, d.IdSucursal_inv, d.IdBodega_inv, d.IdMovi_inven_tipo_inv, d.IdNumMovi_inv, in_movi_inve.cm_fecha, in_movi_inve.cm_observacion
FROM            in_Ing_Egr_Inven_det AS d INNER JOIN
                         in_movi_inve_detalle AS m ON m.IdEmpresa = d.IdEmpresa_inv AND m.IdSucursal = d.IdSucursal_inv AND m.IdBodega = d.IdBodega_inv AND m.IdMovi_inven_tipo = d.IdMovi_inven_tipo_inv AND 
                         m.IdNumMovi = d.IdNumMovi_inv AND m.Secuencia = d.secuencia_inv INNER JOIN
                         in_movi_inve ON m.IdEmpresa = in_movi_inve.IdEmpresa AND m.IdSucursal = in_movi_inve.IdSucursal AND m.IdBodega = in_movi_inve.IdBodega AND m.IdMovi_inven_tipo = in_movi_inve.IdMovi_inven_tipo AND 
                         m.IdNumMovi = in_movi_inve.IdNumMovi
where d.IdEmpresa = @IdEmpresa and d.IdSucursal = @IdSucursal and d.IdMovi_inven_tipo = @IdMovi_inven_tipo and d.IdNumMovi = @IdNumMovi
GROUP BY d.IdEmpresa_inv, d.IdSucursal_inv, d.IdBodega_inv, d.IdMovi_inven_tipo_inv, d.IdNumMovi_inv, in_movi_inve.cm_fecha, in_movi_inve.cm_observacion
END
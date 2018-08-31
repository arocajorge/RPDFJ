

CREATE procedure Fj_servindustrias.spACTF_FJ_Rpt003 
@IdEmpresa int,
@FechaI date,
@FechaF date,
@estadoUbicacion bit
as
begin
/*
@IdEmpresa int
@FechaI date
@FechaF date

set @IdEmpresa=1
set @FechaI=''
set @FechaF =''
*/
-- ***********************************************************************************ACTIVOS FIJOS CON CAMBIO DE UBICACION***********************************************************************************************
SELECT       Af_Activo_fijo.IdEmpresa,Af_CambioUbicacion_Activo.IdCentroCosto_Ant,  dbo.ct_centro_costo_sub_centro_costo.IdCentroCosto_sub_centro_costo, dbo.Af_Activo_fijo_Categoria.IdCategoriaAF, dbo.Af_Activo_fijo_tipo.IdActijoFijoTipo, dbo.Af_Activo_fijo.IdActivoFijo, 
                         dbo.Af_Activo_fijo_Categoria.Descripcion AS Categoria, dbo.Af_Activo_fijo_tipo.Af_Descripcion AS Tipo, dbo.ct_centro_costo_sub_centro_costo.Centro_costo AS [Subcentro Costo], dbo.ct_centro_costo.Centro_costo, 
                         dbo.Af_Activo_fijo.Af_Nombre, dbo.Af_Activo_fijo.CodActivoFijo, dbo.Af_Activo_fijo.Af_DescripcionCorta, CAST(dbo.Af_CambioUbicacion_Activo.FechaCambio AS date) AS FechaCambio, 
                         dbo.Af_CambioUbicacion_Activo.IdCentroCosto_sub_centro_costo_Ant,CAST( 0 as bit) UbicacionActual
FROM            dbo.Af_CambioUbicacion_Activo INNER JOIN
                         dbo.Af_Activo_fijo_Categoria INNER JOIN
                         dbo.Af_Activo_fijo ON dbo.Af_Activo_fijo_Categoria.IdEmpresa = dbo.Af_Activo_fijo.IdEmpresa AND dbo.Af_Activo_fijo_Categoria.IdCategoriaAF = dbo.Af_Activo_fijo.IdCategoriaAF AND 
                         dbo.Af_Activo_fijo_Categoria.IdEmpresa = dbo.Af_Activo_fijo.IdEmpresa AND dbo.Af_Activo_fijo_Categoria.IdCategoriaAF = dbo.Af_Activo_fijo.IdCategoriaAF INNER JOIN
                         dbo.Af_Activo_fijo_tipo ON dbo.Af_Activo_fijo_Categoria.IdEmpresa = dbo.Af_Activo_fijo_tipo.IdEmpresa AND dbo.Af_Activo_fijo_Categoria.IdActivoFijoTipo = dbo.Af_Activo_fijo_tipo.IdActijoFijoTipo AND 
                         dbo.Af_Activo_fijo_Categoria.IdEmpresa = dbo.Af_Activo_fijo_tipo.IdEmpresa AND dbo.Af_Activo_fijo_Categoria.IdActivoFijoTipo = dbo.Af_Activo_fijo_tipo.IdActijoFijoTipo ON 
                         dbo.Af_CambioUbicacion_Activo.IdEmpresa = dbo.Af_Activo_fijo.IdEmpresa AND dbo.Af_CambioUbicacion_Activo.IdActivoFijo = dbo.Af_Activo_fijo.IdActivoFijo INNER JOIN
                         dbo.ct_centro_costo_sub_centro_costo INNER JOIN
                         dbo.ct_centro_costo ON dbo.ct_centro_costo_sub_centro_costo.IdEmpresa = dbo.ct_centro_costo.IdEmpresa AND dbo.ct_centro_costo_sub_centro_costo.IdCentroCosto = dbo.ct_centro_costo.IdCentroCosto ON 
                         dbo.Af_CambioUbicacion_Activo.IdEmpresa = dbo.ct_centro_costo_sub_centro_costo.IdEmpresa AND dbo.Af_CambioUbicacion_Activo.IdCentroCosto_Ant = dbo.ct_centro_costo_sub_centro_costo.IdCentroCosto AND 
                         dbo.Af_CambioUbicacion_Activo.IdCentroCosto_sub_centro_costo_Ant = dbo.ct_centro_costo_sub_centro_costo.IdCentroCosto_sub_centro_costo
						
						 where Af_Activo_fijo.IdEmpresa=@IdEmpresa
						 and CAST( FechaCambio as date) between @FechaI and @FechaF
						  and Af_Activo_fijo_tipo.IdActijoFijoTipo in(1,4)

--************************************************************************************* ACTIVOS FIJOS QUE NO HAN TENIDO CAMBIO DE UBICACION**************************************************************************
union

SELECT      Af_Activo_fijo.IdEmpresa,Af_Activo_fijo.IdCentroCosto,  dbo.ct_centro_costo_sub_centro_costo.IdCentroCosto_sub_centro_costo, dbo.Af_Activo_fijo_Categoria.IdCategoriaAF, dbo.Af_Activo_fijo_tipo.IdActijoFijoTipo, dbo.Af_Activo_fijo.IdActivoFijo, 
                         dbo.Af_Activo_fijo_Categoria.Descripcion AS Categoria, dbo.Af_Activo_fijo_tipo.Af_Descripcion AS Tipo, dbo.ct_centro_costo_sub_centro_costo.Centro_costo AS [Subcentro Costo], dbo.ct_centro_costo.Centro_costo, 
                         dbo.Af_Activo_fijo.Af_Nombre, dbo.Af_Activo_fijo.CodActivoFijo, dbo.Af_Activo_fijo.Af_DescripcionCorta,''FechaCambio, dbo.ct_centro_costo_sub_centro_costo.IdCentroCosto, CAST( 0 as bit) UbicacionActual
FROM            dbo.Af_Activo_fijo_Categoria INNER JOIN
                         dbo.Af_Activo_fijo ON dbo.Af_Activo_fijo_Categoria.IdEmpresa = dbo.Af_Activo_fijo.IdEmpresa AND dbo.Af_Activo_fijo_Categoria.IdCategoriaAF = dbo.Af_Activo_fijo.IdCategoriaAF AND 
                         dbo.Af_Activo_fijo_Categoria.IdEmpresa = dbo.Af_Activo_fijo.IdEmpresa AND dbo.Af_Activo_fijo_Categoria.IdCategoriaAF = dbo.Af_Activo_fijo.IdCategoriaAF INNER JOIN
                         dbo.Af_Activo_fijo_tipo ON dbo.Af_Activo_fijo_Categoria.IdEmpresa = dbo.Af_Activo_fijo_tipo.IdEmpresa AND dbo.Af_Activo_fijo_Categoria.IdActivoFijoTipo = dbo.Af_Activo_fijo_tipo.IdActijoFijoTipo AND 
                         dbo.Af_Activo_fijo_Categoria.IdEmpresa = dbo.Af_Activo_fijo_tipo.IdEmpresa AND dbo.Af_Activo_fijo_Categoria.IdActivoFijoTipo = dbo.Af_Activo_fijo_tipo.IdActijoFijoTipo INNER JOIN
                         dbo.ct_centro_costo_sub_centro_costo INNER JOIN
                         dbo.ct_centro_costo ON dbo.ct_centro_costo_sub_centro_costo.IdEmpresa = dbo.ct_centro_costo.IdEmpresa AND dbo.ct_centro_costo_sub_centro_costo.IdCentroCosto = dbo.ct_centro_costo.IdCentroCosto ON 
                         dbo.Af_Activo_fijo.IdCentroCosto_sub_centro_costo = dbo.ct_centro_costo_sub_centro_costo.IdCentroCosto_sub_centro_costo AND dbo.Af_Activo_fijo.IdCentroCosto = dbo.ct_centro_costo_sub_centro_costo.IdCentroCosto AND 
                         dbo.Af_Activo_fijo.IdEmpresa = dbo.ct_centro_costo_sub_centro_costo.IdEmpresa
						 where IdActivoFijo not in (select C.IdActivoFijo from Af_CambioUbicacion_Activo C where C.IdEmpresa=Af_Activo_fijo.IdEmpresa and C.IdActivoFijo=Af_Activo_fijo.IdActivoFijo)
			            and  Af_Activo_fijo.IdEmpresa=@IdEmpresa
						 and Af_Activo_fijo_tipo.IdActijoFijoTipo in(1,4)
--************************************************************************************* UBICACION ACTUAL DEL ACTIVO FIJO A LA FECHA**************************************************************************


union

SELECT        Af_Activo_fijo.IdEmpresa,Af_Activo_fijo.IdCentroCosto,dbo.ct_centro_costo_sub_centro_costo.IdCentroCosto_sub_centro_costo, dbo.Af_Activo_fijo_Categoria.IdCategoriaAF, dbo.Af_Activo_fijo_tipo.IdActijoFijoTipo, dbo.Af_Activo_fijo.IdActivoFijo, 
                         dbo.Af_Activo_fijo_Categoria.Descripcion AS Categoria, dbo.Af_Activo_fijo_tipo.Af_Descripcion AS Tipo, dbo.ct_centro_costo_sub_centro_costo.Centro_costo AS [Subcentro Costo], dbo.ct_centro_costo.Centro_costo, 
                         dbo.Af_Activo_fijo.Af_Nombre, dbo.Af_Activo_fijo.CodActivoFijo, dbo.Af_Activo_fijo.Af_DescripcionCorta,''FechaCambio, dbo.ct_centro_costo_sub_centro_costo.IdCentroCosto, CAST( 1 as bit) UbicacionActual
FROM            dbo.Af_Activo_fijo_Categoria INNER JOIN
                         dbo.Af_Activo_fijo ON dbo.Af_Activo_fijo_Categoria.IdEmpresa = dbo.Af_Activo_fijo.IdEmpresa AND dbo.Af_Activo_fijo_Categoria.IdCategoriaAF = dbo.Af_Activo_fijo.IdCategoriaAF AND 
                         dbo.Af_Activo_fijo_Categoria.IdEmpresa = dbo.Af_Activo_fijo.IdEmpresa AND dbo.Af_Activo_fijo_Categoria.IdCategoriaAF = dbo.Af_Activo_fijo.IdCategoriaAF INNER JOIN
                         dbo.Af_Activo_fijo_tipo ON dbo.Af_Activo_fijo_Categoria.IdEmpresa = dbo.Af_Activo_fijo_tipo.IdEmpresa AND dbo.Af_Activo_fijo_Categoria.IdActivoFijoTipo = dbo.Af_Activo_fijo_tipo.IdActijoFijoTipo AND 
                         dbo.Af_Activo_fijo_Categoria.IdEmpresa = dbo.Af_Activo_fijo_tipo.IdEmpresa AND dbo.Af_Activo_fijo_Categoria.IdActivoFijoTipo = dbo.Af_Activo_fijo_tipo.IdActijoFijoTipo INNER JOIN
                         dbo.ct_centro_costo_sub_centro_costo INNER JOIN
                         dbo.ct_centro_costo ON dbo.ct_centro_costo_sub_centro_costo.IdEmpresa = dbo.ct_centro_costo.IdEmpresa AND dbo.ct_centro_costo_sub_centro_costo.IdCentroCosto = dbo.ct_centro_costo.IdCentroCosto ON 
                         dbo.Af_Activo_fijo.IdCentroCosto_sub_centro_costo = dbo.ct_centro_costo_sub_centro_costo.IdCentroCosto_sub_centro_costo AND dbo.Af_Activo_fijo.IdCentroCosto = dbo.ct_centro_costo_sub_centro_costo.IdCentroCosto AND 
                         dbo.Af_Activo_fijo.IdEmpresa = dbo.ct_centro_costo_sub_centro_costo.IdEmpresa
						 where IdActivoFijo not in (select C.IdActivoFijo from Af_CambioUbicacion_Activo C where C.IdEmpresa=Af_Activo_fijo.IdEmpresa and C.IdActivoFijo=Af_Activo_fijo.IdActivoFijo)
						 and  Af_Activo_fijo.IdEmpresa=@IdEmpresa
						 and Af_Activo_fijo_tipo.IdActijoFijoTipo in(1,4)
end

select * from Af_Activo_fijo_tipo
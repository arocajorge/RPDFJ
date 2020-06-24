--exec spsys_in_mover_fecha 1,2,1,1101,23,02,2018
CREATE procedure spsys_in_mover_fecha
(
 @IdEmpresa int, @IdSucursal int, @IdMovi_inven_tipo int,  @IdNumMovi numeric, @Dia int, @Mes int, @Anio int
)
as 

select * from in_Ing_Egr_Inven where IdEmpresa = @IdEmpresa AND IdSucursal = @IdSucursal and IdMovi_inven_tipo = @IdMovi_inven_tipo and IdNumMovi = @IdNumMovi

select * from in_movi_inve 
where exists(
select * from in_Ing_Egr_Inven_det as d
where d.IdEmpresa = @IdEmpresa AND d.IdSucursal = @IdSucursal and d.IdMovi_inven_tipo = @IdMovi_inven_tipo and d.IdNumMovi = @IdNumMovi
and in_movi_inve.IdEmpresa = d.IdEmpresa_inv 
and in_movi_inve.IdSucursal = d.IdSucursal_inv 
and in_movi_inve.IdBodega = d.IdBodega_inv
and in_movi_inve.IdMovi_inven_tipo = d.IdMovi_inven_tipo_inv 
and in_movi_inve.IdNumMovi = d.IdNumMovi_inv
)

declare @FechaCambio datetime = datefromparts(@Anio,@Mes,@Dia)
select @FechaCambio

UPDATE in_Ing_Egr_Inven set cm_fecha = @FechaCambio where IdEmpresa = @IdEmpresa AND IdSucursal = @IdSucursal and IdMovi_inven_tipo = @IdMovi_inven_tipo and IdNumMovi = @IdNumMovi

update in_movi_inve set cm_fecha = @FechaCambio 
where exists(
select * from in_Ing_Egr_Inven_det as d
where d.IdEmpresa = @IdEmpresa AND d.IdSucursal = @IdSucursal and d.IdMovi_inven_tipo = @IdMovi_inven_tipo and d.IdNumMovi = @IdNumMovi
and in_movi_inve.IdEmpresa = d.IdEmpresa_inv 
and in_movi_inve.IdSucursal = d.IdSucursal_inv 
and in_movi_inve.IdBodega = d.IdBodega_inv
and in_movi_inve.IdMovi_inven_tipo = d.IdMovi_inven_tipo_inv 
and in_movi_inve.IdNumMovi = d.IdNumMovi_inv
)

select * from in_Ing_Egr_Inven where IdEmpresa = @IdEmpresa AND IdSucursal = @IdSucursal and IdMovi_inven_tipo = @IdMovi_inven_tipo and IdNumMovi = @IdNumMovi

select * from in_movi_inve 
where exists(
select * from in_Ing_Egr_Inven_det as d
where d.IdEmpresa = @IdEmpresa AND d.IdSucursal = @IdSucursal and d.IdMovi_inven_tipo = @IdMovi_inven_tipo and d.IdNumMovi = @IdNumMovi
and in_movi_inve.IdEmpresa = d.IdEmpresa_inv 
and in_movi_inve.IdSucursal = d.IdSucursal_inv 
and in_movi_inve.IdBodega = d.IdBodega_inv
and in_movi_inve.IdMovi_inven_tipo = d.IdMovi_inven_tipo_inv 
and in_movi_inve.IdNumMovi = d.IdNumMovi_inv
)
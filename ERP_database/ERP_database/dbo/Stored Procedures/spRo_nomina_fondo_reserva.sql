

CREATE PROCEDURE [dbo].[spRo_nomina_fondo_reserva] (
@IdEmpresa int,
@IdNomina numeric,
@IdNominaTipo numeric,
@IdPEriodo numeric,
@IdEmpleado numeric,
@IdUsuario varchar(50),
@Observacion varchar(500)
)
AS
begin

--declare
--@IdEmpresa int,
--@IdNomina numeric,
--@IdNominaTipo numeric,
--@IdPEriodo numeric,
--@IdUsuario varchar(50),
--@observacion varchar(500)

--set @IdEmpresa =2
--set @IdNomina =1
--set @IdNominaTipo =2
--set @IdPEriodo= 202004
--set @IdUsuario ='admin'
--set @observacion= 'PERIODO'+CAST( @IdPEriodo AS varchar(15))



BEGIN -- variables
declare
@Fi date,
@Ff date,
@IdRubro_calculado varchar(50),
@Dias_trabajados int,
@Anio float,
@SueldoBasico float,
@Por_apor_pers_iess float,
@por_apor_per_patr float,
@por_apor_fnd float,
@IdSucursal int,
@IdRubro_Provision varchar(50),
@IdRubro_total_ingreso varchar(50),
@IdRubro_total_egreso varchar(50),
@IdRubro_total_pagar varchar(50),
@IdRubro_anticipo varchar(50),
@PorAportePersonal float,
@SalarioBasico float,

@IdRubro_DIII varchar(50),
@IdRubro_DIV varchar(50),
@IdRubro_ProvDIII varchar(50),
@IdRubro_ProvDIV varchar(50),
@IdRubro_FondoReserva varchar(50),
@IdRubro_PagoCheque varchar(50),
@IdRubro_dias_efectivos varchar(50),
@IdRubro_otros_descuentos varchar(50),
@IdRubro_horas_extras varchar(50),
@Orden int

end

select @SueldoBasico= Sueldo_basico,@Por_apor_pers_iess= Porcentaje_aporte_pers, @por_apor_per_patr=Porcentaje_aporte_patr from ro_Parametros where IdEmpresa=@IdEmpresa
----------------------------------------------------------------------------------------------------------------------------------------------
-------------obteniendo fecha del perido------------------- ----------------------------------------------------------------------------------<
----------------------------------------------------------------------------------------------------------------------------------------------
select @Fi= pe_FechaIni, @Ff=pe_FechaFin, @Anio=pe_anio from ro_periodo where IdEmpresa=@IdEmpresa and IdPeriodo=@IdPEriodo
-------------obteniendo aporte personal------------------- ----------------------------------------------------------------------------------<
select @PorAportePersonal = Porcentaje_aporte_pers, @SalarioBasico = Sueldo_basico from ro_Parametros where IdEmpresa=@IdEmpresa

----------------------------------------------------------------------------------------------------------------------------------------------
-------------preparando la cabecera del rol general-------- ----------------------------------------------------------------------------------<
----------------------------------------------------------------------------------------------------------------------------------------------
if((select  COUNT(IdPeriodo) from ro_rol where IdEmpresa=@IdEmpresa and IdNominaTipo=@IdNomina and IdNominaTipoLiqui=@IdNominaTipo and IdPeriodo=@IdPEriodo)>0)
update ro_rol set PorAportePersonal=@PorAportePersonal, SalarioBasico=@SalarioBasico, UsuarioModifica=@IdUsuario, FechaModifica=GETDATE() where IdEmpresa=@IdEmpresa  and IdNominaTipo=@IdNomina and IdNominaTipoLiqui=@IdNominaTipo
else
insert into ro_rol
(IdEmpresa,	IdNominaTipo,		IdNominaTipoLiqui,		IdPeriodo,			Descripcion,				Observacion,				Cerrado,			FechaIngresa,
UsuarioIngresa,	FechaModifica,		UsuarioModifica,		FechaAnula,			UsuarioAnula,				MotivoAnula,				UsuarioCierre,		FechaCierre,
IdCentroCosto, PorAportePersonal, SalarioBasico)
select
 @IdEmpresa	,@IdNomina			,@IdNominaTipo			,@IdPEriodo			,@observacion				,@observacion				,'ABIERTO'				,GETDATE()
,@IdUsuario		,null				,null					,null				,null						,null						,null				,null
,null, @PorAportePersonal, @SalarioBasico

----------------------------------------------------------------------------------------------------------------------------------------------
-------------eliminando detalle--------------------------- ----------------------------------------------------------------------------------<
----------------------------------------------------------------------------------------------------------------------------------------------
delete ro_rol_detalle_x_rubro_acumulado  where IdEmpresa=@IdEmpresa  and IdNominaTipo=@IdNomina and IdNominaTipoLiqui=@IdNominaTipo and IdPeriodo=@IdPEriodo and IdEmpleado=@IdEmpleado
delete ro_rol_x_empleado_novedades where IdEmpresa=@IdEmpresa  and IdNominaTipo=@IdNomina and IdNominaTipoLiqui=@IdNominaTipo and IdPeriodo=@IdPEriodo and IdEmpleado=@IdEmpleado
delete ro_rol_x_prestamo_detalle where IdEmpresa=@IdEmpresa  and IdNominaTipo=@IdNomina and IdNominaTipoLiqui=@IdNominaTipo and IdPeriodo=@IdPEriodo and IdEmpleado=@IdEmpleado
delete ro_rol_detalle where ro_rol_detalle.IdEmpresa=@IdEmpresa  and IdNominaTipo=@IdNomina and IdNominaTipoLiqui=@IdNominaTipo and IdPeriodo=@IdPEriodo and IdEmpleado=@IdEmpleado

----------------------------------------------------------------------------------------------------------------------------------------------
-------------buscando novedades del periodo e insertando al rol detalle-----------------------------------------------------------------------<
----------------------------------------------------------------------------------------------------------------------------------------------
insert into ro_rol_detalle
(IdEmpresa,	IdNominaTipo,IdNominaTipoLiqui,IdPeriodo,									IdEmpleado,			IdRubro,			Orden,			Valor
,rub_visible_reporte,	Observacion)

select 
@IdEmpresa		,@IdNomina,@IdNominaTipo,@IdPEriodo							,novc.IdEmpleado		,nov.IdRubro		,ISNULL( rub.ru_orden_rol_general,0)	,sum(nov.Valor)
,ISNULL( rub.ru_muestra_rol_general,0)						,rub.ru_descripcion		
FROM            dbo.ro_empleado_x_ro_tipoNomina RIGHT OUTER JOIN
                         dbo.ro_empleado AS emp INNER JOIN
                         dbo.ro_empleado_Novedad AS novc ON emp.IdEmpresa = novc.IdEmpresa AND emp.IdEmpleado = novc.IdEmpleado ON dbo.ro_empleado_x_ro_tipoNomina.IdEmpresa = emp.IdEmpresa AND 
                         dbo.ro_empleado_x_ro_tipoNomina.IdEmpleado = emp.IdEmpleado LEFT OUTER JOIN
                         dbo.ro_rubro_tipo AS rub INNER JOIN
                         dbo.ro_empleado_novedad_det AS nov ON rub.IdEmpresa = nov.IdEmpresa AND rub.IdRubro = nov.IdRubro ON novc.IdEmpresa = nov.IdEmpresa AND novc.IdNovedad = nov.IdNovedad AND novc.IdEmpleado = nov.IdEmpleado
where ro_empleado_x_ro_tipoNomina.IdTipoNomina=@IdNomina

and nov.IdEmpresa=@IdEmpresa
and emp.IdEmpresa=@IdEmpresa
and novc.IdNomina_tipo=@IdNomina
and novc.IdNomina_TipoLiqui=@IdNominaTipo
and nov.FechaPago between @Fi and @Ff
and novc.Estado='A'
and nov.EstadoCobro='PEN'
and (emp.em_status<>'EST_LIQ')
and CAST( emp.em_fechaIngaRol as date)<=@Ff
and ISNULL( emp.em_fechaSalida, @Fi) between @Fi and @Ff
and emp.IdEmpleado=@IdEmpleado
group by novc.IdEmpresa,novc.IdEmpleado,nov.IdRubro,rub.ru_orden,rub.ru_descripcion, emp.IdSucursal,rub.ru_muestra_rol_general, rub.ru_orden_rol_general

----------------------------------------------------------------------------------------------------------------------
-------------calculando total ingreso por empleado-------------------------------------------------------------------------------------------<
----------------------------------------------------------------------------------------------------------------------------------------------

select @IdRubro_calculado= IdRubro_tot_ing, @IdRubro_FondoReserva= IdRubro_fondo_reserva from ro_rubros_calculados where IdEmpresa=@IdEmpresa-- obteniendo el idrubro desde parametros
select @Orden=ru_orden_rol_general from ro_rubro_tipo where IdEmpresa=@IdEmpresa and IdRubro=@IdRubro_calculado
insert into ro_rol_detalle
(IdEmpresa,	IdNominaTipo,IdNominaTipoLiqui,IdPeriodo,								IdEmpleado,			IdRubro,			Orden,			Valor
,rub_visible_reporte,	Observacion)


select
@IdEmpresa	,@IdNomina,@IdNominaTipo,@IdPEriodo										,rol_det.IdEmpleado		,@IdRubro_calculado	,ISNULL( @Orden,0)			,round( sum(round(rol_det.Valor,2)),2)
,1						,'Total ingresos'	
FROM            dbo.ro_rol_detalle AS rol_det INNER JOIN
                         dbo.ro_rubro_tipo AS rub ON rol_det.IdEmpresa = rub.IdEmpresa AND rol_det.IdRubro = rub.IdRubro INNER JOIN
                         dbo.ro_rol ON rol_det.IdEmpresa = dbo.ro_rol.IdEmpresa AND rol_det.IdNominaTipo = dbo.ro_rol.IdNominaTipo AND rol_det.IdNominaTipoLiqui = dbo.ro_rol.IdNominaTipoLiqui AND 
                         rol_det.IdPeriodo = dbo.ro_rol.IdPeriodo INNER JOIN
                         dbo.ro_empleado AS emp ON rol_det.IdEmpresa = emp.IdEmpresa AND rol_det.IdEmpleado = emp.IdEmpleado INNER JOIN
                         dbo.vwro_contrato_activo AS cont ON emp.IdEmpresa = cont.IdEmpresa AND emp.IdEmpleado = cont.IdEmpleado

where rol_det.IdEmpresa=@IdEmpresa
and ro_rol.IdNominaTipo=@IdNomina
and ro_rol.IdNominaTipoLiqui=@IdNominaTipo
and emp.IdEmpleado=@IdEmpleado
and ro_rol.IdPeriodo=@IdPEriodo
and rub.ru_tipo='I'
and rol_det.IdRubro!=@IdRubro_FondoReserva
and cont.EstadoContrato<>'ECT_LIQ'
group by rol_det.IdEmpresa,rol_det.IdEmpleado,ro_rol.IdNominaTipo,ro_rol.IdNominaTipoLiqui,ro_rol.IdPeriodo, emp.IdSucursal

----------------------------------------------------------------------------------------------------------------------------------------------
-------------calculando total egreso por empleado--------------------------------------------------------------------------------------------<
----------------------------------------------------------------------------------------------------------------------------------------------

select @IdRubro_calculado= IdRubro_tot_egr, @IdRubro_otros_descuentos=IdRubro_otros_descuentos,@IdRubro_anticipo=IdRubro_anticipo from ro_rubros_calculados where IdEmpresa=@IdEmpresa-- obteniendo el idrubro desde parametros
select @Orden=ru_orden_rol_general from ro_rubro_tipo where IdEmpresa=@IdEmpresa and IdRubro=@IdRubro_calculado
insert into ro_rol_detalle
(IdEmpresa,		IdNominaTipo,IdNominaTipoLiqui,IdPeriodo,					IdEmpleado,			IdRubro,			Orden,			Valor
,rub_visible_reporte,	Observacion)

select
@IdEmpresa	,@IdNomina,@IdNominaTipo,@IdPEriodo										,rol_det.IdEmpleado		,@IdRubro_calculado	,ISNULL( @Orden,0)			,round( sum(round(rol_det.Valor,2)),2)
,1						,'Total Egreso'	
FROM            dbo.ro_rol_detalle AS rol_det INNER JOIN
                         dbo.ro_rubro_tipo AS rub ON rol_det.IdEmpresa = rub.IdEmpresa AND rol_det.IdRubro = rub.IdRubro INNER JOIN
                         dbo.ro_rol ON rol_det.IdEmpresa = dbo.ro_rol.IdEmpresa AND rol_det.IdNominaTipo = dbo.ro_rol.IdNominaTipo AND rol_det.IdNominaTipoLiqui = dbo.ro_rol.IdNominaTipoLiqui AND 
                         rol_det.IdPeriodo = dbo.ro_rol.IdPeriodo INNER JOIN
                         dbo.ro_empleado AS emp ON rol_det.IdEmpresa = emp.IdEmpresa AND rol_det.IdEmpleado = emp.IdEmpleado INNER JOIN
                         dbo.vwro_contrato_activo AS cont ON emp.IdEmpresa = cont.IdEmpresa AND emp.IdEmpleado = cont.IdEmpleado
where rol_det.IdEmpresa=@IdEmpresa
and ro_rol.IdNominaTipo=@IdNomina
and ro_rol.IdNominaTipoLiqui=@IdNominaTipo
and ro_rol.IdPeriodo=@IdPEriodo
and ( rub.ru_tipo='E' or rol_det.IdRubro=@IdRubro_anticipo)
and rol_det.IdRubro!=@IdRubro_otros_descuentos
and emp.IdEmpleado=@IdEmpleado
--and cont.IdNomina=@IdNomina
and cont.EstadoContrato<>'ECT_LIQ'
group by rol_det.IdEmpresa,rol_det.IdEmpleado,ro_rol.IdNominaTipo,ro_rol.IdNominaTipoLiqui,ro_rol.IdPeriodo, emp.IdSucursal

----------------------------------------------------------------------------------------------------------------------------------------------
-------------calculandoliquido a recibir--------------------------------------------------------------------------------------------<
----------------------------------------------------------------------------------------------------------------------------------------------

select @IdRubro_calculado= IdRubro_tot_pagar from ro_rubros_calculados where IdEmpresa=@IdEmpresa-- obteniendo el idrubro desde parametros
select @Orden=ru_orden_rol_general from ro_rubro_tipo where IdEmpresa=@IdEmpresa and IdRubro=@IdRubro_calculado
insert into ro_rol_detalle
(IdEmpresa,	IdNominaTipo,IdNominaTipoLiqui,IdPeriodo,									IdEmpleado,			IdRubro,			Orden,			Valor
,rub_visible_reporte,	Observacion)

select
@IdEmpresa		,@IdNomina,@IdNominaTipo,@IdPEriodo					,IdEmpleado		,@IdRubro_calculado	,ISNULL( @Orden,0)		, cast( (ISNULL( [500],0) -ISNULL( [900],0)) as numeric(12,2))
,1						,'Liquido a recibir'	
FROM (
    SELECT 
        rol_det.IdEmpresa,emp.IdEmpleado, emp.IdSucursal,rol_det.IdNominaTipo,rol_det.IdNominaTipoLiqui ,rol_det.IdPeriodo ,rol_det.IdRubro, Valor
FROM            dbo.ro_rol_detalle AS rol_det INNER JOIN
                         dbo.ro_rubro_tipo AS rub ON rol_det.IdEmpresa = rub.IdEmpresa AND rol_det.IdRubro = rub.IdRubro INNER JOIN
                         dbo.ro_rol ON rol_det.IdEmpresa = dbo.ro_rol.IdEmpresa AND rol_det.IdNominaTipo = dbo.ro_rol.IdNominaTipo AND rol_det.IdNominaTipoLiqui = dbo.ro_rol.IdNominaTipoLiqui AND 
                         rol_det.IdPeriodo = dbo.ro_rol.IdPeriodo INNER JOIN
                         dbo.ro_empleado AS emp ON rol_det.IdEmpresa = emp.IdEmpresa AND rol_det.IdEmpleado = emp.IdEmpleado INNER JOIN
                         dbo.vwro_contrato_activo AS cont ON emp.IdEmpresa = cont.IdEmpresa AND emp.IdEmpleado = cont.IdEmpleado	 where rol_det.IdEmpresa=@IdEmpresa
	 and rol_det.IdNominaTipo=@IdNomina
	 and rol_det.IdNominaTipoLiqui=@IdNominaTipo
	 and rol_det.IdPeriodo=@IdPEriodo
	 and emp.IdEmpleado=@IdEmpleado

--and cont.IdNomina=@IdNomina
and cont.EstadoContrato<>'ECT_LIQ'
) as s
PIVOT
(
   max([Valor])
    FOR [IdRubro] IN ([500],[900])
)AS pvt
----------------------------------------------------------------------------------------------------------------------------------------------
-------------INSERTANDO NOVEDADES QUE SE CONSIDERARON EN ESTE ROL----------------------------------------------------------------------------<
----------------------------------------------------------------------------------------------------------------------------------------------
insert into ro_rol_x_empleado_novedades
(IdEmpresa_nov,
IdEmpleado,
IdNovedad,
Secuencia_nov,
IdEmpresa,
IdNominaTipo,
IdNominaTipoLiqui,
IdPeriodo,
Observacion)

select 
novc.IdEmpresa,novc.IdEmpleado,novc.IdNovedad,nov.Secuencia,@IdEmpresa,@IdNomina,@IdNominaTipo,@IdPEriodo,ru_descripcion
FROM            dbo.ro_empleado AS emp INNER JOIN
                         dbo.ro_empleado_Novedad AS novc ON emp.IdEmpresa = novc.IdEmpresa AND emp.IdEmpleado = novc.IdEmpleado INNER JOIN
                         dbo.ro_empleado_novedad_det AS nov ON novc.IdEmpresa = nov.IdEmpresa AND novc.IdNovedad = nov.IdNovedad AND novc.IdEmpleado = nov.IdEmpleado INNER JOIN
                         dbo.ro_rubro_tipo AS rub ON nov.IdEmpresa = rub.IdEmpresa AND nov.IdRubro = rub.IdRubro

where nov.IdEmpresa=@IdEmpresa
and emp.IdEmpresa=@IdEmpresa
and novc.IdNomina_tipo=@IdNomina
and novc.IdNomina_TipoLiqui=@IdNominaTipo
and nov.FechaPago between @Fi and @Ff
and emp.IdEmpleado=@IdEmpleado
and novc.IdEmpleado=@IdEmpleado
and novc.Estado='A'
and nov.EstadoCobro='PEN'
and (emp.em_status<>'EST_LIQ')
and CAST( emp.em_fechaIngaRol as date)<=@Ff
and ISNULL( emp.em_fechaSalida, @Fi) between @Fi and @Ff


update ro_rol_detalle set valor=round(valor,2) where  ro_rol_detalle.IdEmpresa=@IdEmpresa  and IdNominaTipo=@IdNomina and IdNominaTipoLiqui=@IdNominaTipo and IdPeriodo=@IdPEriodo and IdEmpleado=@IdEmpleado

END
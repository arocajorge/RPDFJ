

CREATE PROCEDURE [dbo].[spRo_nomina_segunda_quincena_fijo] (
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
-------------calculando dias trabajados por empleado-----------------------------------------------------------------------------------------<
----------------------------------------------------------------------------------------------------------------------------------------------

select @IdRubro_calculado= IdRubro_dias_trabajados from ro_rubros_calculados where IdEmpresa=@IdEmpresa-- obteniendo el idrubro desde parametros
select @Orden=ru_orden_rol_general from ro_rubro_tipo where IdEmpresa=@IdEmpresa and IdRubro=@IdRubro_calculado
insert into ro_rol_detalle
(IdEmpresa,	IdNominaTipo,IdNominaTipoLiqui,IdPeriodo,									IdEmpleado,			IdRubro,			Orden,			Valor
,rub_visible_reporte,	Observacion			)

select 

@IdEmpresa	,@IdNomina,@IdNominaTipo,@IdPEriodo			,cont.IdEmpleado		,@IdRubro_calculado	,ISNULL( @Orden,0) , ISNULL( dbo.calcular_dias_trabajados(emp.IdEmpresa,emp.IdEmpleado, @Fi,@Ff,emp.em_fechaIngaRol, emp.em_status, emp.em_fechaSalida),0)
,1						,'Días trabajados'		        
FROM            dbo.vwro_contrato_activo AS cont INNER JOIN
                         dbo.ro_empleado AS emp ON cont.IdEmpresa = emp.IdEmpresa AND cont.IdEmpleado = emp.IdEmpleado INNER JOIN
                         dbo.ro_empleado_x_ro_tipoNomina ON emp.IdEmpresa = dbo.ro_empleado_x_ro_tipoNomina.IdEmpresa AND emp.IdEmpleado = dbo.ro_empleado_x_ro_tipoNomina.IdEmpleado

where cont.IdEmpresa=@IdEmpresa 
and ro_empleado_x_ro_tipoNomina.IdTipoNomina=@IdNomina
and cont.EstadoContrato<>'ECT_LIQ'
and (emp.em_status<>'EST_LIQ' and isnull( emp.em_fechaSalida, @Ff) between @Fi and @Ff )
and CAST( cont.FechaInicio as date)<=@Ff
and emp.IdEmpleado=@IdEmpleado

----------------------------------------------------------------------------------------------------------------------------------------------
-------------calculando sueldo por días trabajados-------------------------------------------------------------------------------------------<
----------------------------------------------------------------------------------------------------------------------------------------------
select @IdRubro_calculado= IdRubro_sueldo from ro_rubros_calculados where IdEmpresa=@IdEmpresa-- obteniendo el idrubro desde parametros
select @Orden=ru_orden_rol_general from ro_rubro_tipo where IdEmpresa=@IdEmpresa and IdRubro=@IdRubro_calculado
insert into ro_rol_detalle
(IdEmpresa,		IdNominaTipo,IdNominaTipoLiqui,IdPeriodo,								IdEmpleado,			IdRubro,			Orden,			Valor
,rub_visible_reporte,	Observacion)

select 
@IdEmpresa	,@IdNomina,@IdNominaTipo,@IdPEriodo,						cont.IdEmpleado		,@IdRubro_calculado	,ISNULL( @Orden,0) ,
 (sueldo.SueldoActual/30)*isnull( (dbo.calcular_dias_trabajados(emp.IdEmpresa,emp.IdEmpleado,@Fi,@Ff,emp.em_fechaIngaRol, emp.em_status, emp.em_fechaSalida)),0) 
 
,1						,'Sueldo base'	
	FROM            dbo.vwro_contrato_activo AS cont INNER JOIN
                         dbo.ro_empleado AS emp ON cont.IdEmpresa = emp.IdEmpresa AND cont.IdEmpleado = emp.IdEmpleado INNER JOIN
                         dbo.ro_empleado_x_ro_tipoNomina AS nomina ON emp.IdEmpresa = nomina.IdEmpresa AND emp.IdEmpleado = nomina.IdEmpleado LEFT OUTER JOIN
                         dbo.vwro_empleado_historial_Sueldo_actual AS sueldo ON emp.IdEmpresa = sueldo.IdEmpresa AND emp.IdEmpleado = sueldo.IdEmpleado
where cont.IdEmpresa=@IdEmpresa 
and nomina.IdTipoNomina=@IdNomina
and cont.EstadoContrato<>'ECT_LIQ'
and (emp.em_status<>'EST_LIQ' and isnull( emp.em_fechaSalida, @Ff) between @Fi and @Ff )
and CAST( cont.FechaInicio as date)<=@Ff
and emp.IdEmpleado=@IdEmpleado
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


----------------------------------------------------------------------------------------------------------------------------------------------
-------------AGRUPANDO EGRESOS QUE NO SE MUESTRAN ROL RENERAL-----------------------------------------------------------------------<
----------------------------------------------------------------------------------------------------------------------------------------------
select @IdRubro_calculado= IdRubro_otros_descuentos from ro_rubros_calculados where IdEmpresa=@IdEmpresa-- obteniendo el idrubro desde parametros
select @Orden=ru_orden_rol_general from ro_rubro_tipo where IdEmpresa=@IdEmpresa and IdRubro=@IdRubro_calculado
insert into ro_rol_detalle
(IdEmpresa,	IdNominaTipo,IdNominaTipoLiqui,IdPeriodo,									IdEmpleado,			IdRubro,			Orden,			Valor
,rub_visible_reporte,	Observacion)

select 
@IdEmpresa		,@IdNomina,@IdNominaTipo,@IdPEriodo							,novc.IdEmpleado		,@IdRubro_calculado		,ISNULL(@Orden,0)	,sum(nov.Valor)
,1					,'OTROS DESCUENTOS'		
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
and emp.IdEmpleado=@IdEmpleado
and novc.Estado='A'
and nov.EstadoCobro='PEN'
and (emp.em_status<>'EST_LIQ')
and rub.ru_muestra_rol_general=0
and rub.rub_concep=1
and rub.ru_tipo='E'
and CAST( emp.em_fechaIngaRol as date)<=@Ff
and ISNULL( emp.em_fechaSalida, @Fi) between @Fi and @Ff
group by novc.IdEmpresa,novc.IdEmpleado

----------------------------------------------------------------------------------------------------------------------------------------------
-------------AGRUPANDOS HORAS EXTRAS-----------------------------------------------------------------------<
----------------------------------------------------------------------------------------------------------------------------------------------
select @IdRubro_calculado= IdRubro_horas_extras from ro_rubros_calculados where IdEmpresa=@IdEmpresa-- obteniendo el idrubro desde parametros
select @Orden=ru_orden_rol_general from ro_rubro_tipo where IdEmpresa=@IdEmpresa and IdRubro=@IdRubro_calculado
insert into ro_rol_detalle
(IdEmpresa,	IdNominaTipo,IdNominaTipoLiqui,IdPeriodo,									IdEmpleado,			IdRubro,			Orden,			Valor
,rub_visible_reporte,	Observacion)

select 
@IdEmpresa		,@IdNomina,@IdNominaTipo,@IdPEriodo							,novc.IdEmpleado		,@IdRubro_calculado		,ISNULL(@Orden,0)	,sum(nov.Valor)
,1					,'HORAS EXTRAS'		
FROM            dbo.ro_empleado_x_ro_tipoNomina RIGHT OUTER JOIN
                         dbo.ro_empleado AS emp INNER JOIN
                         dbo.ro_empleado_Novedad AS novc ON emp.IdEmpresa = novc.IdEmpresa AND emp.IdEmpleado = novc.IdEmpleado ON dbo.ro_empleado_x_ro_tipoNomina.IdEmpresa = emp.IdEmpresa AND 
                         dbo.ro_empleado_x_ro_tipoNomina.IdEmpleado = emp.IdEmpleado LEFT OUTER JOIN
                         dbo.ro_rubro_tipo AS rub INNER JOIN
                         dbo.ro_empleado_novedad_det AS nov ON rub.IdEmpresa = nov.IdEmpresa AND rub.IdRubro = nov.IdRubro ON novc.IdEmpresa = nov.IdEmpresa AND novc.IdNovedad = nov.IdNovedad AND novc.IdEmpleado = nov.IdEmpleado
where ro_empleado_x_ro_tipoNomina.IdTipoNomina=@IdNomina
and nov.IdEmpresa=@IdEmpresa
and novc.IdNomina_tipo=@IdNomina
and novc.IdNomina_TipoLiqui=@IdNominaTipo
and nov.FechaPago between @Fi and @Ff
and emp.IdEmpleado=@IdEmpleado
and novc.Estado='A'
and nov.EstadoCobro='PEN'
and (emp.em_status<>'EST_LIQ')
and rub.IdRubro in(7,8,9)
and CAST( emp.em_fechaIngaRol as date)<=@Ff
and ISNULL( emp.em_fechaSalida, @Fi) between @Fi and @Ff
group by novc.IdEmpresa,novc.IdEmpleado
----------------------------------------------------------------------------------------------------------------------------------------------
-------------buscando cuota de prestamos e insertando al rol detalle-------------------------------------------------------------------------<
----------------------------------------------------------------------------------------------------------------------------------------------
insert into ro_rol_detalle
(IdEmpresa,		IdNominaTipo,IdNominaTipoLiqui,IdPeriodo,						IdEmpleado,			IdRubro,			Orden,			Valor
,rub_visible_reporte,	Observacion)

select
@IdEmpresa		,@IdNomina,@IdNominaTipo,@IdPEriodo				,pre.IdEmpleado		,pre.IdRubro		,rub.ru_orden_rol_general	,sum(pred.TotalCuota)
,1						,rub.ru_descripcion
FROM            dbo.ro_prestamo AS pre INNER JOIN
                         dbo.ro_prestamo_detalle AS pred ON pre.IdEmpresa = pred.IdEmpresa AND pre.IdPrestamo = pred.IdPrestamo INNER JOIN
                         dbo.ro_rubro_tipo AS rub ON pre.IdEmpresa = rub.IdEmpresa AND pre.IdRubro = rub.IdRubro INNER JOIN
                         dbo.ro_empleado AS emp ON pre.IdEmpresa = emp.IdEmpresa AND pre.IdEmpleado = emp.IdEmpleado INNER JOIN
                         dbo.vwro_contrato_activo AS cont ON emp.IdEmpresa = cont.IdEmpresa AND emp.IdEmpleado = cont.IdEmpleado INNER JOIN
                         dbo.ro_empleado_x_ro_tipoNomina ON emp.IdEmpresa = dbo.ro_empleado_x_ro_tipoNomina.IdEmpresa AND emp.IdEmpleado = dbo.ro_empleado_x_ro_tipoNomina.IdEmpleado

and pre.IdEmpresa=@IdEmpresa
and emp.IdEmpresa=@IdEmpresa
and pred.IdNominaTipoLiqui=@IdNominaTipo
and ro_empleado_x_ro_tipoNomina.IdTipoNomina=@IdNomina
and CAST(pred.FechaPago AS DATE) between @Fi and @Ff
and emp.IdEmpleado=@IdEmpleado
and pred.Estado='A'
and pred.EstadoPago='PEN'
and (emp.em_status <>'EST_LIQ' and isnull( emp.em_fechaSalida, @Ff) between @Fi and @Ff )
and CAST( emp.em_fechaIngaRol as date)<=@Ff
--and emp.IdSucursal = @IdSucursalFin
and pred.FechaPago between  @Fi and @Ff 
and pred.IdNominaTipoLiqui=@IdNominaTipo
and ro_empleado_x_ro_tipoNomina.IdTipoNomina=@IdNomina
and cont.EstadoContrato <>'ECT_LIQ'
group by pred.IdEmpresa,pre.IdEmpleado,emp.IdSucursal, pre.IdRubro, rub.ru_orden, rub.ru_descripcion,rub.ru_orden_rol_general
----------------------------------------------------------------------------------------------------------------------------------------------
-------------buscando rubros fijos e insertando al rol detalle-------------------------------------------------------------------------------<
----------------------------------------------------------------------------------------------------------------------------------------------
insert into ro_rol_detalle
(IdEmpresa,	IdNominaTipo,IdNominaTipoLiqui,IdPeriodo,					IdEmpleado,			IdRubro,			Orden,			Valor
,rub_visible_reporte,	Observacion)

select
@IdEmpresa	,@IdNomina,@IdNominaTipo,@IdPEriodo						,emp.IdEmpleado		,rub_fij.IdRubro	,rub.ru_orden_rol_general	,rub_fij.Valor
,ISNULL( rub.ru_muestra_rol_general,0)						,rub.ru_descripcion	
FROM            dbo.ro_rubro_tipo AS rub INNER JOIN
                         dbo.ro_empleado_x_ro_rubro AS rub_fij ON rub.IdEmpresa = rub_fij.IdEmpresa AND rub.IdRubro = rub_fij.IdRubro INNER JOIN
                         dbo.ro_empleado AS emp ON rub_fij.IdEmpresa = emp.IdEmpresa AND rub_fij.IdEmpleado = emp.IdEmpleado INNER JOIN
                         dbo.vwro_contrato_activo AS cont ON emp.IdEmpresa = cont.IdEmpresa AND emp.IdEmpleado = cont.IdEmpleado INNER JOIN
                         dbo.ro_empleado_x_ro_tipoNomina ON emp.IdEmpresa = dbo.ro_empleado_x_ro_tipoNomina.IdEmpresa AND emp.IdEmpleado = dbo.ro_empleado_x_ro_tipoNomina.IdEmpleado
where rub_fij.IdEmpresa=@IdEmpresa
and emp.IdEmpresa=@IdEmpresa
and rub_fij.IdNomina_tipo=@IdNomina
and rub_fij.IdNomina_TipoLiqui=@IdNominaTipo
and ro_empleado_x_ro_tipoNomina.IdTipoNomina=@IdNomina
and (emp.em_status<>'EST_LIQ' and isnull( emp.em_fechaSalida, @Ff) between @Fi and @Ff )
and emp.IdEmpleado=@IdEmpleado
and CAST( emp.em_fechaIngaRol as date)<=@Ff
and cont.EstadoContrato<>'ECT_LIQ'

----------------------------------------------------------------------------------------------------------------------------------------------
-------------calculando aporte personal------------------------------------------------------------------------------------------------------<
----------------------------------------------------------------------------------------------------------------------------------------------
select @IdRubro_calculado= IdRubro_iess_perso from ro_rubros_calculados where IdEmpresa=@IdEmpresa-- obteniendo el idrubro desde parametros
select @Orden=ru_orden_rol_general from ro_rubro_tipo where IdEmpresa=@IdEmpresa and IdRubro=@IdRubro_calculado
insert into ro_rol_detalle
(IdEmpresa,IdNominaTipo,IdNominaTipoLiqui,IdPeriodo,										IdEmpleado,			IdRubro,			Orden,			Valor
,rub_visible_reporte,	Observacion)

select
@IdEmpresa		,@IdNomina,@IdNominaTipo,@IdPEriodo									,rol_det.IdEmpleado		,@IdRubro_calculado	,ISNULL( @Orden,0)			,ISNULL( sum(rol_det.Valor)*@Por_apor_pers_iess ,0)
,1					,'Aporte personal'	
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
and emp.IdEmpleado=@IdEmpleado
and rub.ru_tipo='I' 
and rub.rub_aplica_IESS=1
and cont.EstadoContrato<>'ECT_LIQ'
--AND cont.IdNomina=@IdNomina
group by rol_det.IdEmpresa,rol_det.IdEmpleado,ro_rol.IdNominaTipo,ro_rol.IdNominaTipoLiqui,ro_rol.IdPeriodo, emp.IdSucursal
----------------------------------------------------------------------------------------------------------------------------------------------
-------------calculando anticipo de quincena------------------------------------------------------------------------------------------------------<
----------------------------------------------------------------------------------------------------------------------------------------------
select @IdRubro_calculado= IdRubro_anticipo, @IdRubro_anticipo=IdRubro_tot_ing from ro_rubros_calculados where IdEmpresa=@IdEmpresa-- obteniendo el idrubro desde parametros
select @Orden=ru_orden_rol_general from ro_rubro_tipo where IdEmpresa=@IdEmpresa and IdRubro=@IdRubro_calculado
insert into ro_rol_detalle
(IdEmpresa	,IdNominaTipo,IdNominaTipoLiqui,IdPeriodo,							IdEmpleado,			IdRubro,			Orden,			Valor
,rub_visible_reporte,	Observacion)

select
@IdEmpresa	,@IdNomina,@IdNominaTipo,@IdPEriodo							,rol_det.IdEmpleado		,@IdRubro_calculado	,ISNULL( @Orden,0)			,sum(rol_det.Valor)
,1						,'Anticipo 25 primera quincena'	
FROM            dbo.ro_rol_detalle AS rol_det INNER JOIN
                         dbo.ro_rubro_tipo AS rub ON rol_det.IdEmpresa = rub.IdEmpresa AND rol_det.IdRubro = rub.IdRubro INNER JOIN
                         dbo.ro_rol ON rol_det.IdEmpresa = dbo.ro_rol.IdEmpresa AND rol_det.IdNominaTipo = dbo.ro_rol.IdNominaTipo AND rol_det.IdNominaTipoLiqui = dbo.ro_rol.IdNominaTipoLiqui AND 
                         rol_det.IdPeriodo = dbo.ro_rol.IdPeriodo INNER JOIN
                         dbo.ro_empleado AS emp ON rol_det.IdEmpresa = emp.IdEmpresa AND rol_det.IdEmpleado = emp.IdEmpleado INNER JOIN
                         dbo.vwro_contrato_activo AS cont ON emp.IdEmpresa = cont.IdEmpresa AND emp.IdEmpleado = cont.IdEmpleado
where rol_det.IdEmpresa=@IdEmpresa
and ro_rol.IdNominaTipo=@IdNomina
and ro_rol.IdNominaTipoLiqui=1
and ro_rol.IdPeriodo=CAST( @IdPEriodo as varchar)+'01'
and rol_det.IdRubro in(@IdRubro_anticipo)
and rol_det.IdNominaTipo=@IdNomina
and emp.IdEmpleado=@IdEmpleado
and cont.EstadoContrato<>'ECT_LIQ'
and rol_det.Valor != 0
group by rol_det.IdEmpresa,rol_det.IdEmpleado,ro_rol.IdNominaTipo,ro_rol.IdNominaTipoLiqui,ro_rol.IdPeriodo, emp.IdSucursal

----------------------------------------------------------------------------------------------------------------------------------------------
-------------calculando fondo de reserva----------------------------------------------------------------------------------------------------<
----------------------------------------------------------------------------------------------------------------------------------------------
select @IdRubro_calculado= IdRubro_fondo_reserva,@IdRubro_Provision=IdRubro_fondo_reserva,@IdRubro_horas_extras=IdRubro_horas_extras from ro_rubros_calculados where IdEmpresa=@IdEmpresa-- obteniendo el idrubro desde parametros
select @Orden=ru_orden_rol_general from ro_rubro_tipo where IdEmpresa=@IdEmpresa and IdRubro=@IdRubro_calculado
insert into ro_rol_detalle
(IdEmpresa	,IdNominaTipo,IdNominaTipoLiqui,IdPeriodo,						IdEmpleado,			IdRubro,			Orden,			Valor
,rub_visible_reporte,	Observacion)
select
@IdEmpresa,@IdNomina,@IdNominaTipo,@IdPEriodo					,rol_det.IdEmpleado		,@IdRubro_calculado	,ISNULL( @Orden,0)			, 
ISNULL( round( (sum(rol_det.Valor) /30) * dbo.calcular_dias_fondos_reserva(@Fi,@Ff,emp.em_fechaIngaRol, emp.em_status, ISNULL(EMP.em_fechaSalida,DATEADD(YEAR,50,GETDATE())), cont.FechaAcumulacion)*0.0833 ,2),0)

,1						,'Fondos de reserva'	
FROM            dbo.ro_rol_detalle AS rol_det INNER JOIN
                         dbo.ro_rubro_tipo AS rub ON rol_det.IdEmpresa = rub.IdEmpresa AND rol_det.IdRubro = rub.IdRubro INNER JOIN
                         dbo.ro_rol ON rol_det.IdEmpresa = dbo.ro_rol.IdEmpresa AND rol_det.IdNominaTipo = dbo.ro_rol.IdNominaTipo AND rol_det.IdNominaTipoLiqui = dbo.ro_rol.IdNominaTipoLiqui AND 
                         rol_det.IdPeriodo = dbo.ro_rol.IdPeriodo INNER JOIN
                         dbo.ro_empleado AS emp ON rol_det.IdEmpresa = emp.IdEmpresa AND rol_det.IdEmpleado = emp.IdEmpleado
						 
						 
						 left join
						 (
						 
select con.IdEmpresa,con.IdEmpleado, case when  sum(Dias) is null then dateadd(year,1,CON.FechaInicio) else DATEADD(DAY,(365 - case when isnull(sum(Dias),0) > 365 then isnull(sum(Dias),0) else isnull(sum(Dias),0) end), CON.FechaInicio ) end FechaAcumulacion
from vwro_contrato_activo as con left join (
SELECT IdEmpresa, IdEmpleado, DATEDIFF(DAY,FechaInicio,FechaFin)+1 Dias FROM vwro_contrato_activo C WHERE C.EstadoContrato = 'ECT_LIQ' ) a 
on con.IdEmpresa = a.IdEmpresa and con.IdEmpleado = a.IdEmpleado 
WHERE con.EstadoContrato<>'ECT_LIQ' --and con.IdEmpresa = 5 and con.IdEmpleado = 31
group by con.IdEmpresa,con.IdEmpleado, con.FechaInicio
)

as cont on emp.IdEmpresa = cont.IdEmpresa and emp.IdEmpleado = cont.IdEmpleado

where rol_det.IdEmpresa=@IdEmpresa
and ro_rol.IdNominaTipo=@IdNomina
and ro_rol.IdNominaTipoLiqui=@IdNominaTipo
and ro_rol.IdPeriodo=@IdPEriodo
and rub.ru_tipo='I' and rub.rub_aplica_IESS=1
and rol_det.IdRubro!=@IdRubro_horas_extras
AND CONT.FechaAcumulacion <= @FF
and emp.IdEmpleado=@IdEmpleado
and  not exists(select acum.IdEmpleado from ro_empleado_x_rubro_acumulado acum 
where acum.IdEmpresa= @IdEmpresa
and acum.IdEmpresa=emp.IdEmpresa
and acum.IdEmpleado=emp.IdEmpleado
and acum.IdRubro=@IdRubro_Provision)
and CAST( emp.em_fechaIngaRol as date)<=@Ff
group by rol_det.IdEmpresa,rol_det.IdEmpleado,ro_rol.IdNominaTipo,ro_rol.IdNominaTipoLiqui,ro_rol.IdPeriodo, emp.IdSucursal, emp.em_fechaIngaRol, emp.em_fechaSalida, emp.em_status,cont.FechaAcumulacion

----------------------------------------------------------------------------------------------------------------------------------------------
-------------calculando decimo tercer sueldo-------------------------------------------------------------------------------------------------<
----------------------------------------------------------------------------------------------------------------------------------------------
select @IdRubro_calculado= IdRubro_DIII, @IdRubro_Provision=IdRubro_DIII from ro_rubros_calculados where IdEmpresa=@IdEmpresa-- obteniendo el idrubro desde parametros
select @Orden=ru_orden_rol_general from ro_rubro_tipo where IdEmpresa=@IdEmpresa and IdRubro=@IdRubro_calculado
insert into ro_rol_detalle
(IdEmpresa,	IdNominaTipo,IdNominaTipoLiqui,IdPeriodo,								IdEmpleado,			IdRubro,			Orden,			Valor
,rub_visible_reporte,	Observacion)
select
@IdEmpresa	,@IdNomina,@IdNominaTipo,@IdPEriodo									,rol_det.IdEmpleado		,@IdRubro_calculado	,ISNULL( @Orden,0)			, ROUND((sum(rol_det.Valor)/360)*30 ,2)
/*dbo.calcular_dias_trabajados(@Fi,@Ff,emp.em_fechaIngaRol, emp.em_status, emp.em_fechaSalida),2)*/
,1						,'Decimo tercer sueldo'	
FROM            dbo.ro_rol_detalle AS rol_det INNER JOIN
                         dbo.ro_rubro_tipo AS rub ON rol_det.IdEmpresa = rub.IdEmpresa AND rol_det.IdRubro = rub.IdRubro INNER JOIN
                         dbo.ro_rol ON rol_det.IdEmpresa = dbo.ro_rol.IdEmpresa AND rol_det.IdNominaTipo = dbo.ro_rol.IdNominaTipo AND rol_det.IdNominaTipoLiqui = dbo.ro_rol.IdNominaTipoLiqui AND 
                         rol_det.IdPeriodo = dbo.ro_rol.IdPeriodo INNER JOIN
                         dbo.ro_empleado AS emp ON rol_det.IdEmpresa = emp.IdEmpresa AND rol_det.IdEmpleado = emp.IdEmpleado INNER JOIN
                         dbo.vwro_contrato_activo AS cont ON emp.IdEmpresa = cont.IdEmpresa AND emp.IdEmpleado = cont.IdEmpleado where rol_det.IdEmpresa=@IdEmpresa
and ro_rol.IdNominaTipo=@IdNomina
and ro_rol.IdNominaTipoLiqui=@IdNominaTipo
and ro_rol.IdPeriodo=@IdPEriodo
and rub.ru_tipo='I' and rub.rub_aplica_IESS=1
and emp.IdEmpleado=@IdEmpleado
and rol_det.IdEmpleado not in(
select acum.IdEmpleado from ro_empleado_x_rubro_acumulado acum 
where acum.IdEmpresa= emp.IdEmpresa
and acum.IdEmpleado=emp.IdEmpleado
and acum.IdRubro=@IdRubro_Provision
and acum.IdEmpresa=@IdEmpresa
and emp.IdEmpresa=@IdEmpresa
)
and cont.EstadoContrato<>'ECT_LIQ'
and ISNULL( emp.em_fechaSalida, @Fi) between @Fi and @Ff

group by rol_det.IdEmpresa,rol_det.IdEmpleado,ro_rol.IdNominaTipo,ro_rol.IdNominaTipoLiqui,ro_rol.IdPeriodo, emp.IdSucursal,emp.em_fechaIngaRol, emp.em_status, emp.em_fechaSalida

----------------------------------------------------------------------------------------------------------------------------------------------
-------------calculando decimo cuarto sueldo-------------------------------------------------------------------------------------------------<
----------------------------------------------------------------------------------------------------------------------------------------------
select @IdRubro_calculado= IdRubro_DIV, @IdRubro_Provision=IdRubro_DIV from ro_rubros_calculados where IdEmpresa=@IdEmpresa-- obteniendo el idrubro desde parametros
select @Orden=ru_orden_rol_general from ro_rubro_tipo where IdEmpresa=@IdEmpresa and IdRubro=@IdRubro_calculado
insert into ro_rol_detalle
(IdEmpresa,		IdNominaTipo,IdNominaTipoLiqui,IdPeriodo,								IdEmpleado,			IdRubro,			Orden,			Valor
,rub_visible_reporte,	Observacion)
select
@IdEmpresa	,@IdNomina,@IdNominaTipo,@IdPEriodo										,emp.IdEmpleado		,@IdRubro_calculado	,ISNULL( @Orden,0)			,ISNULL( ROUND((@SueldoBasico/360)* 
dbo.calcular_dias_trabajados(emp.IdEmpresa,emp.IdEmpleado,@Fi,@Ff,emp.em_fechaIngaRol, emp.em_status, emp.em_fechaSalida),2) ,0)
,1						,'Decimo cuarto sueldo'	
FROM            dbo.ro_empleado AS emp INNER JOIN
                         dbo.vwro_contrato_activo AS cont ON emp.IdEmpresa = cont.IdEmpresa AND emp.IdEmpleado = cont.IdEmpleado LEFT OUTER JOIN
                         dbo.ro_empleado_x_ro_tipoNomina ON emp.IdEmpresa = dbo.ro_empleado_x_ro_tipoNomina.IdEmpresa AND emp.IdEmpleado = dbo.ro_empleado_x_ro_tipoNomina.IdEmpleado

where 
 cont.EstadoContrato<>'ECT_LIQ'
and (emp.em_status<>'EST_LIQ')
and ro_empleado_x_ro_tipoNomina.IdTipoNomina=@IdNomina
and emp.IdEmpleado=@IdEmpleado
and emp.IdEmpleado not in(select acum.IdEmpleado from ro_empleado_x_rubro_acumulado acum 
where acum.IdEmpresa= emp.IdEmpresa
and acum.IdEmpresa=emp.IdEmpresa
and acum.IdEmpleado=emp.IdEmpleado
and acum.IdRubro=@IdRubro_Provision
and acum.IdEmpresa=@IdEmpresa
and emp.IdEmpresa=@IdEmpresa)
AND emp.IdEmpresa=@IdEmpresa

and CAST( emp.em_fechaIngaRol as date)<=@Ff
and ISNULL( emp.em_fechaSalida, @Fi) between @Fi and @Ff
group by emp.IdEmpresa,emp.IdEmpleado, emp.em_fechaSalida, cont.FechaInicio, cont.FechaFin, emp.em_status, emp.IdSucursal, emp.em_status, emp.em_fechaSalida, emp.em_fechaIngaRol

----------------------------------------------------------------------------------------------------------------------
-------------calculando DIAS EFECTIVOS-------------------------------------------------------------------------------------------<
----------------------------------------------------------------------------------------------------------------------------------------------
select  @IdRubro_dias_efectivos=IdRubro_dias_efectivos,  @IdRubro_calculado= IdRubro_alimentacion  from ro_rubros_calculados where IdEmpresa=@IdEmpresa
select @Orden=ru_orden_rol_general from ro_rubro_tipo where IdEmpresa=@IdEmpresa and IdRubro=@IdRubro_dias_efectivos
insert into ro_rol_detalle
(IdEmpresa,	IdNominaTipo,IdNominaTipoLiqui,IdPeriodo,									IdEmpleado,			IdRubro,			Orden,			Valor
,rub_visible_reporte,	Observacion)

select TOP(9000)
@IdEmpresa		,@IdNomina,@IdNominaTipo,@IdPEriodo							,emp.IdEmpleado		,@IdRubro_dias_efectivos		,ISNULL( @Orden,0)	,COUNT(emp.IdEmpleado)
,1						,'DIAS EFECTIVOS'		
FROM            dbo.ro_empleado AS emp LEFT OUTER JOIN
                         dbo.vwro_contrato_activo AS contr ON emp.IdEmpresa = contr.IdEmpresa AND emp.IdEmpleado = contr.IdEmpleado LEFT OUTER JOIN
                         dbo.ro_empleado_x_ro_tipoNomina AS nom ON emp.IdEmpresa = nom.IdEmpresa AND emp.IdEmpleado = nom.IdEmpleado LEFT OUTER JOIN
                         Fj_servindustrias.ro_Grupo_empleado AS grup ON emp.IdEmpresa = grup.IdEmpresa AND emp.IdGrupo = grup.IdGrupo LEFT OUTER JOIN
                         Fj_servindustrias.ro_marcaciones_x_empleado_x_incidentes_falt_Perm AS marc ON emp.IdEmpresa = marc.IdEmpresa AND emp.IdEmpleado = marc.IdEmpleado


where emp.IdEmpresa=@IdEmpresa
and nom.IdTipoNomina=@IdNomina
and marc.es_fecha_registro between @Fi and @Ff
and emp.IdEmpleado=@IdEmpleado
and (emp.em_status<>'EST_LIQ')
and marc.Id_catalogo_Cat='ASIST'
and CAST( emp.em_fechaIngaRol as date)<=@Ff
and ISNULL( emp.em_fechaSalida, @Fi) between @Fi and @Ff
and grup.IdRubro_Alim=@IdRubro_calculado
and grup.IdRubro_Alim is not null
GROUP BY emp.IdEmpresa, emp.IdEmpleado,  grup.IdRubro_Alim, grup.Valor_Alimen, grup.Valor_bono, contr.FechaFin, contr.FechaInicio, 
                         contr.EstadoContrato
----------------------------------------------------------------------------------------------------------------------
-------------calculando ALIMENTACION-------------------------------------------------------------------------------------------<
----------------------------------------------------------------------------------------------------------------------------------------------
select @IdRubro_calculado= IdRubro_alimentacion from ro_rubros_calculados where IdEmpresa=@IdEmpresa
select @Orden=ru_orden_rol_general from ro_rubro_tipo where IdEmpresa=@IdEmpresa and IdRubro=@IdRubro_calculado
insert into ro_rol_detalle
(IdEmpresa,	IdNominaTipo,IdNominaTipoLiqui,IdPeriodo,									IdEmpleado,			IdRubro,			Orden,			Valor
,rub_visible_reporte,	Observacion)

select TOP(9000)
@IdEmpresa		,@IdNomina,@IdNominaTipo,@IdPEriodo							,emp.IdEmpleado		,grup.IdRubro_Alim		,ISNULL( @Orden,0)	,grup.Valor_Alimen*COUNT(emp.IdEmpleado)
,1						,'ALIMENTACION'		
FROM            dbo.ro_empleado AS emp LEFT OUTER JOIN
                         dbo.vwro_contrato_activo AS contr ON emp.IdEmpresa = contr.IdEmpresa AND emp.IdEmpleado = contr.IdEmpleado LEFT OUTER JOIN
                         dbo.ro_empleado_x_ro_tipoNomina AS nom ON emp.IdEmpresa = nom.IdEmpresa AND emp.IdEmpleado = nom.IdEmpleado LEFT OUTER JOIN
                         Fj_servindustrias.ro_Grupo_empleado AS grup ON emp.IdEmpresa = grup.IdEmpresa AND emp.IdGrupo = grup.IdGrupo LEFT OUTER JOIN
                         Fj_servindustrias.ro_marcaciones_x_empleado_x_incidentes_falt_Perm AS marc ON emp.IdEmpresa = marc.IdEmpresa AND emp.IdEmpleado = marc.IdEmpleado

where emp.IdEmpresa=@IdEmpresa
and nom.IdTipoNomina=@IdNomina
and marc.es_fecha_registro between @Fi and @Ff
and emp.IdEmpleado=@IdEmpleado
and (emp.em_status<>'EST_LIQ')
and marc.Id_catalogo_Cat='ASIST'
and CAST( emp.em_fechaIngaRol as date)<=@Ff
and ISNULL( emp.em_fechaSalida, @Fi) between @Fi and @Ff
and grup.IdRubro_Alim=@IdRubro_calculado
and grup.IdRubro_Alim is not null
GROUP BY emp.IdEmpresa, emp.IdEmpleado,  grup.IdRubro_Alim, grup.Valor_Alimen, grup.Valor_bono, contr.FechaFin, contr.FechaInicio, 
                         contr.EstadoContrato
----------------------------------------------------------------------------------------------------------------------
-------------calculando TRANSPORTE-------------------------------------------------------------------------------------------<
----------------------------------------------------------------------------------------------------------------------------------------------
select @IdRubro_calculado= IdRubro_transporte from ro_rubros_calculados where IdEmpresa=@IdEmpresa
select @Orden=ru_orden_rol_general from ro_rubro_tipo where IdEmpresa=@IdEmpresa and IdRubro=@IdRubro_calculado
insert into ro_rol_detalle
(IdEmpresa,	IdNominaTipo,IdNominaTipoLiqui,IdPeriodo,									IdEmpleado,			IdRubro,			Orden,			Valor
,rub_visible_reporte,	Observacion)

select TOP(9000)
@IdEmpresa		,@IdNomina,@IdNominaTipo,@IdPEriodo							,emp.IdEmpleado		,grup.IdRubro_Trans		,ISNULL( @Orden,0),grup.Valor_Transp*COUNT(emp.IdEmpleado)
,1						,'TRANSPORTE'		
FROM            dbo.ro_empleado AS emp LEFT OUTER JOIN
                         dbo.vwro_contrato_activo AS contr ON emp.IdEmpresa = contr.IdEmpresa AND emp.IdEmpleado = contr.IdEmpleado LEFT OUTER JOIN
                         dbo.ro_empleado_x_ro_tipoNomina AS nom ON emp.IdEmpresa = nom.IdEmpresa AND emp.IdEmpleado = nom.IdEmpleado LEFT OUTER JOIN
                         Fj_servindustrias.ro_Grupo_empleado AS grup ON emp.IdEmpresa = grup.IdEmpresa AND emp.IdGrupo = grup.IdGrupo LEFT OUTER JOIN
                         Fj_servindustrias.ro_marcaciones_x_empleado_x_incidentes_falt_Perm AS marc ON emp.IdEmpresa = marc.IdEmpresa AND emp.IdEmpleado = marc.IdEmpleado


where emp.IdEmpresa=@IdEmpresa
and nom.IdTipoNomina=@IdNomina
and marc.es_fecha_registro between @Fi and @Ff
and emp.IdEmpleado=@IdEmpleado
and (emp.em_status<>'EST_LIQ')
and marc.Id_catalogo_Cat='ASIST'
and CAST( emp.em_fechaIngaRol as date)<=@Ff
and ISNULL( emp.em_fechaSalida, @Fi) between @Fi and @Ff
and grup.IdRubro_Trans=@IdRubro_calculado
and grup.IdRubro_Trans is not null
GROUP BY emp.IdEmpresa, emp.IdEmpleado,  grup.IdRubro_Trans, grup.Valor_Transp, grup.Valor_bono, contr.FechaFin, contr.FechaInicio, 
                         contr.EstadoContrato
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
-------------INSERTANDO PROVISIONES ACUMULADAS-----------------------------------------------------------------------------------------------<
----------------------------------------------------------------------------------------------------------------------------------------------


----------------------------------------------------------------------------------------------------------------------------------------------
-------------calculando fondo de reserva----------------------------------------------------------------------------------------------------<
----------------------------------------------------------------------------------------------------------------------------------------------
select @IdRubro_calculado= IdRubro_prov_FR,@IdRubro_Provision=IdRubro_fondo_reserva from ro_rubros_calculados where IdEmpresa=@IdEmpresa-- obteniendo el idrubro desde parametros
insert into ro_rol_detalle_x_rubro_acumulado
(IdEmpresa,IdNominaTipo,IdNominaTipoLiqui,IdPeriodo,								IdEmpleado,			IdRubro,						Valor, Estado
)
select
@IdEmpresa	,@IdNomina,@IdNominaTipo,@IdPEriodo							,rol_det.IdEmpleado		,@IdRubro_calculado	,			

--CASE WHEN emp.Pago_por_horas = 1 then 
ISNULL( round( (sum(rol_det.Valor) /30) * dbo.calcular_dias_fondos_reserva(@Fi,@Ff,emp.em_fechaIngaRol, emp.em_status, ISNULL(EMP.em_fechaSalida,DATEADD(YEAR,50,GETDATE())), contI.FechaAcumulacion)*0.0833 ,2),0)
,'PEN'

FROM            dbo.ro_rol_detalle AS rol_det INNER JOIN
                         dbo.ro_rubro_tipo AS rub ON rol_det.IdEmpresa = rub.IdEmpresa AND rol_det.IdRubro = rub.IdRubro INNER JOIN
                         dbo.ro_rol ON rol_det.IdEmpresa = dbo.ro_rol.IdEmpresa AND rol_det.IdNominaTipo = dbo.ro_rol.IdNominaTipo AND rol_det.IdNominaTipoLiqui = dbo.ro_rol.IdNominaTipoLiqui AND 
                         rol_det.IdPeriodo = dbo.ro_rol.IdPeriodo INNER JOIN
                         dbo.ro_empleado AS emp ON rol_det.IdEmpresa = emp.IdEmpresa AND rol_det.IdEmpleado = emp.IdEmpleado INNER JOIN
                         dbo.vwro_contrato_activo AS cont ON emp.IdEmpresa = cont.IdEmpresa AND emp.IdEmpleado = cont.IdEmpleado INNER JOIN
                         dbo.ro_empleado_x_ro_tipoNomina ON emp.IdEmpresa = dbo.ro_empleado_x_ro_tipoNomina.IdEmpresa AND emp.IdEmpleado = dbo.ro_empleado_x_ro_tipoNomina.IdEmpleado
						 						 
						 INNER JOIN
                         dbo.ro_empleado_x_rubro_acumulado AS emp_x_rub_acum ON emp.IdEmpresa = emp_x_rub_acum.IdEmpresa AND emp.IdEmpleado = emp_x_rub_acum.IdEmpleado left join
						 (
						 
select con.IdEmpresa,con.IdEmpleado, case when  sum(Dias) is null then dateadd(year,1,CON.FechaInicio) else DATEADD(DAY,(365 - case when isnull(sum(Dias),0) > 365 then isnull(sum(Dias),0) else isnull(sum(Dias),0) end), CON.FechaInicio ) end FechaAcumulacion
from vwro_contrato_activo as con left join (
SELECT IdEmpresa, IdEmpleado, DATEDIFF(DAY,FechaInicio,FechaFin)+1 Dias FROM vwro_contrato_activo C WHERE C.EstadoContrato = 'ECT_LIQ' ) a 
on con.IdEmpresa = a.IdEmpresa and con.IdEmpleado = a.IdEmpleado 
WHERE con.EstadoContrato<>'ECT_LIQ' --and con.IdEmpresa = 5 and con.IdEmpleado = 31
group by con.IdEmpresa,con.IdEmpleado, CON.FechaInicio
)

as contI on emp.IdEmpresa = contI.IdEmpresa and emp.IdEmpleado = contI.IdEmpleado
where rol_det.IdEmpresa=@IdEmpresa
and ro_rol.IdNominaTipo=@IdNomina
and ro_rol.IdNominaTipoLiqui=@IdNominaTipo
and ro_rol.IdPeriodo=@IdPEriodo
and rub.ru_tipo='I' and rub.rub_aplica_IESS=1
AND CONTI.FechaAcumulacion <= @Ff
and CAST( emp.em_fechaIngaRol as date)<=@Ff
and ro_empleado_x_ro_tipoNomina.IdTipoNomina=@IdNomina
and cont.EstadoContrato<>'ECT_LIQ'
and (emp.em_status<>'EST_LIQ' and isnull( emp.em_fechaSalida, @Ff) between @Fi and @Ff )
and CAST( cont.FechaInicio as date)<=@Ff
and emp_x_rub_acum.IdRubro=@IdRubro_Provision
and emp.IdEmpleado=@IdEmpleado
group by rol_det.IdEmpresa,rol_det.IdEmpleado,ro_rol.IdNominaTipo,ro_rol.IdNominaTipoLiqui,ro_rol.IdPeriodo, emp.IdSucursal, emp.em_fechaIngaRol,emp.em_fechaSalida, CONT.FechaFin,emp.em_status,contI.FechaAcumulacion

----------------------------------------------------------------------------------------------------------------------------------------------
-------------calculando decimo tercer sueldo-------------------------------------------------------------------------------------------------<
----------------------------------------------------------------------------------------------------------------------------------------------
select @IdRubro_calculado= IdRubro_prov_DIII,@IdRubro_Provision=IdRubro_DIII from ro_rubros_calculados where IdEmpresa=@IdEmpresa-- obteniendo el idrubro desde parametros
insert into ro_rol_detalle_x_rubro_acumulado
(IdEmpresa,	IdNominaTipo,IdNominaTipoLiqui,IdPeriodo,								IdEmpleado,			IdRubro,						Valor, Estado
)
select
@IdEmpresa	,@IdNomina,@IdNominaTipo,@IdPEriodo								,rol_det.IdEmpleado		,@IdRubro_calculado				,round((sum(rol_det.Valor)/360)*30,2)
/*dbo.calcular_dias_trabajados(@Fi,isnull(emp.em_fechaSalida, cast(@Ff as date)),cont.FechaInicio, emp.em_status, emp.em_fechaSalida) as numeric(10,2))*/
,'PEN'
FROM            dbo.ro_rol_detalle AS rol_det INNER JOIN
                         dbo.ro_rubro_tipo AS rub ON rol_det.IdEmpresa = rub.IdEmpresa AND rol_det.IdRubro = rub.IdRubro INNER JOIN
                         dbo.ro_empleado AS emp ON rol_det.IdEmpresa = emp.IdEmpresa AND rol_det.IdEmpleado = emp.IdEmpleado INNER JOIN
                         dbo.vwro_contrato_activo AS cont ON emp.IdEmpresa = cont.IdEmpresa AND emp.IdEmpleado = cont.IdEmpleado INNER JOIN
                         dbo.ro_empleado_x_rubro_acumulado AS emp_x_rub_acum ON emp.IdEmpresa = emp_x_rub_acum.IdEmpresa AND emp.IdEmpleado = emp_x_rub_acum.IdEmpleado INNER JOIN
                         dbo.ro_empleado_x_ro_tipoNomina ON emp.IdEmpresa = dbo.ro_empleado_x_ro_tipoNomina.IdEmpresa AND emp.IdEmpleado = dbo.ro_empleado_x_ro_tipoNomina.IdEmpleado RIGHT OUTER JOIN
                         dbo.ro_rol ON rol_det.IdEmpresa = dbo.ro_rol.IdEmpresa AND rol_det.IdNominaTipo = dbo.ro_rol.IdNominaTipo AND rol_det.IdNominaTipoLiqui = dbo.ro_rol.IdNominaTipoLiqui AND rol_det.IdPeriodo = dbo.ro_rol.IdPeriodo

where rol_det.IdEmpresa=@IdEmpresa
and ro_rol.IdNominaTipo=@IdNomina
and ro_rol.IdNominaTipoLiqui=@IdNominaTipo
and ro_rol.IdPeriodo=@IdPEriodo
and rub.ru_tipo='I' and rub.rub_aplica_IESS=1
and CAST( emp.em_fechaIngaRol as date)<=@Ff
and emp.IdEmpleado=@IdEmpleado
and ro_empleado_x_ro_tipoNomina.IdTipoNomina=@IdNomina
and cont.EstadoContrato <> 'ECT_LIQ'
and (emp.em_status<>'EST_LIQ' and isnull( emp.em_fechaSalida, @Ff) between @Fi and @Ff )
and CAST( cont.FechaInicio as date)<=@Ff


and emp_x_rub_acum.IdRubro=@IdRubro_Provision
group by rol_det.IdEmpresa,rol_det.IdEmpleado,ro_rol.IdNominaTipo,ro_rol.IdNominaTipoLiqui,ro_rol.IdPeriodo, emp.IdSucursal,emp.em_fechaSalida,cont.FechaInicio, emp.em_status, emp.em_fechaSalida

----------------------------------------------------------------------------------------------------------------------------------------------
-------------calculando decimo cuarto sueldo-------------------------------------------------------------------------------------------------<
----------------------------------------------------------------------------------------------------------------------------------------------
select @IdRubro_calculado= IdRubro_prov_DIV, @IdRubro_Provision=IdRubro_DIV from ro_rubros_calculados where IdEmpresa=@IdEmpresa-- obteniendo el idrubro desde parametros
insert into ro_rol_detalle_x_rubro_acumulado
(IdEmpresa,	IdNominaTipo,IdNominaTipoLiqui,IdPeriodo,									IdEmpleado,			IdRubro,						Valor,	Estado
)
select
@IdEmpresa		,@IdNomina,@IdNominaTipo,@IdPEriodo					,emp.IdEmpleado		,@IdRubro_calculado				,ISNULL( round( (@SueldoBasico/360)* 
dbo.calcular_dias_trabajados(emp.IdEmpresa,emp.IdEmpleado,@Fi,isnull(emp.em_fechaSalida, cast(@Ff as date)),cont.FechaInicio, emp.em_status, emp.em_fechaSalida) ,2),0)
,'PEN'
FROM            dbo.ro_empleado AS emp INNER JOIN
                         dbo.vwro_contrato_activo AS cont ON emp.IdEmpresa = cont.IdEmpresa AND emp.IdEmpleado = cont.IdEmpleado LEFT OUTER JOIN
                         dbo.ro_empleado_x_ro_tipoNomina ON emp.IdEmpresa = dbo.ro_empleado_x_ro_tipoNomina.IdEmpresa AND emp.IdEmpleado = dbo.ro_empleado_x_ro_tipoNomina.IdEmpleado LEFT OUTER JOIN
                         dbo.ro_empleado_x_rubro_acumulado AS emp_x_rub_acum ON emp.IdEmpresa = emp_x_rub_acum.IdEmpresa AND emp.IdEmpleado = emp_x_rub_acum.IdEmpleado

where

 (emp.em_status<>'EST_LIQ' and isnull( emp.em_fechaSalida, @Ff) between @Fi and @Ff )
and CAST( cont.FechaInicio as date)<=@Ff
and cont.EstadoContrato <> 'ECT_LIQ'
and emp.IdEmpleado=@IdEmpleado
and emp_x_rub_acum.IdRubro=@IdRubro_Provision
and emp.IdEmpresa=@IdEmpresa
and ro_empleado_x_ro_tipoNomina.IdTipoNomina=@IdNomina
group by emp.IdEmpresa,emp.IdEmpleado, emp.em_fechaSalida, cont.FechaInicio, cont.FechaFin, emp.em_status, emp.IdSucursal
----------------------------------------------------------------------------------------------------------------------------------------------
-------------calculando provision de vacaciones----------------------------------------------------------------------------------------------<
----------------------------------------------------------------------------------------------------------------------------------------------
select @IdRubro_calculado= IdRubro_prov_vac from ro_rubros_calculados where IdEmpresa=@IdEmpresa-- obteniendo el idrubro desde parametros
insert into ro_rol_detalle_x_rubro_acumulado
(IdEmpresa,		IdNominaTipo,IdNominaTipoLiqui,IdPeriodo,								IdEmpleado,			IdRubro,						Valor,						Estado
)
select
@IdEmpresa		,@IdNomina,@IdNominaTipo,@IdPEriodo						,rol_det.IdEmpleado		,@IdRubro_calculado				,CAST( sum(rol_det.Valor)/24 as numeric(10,2)), 'PEN'

FROM            dbo.ro_rol_detalle AS rol_det INNER JOIN
                         dbo.ro_rubro_tipo AS rub ON rol_det.IdEmpresa = rub.IdEmpresa AND rol_det.IdRubro = rub.IdRubro INNER JOIN
                         dbo.ro_empleado AS emp ON rol_det.IdEmpresa = emp.IdEmpresa AND rol_det.IdEmpleado = emp.IdEmpleado INNER JOIN
                         dbo.vwro_contrato_activo AS cont ON emp.IdEmpresa = cont.IdEmpresa AND emp.IdEmpleado = cont.IdEmpleado INNER JOIN
                         dbo.ro_empleado_x_ro_tipoNomina ON emp.IdEmpresa = dbo.ro_empleado_x_ro_tipoNomina.IdEmpresa AND emp.IdEmpleado = dbo.ro_empleado_x_ro_tipoNomina.IdEmpleado RIGHT OUTER JOIN
                         dbo.ro_rol ON rol_det.IdEmpresa = dbo.ro_rol.IdEmpresa AND rol_det.IdNominaTipo = dbo.ro_rol.IdNominaTipo AND rol_det.IdNominaTipoLiqui = dbo.ro_rol.IdNominaTipoLiqui AND rol_det.IdPeriodo = dbo.ro_rol.IdPeriodo


where rol_det.IdEmpresa=@IdEmpresa
and ro_rol.IdNominaTipo=@IdNomina
and ro_rol.IdNominaTipoLiqui=@IdNominaTipo
and ro_rol.IdPeriodo=@IdPEriodo
and rub.ru_tipo='I' and rub.rub_aplica_IESS=1
and emp.IdEmpleado=@IdEmpleado
and CAST( emp.em_fechaIngaRol as date)<=@Ff
and ro_empleado_x_ro_tipoNomina.IdTipoNomina=@IdNomina

and (emp.em_status<>'EST_LIQ' and isnull( emp.em_fechaSalida, @Ff) between @Fi and @Ff )
and CAST( cont.FechaInicio as date)<=@Ff

group by rol_det.IdEmpresa,rol_det.IdEmpleado,ro_rol.IdNominaTipo,ro_rol.IdNominaTipoLiqui,ro_rol.IdPeriodo, emp.IdSucursal

----------------------------------------------------------------------------------------------------------------------------------------------
-------------calculando aporte patronal------------------------------------------------------------------------------------------------------<
----------------------------------------------------------------------------------------------------------------------------------------------
select @IdRubro_calculado= IdRubro_aporte_patronal from ro_rubros_calculados where IdEmpresa=@IdEmpresa-- obteniendo el idrubro desde parametros
insert into ro_rol_detalle_x_rubro_acumulado
(IdEmpresa,IdNominaTipo,IdNominaTipoLiqui,IdPeriodo,										IdEmpleado,			IdRubro,						Valor, Estado
)
select
@IdEmpresa		,@IdNomina,@IdNominaTipo,@IdPEriodo						,rol_det.IdEmpleado		,@IdRubro_calculado	,			round( sum(rol_det.Valor)*0.1215 ,2),'PEN'

FROM            dbo.ro_rol_detalle AS rol_det INNER JOIN
                         dbo.ro_rubro_tipo AS rub ON rol_det.IdEmpresa = rub.IdEmpresa AND rol_det.IdRubro = rub.IdRubro INNER JOIN
                         dbo.ro_empleado AS emp ON rol_det.IdEmpresa = emp.IdEmpresa AND rol_det.IdEmpleado = emp.IdEmpleado INNER JOIN
                         dbo.vwro_contrato_activo AS cont ON emp.IdEmpresa = cont.IdEmpresa AND emp.IdEmpleado = cont.IdEmpleado RIGHT OUTER JOIN
                         dbo.ro_rol ON rol_det.IdEmpresa = dbo.ro_rol.IdEmpresa AND rol_det.IdNominaTipo = dbo.ro_rol.IdNominaTipo AND rol_det.IdNominaTipoLiqui = dbo.ro_rol.IdNominaTipoLiqui AND 
                         rol_det.IdPeriodo = dbo.ro_rol.IdPeriodo LEFT OUTER JOIN
                         dbo.ro_empleado_x_ro_tipoNomina ON emp.IdEmpresa = dbo.ro_empleado_x_ro_tipoNomina.IdEmpresa AND emp.IdEmpleado = dbo.ro_empleado_x_ro_tipoNomina.IdEmpleado
						       
where rol_det.IdEmpresa=@IdEmpresa
and ro_rol.IdNominaTipo=@IdNomina
and ro_rol.IdNominaTipoLiqui=@IdNominaTipo
and ro_rol.IdPeriodo=@IdPEriodo
and rub.ru_tipo='I' 
and rub.rub_aplica_IESS=1
and ro_empleado_x_ro_tipoNomina.IdTipoNomina=1
and emp.IdEmpleado=@IdEmpleado
and cont.EstadoContrato <> 'ECT_LIQ'
and (emp.em_status<>'EST_LIQ' and isnull( emp.em_fechaSalida, @Ff) between @Fi and @Ff )
and CAST( cont.FechaInicio as date)<=@Ff
group by rol_det.IdEmpresa,rol_det.IdEmpleado,ro_rol.IdNominaTipo,ro_rol.IdNominaTipoLiqui,ro_rol.IdPeriodo, emp.IdSucursal














----------------------------------------------------------------------------------------------------------------------------------------------
-------------INSERTANDO PROVISIONES PARA CONTABILIZAR------------------------------------------------------------------------------------------------------<
----------------------------------------------------------------------------------------------------------------------------------------------
























----------------------------------------------------------------------------------------------------------------------------------------------
-------------calculando fondo de reserva----------------------------------------------------------------------------------------------------<
----------------------------------------------------------------------------------------------------------------------------------------------
select @IdRubro_calculado= IdRubro_prov_FR,@IdRubro_Provision=IdRubro_fondo_reserva,@IdRubro_horas_extras=IdRubro_horas_extras from ro_rubros_calculados where IdEmpresa=@IdEmpresa-- obteniendo el idrubro desde parametros
select @Orden=ru_orden_rol_general from ro_rubro_tipo where IdEmpresa=@IdEmpresa and IdRubro=@IdRubro_calculado
insert into ro_rol_detalle
(IdEmpresa	,IdNominaTipo,IdNominaTipoLiqui,IdPeriodo,						IdEmpleado,			IdRubro,			Orden,			Valor
,rub_visible_reporte,	Observacion)
select
@IdEmpresa,@IdNomina,@IdNominaTipo,@IdPEriodo					,rol_det.IdEmpleado		,@IdRubro_calculado	,ISNULL( @Orden,0)			, 
ISNULL( round( (sum(rol_det.Valor) /30) * dbo.calcular_dias_fondos_reserva(@Fi,@Ff,emp.em_fechaIngaRol, emp.em_status, ISNULL(EMP.em_fechaSalida,DATEADD(YEAR,50,GETDATE())), cont.FechaAcumulacion)*0.0833 ,2),0)

,0						,'Fondos de reserva'	
FROM            dbo.ro_rol_detalle AS rol_det INNER JOIN
                         dbo.ro_rubro_tipo AS rub ON rol_det.IdEmpresa = rub.IdEmpresa AND rol_det.IdRubro = rub.IdRubro INNER JOIN
                         dbo.ro_rol ON rol_det.IdEmpresa = dbo.ro_rol.IdEmpresa AND rol_det.IdNominaTipo = dbo.ro_rol.IdNominaTipo AND rol_det.IdNominaTipoLiqui = dbo.ro_rol.IdNominaTipoLiqui AND 
                         rol_det.IdPeriodo = dbo.ro_rol.IdPeriodo INNER JOIN
                         dbo.ro_empleado AS emp ON rol_det.IdEmpresa = emp.IdEmpresa AND rol_det.IdEmpleado = emp.IdEmpleado
						 
						 
						 left join
						 (
						 
select con.IdEmpresa,con.IdEmpleado, case when  sum(Dias) is null then dateadd(year,1,CON.FechaInicio) else DATEADD(DAY,(365 - case when isnull(sum(Dias),0) > 365 then isnull(sum(Dias),0) else isnull(sum(Dias),0) end), CON.FechaInicio ) end FechaAcumulacion
from vwro_contrato_activo as con left join (
SELECT IdEmpresa, IdEmpleado, DATEDIFF(DAY,FechaInicio,FechaFin)+1 Dias FROM vwro_contrato_activo C WHERE C.EstadoContrato = 'ECT_LIQ' ) a 
on con.IdEmpresa = a.IdEmpresa and con.IdEmpleado = a.IdEmpleado 
WHERE con.EstadoContrato<>'ECT_LIQ' --and con.IdEmpresa = 5 and con.IdEmpleado = 31
group by con.IdEmpresa,con.IdEmpleado, con.FechaInicio
)

as cont on emp.IdEmpresa = cont.IdEmpresa and emp.IdEmpleado = cont.IdEmpleado

where rol_det.IdEmpresa=@IdEmpresa
and ro_rol.IdNominaTipo=@IdNomina
and ro_rol.IdNominaTipoLiqui=@IdNominaTipo
and ro_rol.IdPeriodo=@IdPEriodo
and rub.ru_tipo='I' and rub.rub_aplica_IESS=1
and rol_det.IdRubro!=@IdRubro_horas_extras
AND CONT.FechaAcumulacion <= @FF
and emp.IdEmpleado=@IdEmpleado
and exists(select acum.IdEmpleado from ro_empleado_x_rubro_acumulado acum 
where acum.IdEmpresa= @IdEmpresa
and acum.IdEmpresa=emp.IdEmpresa
and acum.IdEmpleado=emp.IdEmpleado
and acum.IdRubro=@IdRubro_Provision)
and CAST( emp.em_fechaIngaRol as date)<=@Ff
group by rol_det.IdEmpresa,rol_det.IdEmpleado,ro_rol.IdNominaTipo,ro_rol.IdNominaTipoLiqui,ro_rol.IdPeriodo, emp.IdSucursal, emp.em_fechaIngaRol, emp.em_fechaSalida, emp.em_status,cont.FechaAcumulacion

----------------------------------------------------------------------------------------------------------------------------------------------
-------------calculando decimo tercer sueldo-------------------------------------------------------------------------------------------------<
----------------------------------------------------------------------------------------------------------------------------------------------
select @IdRubro_calculado= IdRubro_prov_DIII, @IdRubro_Provision=IdRubro_DIII from ro_rubros_calculados where IdEmpresa=@IdEmpresa-- obteniendo el idrubro desde parametros
select @Orden=ru_orden_rol_general from ro_rubro_tipo where IdEmpresa=@IdEmpresa and IdRubro=@IdRubro_calculado
insert into ro_rol_detalle
(IdEmpresa,	IdNominaTipo,IdNominaTipoLiqui,IdPeriodo,								IdEmpleado,			IdRubro,			Orden,			Valor
,rub_visible_reporte,	Observacion)
select
@IdEmpresa	,@IdNomina,@IdNominaTipo,@IdPEriodo									,rol_det.IdEmpleado		,@IdRubro_calculado	,ISNULL( @Orden,0)			, ROUND((sum(rol_det.Valor)/360)*30 ,2)
,0						,'Decimo tercer sueldo'	
FROM            dbo.ro_rol_detalle AS rol_det INNER JOIN
                         dbo.ro_rubro_tipo AS rub ON rol_det.IdEmpresa = rub.IdEmpresa AND rol_det.IdRubro = rub.IdRubro INNER JOIN
                         dbo.ro_rol ON rol_det.IdEmpresa = dbo.ro_rol.IdEmpresa AND rol_det.IdNominaTipo = dbo.ro_rol.IdNominaTipo AND rol_det.IdNominaTipoLiqui = dbo.ro_rol.IdNominaTipoLiqui AND 
                         rol_det.IdPeriodo = dbo.ro_rol.IdPeriodo INNER JOIN
                         dbo.ro_empleado AS emp ON rol_det.IdEmpresa = emp.IdEmpresa AND rol_det.IdEmpleado = emp.IdEmpleado INNER JOIN
                         dbo.vwro_contrato_activo AS cont ON emp.IdEmpresa = cont.IdEmpresa AND emp.IdEmpleado = cont.IdEmpleado where rol_det.IdEmpresa=@IdEmpresa
and ro_rol.IdNominaTipo=@IdNomina
and ro_rol.IdNominaTipoLiqui=@IdNominaTipo
and ro_rol.IdPeriodo=@IdPEriodo
and rub.ru_tipo='I' and rub.rub_aplica_IESS=1
and emp.IdEmpleado=@IdEmpleado
and rol_det.IdEmpleado  in(
select acum.IdEmpleado from ro_empleado_x_rubro_acumulado acum 
where acum.IdEmpresa= emp.IdEmpresa
and acum.IdEmpleado=emp.IdEmpleado
and acum.IdRubro=@IdRubro_Provision
and acum.IdEmpresa=@IdEmpresa
and emp.IdEmpresa=@IdEmpresa
)
and cont.EstadoContrato<>'ECT_LIQ'
and ISNULL( emp.em_fechaSalida, @Fi) between @Fi and @Ff

group by rol_det.IdEmpresa,rol_det.IdEmpleado,ro_rol.IdNominaTipo,ro_rol.IdNominaTipoLiqui,ro_rol.IdPeriodo, emp.IdSucursal,emp.em_fechaIngaRol, emp.em_status, emp.em_fechaSalida

----------------------------------------------------------------------------------------------------------------------------------------------
-------------calculando decimo cuarto sueldo-------------------------------------------------------------------------------------------------<
----------------------------------------------------------------------------------------------------------------------------------------------
select @IdRubro_calculado= IdRubro_prov_DIV, @IdRubro_Provision=IdRubro_DIV from ro_rubros_calculados where IdEmpresa=@IdEmpresa-- obteniendo el idrubro desde parametros
select @Orden=ru_orden_rol_general from ro_rubro_tipo where IdEmpresa=@IdEmpresa and IdRubro=@IdRubro_calculado
insert into ro_rol_detalle
(IdEmpresa,		IdNominaTipo,IdNominaTipoLiqui,IdPeriodo,								IdEmpleado,			IdRubro,			Orden,			Valor
,rub_visible_reporte,	Observacion)
select
@IdEmpresa	,@IdNomina,@IdNominaTipo,@IdPEriodo										,emp.IdEmpleado		,@IdRubro_calculado	,ISNULL( @Orden,0)			,ISNULL( ROUND((@SueldoBasico/360)* 
dbo.calcular_dias_trabajados(emp.IdEmpresa,emp.IdEmpleado,@Fi,@Ff,emp.em_fechaIngaRol, emp.em_status, emp.em_fechaSalida),2) ,0)
,0						,'Decimo cuarto sueldo'	
FROM            dbo.ro_empleado AS emp INNER JOIN
                         dbo.vwro_contrato_activo AS cont ON emp.IdEmpresa = cont.IdEmpresa AND emp.IdEmpleado = cont.IdEmpleado LEFT OUTER JOIN
                         dbo.ro_empleado_x_ro_tipoNomina ON emp.IdEmpresa = dbo.ro_empleado_x_ro_tipoNomina.IdEmpresa AND emp.IdEmpleado = dbo.ro_empleado_x_ro_tipoNomina.IdEmpleado

where 
 cont.EstadoContrato<>'ECT_LIQ'
and (emp.em_status<>'EST_LIQ')
and ro_empleado_x_ro_tipoNomina.IdTipoNomina=@IdNomina
and emp.IdEmpleado=@IdEmpleado
and emp.IdEmpleado  in(select acum.IdEmpleado from ro_empleado_x_rubro_acumulado acum 
where acum.IdEmpresa= emp.IdEmpresa
and acum.IdEmpresa=emp.IdEmpresa
and acum.IdEmpleado=emp.IdEmpleado
and acum.IdRubro=@IdRubro_Provision
and acum.IdEmpresa=@IdEmpresa
and emp.IdEmpresa=@IdEmpresa)
AND emp.IdEmpresa=@IdEmpresa

and CAST( emp.em_fechaIngaRol as date)<=@Ff
and ISNULL( emp.em_fechaSalida, @Fi) between @Fi and @Ff
group by emp.IdEmpresa,emp.IdEmpleado, emp.em_fechaSalida, cont.FechaInicio, cont.FechaFin, emp.em_status, emp.IdSucursal, emp.em_status, emp.em_fechaSalida, emp.em_fechaIngaRol



----------------------------------------------------------------------------------------------------------------------------------------------
-------------calculando provision de vacaciones----------------------------------------------------------------------------------------------<
----------------------------------------------------------------------------------------------------------------------------------------------
select @IdRubro_calculado= IdRubro_prov_vac from ro_rubros_calculados where IdEmpresa=@IdEmpresa-- obteniendo el idrubro desde parametros
insert into ro_rol_detalle
(IdEmpresa,		IdNominaTipo,IdNominaTipoLiqui,IdPeriodo,								IdEmpleado,			IdRubro,	Orden,					Valor						
,rub_visible_reporte, Observacion)
select
@IdEmpresa		,@IdNomina,@IdNominaTipo,@IdPEriodo						,rol_det.IdEmpleado		,@IdRubro_calculado	,	200		,CAST( sum(rol_det.Valor)/24 as numeric(10,2))
,0,'PROVICION VACACIONES'
FROM            dbo.ro_rol_detalle AS rol_det INNER JOIN
                         dbo.ro_rubro_tipo AS rub ON rol_det.IdEmpresa = rub.IdEmpresa AND rol_det.IdRubro = rub.IdRubro INNER JOIN
                         dbo.ro_empleado AS emp ON rol_det.IdEmpresa = emp.IdEmpresa AND rol_det.IdEmpleado = emp.IdEmpleado INNER JOIN
                         dbo.vwro_contrato_activo AS cont ON emp.IdEmpresa = cont.IdEmpresa AND emp.IdEmpleado = cont.IdEmpleado INNER JOIN
                         dbo.ro_empleado_x_ro_tipoNomina ON emp.IdEmpresa = dbo.ro_empleado_x_ro_tipoNomina.IdEmpresa AND emp.IdEmpleado = dbo.ro_empleado_x_ro_tipoNomina.IdEmpleado RIGHT OUTER JOIN
                         dbo.ro_rol ON rol_det.IdEmpresa = dbo.ro_rol.IdEmpresa AND rol_det.IdNominaTipo = dbo.ro_rol.IdNominaTipo AND rol_det.IdNominaTipoLiqui = dbo.ro_rol.IdNominaTipoLiqui AND rol_det.IdPeriodo = dbo.ro_rol.IdPeriodo


where rol_det.IdEmpresa=@IdEmpresa
and ro_rol.IdNominaTipo=@IdNomina
and ro_rol.IdNominaTipoLiqui=@IdNominaTipo
and ro_rol.IdPeriodo=@IdPEriodo
and rub.ru_tipo='I' and rub.rub_aplica_IESS=1
and emp.IdEmpleado=@IdEmpleado
and CAST( emp.em_fechaIngaRol as date)<=@Ff
and ro_empleado_x_ro_tipoNomina.IdTipoNomina=@IdNomina

and (emp.em_status<>'EST_LIQ' and isnull( emp.em_fechaSalida, @Ff) between @Fi and @Ff )
and CAST( cont.FechaInicio as date)<=@Ff

group by rol_det.IdEmpresa,rol_det.IdEmpleado,ro_rol.IdNominaTipo,ro_rol.IdNominaTipoLiqui,ro_rol.IdPeriodo, emp.IdSucursal
















----------------------------------------------------------------------------------------------------------------------------------------------
-------------INSERTANDO CUOTAS DE PRESTAMO CONSIDERADAS EN ESTE ROL---------------------------------------------------------------------------<
------------------------------------------------------------------------------------------------------------------------------------------------
insert into ro_rol_x_prestamo_detalle
(
IdEmpresa,
IdPrestamo,
NumCuota,
IdEmpleado,
IdNominaTipo,
IdNominaTipoLiqui,
IdPeriodo,
Observacion
)

select
pre.IdEmpresa,pre.IdPrestamo,pred.NumCuota,pre.IdEmpleado,@IdNomina,@IdNominaTipo,@IdPEriodo,pred.Observacion_det
FROM            dbo.ro_prestamo AS pre INNER JOIN
                         dbo.ro_prestamo_detalle AS pred ON pre.IdEmpresa = pred.IdEmpresa AND pre.IdPrestamo = pred.IdPrestamo INNER JOIN
                         dbo.ro_rubro_tipo AS rub ON pre.IdEmpresa = rub.IdEmpresa AND pre.IdRubro = rub.IdRubro INNER JOIN
                         dbo.ro_empleado AS emp ON pre.IdEmpresa = emp.IdEmpresa AND pre.IdEmpleado = emp.IdEmpleado INNER JOIN
                         dbo.vwro_contrato_activo AS cont ON emp.IdEmpresa = cont.IdEmpresa AND emp.IdEmpleado = cont.IdEmpleado
where pre.IdEmpresa=@IdEmpresa
and emp.IdEmpresa=@IdEmpresa
and pred.IdNominaTipoLiqui=@IdNominaTipo
and CAST(pred.FechaPago AS DATE) between @Fi and @Ff
and pred.Estado='A'
and pred.EstadoPago='PEN'
and (emp.em_status <>'EST_LIQ' and isnull( emp.em_fechaSalida, @Ff) between @Fi and @Ff )
and CAST( emp.em_fechaIngaRol as date)<=@Ff
and pred.FechaPago between  @Fi and @Ff 
and pred.IdNominaTipoLiqui=@IdNominaTipo
and emp.IdEmpleado=@IdEmpleado

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



END
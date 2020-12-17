

CREATE view [dbo].[vwro_rol_detalle_calculo_vacaciones] as
select a.idempresa,a.idempleado,a.pe_anio,a.pe_mes, SUM(Remuneracion)Remuneracion,sum( a.Vacacion)Vacacion from (
SELECT        dbo.ro_rol_detalle.IdEmpresa, dbo.ro_rol_detalle.IdEmpleado, dbo.ro_periodo.pe_anio, dbo.ro_periodo.pe_mes,
ROUND( sum( dbo.ro_rol_detalle.Valor),2)Remuneracion,
ROUND( sum( dbo.ro_rol_detalle.Valor)/24,2) Vacacion

FROM            dbo.ro_rol_detalle INNER JOIN
                         dbo.ro_rol ON dbo.ro_rol_detalle.IdEmpresa = dbo.ro_rol.IdEmpresa AND dbo.ro_rol_detalle.IdNominaTipo = dbo.ro_rol.IdNominaTipo AND dbo.ro_rol_detalle.IdNominaTipoLiqui = dbo.ro_rol.IdNominaTipoLiqui AND 
                         dbo.ro_rol_detalle.IdPeriodo = dbo.ro_rol.IdPeriodo INNER JOIN
                         dbo.ro_periodo_x_ro_Nomina_TipoLiqui ON dbo.ro_rol.IdEmpresa = dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdEmpresa AND dbo.ro_rol.IdNominaTipo = dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdNomina_Tipo AND 
                         dbo.ro_rol.IdNominaTipoLiqui = dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdNomina_TipoLiqui AND dbo.ro_rol.IdPeriodo = dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdPeriodo INNER JOIN
                         dbo.ro_periodo ON dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdEmpresa = dbo.ro_periodo.IdEmpresa AND dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdPeriodo = dbo.ro_periodo.IdPeriodo INNER JOIN
                         dbo.ro_rubro_tipo ON dbo.ro_rol_detalle.IdEmpresa = dbo.ro_rubro_tipo.IdEmpresa AND dbo.ro_rol_detalle.IdRubro = dbo.ro_rubro_tipo.IdRubro
where 
 ro_rol_detalle.IdNominaTipoLiqui=2
and ro_rubro_tipo.ru_tipo='I' and ro_rubro_tipo.rub_aplica_IESS=1
--idempleado=371 and ro_rol_detalle.IdEmpresa=2
GROUP BY dbo.ro_rol_detalle.IdEmpresa, dbo.ro_rol_detalle.IdEmpleado,  dbo.ro_periodo.pe_anio, dbo.ro_periodo.pe_mes

union all

SELECT        dbo.ro_rol_detalle.IdEmpresa, dbo.ro_rol_detalle.IdEmpleado, dbo.ro_periodo.pe_anio, dbo.ro_periodo.pe_mes,
ROUND( sum( dbo.ro_rol_detalle.Valor),2)Remuneracion,
ROUND( sum( dbo.ro_rol_detalle.Valor)/24,2) Vacacion

FROM            dbo.ro_rol_detalle INNER JOIN
                         dbo.ro_rol ON dbo.ro_rol_detalle.IdEmpresa = dbo.ro_rol.IdEmpresa AND dbo.ro_rol_detalle.IdNominaTipo = dbo.ro_rol.IdNominaTipo AND dbo.ro_rol_detalle.IdNominaTipoLiqui = dbo.ro_rol.IdNominaTipoLiqui AND 
                         dbo.ro_rol_detalle.IdPeriodo = dbo.ro_rol.IdPeriodo INNER JOIN
                         dbo.ro_periodo_x_ro_Nomina_TipoLiqui ON dbo.ro_rol.IdEmpresa = dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdEmpresa AND dbo.ro_rol.IdNominaTipo = dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdNomina_Tipo AND 
                         dbo.ro_rol.IdNominaTipoLiqui = dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdNomina_TipoLiqui AND dbo.ro_rol.IdPeriodo = dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdPeriodo INNER JOIN
                         dbo.ro_periodo ON dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdEmpresa = dbo.ro_periodo.IdEmpresa AND dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdPeriodo = dbo.ro_periodo.IdPeriodo INNER JOIN
                         dbo.ro_rubro_tipo ON dbo.ro_rol_detalle.IdEmpresa = dbo.ro_rubro_tipo.IdEmpresa AND dbo.ro_rol_detalle.IdRubro = dbo.ro_rubro_tipo.IdRubro
where 
 ro_rol_detalle.IdNominaTipoLiqui=3
and ro_rubro_tipo.IdRubro=500
and ro_rol_detalle.IdEmpresa=2
--idempleado=371 and ro_rol_detalle.IdEmpresa=2
GROUP BY dbo.ro_rol_detalle.IdEmpresa, dbo.ro_rol_detalle.IdEmpleado,  dbo.ro_periodo.pe_anio, dbo.ro_periodo.pe_mes


)a 

group by a.idempresa,a.idempleado,a.pe_anio,a.pe_mes
--order by a.pe_anio
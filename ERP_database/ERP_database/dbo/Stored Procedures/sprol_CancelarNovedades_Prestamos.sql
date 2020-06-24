

CREATE procedure [dbo].[sprol_CancelarNovedades_Prestamos] 
@IdEmpresa int,
@IdNomina int,
@IdNominaTipo int,
@FechaInicio date,
@fechaFin date
as
begin
update ro_empleado_novedad_det set EstadoCobro='CAN'
FROM            dbo.ro_rol_detalle AS rol INNER JOIN
                         dbo.ro_empleado_novedad_det AS novedad ON rol.IdEmpresa = novedad.IdEmpresa AND rol.IdNominaTipo = novedad.IdNomina_tipo AND rol.IdNominaTipoLiqui = novedad.IdNomina_Tipo_Liq AND 
                         rol.IdEmpleado = novedad.IdEmpleado AND rol.IdRubro = novedad.IdRubro
						 WHERE FechaPago between @FechaInicio and @fechaFin
						 and IdNomina_tipo=@IdNomina
						 and IdNomina_Tipo_Liq=@IdNominaTipo
						 and novedad.IdEmpresa=@IdEmpresa

						 and novedad.IdRubro in (select d.IdRubro from vwRo_Rol_Detalle D where D.FechaIni between @FechaInicio and @fechaFin
						 and d.IdEmpresa=novedad.IdEmpresa
						 and d.IdEmpleado=novedad.IdEmpleado
						 and d.IdNominaTipoLiqui=@IdNominaTipo
						 and D.IdNominaTipo=@IdNomina
						 and D.Valor>0)

						 update ro_prestamo_detalle set EstadoPago='CAN'

						 FROM            dbo.ro_prestamo_detalle INNER JOIN
                         dbo.ro_prestamo ON dbo.ro_prestamo_detalle.IdEmpresa = dbo.ro_prestamo.IdEmpresa AND dbo.ro_prestamo_detalle.IdPrestamo = dbo.ro_prestamo.IdPrestamo
						  WHERE FechaPago between @FechaInicio and @fechaFin
						 and ro_prestamo.IdNomina_Tipo=@IdNomina
						 and ro_prestamo_detalle.IdNominaTipoLiqui=@IdNominaTipo
						 and ro_prestamo_detalle.IdEmpresa=@IdEmpresa

						 and IdRubro in (select d.IdRubro from vwRo_Rol_Detalle D where D.FechaIni between @FechaInicio and @fechaFin
						 and d.IdEmpresa=ro_prestamo.IdEmpresa
						 and d.IdEmpleado=ro_prestamo.IdEmpleado
						 and d.IdNominaTipoLiqui=@IdNominaTipo
						 and d.IdNominaTipo=@IdNomina
						 and D.Valor>0)
end



CREATE procedure [dbo].[sprol_CancelarNovedades_Prestamos] 
@IdEmpresa int,
@IdNomina int,
@IdNominaTipo int,
@FechaInicio date,
@fechaFin date
as
begin
update ro_empleado_novedad_det set EstadoCobro='CAN'
FROM            dbo.ro_empleado_Novedad INNER JOIN
                         dbo.ro_empleado_novedad_det ON dbo.ro_empleado_Novedad.IdEmpresa = dbo.ro_empleado_novedad_det.IdEmpresa AND 
                         dbo.ro_empleado_Novedad.IdNovedad = dbo.ro_empleado_novedad_det.IdNovedad AND dbo.ro_empleado_Novedad.IdEmpleado = dbo.ro_empleado_novedad_det.IdEmpleado INNER JOIN
                         dbo.ro_rol_x_empleado_novedades ON dbo.ro_empleado_novedad_det.IdEmpresa = dbo.ro_rol_x_empleado_novedades.IdEmpresa_nov AND 
                         dbo.ro_empleado_novedad_det.IdEmpleado = dbo.ro_rol_x_empleado_novedades.IdEmpleado AND dbo.ro_empleado_novedad_det.IdNovedad = dbo.ro_rol_x_empleado_novedades.IdNovedad AND 
                         dbo.ro_empleado_novedad_det.Secuencia = dbo.ro_rol_x_empleado_novedades.Secuencia_nov
						
						
						
						
						 WHERE 
						  ro_empleado_Novedad.IdNomina_Tipo=@IdNomina
						 and ro_empleado_Novedad.IdNomina_TipoLiqui=@IdNominaTipo
						 and ro_empleado_Novedad.IdEmpresa=@IdEmpresa
						 and CAST( ro_empleado_novedad_det.FechaPago as date)between @FechaInicio and @fechaFin
						

						 update ro_prestamo_detalle set EstadoPago='CAN'
FROM            dbo.ro_prestamo INNER JOIN
                         dbo.ro_prestamo_detalle ON dbo.ro_prestamo.IdEmpresa = dbo.ro_prestamo_detalle.IdEmpresa AND dbo.ro_prestamo.IdPrestamo = dbo.ro_prestamo_detalle.IdPrestamo INNER JOIN
                         dbo.ro_rol_x_prestamo_detalle ON dbo.ro_prestamo_detalle.IdEmpresa = dbo.ro_rol_x_prestamo_detalle.IdEmpresa AND dbo.ro_prestamo_detalle.IdPrestamo = dbo.ro_rol_x_prestamo_detalle.IdPrestamo AND 
                         dbo.ro_prestamo_detalle.NumCuota = dbo.ro_rol_x_prestamo_detalle.NumCuota AND dbo.ro_prestamo.IdEmpleado = dbo.ro_rol_x_prestamo_detalle.IdEmpleado AND 
                         dbo.ro_prestamo.IdPrestamo = dbo.ro_rol_x_prestamo_detalle.IdPrestamo AND dbo.ro_prestamo.IdEmpresa = dbo.ro_rol_x_prestamo_detalle.IdEmpresa
						 						  
						  WHERE CAST( FechaPago as date) between @FechaInicio and @fechaFin
						 and ro_prestamo.IdNomina_Tipo=@IdNomina
						 and ro_prestamo_detalle.IdNominaTipoLiqui=@IdNominaTipo
						 and ro_prestamo_detalle.IdEmpresa=@IdEmpresa

						
end
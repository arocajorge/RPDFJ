
--  exec [Fj_servindustrias].[spro_empleados_sin_registro_asistencia] 2,'07/06/2020',1,202006

CREATE PROCEDURE [Fj_servindustrias].[spro_empleados_sin_registro_asistencia]
	@Idempres int,
	@Fecha date,
	@IdNomina_Tipo int,
	@IdPeriodo int
AS

BEGIN
	/*
	declare 
	@Idempres int,
	@Fecha datetime,
    @IdNomina_Tipo int,
	@IdPeriodo int
	set @Idempres=2
	set @Fecha='23/06/2017'
	set @IdNomina_Tipo=1
	set @IdPeriodo=201706
	--set @Estado_em=''
	*/
	declare 
	@vacaciones int,
	@permiso int,
	@Fecha_inicio date,
	@Fecha_fin date

	select @Fecha_inicio=pe_FechaIni, @Fecha_fin=pe_FechaFin from ro_periodo where IdEmpresa=@Idempres and IdPeriodo=@IdPeriodo
	
	
	-- traet todos los empleados que no tienen marcaciones en ese dia
SELECT                  dbo.ro_empleado.IdEmpresa,
                        dbo.ro_empleado.IdEmpleado,
					    dbo.ro_Departamento.IdDepartamento, 
						dbo.ro_cargo.IdCargo, 
						dbo.tb_persona.pe_apellido, 
                        dbo.tb_persona.pe_nombre, 
						dbo.tb_persona.pe_cedulaRuc, 
						dbo.ro_Departamento.de_descripcion,
					    dbo.ro_cargo.ca_descripcion,
					    dbo.ro_empleado.em_status, 
						dbo.ro_empleado.em_estado,
						

						  
                       case when  (select  COUNT( Fecha) 
						  from ro_Solicitud_Vacaciones_x_empleado 
						  where ro_Solicitud_Vacaciones_x_empleado.IdEmpresa=@Idempres
						  and dbo.ro_empleado.IdEmpresa=@Idempres
						  and  dbo.ro_empleado.IdEmpleado=ro_Solicitud_Vacaciones_x_empleado.IdEmpleado
						  and  dbo.ro_empleado.IdEmpresa=ro_Solicitud_Vacaciones_x_empleado.IdEmpresa
						  and @Fecha between ro_Solicitud_Vacaciones_x_empleado.Fecha_Desde and ro_Solicitud_Vacaciones_x_empleado.Fecha_Hasta)
						 >0 then 'VACA'



					     WHEN  (select COUNT( ro_permiso_x_empleado.IdEmpleado)
						  from ro_permiso_x_empleado 
						  where dbo.ro_permiso_x_empleado.IdEmpresa=@Idempres
						  and  dbo.ro_empleado.IdEmpresa=@Idempres
						  and  dbo.ro_empleado.IdEmpleado=ro_permiso_x_empleado.IdEmpleado
						  and  dbo.ro_empleado.IdEmpresa=ro_permiso_x_empleado.IdEmpresa
						   and ro_permiso_x_empleado.Estado='A'
						  and  @Fecha between CAST( ro_permiso_x_empleado.FechaSalida AS DATE) and CAST( ro_permiso_x_empleado.FechaEntrada AS DATE))>0
						  THEN 'PER'
						  WHEN  (select COUNT( Fj_servindustrias.ro_marcaciones_no_aplica_sobretiempo.IdEmpleado)
						  from Fj_servindustrias.ro_marcaciones_no_aplica_sobretiempo 
						  where Fj_servindustrias.ro_marcaciones_no_aplica_sobretiempo.IdEmpresa=ro_empleado.IdEmpresa
						  and Fj_servindustrias.ro_marcaciones_no_aplica_sobretiempo.idempleado=ro_empleado.IdEmpleado
						  and Fj_servindustrias.ro_marcaciones_no_aplica_sobretiempo.es_fecha_registro=@Fecha
						  and Fj_servindustrias.ro_marcaciones_no_aplica_sobretiempo.IdEmpresa=@Idempres)>0 then
			     		   'S/S'

						 else 'ASIST' end Tipo_asistencia_Cat,




						 '' tu_descripcion, 
						CAST ( 0 as bit)es_jornada_desfasada,
						 1 IdTurno,
						 ro_empleado.em_fechaSalida,
						 dbo.ro_empleado.IdDivision



FROM            dbo.ro_empleado INNER JOIN
                         dbo.tb_persona ON dbo.ro_empleado.IdPersona = dbo.tb_persona.IdPersona INNER JOIN
                         dbo.ro_Departamento ON dbo.ro_empleado.IdEmpresa = dbo.ro_Departamento.IdEmpresa AND dbo.ro_empleado.IdDepartamento = dbo.ro_Departamento.IdDepartamento INNER JOIN
                         dbo.ro_cargo ON dbo.ro_empleado.IdEmpresa = dbo.ro_cargo.IdEmpresa AND dbo.ro_empleado.IdCargo = dbo.ro_cargo.IdCargo INNER JOIN
                         dbo.ro_empleado_x_ro_tipoNomina ON dbo.ro_empleado.IdEmpresa = dbo.ro_empleado_x_ro_tipoNomina.IdEmpresa AND dbo.ro_empleado.IdEmpleado = dbo.ro_empleado_x_ro_tipoNomina.IdEmpleado AND 
                         dbo.ro_empleado.IdEmpresa = dbo.ro_empleado_x_ro_tipoNomina.IdEmpresa AND dbo.ro_empleado.IdEmpleado = dbo.ro_empleado_x_ro_tipoNomina.IdEmpleado
						 and dbo.ro_empleado_x_ro_tipoNomina.IdTipoNomina=@IdNomina_Tipo
						 and dbo.ro_empleado_x_ro_tipoNomina.IdEmpresa=@Idempres
						 and cast( dbo.ro_empleado.em_fechaIngaRol as date)<=@Fecha
WHERE                    
                        dbo.ro_empleado.em_status not in('EST_LIQ')
						and dbo.ro_empleado.em_estado='A'              
						and ro_empleado.em_status<>'ECT_LIQ'
						and (ro_empleado.em_status<>'EST_LIQ' 
						--and isnull( ro_empleado.em_fechaSalida, @Fecha_inicio) between @Fecha_inicio and @Fecha_fin
						and isnull( ro_empleado.em_fechaSalida, @Fecha) >=@Fecha
						)
						and dbo.ro_empleado_x_ro_tipoNomina.IdTipoNomina=@IdNomina_Tipo
						and dbo.ro_empleado_x_ro_tipoNomina.IdEmpresa=@Idempres
						and dbo.ro_empleado.IdEmpresa=@Idempres

                        and (NOT EXISTS
                         (SELECT       M.IdEmpleado
                               FROM            ro_marcaciones_x_empleado AS M
                               WHERE 
							   M.IdEmpleado =  dbo.ro_empleado.IdEmpleado 
							   and M.IdEmpresa=dbo.ro_empleado.IdEmpresa
							   and M.IdEmpresa=@Idempres
							   and dbo.ro_empleado.IdEmpresa=@Idempres
							   AND CAST( es_fechaRegistro as date) = @Fecha))
					   
										
						
END
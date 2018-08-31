
CREATE PROCEDURE [Fj_servindustrias].[spROLES_Rpt009]  
	@IdEmpresa int,
	@IdNomina_tipo int,
	@Anio int,
	@Mes int
	
	
AS
/*

declare
    @IdEmpresa int,
	@IdNomina_tipo int,
	@Anio int,
	@Mes int

	set @IdEmpresa=1
	set @IdNomina_tipo=1
	set @Anio ='2017'
	set @Mes ='06'
	
	*/
	SELECT        dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdPeriodo, person.pe_cedulaRuc, person.pe_apellido + ' ' + person.pe_nombre AS Nombres, cargo.ca_descripcion, dbo.ct_centro_costo_sub_centro_costo.Centro_costo, 
                         perio.pe_FechaIni, dbo.Af_Activo_fijo.Af_DescripcionCorta,
						 ISNULL
                             ((SELECT        Valor
                                 FROM            dbo.vwRo_Rol_Detalle AS R_det
                                 WHERE        
								     (R_det.IdEmpresa = param_repo.IdEmpresa) 
								 AND (R_det.IdNominaTipo = param_repo.IdNomina_Tipo) 
								 AND (R_det.IdNominaTipoLiqui = param_repo.IdNomina_tipo_Liq)
								  AND (R_det.IdRubro = param_repo.IdRubro) 
								  AND (R_det.IdEmpleado = ro_rol_detalle.IdEmpleado) 
								  AND (R_det.pe_anio = perio.pe_anio) 
								  AND (R_det.pe_mes = perio.pe_mes)), 0) AS Valor, emp.em_fechaIngaRol, perio.pe_anio, 
                         perio.pe_mes, person.pe_apellido, person.pe_nombre, ro_catalogo_1.ca_descripcion AS CatalogoGrupo, emp.em_fechaSalida, param_repo.Orden, param_repo.Descripcion, 
                         dbo.ro_catalogo.ca_descripcion AS EstadoEmpleado, param_repo.IdEmpresa, param_repo.IdNomina_Tipo, param_repo.IdNomina_tipo_Liq
FROM            dbo.Af_Activo_fijo INNER JOIN
                         dbo.ct_centro_costo_sub_centro_costo ON dbo.Af_Activo_fijo.IdCentroCosto_sub_centro_costo = dbo.ct_centro_costo_sub_centro_costo.IdCentroCosto_sub_centro_costo AND 
                         dbo.Af_Activo_fijo.IdCentroCosto = dbo.ct_centro_costo_sub_centro_costo.IdCentroCosto AND dbo.Af_Activo_fijo.IdEmpresa = dbo.ct_centro_costo_sub_centro_costo.IdEmpresa LEFT OUTER JOIN
                         Fj_servindustrias.ro_empleado_x_Activo_Fijo ON dbo.Af_Activo_fijo.IdEmpresa = Fj_servindustrias.ro_empleado_x_Activo_Fijo.IdEmpresa AND 
                         dbo.Af_Activo_fijo.IdActivoFijo = Fj_servindustrias.ro_empleado_x_Activo_Fijo.IdActivo_fijo RIGHT OUTER JOIN
                         dbo.ro_periodo_x_ro_Nomina_TipoLiqui INNER JOIN
                         dbo.ro_periodo AS perio ON dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdEmpresa = perio.IdEmpresa AND dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdPeriodo = perio.IdPeriodo AND 
                         dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdEmpresa = perio.IdEmpresa AND dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdPeriodo = perio.IdPeriodo AND 
                         dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdEmpresa = perio.IdEmpresa AND dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdPeriodo = perio.IdPeriodo INNER JOIN
                         dbo.ro_rol_detalle INNER JOIN
                         dbo.ro_catalogo INNER JOIN
                         dbo.tb_persona AS person INNER JOIN
                         dbo.ro_empleado AS emp INNER JOIN
                         dbo.ro_cargo AS cargo ON emp.IdEmpresa = cargo.IdEmpresa AND emp.IdCargo = cargo.IdCargo AND emp.IdEmpresa = cargo.IdEmpresa AND emp.IdCargo = cargo.IdCargo AND 
                         emp.IdEmpresa = cargo.IdEmpresa AND emp.IdCargo = cargo.IdCargo AND emp.IdEmpresa = cargo.IdEmpresa AND emp.IdCargo = cargo.IdCargo AND emp.IdEmpresa = cargo.IdEmpresa AND 
                         emp.IdCargo = cargo.IdCargo AND emp.IdEmpresa = cargo.IdEmpresa AND emp.IdCargo = cargo.IdCargo AND emp.IdEmpresa = cargo.IdEmpresa AND emp.IdCargo = cargo.IdCargo AND 
                         emp.IdEmpresa = cargo.IdEmpresa AND emp.IdCargo = cargo.IdCargo ON person.IdPersona = emp.IdPersona ON dbo.ro_catalogo.CodCatalogo = emp.em_status ON 
                         dbo.ro_rol_detalle.IdEmpresa = emp.IdEmpresa AND dbo.ro_rol_detalle.IdEmpleado = emp.IdEmpleado AND dbo.ro_rol_detalle.IdEmpresa = emp.IdEmpresa AND 
                         dbo.ro_rol_detalle.IdEmpleado = emp.IdEmpleado INNER JOIN
                         dbo.ro_catalogo AS ro_catalogo_1 INNER JOIN
                         dbo.ro_rubro_tipo INNER JOIN
                         Fj_servindustrias.ro_parametros_reporte AS param_repo ON dbo.ro_rubro_tipo.IdRubro = param_repo.IdRubro AND dbo.ro_rubro_tipo.IdEmpresa = param_repo.IdEmpresa ON 
                         ro_catalogo_1.CodCatalogo = param_repo.Id_Catalogo ON dbo.ro_rol_detalle.IdEmpresa = dbo.ro_rubro_tipo.IdEmpresa AND dbo.ro_rol_detalle.IdRubro = dbo.ro_rubro_tipo.IdRubro AND 
                         dbo.ro_rol_detalle.IdEmpresa = dbo.ro_rubro_tipo.IdEmpresa AND dbo.ro_rol_detalle.IdRubro = dbo.ro_rubro_tipo.IdRubro AND dbo.ro_rol_detalle.IdEmpresa = param_repo.IdEmpresa AND 
                         dbo.ro_rol_detalle.IdNominaTipo = param_repo.IdNomina_Tipo AND dbo.ro_rol_detalle.IdNominaTipoLiqui = param_repo.IdNomina_tipo_Liq ON 
                         dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdEmpresa = dbo.ro_rol_detalle.IdEmpresa AND dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdNomina_Tipo = dbo.ro_rol_detalle.IdNominaTipo AND 
                         dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdNomina_TipoLiqui = dbo.ro_rol_detalle.IdNominaTipoLiqui ON Fj_servindustrias.ro_empleado_x_Activo_Fijo.IdEmpresa = emp.IdEmpresa AND 
                         Fj_servindustrias.ro_empleado_x_Activo_Fijo.IdEmpleado = emp.IdEmpleado
WHERE          param_repo.IdEmpresa=@IdEmpresa
and  perio.pe_anio=@Anio
and perio.pe_mes=@Mes
and perio.IdPeriodo=ro_rol_detalle.IdPeriodo
and  dbo.ro_periodo_x_ro_Nomina_TipoLiqui.IdNomina_Tipo=@IdNomina_tipo
and emp.idempresa=@IdEmpresa
and dbo.ro_rol_detalle.IdEmpresa=@IdEmpresa 
and dbo.ro_periodo_x_ro_Nomina_TipoLiqui.idempresa=@IdEmpresa
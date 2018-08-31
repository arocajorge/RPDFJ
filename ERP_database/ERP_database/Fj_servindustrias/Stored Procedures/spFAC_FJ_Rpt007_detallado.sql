

CREATE procedure [Fj_servindustrias].[spFAC_FJ_Rpt007_detallado] 
@IdEmpresa int,
@IdPeriodo int
as
SELECT        queryUnidad_maxima.IdEmpresa, queryUnidad_maxima.IdPeriodo, queryUnidad_maxima.IdActivoFijo, queryUnidad_maxima.Valor_Maximo_x_periodo, Query_unidad_inicial_x_periodo.Af_ValorUnidad_Actu, 
                         Query_empleado_af_x_periodo.Af_DescripcionCorta, Query_empleado_af_x_periodo.Centro_costo, Query_empleado_af_x_periodo.SucentroCosto, Query_empleado_af_x_periodo.Total_horas_operadores, 
                         queryUnidad_maxima.Valor_Maximo_x_periodo - Query_unidad_inicial_x_periodo.Af_ValorUnidad_Actu AS Total_Horas_maquina, 
                         Query_empleado_af_x_periodo.Total_horas_operadores - (queryUnidad_maxima.Valor_Maximo_x_periodo - Query_unidad_inicial_x_periodo.Af_ValorUnidad_Actu) AS diferencia, 
                         (queryUnidad_maxima.Valor_Maximo_x_periodo - Query_unidad_inicial_x_periodo.Af_ValorUnidad_Actu) / Query_empleado_af_x_periodo.Total_horas_operadores AS por_horas_ocupada_la_maquina_vx_ho, 
                         Query_empleado_af_x_periodo.pe_nombreCompleto, Query_empleado_af_x_periodo.DiasEfectivos, Query_empleado_af_x_periodo.IdCentroCosto, Query_empleado_af_x_periodo.IdCentroCosto_sub_centro_costo, 
                         Fj_servindustrias.fa_cliente_x_ct_centro_costo.IdCliente_cli
FROM            (SELECT        IdEmpresa, IdActivoFijo, IdPeriodo, MAX(ISNULL(Valor, 0)) AS Valor_Maximo_x_periodo
                          FROM            Fj_servindustrias.fa_registro_unidades_x_equipo_det
                          GROUP BY IdEmpresa, IdActivoFijo, IdPeriodo) AS queryUnidad_maxima INNER JOIN
                             (SELECT        cab.IdEmpresa, det.IdActivoFijo, cab.IdPeriodo, det.Af_ValorUnidad_Actu
                               FROM            Fj_servindustrias.fa_registro_unidades_x_equipo_det_ini_x_Af AS det INNER JOIN
                                                         Fj_servindustrias.fa_registro_unidades_x_equipo AS cab ON det.IdEmpresa = cab.IdEmpresa AND det.IdRegistro = cab.IdRegistro) AS Query_unidad_inicial_x_periodo ON 
                         queryUnidad_maxima.IdEmpresa = Query_unidad_inicial_x_periodo.IdEmpresa AND queryUnidad_maxima.IdPeriodo = Query_unidad_inicial_x_periodo.IdPeriodo AND 
                         queryUnidad_maxima.IdActivoFijo = Query_unidad_inicial_x_periodo.IdActivoFijo AND queryUnidad_maxima.IdActivoFijo = Query_unidad_inicial_x_periodo.IdActivoFijo INNER JOIN
                             (SELECT  nomina_x_he.IdEmpresa, nomina_x_he.IdEmpleado, nomina_x_he.IdNominaTipo, nomina_x_he.IdNominaTipoLiqui, nomina_x_he.IdPeriodo, pre_fact_mo.IdActivoFijo, cc.Centro_costo, 
                            sub.Centro_costo AS SucentroCosto, af.Af_DescripcionCorta, SUM(CAST(nomina_x_he.hora_trabajada AS numeric(8, 2))) AS Total_horas_operadores, persona.pe_nombreCompleto,
                            (SELECT  Valor
                            FROM    dbo.ro_rol_detalle AS R
                            WHERE   (IdEmpresa = nomina_x_he.IdEmpresa) AND (IdEmpleado = nomina_x_he.IdEmpleado) AND (IdNominaTipo = 1) AND (IdNominaTipoLiqui = 2) AND (IdPeriodo = @IdPeriodo) AND (IdRubro = 976)) 
                            AS DiasEfectivos, cc.IdCentroCosto, sub.IdCentroCosto_sub_centro_costo
                            FROM            dbo.ro_nomina_x_horas_extras AS nomina_x_he INNER JOIN
                            Fj_servindustrias.fa_pre_facturacion_mano_obra_servindustria AS pre_fact_mo ON nomina_x_he.IdEmpresa = pre_fact_mo.IdEmpresa AND nomina_x_he.IdEmpleado = pre_fact_mo.IdEmpleado AND 
                            nomina_x_he.IdPeriodo = pre_fact_mo.IdPeriodo INNER JOIN
                            dbo.ct_centro_costo AS cc ON pre_fact_mo.IdEmpresa = cc.IdEmpresa AND pre_fact_mo.IdCentroCosto = cc.IdCentroCosto INNER JOIN
                            dbo.ct_centro_costo_sub_centro_costo AS sub ON pre_fact_mo.IdEmpresa = sub.IdEmpresa AND pre_fact_mo.IdCentroCosto = sub.IdCentroCosto AND 
                            pre_fact_mo.IdCentroCosto_sub_centro_costo = sub.IdCentroCosto_sub_centro_costo INNER JOIN
                            dbo.ro_empleado AS emplea ON nomina_x_he.IdEmpresa = emplea.IdEmpresa AND nomina_x_he.IdEmpleado = emplea.IdEmpleado AND nomina_x_he.IdEmpresa = emplea.IdEmpresa AND 
                            nomina_x_he.IdEmpleado = emplea.IdEmpleado AND nomina_x_he.IdEmpresa = emplea.IdEmpresa AND nomina_x_he.IdEmpleado = emplea.IdEmpleado AND nomina_x_he.IdEmpresa = emplea.IdEmpresa AND 
                            nomina_x_he.IdEmpleado = emplea.IdEmpleado AND nomina_x_he.IdEmpresa = emplea.IdEmpresa AND nomina_x_he.IdEmpleado = emplea.IdEmpleado AND nomina_x_he.IdEmpresa = emplea.IdEmpresa AND 
                            nomina_x_he.IdEmpleado = emplea.IdEmpleado AND nomina_x_he.IdEmpresa = emplea.IdEmpresa AND nomina_x_he.IdEmpleado = emplea.IdEmpleado INNER JOIN
                            dbo.tb_persona AS persona ON emplea.IdPersona = persona.IdPersona AND emplea.IdPersona = persona.IdPersona INNER JOIN
                            dbo.Af_Activo_fijo AS af ON pre_fact_mo.IdEmpresa = af.IdEmpresa AND pre_fact_mo.IdActivoFijo = af.IdActivoFijo AND pre_fact_mo.IdEmpresa = af.IdEmpresa AND pre_fact_mo.IdActivoFijo = af.IdActivoFijo AND 
                            pre_fact_mo.IdEmpresa = af.IdEmpresa AND pre_fact_mo.IdActivoFijo = af.IdActivoFijo AND pre_fact_mo.IdEmpresa = af.IdEmpresa AND pre_fact_mo.IdActivoFijo = af.IdActivoFijo AND 
                            pre_fact_mo.IdEmpresa = af.IdEmpresa AND pre_fact_mo.IdActivoFijo = af.IdActivoFijo
                            GROUP BY nomina_x_he.IdEmpresa, nomina_x_he.IdEmpleado, nomina_x_he.IdNominaTipo, nomina_x_he.IdNominaTipoLiqui, nomina_x_he.IdPeriodo, af.Af_DescripcionCorta, pre_fact_mo.IdActivoFijo, cc.Centro_costo, 
                                                         sub.Centro_costo, persona.pe_nombreCompleto, cc.IdCentroCosto, sub.IdCentroCosto_sub_centro_costo) AS Query_empleado_af_x_periodo ON 
                         Query_empleado_af_x_periodo.IdEmpresa = Query_unidad_inicial_x_periodo.IdEmpresa AND Query_empleado_af_x_periodo.IdPeriodo = Query_unidad_inicial_x_periodo.IdPeriodo AND 
                         Query_empleado_af_x_periodo.IdActivoFijo = Query_unidad_inicial_x_periodo.IdActivoFijo INNER JOIN
                         Fj_servindustrias.fa_cliente_x_ct_centro_costo ON Query_empleado_af_x_periodo.IdEmpresa = Fj_servindustrias.fa_cliente_x_ct_centro_costo.IdEmpresa_cli AND 
                         Query_empleado_af_x_periodo.IdCentroCosto = Fj_servindustrias.fa_cliente_x_ct_centro_costo.IdCentroCosto_cc

WHERE queryUnidad_maxima.IdPeriodo=@IdPeriodo
and Query_empleado_af_x_periodo.IdPeriodo=@IdPeriodo
and Query_unidad_inicial_x_periodo.IdPeriodo=@IdPeriodo

and Query_empleado_af_x_periodo.IdEmpresa=@IdEmpresa
and Query_unidad_inicial_x_periodo.IdEmpresa=@IdEmpresa
and Query_empleado_af_x_periodo.IdEmpresa=@IdEmpresa

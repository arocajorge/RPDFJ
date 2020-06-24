

CREATE view [Fj_servindustrias].[vwro_fectividad_Entrega_x_Periodo_Empleado_Det_x_servicio] as
select a.IdEmpresa,a.IdNomina_Tipo,a.IdNomina_tipo_Liq, a.IdEmpleado,a.IdPeriodo, a.Efectividad_Entrega, a.Efectividad_Entrega_aplica, a.Efectividad_Volumen,a.Efectividad_Volumen_aplica,
a.Recuperacion_cartera,a.Recuperacion_cartera_aplica,

B.Efectividad_Entrega Efectividad_Entrega_ali, B.Efectividad_Entrega_aplica Efectividad_Entrega_aplica_ali, B.Efectividad_Volumen Efectividad_Volumen_ali,B.Efectividad_Volumen_aplica Efectividad_Volumen_aplica_ali,
B.Recuperacion_cartera Recuperacion_cartera_ali,B.Recuperacion_cartera_aplica Recuperacion_cartera_aplica_ali

from
( 

SELECT        efec_det.IdEmpresa, efec_det.IdNomina_Tipo, efec_det.IdNomina_tipo_Liq, efec_det.IdPeriodo, efec_det.IdEmpleado, efec_det.IdRuta, efec_det.IdEfectividad, efec_det.Efectividad_Entrega, efec_det.Efectividad_Entrega_aplica, 
                         efec_det.Efectividad_Volumen, efec_det.Efectividad_Volumen_aplica, efec_det.Recuperacion_cartera, efec_det.Recuperacion_cartera_aplica, serv.ts_codigo
FROM            Fj_servindustrias.ro_fectividad_Entrega_x_Periodo_Empleado AS efec INNER JOIN
                         Fj_servindustrias.ro_fectividad_Entrega_x_Periodo_Empleado_Det AS efec_det ON efec.IdEmpresa = efec_det.IdEmpresa AND efec.IdNomina_Tipo = efec_det.IdNomina_Tipo AND 
                         efec.IdNomina_tipo_Liq = efec_det.IdNomina_tipo_Liq AND efec.IdPeriodo = efec_det.IdPeriodo AND efec.IdEfectividad = efec_det.IdEfectividad LEFT OUTER JOIN
                         Fj_servindustrias.ro_fectividad_Entrega_tipoServicio AS serv ON efec.IdEmpresa = serv.IdEmpresa AND efec.IdServicioTipo = serv.IdServicio
WHERE        (serv.ts_codigo = 'BEBIDAS')

	)a
	left join 

	(
SELECT        efec_det.IdEmpresa, efec_det.IdNomina_Tipo, efec_det.IdNomina_tipo_Liq, efec_det.IdPeriodo, efec_det.IdEmpleado, efec_det.IdRuta, efec_det.IdEfectividad, efec_det.Efectividad_Entrega, efec_det.Efectividad_Entrega_aplica, 
                         efec_det.Efectividad_Volumen, efec_det.Efectividad_Volumen_aplica, efec_det.Recuperacion_cartera, efec_det.Recuperacion_cartera_aplica, serv.ts_codigo
FROM            Fj_servindustrias.ro_fectividad_Entrega_x_Periodo_Empleado AS efec INNER JOIN
                         Fj_servindustrias.ro_fectividad_Entrega_x_Periodo_Empleado_Det AS efec_det ON efec.IdEmpresa = efec_det.IdEmpresa AND efec.IdNomina_Tipo = efec_det.IdNomina_Tipo AND 
                         efec.IdNomina_tipo_Liq = efec_det.IdNomina_tipo_Liq AND efec.IdPeriodo = efec_det.IdPeriodo AND efec.IdEfectividad = efec_det.IdEfectividad LEFT OUTER JOIN
                         Fj_servindustrias.ro_fectividad_Entrega_tipoServicio AS serv ON efec.IdEmpresa = serv.IdEmpresa AND efec.IdServicioTipo = serv.IdServicio
WHERE        (serv.ts_codigo = 'ALIMENTOS')
	) B
	ON
	a.IdEmpresa=B.IdEmpresa
	and a.IdPeriodo=B.IdPeriodo
	and a.IdEmpleado=B.IdEmpleado
	--WHERE a.IdEmpleado=1
	--AND a.IdPeriodo=201906
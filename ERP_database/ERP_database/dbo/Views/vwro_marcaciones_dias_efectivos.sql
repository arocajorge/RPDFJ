

CREATE view [dbo].[vwro_marcaciones_dias_efectivos] as
select
distinct 
a.IdEmpresa,
a.IdNomina_Tipo,
a.IdEmpleado,
a.IdTurno,
a.es_fecha_registro,
a.Id_catalogo_Cat

 from 
(
select IdEmpresa,
IdNomina_Tipo,
IdEmpleado,
IdTurno,
es_fecha_registro,
Id_catalogo_Cat
from [Fj_servindustrias].[ro_marcaciones_x_empleado_x_incidentes_falt_Perm]
union all
select idempresa,idnomina,idempleado,1 IdTurno,es_fechaRegistro,'ASIST'Tipo
 from ro_marcaciones_x_empleado
 where
 es_fechaRegistro not in (select es_fecha_registro from 
  [Fj_servindustrias].[ro_marcaciones_x_empleado_x_incidentes_falt_Perm] where 
  ro_marcaciones_x_empleado.IdEmpresa= [Fj_servindustrias].[ro_marcaciones_x_empleado_x_incidentes_falt_Perm].IdEmpresa
  and ro_marcaciones_x_empleado.IdEmpleado= [Fj_servindustrias].[ro_marcaciones_x_empleado_x_incidentes_falt_Perm].IdEmpleado
  and cast( ro_marcaciones_x_empleado.es_fechaRegistro as date)=CAST( [Fj_servindustrias].[ro_marcaciones_x_empleado_x_incidentes_falt_Perm].es_fecha_registro as date)

 )  
)a 
--where a.IdEmpresa=2
--and a.es_fecha_registro between '01/08/2020' and '31/08/2020'
--and a.idempleado=20
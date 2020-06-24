create view XXXDECIMOTERCERO_MENSUAL
as
SELECT A.IdEmpresa, A.pe_cedulaRuc, A.pe_nombreCompleto, A.IdPeriodo,A.IdEmpleado,  SUM(SUELDO_NETO)SUELDO_NETO, ROUND(SUM(SUELDO_NETO) - (SUM(SUELDO_BASE) /30) * SUM(DIAS_FALTAS),2) SUELDO_MENOS_FALTA, SUM(TOTAL_SOBRETIEMPO)TOTAL_SOBRETIEMPO,SUM(VARIABLE)VARIABLE,
SUM(DIAS_FALTAS) DIAS_FALTAS, ROUND((SUM(SUELDO_BASE) /30) * SUM(DIAS_FALTAS),2) VALOR_FALTA,
ROUND(SUM(SUELDO_NETO) ,2)+SUM(TOTAL_SOBRETIEMPO)+SUM(VARIABLE) TOTAL_MAS_FALTA,
ROUND(SUM(SUELDO_NETO) - (SUM(SUELDO_BASE) /30) * SUM(DIAS_FALTAS),2)+SUM(TOTAL_SOBRETIEMPO)+SUM(VARIABLE) TOTAL_MENOS_FALTA
FROM (
SELECT D.IdEmpresa, P.pe_cedulaRuc, P.pe_apellido +' '+P.pe_nombre pe_nombreCompleto, --R.IdRubro, R.ru_descripcion, 
d.idperiodo, D.IDEMPLEADO,
case when d.IdRubro = 103 then d.Valor else 0 end as SUELDO_BASE,
case when cast(cast( year(em_fechaIngaRol) as varchar) + right('00'+cast( month(em_fechaIngaRol) as varchar),2) as int) = D.IdPeriodo and d.IdRubro = 24 then d.Valor
when cast(cast( year(em_fechaIngaRol) as varchar) + right('00'+cast( month(em_fechaIngaRol) as varchar),2) as int) != D.IdPeriodo and d.IdRubro = 103 then d.Valor 
else 0 end as SUELDO_NETO,
case when d.IdRubro in (966) then D.Valor else 0 end as TOTAL_SOBRETIEMPO,
case when d.IdRubro in (994) then D.Valor else 0 end as VARIABLE,
case when d.IdRubro in (973) then D.Valor else 0 end as DIAS_FALTAS
FROM ro_rol_detalle AS D INNER JOIN
ro_empleado AS E ON D.IdEmpresa = E.IdEmpresa AND D.IdEmpleado = E.IdEmpleado INNER JOIN
tb_persona AS P ON E.IdPersona = P.IdPersona INNER JOIN
ro_rubro_tipo AS R ON R.IdEmpresa = D.IdEmpresa AND R.IdRubro = D.IdRubro
WHERE D.IdEmpresa = 2 AND D.IdNominaTipo = 1 AND D.IdPeriodo in (201812,201901,201902,201903,201904,201905,201906,201907,201908,201909,201910,201911) AND d.IdRubro in (966,103,994,973,24)
AND E.em_statuS IN('EST_ACT','EST_SUB','EST_PER') 
--and e.IdEmpleado = 158

)A 
GROUP BY A.IdEmpresa, A.pe_cedulaRuc, A.pe_nombreCompleto,A.IdPeriodo,A.IDEMPLEADO
--order by A.IdPeriodo
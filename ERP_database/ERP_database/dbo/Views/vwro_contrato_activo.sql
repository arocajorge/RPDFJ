

CREATE view [dbo].[vwro_contrato_activo] as
select IdEmpresa,IdEmpleado,MAX(IdContrato)IdContrato, FechaFin,FechaInicio,EstadoContrato from vwro_contrato 
--where Estado='A'
--and EstadoContrato!='ECT_LIQ'
group by  IdEmpresa,IdEmpleado,FechaFin,FechaInicio,EstadoContrato
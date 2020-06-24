
CREATE procedure [Naturisa].[spGE_Actualizacion_Nun_Autorizacion] as
update fa_factura
set Fecha_Autorizacion=cbte_auto.FechaAutorizacion
,vt_autorizacion=cbte_auto.Numero_Autorizacion
from fa_factura fac,
(
		SELECT        a.IdEmpresa, IdComprobante, FechaAutorizacion, Numero_Autorizacion, EstadoDoc, IdTipoDocumento
		,SUBSTRING(IdComprobante,4,3) as IdEstablecimiento,SUBSTRING(IdComprobante,8,3) as IdPtoEmision
		,cast(SUBSTRING(rtrim(ltrim(right(IdComprobante,10))),charindex('-', rtrim(ltrim(right(IdComprobante,10))))+1,10) as numeric)
		as NumCbte
		from DBERP_FJ_PRODUCCION.dbo.tb_empresa as a inner join
		DBFacturacion_Electronica.dbo.tb_Empresa as b on a.em_ruc = b.RUC inner join
		DBFacturacion_Electronica.dbo.tb_Comprobante as c on b.IdEmpresa = c.IdEmpresa
		where c.IdTipoDocumento = '01' and RTRIM(LTRIM(c.EstadoDoc))='AUTORIZADO'
) as cbte_auto
where fac.IdEmpresa=cbte_auto.IdEmpresa
and fac.vt_serie1=cbte_auto.IdEstablecimiento
and fac.vt_serie2=cbte_auto.IdPtoEmision
and cast(fac.vt_NumFactura as numeric) =cbte_auto.NumCbte
and fac.vt_autorizacion is null


update cp_retencion
set NAutorizacion=cbte_x_ret.Numero_Autorizacion
,Fecha_Autorizacion=cbte_x_ret.FechaAutorizacion
from cp_retencion Ret,
(
		select a.IdEmpresa, IdComprobante, FechaAutorizacion, Numero_Autorizacion, EstadoDoc, IdTipoDocumento
		,SUBSTRING(IdComprobante,4,3) as IdEstablecimiento,SUBSTRING(IdComprobante,8,3) as IdPtoEmision
		,cast(SUBSTRING(rtrim(ltrim(right(IdComprobante,10))),charindex('-', rtrim(ltrim(right(IdComprobante,10))))+1,10) as numeric)
		as NumCbte
		from DBERP_FJ_PRODUCCION.dbo.tb_empresa as a inner join
		DBFacturacion_Electronica.dbo.tb_Empresa as b on a.em_ruc = b.RUC inner join
		DBFacturacion_Electronica.dbo.tb_Comprobante as c on b.IdEmpresa = c.IdEmpresa
		where c.IdTipoDocumento = '07' and RTRIM(LTRIM(c.EstadoDoc))='AUTORIZADO'
) as cbte_x_ret
where Ret.IdEmpresa=cbte_x_ret.IdEmpresa
and Ret.serie1=cbte_x_ret.IdEstablecimiento
and Ret.serie2=cbte_x_ret.IdPtoEmision
and cast(isnull(iif(ltrim(rtrim(Ret.NumRetencion)) = '',null,Ret.NumRetencion),'0') as numeric) =cbte_x_ret.NumCbte
and Ret.NAutorizacion is null


UPDATE Digitalizacion.cp_XML_Documento SET ret_NumeroAutorizacion = Clave_Acceso, ret_FechaAutorizacion = FechaAutorizacion
FROM(
select A.IdEmpresa,A.IdDocumento, B.Clave_Acceso, B.FechaAutorizacion
FROM DBFacturacion_Electronica.dbo.tb_Comprobante as b INNER JOIN
DBFacturacion_Electronica.DBO.tb_Empresa as c on b.IdEmpresa = c.IdEmpresa inner join
DBERP_FJ_PRODUCCION.Digitalizacion.cp_XML_Documento as a on c.RUC = a.rec_Identificacion and 
('RT-'+LTRIM(RTRIM(a.ret_Establecimiento))+'-'+LTRIM(RTRIM(a.ret_PuntoEmision))+'-'+LTRIM(RTRIM(a.ret_NumeroDocumento))) = B.IdComprobante
WHERE (B.IdTipoDocumento = '07') and RTRIM(LTRIM(B.EstadoDoc))='AUTORIZADO' AND A.ret_NumeroAutorizacion IS NULL
) A
WHERE Digitalizacion.cp_XML_Documento.IdEmpresa = A.IdEmpresa
AND Digitalizacion.cp_XML_Documento.IdDocumento = A.IdDocumento

update fa_notaCreDeb
set Fecha_Autorizacion=cbte_auto.FechaAutorizacion
,NumAutorizacion=cbte_auto.Numero_Autorizacion
from fa_notaCreDeb fac,
(
		SELECT        a.IdEmpresa, IdComprobante, FechaAutorizacion, Numero_Autorizacion, EstadoDoc, IdTipoDocumento
		,SUBSTRING(IdComprobante,4,3) as IdEstablecimiento,SUBSTRING(IdComprobante,8,3) as IdPtoEmision
		,cast(SUBSTRING(rtrim(ltrim(right(IdComprobante,10))),charindex('-', rtrim(ltrim(right(IdComprobante,10))))+1,10) as numeric)
		as NumCbte
		from DBERP_FJ_PRODUCCION.dbo.tb_empresa as a inner join
		DBFacturacion_Electronica.dbo.tb_Empresa as b on a.em_ruc = b.RUC inner join
		DBFacturacion_Electronica.dbo.tb_Comprobante as c on b.IdEmpresa = c.IdEmpresa
		where c.IdTipoDocumento = '04' and RTRIM(LTRIM(c.EstadoDoc))='AUTORIZADO'
) as cbte_auto
where fac.IdEmpresa=cbte_auto.IdEmpresa
and fac.Serie1=cbte_auto.IdEstablecimiento
and fac.Serie2=cbte_auto.IdPtoEmision
and cast(fac.NumNota_Impresa as numeric) =cbte_auto.NumCbte
and fac.CreDeb='C'
and fac.Fecha_Autorizacion is null




update fa_notaCreDeb
set Fecha_Autorizacion=cbte_auto.FechaAutorizacion
,NumAutorizacion=cbte_auto.Numero_Autorizacion
from fa_notaCreDeb fac,
(
		SELECT        a.IdEmpresa, IdComprobante, FechaAutorizacion, Numero_Autorizacion, EstadoDoc, IdTipoDocumento
		,SUBSTRING(IdComprobante,4,3) as IdEstablecimiento,SUBSTRING(IdComprobante,8,3) as IdPtoEmision
		,cast(SUBSTRING(rtrim(ltrim(right(IdComprobante,10))),charindex('-', rtrim(ltrim(right(IdComprobante,10))))+1,10) as numeric)
		as NumCbte
		from DBERP_FJ_PRODUCCION.dbo.tb_empresa as a inner join
		DBFacturacion_Electronica.dbo.tb_Empresa as b on a.em_ruc = b.RUC inner join
		DBFacturacion_Electronica.dbo.tb_Comprobante as c on b.IdEmpresa = c.IdEmpresa
		where c.IdTipoDocumento = '05' and RTRIM(LTRIM(c.EstadoDoc))='AUTORIZADO'
) as cbte_auto
where fac.IdEmpresa=cbte_auto.IdEmpresa
and fac.Serie1=cbte_auto.IdEstablecimiento
and fac.Serie2=cbte_auto.IdPtoEmision
and cast(fac.NumNota_Impresa as numeric) =cbte_auto.NumCbte
and fac.CreDeb='D'
and fac.Fecha_Autorizacion is null
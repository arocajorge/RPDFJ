using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Erp.Business.General;
using Core.Erp.Info.General;
using Core.Erp.Data.General;


namespace Core.Erp.Reportes.Caja
{
   public class XCAJ_Rpt003_Data
    { 

        string MensajeError = "";

        public List<XCAJ_Rpt003_Info> Get_List_Conciliacion_Caja_X_Usuario(int IdEmpresa, decimal IdConciliacion_Caja)
        {
            try
            {
                List<XCAJ_Rpt003_Info> Lista = new List<XCAJ_Rpt003_Info>();
                using (EntitiesCaja_General context = new EntitiesCaja_General())
                {
                    context.SetCommandTimeOut(3000);
                    Lista = (from c in context.vwCAJ_Rpt003
                             where c.IdEmpresa == IdEmpresa
                             && c.IdConciliacion_Caja == IdConciliacion_Caja
                             orderby c.co_FechaFactura
                             select new XCAJ_Rpt003_Info
                             {
                                 IdEmpresa = c.IdEmpresa,
                                 IdCbteCble_Ogiro = c.IdCbteCble_Ogiro,
                                 IdTipoCbte_Ogiro = c.IdTipoCbte_Ogiro,
                                 co_fechaOg = c.co_fechaOg,
                                 IdPersona = c.IdPersona,
                                 pe_cedulaRuc = c.pe_cedulaRuc,
                                 IdTipoDocumento = c.IdTipoDocumento,
                                 IdOrden_giro_Tipo = c.IdOrden_giro_Tipo,
                                 Descripcion = c.Descripcion,
                                 IdProveedor = c.IdProveedor,
                                 Num_Autorizacion = c.Num_Autorizacion,
                                 co_serie = c.co_serie,
                                 co_factura = c.co_factura,
                                 co_FechaFactura = c.co_FechaFactura,
                                 IdConciliacion_Caja = c.IdConciliacion_Caja,
                                 pe_FechaIni = c.pe_FechaIni,
                                 pe_FechaFin = c.pe_FechaFin,
                                 IdCaja = c.IdCaja,
                                 ca_Descripcion = c.ca_Descripcion,
                                 IdCtaCble = c.IdCtaCble,
                                 co_observacion = c.co_observacion,
                                 IdTipoMovi = c.IdTipoMovi,
                                 tm_descripcion = c.tm_descripcion,
                                 co_baseImponible = c.co_baseImponible,
                                 co_subtotal_iva = c.co_subtotal_iva,
                                 co_subtotal_siniva = c.co_subtotal_siniva,
                                 co_valoriva = c.co_valoriva,
                                 co_Serv_valor = c.co_Serv_valor,
                                 co_total = c.co_total,
                                 co_valorpagar = c.co_valorpagar,
                                 IdRetencion = c.IdRetencion,
                                 serie = c.serie,
                                 NumRetencion = c.NumRetencion,
                                 NAutorizacion = c.NAutorizacion,
                                 re_tipoRet_RF = c.re_tipoRet_RF,
                                 re_baseRetencion_RF = c.re_baseRetencion_RF,
                                 re_Porcen_retencion_RF = c.re_Porcen_retencion_RF,
                                 re_valor_retencion_RF = c.re_valor_retencion_RF,
                                 re_tipoRet_RIVA = c.re_tipoRet_RIVA,
                                 re_baseRetencion_RIVA = c.re_baseRetencion_RIVA,
                                 re_Porcen_retencion_RIVA = c.re_Porcen_retencion_RIVA,
                                 re_valor_retencion_RIVA = c.re_valor_retencion_RIVA,
                                 pe_nombreCompleto = c.pe_nombreCompleto,
                                 pe_razonSocial = c.pe_razonSocial,
                                 pe_apellido = c.pe_apellido,
                                 pe_nombre = c.pe_nombre,

                                 pe_mes = c.pe_mes,
                                 smes = c.smes,
                                 Fecha = c.Fecha,
                                 IdanioFiscal = c.IdanioFiscal,
                                 IdEstadoCierre = c.IdEstadoCierre,
                                 Observacion = c.Observacion,
                                 Saldo_cont_al_periodo = c.Saldo_cont_al_periodo,
                                 Ingresos = c.Ingresos,
                                 Total_Ing = c.Total_Ing,
                                 Total_fact_vale = c.Total_fact_vale,
                                 Total_fondo = c.Total_fondo,
                                 Dif_x_pagar_o_cobrar = c.Dif_x_pagar_o_cobrar,
                                 co_OtroValor_a_descontar = c.co_OtroValor_a_descontar,
                             }).ToList();
                }
                return Lista;
            }
            catch (Exception ex)
            {
                string MensajeError = "";
                tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
                tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", "", "", "", "", "", "", DateTime.Now);
                MensajeError = ex.ToString();
                oDataLog.Guardar_Log_Error(Log_Error_sis, ref MensajeError);

                Core.Erp.Info.Log_Exception.LoggingManager.Logger.Log(Core.Erp.Info.Log_Exception.LoggingCategory.Error, ex.Message);
                throw new Core.Erp.Info.Log_Exception.DalException(string.Format("", "Get_Data_Reporte", ex.Message), ex) { EntityType = typeof(XCAJ_Rpt003_Data) };
            }
        }
   
    }
}

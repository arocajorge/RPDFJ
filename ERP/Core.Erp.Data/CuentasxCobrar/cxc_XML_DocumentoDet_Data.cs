using Core.Erp.Info.CuentasxCobrar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Data.CuentasxCobrar
{
    public class cxc_XML_DocumentoDet_Data
    {
        public List<cxc_XML_DocumentoDet_Info> GetList(int IdEmpresa, decimal IdDocumento)
        {
            try
            {
                List<cxc_XML_DocumentoDet_Info> Lista = new List<cxc_XML_DocumentoDet_Info>();

                using (EntitiesCuentas_x_Cobrar db = new EntitiesCuentas_x_Cobrar())
                {
                    var lst = db.cxc_XML_DocumentoDet.Where(q => q.IdEmpresa == IdEmpresa && q.IdDocumento == IdDocumento).ToList();

                    foreach (var item in lst)
                    {
                        Lista.Add(new cxc_XML_DocumentoDet_Info
                        {
                            IdEmpresa = item.IdEmpresa,
                            IdDocumento = item.IdDocumento,
                            Secuencia = item.Secuencia,
                            TipoRetencion = item.TipoRetencion,
                            CodigoRetencion = item.CodigoRetencion,
                            BaseImponible = item.BaseImponible,
                            PorcentajeRetencion = item.PorcentajeRetencion,
                            ValorRetenido = item.ValorRetenido,
                            CodDocSustento = item.CodDocSustento,
                            NumDocSustento = item.NumDocSustento,
                            FechaEmisionDocSustento = item.FechaEmisionDocSustento,
                            IdSucursal = item.IdSucursal,
                            IdCobro = item.IdCobro,
                            dc_TipoDocumento = item.dc_TipoDocumento,
                            IdBodega_Cbte = item.IdBodega_Cbte,
                            IdCbte_vta_nota = item.IdCbte_vta_nota,
                            IdCobro_tipo = item.IdCobro_tipo
                        });
                    }
                }

                return Lista;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public cxc_XML_Documento_Info GetInfoParaCruzar(int IdEmpresa, string dc_TipoDocumento, string NumDocSustento, double ValorRetenido, decimal IdCliente)
        {
            try
            {
                cxc_XML_Documento_Info info = new cxc_XML_Documento_Info();
                EntitiesFacturacion dbFac = new EntitiesFacturacion();
                EntitiesCuentas_x_Cobrar dbCxc = new EntitiesCuentas_x_Cobrar();

                string Establecimiento = NumDocSustento.Substring(0, 3);
                string PuntoEmision = NumDocSustento.Substring(3, 3);
                string NumeroDocumento = NumDocSustento.Substring(6, 9);

                if (dc_TipoDocumento == "FACT")
                {
                    var Factura = dbFac.vwfa_factura.Where(q => q.IdEmpresa == IdEmpresa && q.vt_serie1 == Establecimiento && q.vt_serie2 == PuntoEmision && q.vt_NumFactura == NumeroDocumento && q.Estado == "A" && q.IdCliente == IdCliente).FirstOrDefault();
                    if (Factura != null)
                    {
                        info.IdEmpresa = Factura.IdEmpresa;
                        info.IdSucursal = Factura.IdSucursal;
                        info.IdBodega_Cbte = Factura.IdBodega;
                        info.IdCbte_vta_nota = Factura.IdCbteVta;

                        int CobroRetencion = dbCxc.cxc_cobro_det.Where(q => q.IdEmpresa == info.IdEmpresa && q.IdSucursal == info.IdSucursal && q.IdBodega_Cbte == info.IdBodega_Cbte && q.IdCbte_vta_nota == info.IdCbte_vta_nota && q.cxc_cobro.cr_estado == "A" && q.cxc_cobro.IdCobro_tipo.Contains("RT")).Count();
                        if (CobroRetencion > 0)
                        {
                            info.AplicaRetencion = 2;
                            info.Motivo = "Documento ya tiene una retención aplicada";
                            return info;
                        }

                        if (Math.Round(Factura.vt_saldo, 2, MidpointRounding.AwayFromZero) >= Math.Round(ValorRetenido, 2, MidpointRounding.AwayFromZero))
                            info.AplicaRetencion = 1;
                        else
                        {
                            info.AplicaRetencion = 2;
                            info.Motivo = "Documento no tiene saldo suficiente, \nTiene: " + Math.Round(Factura.vt_saldo, 2, MidpointRounding.AwayFromZero).ToString("c2") + "\nNecesita: " + Math.Round(ValorRetenido, 2, MidpointRounding.AwayFromZero).ToString("c2");
                        }
                    }
                    else
                        info.Motivo = "No existe documento "+NumDocSustento;
                    
                }

                return info;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

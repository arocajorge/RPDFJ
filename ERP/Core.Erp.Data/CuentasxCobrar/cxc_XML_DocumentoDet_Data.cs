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
                            IdCbte_vta_nota = item.IdCbte_vta_nota
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
    }
}

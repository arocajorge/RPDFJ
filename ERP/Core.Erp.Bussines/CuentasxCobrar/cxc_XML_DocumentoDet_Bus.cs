using Core.Erp.Data.CuentasxCobrar;
using Core.Erp.Info.CuentasxCobrar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.Erp.Business.CuentasxCobrar
{
    public class cxc_XML_DocumentoDet_Bus
    {
        cxc_XML_DocumentoDet_Data odata = new cxc_XML_DocumentoDet_Data();

        public List<cxc_XML_DocumentoDet_Info> GetList(int IdEmpresa, decimal IdDocumento)
        {
            try
            {
                return odata.GetList(IdEmpresa, IdDocumento);
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
                return odata.GetInfoParaCruzar(IdEmpresa, dc_TipoDocumento, NumDocSustento, ValorRetenido, IdCliente);
            }
            catch (Exception)
            {   
                throw;
            }
        }
    }
}

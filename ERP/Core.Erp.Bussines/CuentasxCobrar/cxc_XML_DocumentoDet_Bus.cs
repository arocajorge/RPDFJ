using Core.Erp.Data.CuentasxCobrar;
using Core.Erp.Info.CuentasxCobrar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}

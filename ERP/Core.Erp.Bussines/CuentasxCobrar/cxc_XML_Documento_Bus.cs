using Core.Erp.Data.CuentasxCobrar;
using Core.Erp.Info.CuentasxCobrar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Business.CuentasxCobrar
{
    public class cxc_XML_Documento_Bus
    {
        cxc_XML_Documento_Data odata = new cxc_XML_Documento_Data();

        public List<cxc_XML_Documento_Info> GetList(int IdEmpresa, DateTime FechaIni, DateTime FechaFin)
        {
            try
            {
                return odata.GetList(IdEmpresa, FechaIni, FechaFin);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public cxc_XML_Documento_Info GetInfo(int IdEmpresa, decimal IdDocumento)
        {
            try
            {
                return odata.GetInfo(IdEmpresa, IdDocumento);
            }
            catch (Exception)
            {   
                throw;
            }
        }

        public bool GuardarDB(cxc_XML_Documento_Info info)
        {
            try
            {
                return odata.GuardarDB(info);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool AnularDB(int IdEmpresa, decimal IdDocumento, string IdUsuario)
        {
            try
            {
                return odata.AnularDB(IdEmpresa, IdDocumento, IdUsuario);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}

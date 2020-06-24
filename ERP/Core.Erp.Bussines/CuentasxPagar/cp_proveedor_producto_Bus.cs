using Core.Erp.Data.CuentasxPagar;
using Core.Erp.Info.CuentasxPagar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Business.CuentasxPagar
{
    public class cp_proveedor_producto_Bus
    {
        cp_proveedor_producto_Data odata = new cp_proveedor_producto_Data();

        public List<cp_proveedor_producto_Info> GetList(int IdEmpresa, decimal IdProveedor)
        {
            try
            {
                return odata.GetList(IdEmpresa, IdProveedor);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}

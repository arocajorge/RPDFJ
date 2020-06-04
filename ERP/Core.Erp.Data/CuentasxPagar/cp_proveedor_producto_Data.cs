using Core.Erp.Info.CuentasxPagar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Data.CuentasxPagar
{
    public class cp_proveedor_producto_Data
    {
        public List<cp_proveedor_producto_Info> GetList(int IdEmpresa, decimal IdProveedor)
        {
            try
            {
                List<cp_proveedor_producto_Info> Lista = new List<cp_proveedor_producto_Info>();
                
                using (EntitiesCuentasxPagar db = new EntitiesCuentasxPagar())
                {
                    var lst = db.cp_proveedor_producto.Where(q => q.IdEmpresa == IdEmpresa && q.IdProveedor == IdProveedor).ToList();
                    foreach (var item in lst)
                    {
                        Lista.Add(new cp_proveedor_producto_Info
                        {
                            IdEmpresa = item.IdEmpresa,
                            IdProveedor = item.IdProveedor,
                            Secuencia = item.Secuencia,
                            CodProducto = item.CodProducto,
                            BienServicio = item.BienServicio
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

using Core.Erp.Data.Inventario_CG;
using Core.Erp.Info.Inventario_CG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Business.Inventario_CG
{
    public class in_Producto_CG_Bus
    {
        in_Producto_CG_Data da = new in_Producto_CG_Data();
        vw_in_Producto_x_inv_Producto_CG_Bus bus_vw_produc_CG = new vw_in_Producto_x_inv_Producto_CG_Bus();
        vw_in_Producto_x_inv_Producto_CG_Info Info_vw_produc_CG = new vw_in_Producto_x_inv_Producto_CG_Info();

        public bool GrabarDB(in_Producto_CG_Info info, ref string mensaje)
        {
            try
            {
                bool resultado = false;
                resultado = da.GrabarDB(info, ref mensaje);
                if (resultado)
                {
                    //Info_vw_produc_CG = bus_vw_produc_CG.Get_Info(info.IdEmpresa, info.IdProducto);
                    resultado = bus_vw_produc_CG.Grabar_ProductoDBPostgres(info.IdEmpresa, info.IdProducto, ref mensaje);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                Core.Erp.Info.Log_Exception.LoggingManager.Logger.Log(Core.Erp.Info.Log_Exception.LoggingCategory.Error, ex.Message);
                throw new Core.Erp.Info.Log_Exception.DalException(string.Format("", "GrabarDB", ex.Message), ex) { EntityType = typeof(in_Producto_CG_Bus) };
            }

        }


        public bool ActualizarDB(in_Producto_CG_Info info, ref string mensaje)
        {
            try
            {
                bool resultado = false;

                resultado = da.ActualizarDB(info, ref mensaje);
                if (resultado)
                {
                    
                }
                return resultado;
            }
            catch (Exception ex)
            {
                Core.Erp.Info.Log_Exception.LoggingManager.Logger.Log(Core.Erp.Info.Log_Exception.LoggingCategory.Error, ex.Message);
                throw new Core.Erp.Info.Log_Exception.DalException(string.Format("", "ActualizarDB", ex.Message), ex) { EntityType = typeof(in_Producto_CG_Bus) };
            }

        }


        public bool AnularDB(in_Producto_CG_Info info, ref string mensaje)
        {
            try
            {

                return da.AnularDB(info, ref mensaje);
            }
            catch (Exception ex)
            {
                Core.Erp.Info.Log_Exception.LoggingManager.Logger.Log(Core.Erp.Info.Log_Exception.LoggingCategory.Error, ex.Message);
                throw new Core.Erp.Info.Log_Exception.DalException(string.Format("", "AnularDB", ex.Message), ex) { EntityType = typeof(in_Producto_CG_Bus) };
            }

        }


        public List<in_Producto_CG_Info> Get_list(int IdEmpresa, ref string mensaje)
        {
            try
            {
                return da.Get_list(IdEmpresa, ref mensaje);
            }
            catch (Exception ex)
            {
                Core.Erp.Info.Log_Exception.LoggingManager.Logger.Log(Core.Erp.Info.Log_Exception.LoggingCategory.Error, ex.Message);
                throw new Core.Erp.Info.Log_Exception.DalException(string.Format("", "Get_list", ex.Message), ex) { EntityType = typeof(in_Producto_CG_Bus) };
            }

        }


        public in_Producto_CG_Info Get_Info(int IdEmpresa, decimal idProducto)
        {
            try
            {
                return da.Get_Info(IdEmpresa, idProducto);
            }
            catch (Exception ex)
            {
                Core.Erp.Info.Log_Exception.LoggingManager.Logger.Log(Core.Erp.Info.Log_Exception.LoggingCategory.Error, ex.Message);
                throw new Core.Erp.Info.Log_Exception.DalException(string.Format("", "Get_Info", ex.Message), ex) { EntityType = typeof(in_Producto_CG_Bus) };
            }

        }

        
    }
}

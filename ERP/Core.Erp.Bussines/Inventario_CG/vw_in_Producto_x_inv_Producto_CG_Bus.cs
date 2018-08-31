using Core.Erp.Business.General;
using Core.Erp.Data.Inventario_CG;
using Core.Erp.Info.Inventario_CG;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Business.Inventario_CG
{
    public class vw_in_Producto_x_inv_Producto_CG_Bus
    {
        vw_in_Producto_x_in_Producto_CG_Data da = new vw_in_Producto_x_in_Producto_CG_Data();
        tb_conexion_Postgres_Bus conex_post_bus = new tb_conexion_Postgres_Bus();

        public vw_in_Producto_x_inv_Producto_CG_Info Get_Info(int IdEmpresa, decimal idProducto)
        {
            try
            {
                return da.Get_Info(IdEmpresa, idProducto);
            }
            catch (Exception ex)
            {
                Core.Erp.Info.Log_Exception.LoggingManager.Logger.Log(Core.Erp.Info.Log_Exception.LoggingCategory.Error, ex.Message);
                throw new Core.Erp.Info.Log_Exception.DalException(string.Format("", "Get_Info", ex.Message), ex) { EntityType = typeof(vw_in_Producto_x_inv_Producto_CG_Bus) };
            }

        }


        public bool Grabar_ProductoDBPostgres(int IdEmpresa, decimal idProducto, ref string mensaje)
        {
            try
            {
                bool resultado = false;
                string idproductoCG = string.Empty;
                NpgsqlConnection cc = new NpgsqlConnection();
                cc = conex_post_bus.Conexion_Postgres(ref mensaje);
                if (mensaje == "")
                    idproductoCG = da.incremento_ProductoCG(cc);
                if (idproductoCG != null)
                {
                    cc = new NpgsqlConnection();
                    cc = conex_post_bus.Conexion_Postgres(ref mensaje);
                    if (mensaje == "")
                    if (da.Grabar_ProductoDBPostgres(IdEmpresa, idProducto,idproductoCG, cc, ref mensaje))
                    {
                        cc = new NpgsqlConnection();
                        cc = conex_post_bus.Conexion_Postgres(ref mensaje);
                        if (mensaje == "")
                        resultado = da.Grabar_MedicamentoDBPostgres(IdEmpresa, idProducto,idproductoCG, cc, ref mensaje);
                    }
                }
                return resultado;
            }
            catch (Exception ex)
            {
                Core.Erp.Info.Log_Exception.LoggingManager.Logger.Log(Core.Erp.Info.Log_Exception.LoggingCategory.Error, ex.Message);
                throw new Core.Erp.Info.Log_Exception.DalException(string.Format("", "GrabarDBPostgres", ex.Message), ex) { EntityType = typeof(vw_in_Producto_x_inv_Producto_CG_Bus) };
            }

        }
    }
}

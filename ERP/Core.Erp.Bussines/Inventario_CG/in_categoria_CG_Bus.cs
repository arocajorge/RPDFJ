using Core.Erp.Data.Inventario_CG;
using Core.Erp.Info.Inventario_CG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Business.Inventario_CG
{
    public class in_categoria_CG_Bus
    {
        in_categoria_CG_Data da = new in_categoria_CG_Data();

        public bool GrabarDB(in_categoria_CG_Info info, ref string mensaje)
        {
            try
            {

                return da.GrabarDB(info, ref mensaje);
            }
            catch (Exception ex)
            {
                Core.Erp.Info.Log_Exception.LoggingManager.Logger.Log(Core.Erp.Info.Log_Exception.LoggingCategory.Error, ex.Message);
                throw new Core.Erp.Info.Log_Exception.DalException(string.Format("", "GrabarDB", ex.Message), ex) { EntityType = typeof(in_categoria_CG_Bus) };
            }

        }


        public bool ActualizarDB(in_categoria_CG_Info info, ref string mensaje)
        {
            try
            {

                return da.ActualizarDB(info, ref mensaje);
            }
            catch (Exception ex)
            {
                Core.Erp.Info.Log_Exception.LoggingManager.Logger.Log(Core.Erp.Info.Log_Exception.LoggingCategory.Error, ex.Message);
                throw new Core.Erp.Info.Log_Exception.DalException(string.Format("", "ActualizarDB", ex.Message), ex) { EntityType = typeof(in_categoria_CG_Bus) };
            }

        }


        public bool AnularDB(in_categoria_CG_Info info, ref string mensaje)
        {
            try
            {

                return da.AnularDB(info, ref mensaje);
            }
            catch (Exception ex)
            {
                Core.Erp.Info.Log_Exception.LoggingManager.Logger.Log(Core.Erp.Info.Log_Exception.LoggingCategory.Error, ex.Message);
                throw new Core.Erp.Info.Log_Exception.DalException(string.Format("", "AnularDB", ex.Message), ex) { EntityType = typeof(in_categoria_CG_Bus) };
            }

        }


        public List<in_categoria_CG_Info> Get_list(int IdEmpresa, ref string mensaje)
        {
            try
            {
                return da.Get_list(IdEmpresa, ref mensaje);
            }
            catch (Exception ex)
            {
                Core.Erp.Info.Log_Exception.LoggingManager.Logger.Log(Core.Erp.Info.Log_Exception.LoggingCategory.Error, ex.Message);
                throw new Core.Erp.Info.Log_Exception.DalException(string.Format("", "Get_list", ex.Message), ex) { EntityType = typeof(in_categoria_CG_Bus) };
            }

        }


        public in_categoria_CG_Info Get_Info(int IdEmpresa, string categoria)
        {
            try
            {
                return da.Get_Info(IdEmpresa, categoria);
            }
            catch (Exception ex)
            {
                Core.Erp.Info.Log_Exception.LoggingManager.Logger.Log(Core.Erp.Info.Log_Exception.LoggingCategory.Error, ex.Message);
                throw new Core.Erp.Info.Log_Exception.DalException(string.Format("", "Get_Info", ex.Message), ex) { EntityType = typeof(in_categoria_CG_Bus) };
            }

        }

        public Boolean es_medicina(int IdEmpresa, string idcategoria)
        {
            try
            {
                return da.es_medicina(IdEmpresa, idcategoria);
            }
            catch (Exception ex)
            {
                Core.Erp.Info.Log_Exception.LoggingManager.Logger.Log(Core.Erp.Info.Log_Exception.LoggingCategory.Error, ex.Message);
                throw new Core.Erp.Info.Log_Exception.DalException(string.Format("", "es_medicina", ex.Message), ex) { EntityType = typeof(in_categoria_CG_Bus) };
            }

        }
    }
}
